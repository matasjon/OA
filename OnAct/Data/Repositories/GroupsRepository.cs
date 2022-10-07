using Microsoft.EntityFrameworkCore;
using OnAct.Data.Entities;

namespace OnAct.Data.Repositories
{

    public interface IGroupsRepository
    {
        Task<List<Group>> GetAll(int activityId, int placeId);
        Task<Group> Get(int activityId, int placeId, int groupId);
        Task Create(Group group);
        Task Update(Group group);
        Task Delete(Group group);
    }

    public class GroupsRepository : IGroupsRepository
    {
        private readonly OnActContext _onActContext;

        public GroupsRepository(OnActContext onActContext)
        {
            _onActContext = onActContext;
        }

        public async Task<List<Group>> GetAll(int activityId, int placeId)
        {
            return await _onActContext.Groups.Where(o => o.ActivityId == activityId && o.PlaceId == placeId).ToListAsync();
        }

        public async Task<Group> Get(int activityId, int placesId, int groupId)
        {
            return await _onActContext.Groups.FirstOrDefaultAsync(o => o.ActivityId == activityId && o.PlaceId == placesId && o.Id == groupId);
        }

        public async Task Create(Group group)
        {
            _onActContext.Groups.Add(group);
            await _onActContext.SaveChangesAsync();
        }

        public async Task Update(Group group)
        {
            _onActContext.Groups.Update(group);
            await _onActContext.SaveChangesAsync();
        }

        public async Task Delete(Group group)
        {
            _onActContext.Groups.Remove(group);
            await _onActContext.SaveChangesAsync();
        }
    }
}
