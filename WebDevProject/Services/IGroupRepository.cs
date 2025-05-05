using WebDevProject.Models;

namespace WebDevProject.Services
{
    public interface IGroupRepository
    {
        public Task<ICollection<Group>> ReadAllGroups();

        //public Task<Group> GetGroupById(int id);

        public Task<Group> CreateGroup (Group group);

        public Task<ICollection<Genre>> GetAllGenres();

        //public Task DeleteGroup (int id);

        //public Task<Group> UpdateGroup (Group group);
    }
}
