using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OnAct.Data.Dtos.Groups;
using OnAct.Data.Dtos.Places;
using OnAct.Data.Entities;
using OnAct.Data.Repositories;

namespace OnAct.Controllers
{
    [ApiController]
    [Route("api/activities/{activityId}/places/{placeId}/groups")]
    public class GroupsController : ControllerBase
    {
        private readonly IGroupsRepository _groupsRepository;
        private readonly IMapper _mapper;
        private readonly IActivitiesRepository _activitiesRepository;
        private readonly IPlacesRepository _placesRepository;


        public GroupsController(IGroupsRepository groupsRepository, IMapper mapper,
            IActivitiesRepository activitiesRepository, IPlacesRepository placesRepository)
        {
            _groupsRepository = groupsRepository;
            _mapper = mapper;
            _activitiesRepository = activitiesRepository;
            _placesRepository = placesRepository;
        }


        [HttpGet]
        public async Task<IEnumerable<GroupDto>> GetAllAsync(int activityId, int placeId)
        {
            var groups = await _groupsRepository.GetAll(activityId, placeId);

            return groups.Select(o => _mapper.Map<GroupDto>(o));
        }

        [HttpGet("{groupId}")]
        public async Task<ActionResult<GroupDto>> GetAsync(int activityId, int placeId, int groupId)
        {
            var activity = await _activitiesRepository.Get(activityId);
            if (activity == null) return NotFound($"Activity with id '{activityId}' not found.");

            var place = await _placesRepository.Get(activityId, placeId);
            if (place == null) return NotFound($"Place with id '{placeId}' not found in activity with id '{activityId}'.");

            var group = await _groupsRepository.Get(activityId, placeId, groupId);
            if (group == null) return NotFound($"Group with id '{groupId}' not found in activity with id '{activityId}' and place with id '{placeId}'.");

            return Ok(_mapper.Map<GroupDto>(group));
        }

        [HttpPost]
        public async Task<ActionResult<GroupDto>> PostAsync(int activityId, int placeId, CreateGroupDto groupDto)
        {
            var activity = await _activitiesRepository.Get(activityId);
            if (activity == null) return NotFound($"Activity with id '{activityId}' not found.");

            var place = await _placesRepository.Get(activityId, placeId);
            if (place == null) return NotFound($"Place with id '{placeId}' not found in activity with id '{activityId}'.");

            var group = _mapper.Map<Group>(groupDto);
            group.ActivityId = activityId;
            group.PlaceId = placeId;
            group.CreatedDate = DateTime.UtcNow;

            await _groupsRepository.Create(group);

            return Created($"/api/activities/{activityId}/places/{place.Id}/groups/{group.Id}", _mapper.Map<GroupDto>(group));
        }

        [HttpPut("{groupId}")]
        public async Task<ActionResult<GroupDto>> PutAsync(int activityId, int placeId, int groupId, UpdateGroupDto groupDto)
        {
            var activity = await _activitiesRepository.Get(activityId);
            if (activity == null) return NotFound($"Activity with id '{activityId}' not found.");

            var place = await _placesRepository.Get(activityId, placeId);
            if (place == null) return NotFound($"Place with id '{placeId}' not found in activity with id '{activityId}'.");

            var oldGroup = await _groupsRepository.Get(activityId, placeId, groupId);
            if (oldGroup == null) return NotFound($"Group with id '{groupId}' not found in activity with id '{activityId}' and place with id '{placeId}'.");

            //oldPost.Body = postDto.Body;
            _mapper.Map(groupDto, oldGroup);

            await _groupsRepository.Update(oldGroup);

            return Ok(_mapper.Map<GroupDto>(oldGroup));
        }

        [HttpDelete("{groupId}")]
        public async Task<ActionResult> DeleteAsync(int activityId, int placeId, int groupId)
        {
            var activity = await _activitiesRepository.Get(activityId);
            if (activity == null) return NotFound($"Activity with id '{activityId}' not found.");

            var place = await _placesRepository.Get(activityId, placeId);
            if (place == null) return NotFound($"Place with id '{placeId}' not found in activity with id '{activityId}'.");

            var group = await _groupsRepository.Get(activityId, placeId, groupId);
            if (group == null) return NotFound($"Group with id '{groupId}' not found in activity with id '{activityId}' and place with id '{placeId}'.");


            await _groupsRepository.Delete(group);

            // 204
            return NoContent();
        }

    }

}
