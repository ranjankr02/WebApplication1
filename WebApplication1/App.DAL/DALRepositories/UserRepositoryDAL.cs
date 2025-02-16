using Microsoft.EntityFrameworkCore;
using WebApplication1.App.DAL;
using WebApplication1.App.DAL.EntityModel;

namespace WebApplication1.App.DAL.DALRepositories
{
    public interface IUserRepositoryDAL
    {
        Task<IEnumerable<User>> GetAllUserAsync();
        Task<User> GetUserByIdAsync(int Id);
        Task CreateUserAsync(User user);
        Task UpdateUserAsync(User user);
        Task DeleteUserAsync(int Id);
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

        public async Task<User> GetUserByIdAsync(int Id)
        {
            var user =  await _context.Users.FirstOrDefaultAsync(i => i.Id == Id);
            
            return user;
        }

        public async Task CreateUserAsync(User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateUserAsync(User user)
        {
            var matchedUser = await _context.Users.FirstOrDefaultAsync(i => i.Id == user.Id);

            if(matchedUser != null)
            {
                 _context.Users.Remove(matchedUser);
            }
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();

        }

        public async Task DeleteUserAsync(int Id)
        {
            var matchedUser = await _context.Users.FirstOrDefaultAsync(i => i.Id == Id);

            if (matchedUser != null)
            {
                _context.Users.Remove(matchedUser);
            }
           // await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();

        }

    }
}
