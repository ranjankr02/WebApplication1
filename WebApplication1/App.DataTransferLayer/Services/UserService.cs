using WebApplication1.App.DAL.DALRepositories;
using WebApplication1.App.DataTransferLayer.DTOs;

namespace WebApplication1.App.BAL.Services
{
    public interface IUserService
    {
        Task<IEnumerable<UserDto>> GetAllUserAsync();
    }
    public class UserService : IUserService
    {
        private readonly IUserRepositoryDAL  _userRepositoryDAL;
        public UserService(IUserRepositoryDAL userRepositoryDAL) 
        {
            _userRepositoryDAL = userRepositoryDAL;
        }

        public async Task<IEnumerable<UserDto>> GetAllUserAsync()
        {
            var user = await _userRepositoryDAL.GetAllUserAsync();

            return user.Select(p => new UserDto { Id = p.Id, UserName = p.Username, FirstName =p.Firstname, Gender = p.Gender, Email = p.Email });
        }
    }
}
