using Microsoft.EntityFrameworkCore;
using WebApplication1.App.DAL;
using WebApplication1.App.DAL.EntityModel;

namespace WebApplication1.App.DAL.DALRepositories
{
    public interface IUserRepositoryDAL
    {
        Task<IEnumerable<User>> GetAllUserAsync();
    }
    public class UserRepositoryDAL : IUserRepositoryDAL
    {
        private readonly AppDbContext _context;

        public UserRepositoryDAL(AppDbContext context) 
        {
            _context = context;
        }

        public async Task<IEnumerable<User>> GetAllUserAsync()
        {
            return await _context.Users.ToListAsync();
        }

    }
}
