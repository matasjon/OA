using AutoMapper;
using Microsoft.AspNetCore.Mvc;
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


        public ActivitiesController(IActivitiesRepository activitiesRepository, IMapper mapper)
        {
            _activitiesRepository = activitiesRepository;
            _mapper = mapper;
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
        public async Task<ActionResult<ActivityDto>> Post(CreateActivityDto activityDto)
        {
            var activity = _mapper.Map<Activity>(activityDto);
            activity.CreationTimeUt = DateTime.UtcNow;

            await _activitiesRepository.Create(activity);

            //201
            //Created topic
            return Created($"/api/activities/{activity.Id}", _mapper.Map<ActivityDto>(activity));
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ActivityDto>> Put(int id, UpdateActivityDto activityDto)
        {
            var activity = await _activitiesRepository.Get(id);
            if (activity == null) return NotFound($"Activity with id '{id}' not found.");

            //Pirmas budas dedi
            //topic.Name = topicDto.Name;

            //Antras budas
            _mapper.Map(activityDto, activity);

            await _activitiesRepository.Put(activity);

            return Ok(_mapper.Map<ActivityDto>(activity));

        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ActivityDto>> Delete(int id)
        {
            var activity = await _activitiesRepository.Get(id);
            if (activity == null) return NotFound($"Activity with id '{id}' not found.");

            await _activitiesRepository.Delete(activity);

            //204
            return NoContent();
        }

    }
}
