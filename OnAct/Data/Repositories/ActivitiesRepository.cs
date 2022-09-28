using Microsoft.EntityFrameworkCore;
using OnAct.Data.Entities;

namespace OnAct.Data.Repositories
{
    public interface IActivitiesRepository
    {
        Task<List<Activity>> GetAll();
        Task<Activity> Get(int id);
        Task Create(Activity activity);
        Task Put(Activity activity);
        Task Delete(Activity activity);

    }

    public class ActivitiesRepository : IActivitiesRepository
    {
        private readonly OnActContext _onActContext;

        public ActivitiesRepository(OnActContext _onActContext)
        {
            this._onActContext = _onActContext;
        }

        public async Task<List<Activity>> GetAll()
        {
            return await _onActContext.Activities.ToListAsync();
        }

        public async Task<Activity> Get(int id){

            return await _onActContext.Activities.FirstOrDefaultAsync(o => o.Id == id);

        }

        public async Task Create(Activity activity)
        {
            _onActContext.Activities.Add(activity);
            await _onActContext.SaveChangesAsync();
        }

        public async Task Put(Activity activity)
        {
            _onActContext.Activities.Update(activity);
            await _onActContext.SaveChangesAsync();
        }

        public async Task Delete(Activity activity)
        {
            _onActContext.Activities.Remove(activity);
            await _onActContext.SaveChangesAsync();
        }

    }
}
