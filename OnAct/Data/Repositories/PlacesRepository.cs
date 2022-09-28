using Microsoft.EntityFrameworkCore;
using OnAct.Data.Entities;

namespace OnAct.Data.Repositories
{
    public interface IPlacesRepository
    {
        Task<List<Place>> GetAll(int activityId);
        Task<Place> Get(int activityId, int placeId);
        Task Create(Place place);
        Task Update(Place post);
        Task Delete(Place post);
    }


    public class PlacesRepository : IPlacesRepository
    {

        private readonly OnActContext _onActContext;

        public PlacesRepository(OnActContext onActContext)
        {
            _onActContext = onActContext;
        }


        public async Task<List<Place>> GetAll(int activityId)
        {
            return await _onActContext.Places.Where(o => o.ActivityId == activityId).ToListAsync();
        }

        public async Task<Place> Get(int activityId, int placesId)
        {
            return await _onActContext.Places.FirstOrDefaultAsync(o => o.ActivityId == activityId && o.Id == placesId);
        }

        public async Task Create(Place place)
        {
            _onActContext.Places.Add(place);
            await _onActContext.SaveChangesAsync();
        }

        public async Task Update(Place place)
        {
            _onActContext.Places.Update(place);
            await _onActContext.SaveChangesAsync();
        }

        public async Task Delete(Place place)
        {
            _onActContext.Places.Remove(place);
            await _onActContext.SaveChangesAsync();
        }

    }
}
