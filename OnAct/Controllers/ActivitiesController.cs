using System.Security.Claims;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.JsonWebTokens;
using OnAct.Auth.Model;
using OnAct.Data.Dtos.Activities;
using OnAct.Data.Entities;
using OnAct.Data.Repositories;

namespace OnAct.Controllers
{

    [ApiController]
    [Route("api/activities")]
    public class ActivitiesController : ControllerBase
    {
        private readonly IActivitiesRepository _activitiesRepository;
        private readonly IMapper _mapper;
        private readonly IAuthorizationService _authorizationService;


        public ActivitiesController(IActivitiesRepository activitiesRepository, IMapper mapper, IAuthorizationService authorizationService)
        {
            _activitiesRepository = activitiesRepository;
            _mapper = mapper;
            _authorizationService = authorizationService;
        }

        [HttpGet]
        public async Task<IEnumerable<ActivityDto>> GetAll()
        {
            return (await _activitiesRepository.GetAll()).Select(o => _mapper.Map<ActivityDto>(o));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ActivityDto>> Get(int id)
        {
            var activity = await _activitiesRepository.Get(id);
            if (activity == null) return NotFound($"Activity with id '{id}' not found.");

            return Ok(_mapper.Map<ActivityDto>(activity));
        }

        [HttpPost]
        [Authorize(Policy = "CreatorRights")] // cia dadeta
        public async Task<ActionResult<ActivityDto>> Post(CreateActivityDto activityDto)
        {
            var activity = _mapper.Map<Activity>(activityDto);
            activity.CreationTimeUt = DateTime.UtcNow;

            activity.UserId = User.FindFirstValue(JwtRegisteredClaimNames.Sub); // cia dadeta

            await _activitiesRepository.Create(activity);

            //201
            //Created topic
            return Created($"/api/activities/{activity.Id}", _mapper.Map<ActivityDto>(activity));
        }

        [HttpPut("{id}")]
        [Authorize(Policy = "CreatorRights")] // cia dadeta
        public async Task<ActionResult<ActivityDto>> Put(int id, UpdateActivityDto activityDto)
        {
            var activity = await _activitiesRepository.Get(id);
            if (activity == null) return NotFound($"Activity with id '{id}' not found.");


            var authorizationResult =  await _authorizationService.AuthorizeAsync(User, activity, PolicyNames.ResourceOwner);

            if (!authorizationResult.Succeeded)
            {
                //404
                return Forbid();
            }

            //Pirmas budas dedi
            //topic.Name = topicDto.Name;

            //Antras budas
            _mapper.Map(activityDto, activity);

            await _activitiesRepository.Put(activity);

            return Ok(_mapper.Map<ActivityDto>(activity));

        }

        [HttpDelete("{id}")]
        [Authorize(Policy = "CreatorRights")]
        public async Task<ActionResult<ActivityDto>> Delete(int id)
        {
            var activity = await _activitiesRepository.Get(id);
            if (activity == null) return NotFound($"Activity with id '{id}' not found.");


            var authorizationResult = await _authorizationService.AuthorizeAsync(User, activity, PolicyNames.ResourceOwner);

            if (!authorizationResult.Succeeded)
            {
                //404
                return Forbid();
            }

            await _activitiesRepository.Delete(activity);

            //204
            return NoContent();
        }

    }
}
