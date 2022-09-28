using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OnAct.Data.Dtos.Places;
using OnAct.Data.Entities;
using OnAct.Data.Repositories;

namespace OnAct.Controllers
{

    [ApiController]
    [Route("api/activities/{activityId}/places")]
    public class PlacesController : ControllerBase
    {
        private readonly IPlacesRepository _placesRepository;
        private readonly IMapper _mapper;
        private readonly IActivitiesRepository _activitiesRepository;

        public PlacesController(IPlacesRepository placesRepository, IMapper mapper,
            IActivitiesRepository activitiesRepository)
        {
            _placesRepository = placesRepository;
            _mapper = mapper;
            _activitiesRepository = activitiesRepository;
        }


        [HttpGet]
        public async Task<IEnumerable<PlaceDto>> GetAllAsync(int activityId)
        {
            var places = await _placesRepository.GetAll(activityId);

            return places.Select(o => _mapper.Map<PlaceDto>(o));
        }

        [HttpGet("{placeId}")]
        public async Task<ActionResult<PlaceDto>> GetAsync(int activityId, int placeId)
        {
            var activity = await _activitiesRepository.Get(activityId);
            if (activity == null) return NotFound($"Activity with id '{activityId}' not found.");

            var place = await _placesRepository.Get(activityId, placeId);
            if (place == null) return NotFound($"Place with id '{placeId}' not found in activity with id '{activityId}'.");

            return Ok(_mapper.Map<PlaceDto>(place));
        }

        [HttpPost]
        public async Task<ActionResult<PlaceDto>> PostAsync(int activityId, CreatePlaceDto placeDto)
        {
            var activity = await _activitiesRepository.Get(activityId);

            if (activity == null) return NotFound($"Activity with id '{activityId}' not found.");
            

            var place = _mapper.Map<Place>(placeDto);
            place.ActivityId = activityId;
            place.CreationTimeUt = DateTime.UtcNow;

            await _placesRepository.Create(place);

            return Created($"/api/activities/{activityId}/places/{place.Id}", _mapper.Map<PlaceDto>(place));
        }

        [HttpPut("{placeId}")]
        public async Task<ActionResult<PlaceDto>> PutAsync(int activityId, int placeId, UpdatePlaceDto placeDto)
        {
            var activity = await _activitiesRepository.Get(activityId);
            if (activity == null) return NotFound($"Activity with id '{activityId}' not found.");

            var oldPlace = await _placesRepository.Get(activityId, placeId);
            if (oldPlace == null) return NotFound($"Place with id '{placeId}' not found in activity with id '{activityId}'.");

            //oldPost.Body = postDto.Body;
            _mapper.Map(placeDto, oldPlace);

            await _placesRepository.Update(oldPlace);

            return Ok(_mapper.Map<PlaceDto>(oldPlace));
        }

        [HttpDelete("{placeId}")]
        public async Task<ActionResult> DeleteAsync(int activityId, int placeId)
        {
            var activity = await _activitiesRepository.Get(activityId);
            if (activity == null) return NotFound($"Activity with id '{activityId}' not found.");


            var place = await _placesRepository.Get(activityId, placeId);
            if (place == null) return NotFound($"Place with id '{placeId}' not found in activity with id '{activityId}'.");

            await _placesRepository.Delete(place);

            // 204
            return NoContent();
        }

    }
}
