using Microsoft.EntityFrameworkCore;
using WebDevProject.Models;

namespace WebDevProject.Services
{
    public class DbGroupRepository(ApplicationDbContext db) : IGroupRepository
    {
        private readonly ApplicationDbContext _db = db;
        public async Task<ICollection<Group>> ReadAllGroups()
        {
            var groups = await _db.Group.ToListAsync();
            return groups;
        }

        public async Task<Group> CreateGroup(Group group)
        {
            await _db.Group.AddAsync(group);
            await _db.SaveChangesAsync();
            return group;
        }

        public async Task<ICollection<Genre>> GetAllGenres()
        {
            List<Genre> genres = await _db.Genre.ToListAsync();
            return genres;
        } 
    }
}
