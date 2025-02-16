using AutoMapper;
using WebApplication1.App.DAL.DALRepositories;
using WebApplication1.App.DAL.EntityModel;
using WebApplication1.App.DataTransferLayer.DTOs;

namespace WebApplication1.App.BAL.Services
{
    public interface IUserService
    {
        Task<IEnumerable<UserDto>> GetAllUserAsync();
        Task <UserDto> GetUserByIdAsync(int Id);
        Task CreateUserAsync(UserDto userDto);  // 🚀 Method to add user
        Task UpdateUserAsync(UserDto userDto);
        Task DeleteUserAsync(int Id);
    }
    public class UserService : IUserService
    {
        private readonly IUserRepositoryDAL  _userRepositoryDAL;
        private readonly IMapper _mapper;
        public UserService(IUserRepositoryDAL userRepositoryDAL, IMapper mapper) 
        {
            _userRepositoryDAL = userRepositoryDAL;
            _mapper = mapper;
        }

        public async Task<IEnumerable<UserDto>> GetAllUserAsync()
        {
            var user = await _userRepositoryDAL.GetAllUserAsync();

            return _mapper.Map<IEnumerable<UserDto>>(user); 
            //user.Select(p => new UserDto 
            //{ 
            //    Id = p.Id, 
            //    UserName = p.Username, 
            //    FirstName =p.Firstname, 
            //    Gender = p.Gender, 
            //    Email = p.Email 
            //});
        }

        public async Task <UserDto> GetUserByIdAsync(int Id)
        {
            var user = await _userRepositoryDAL.GetUserByIdAsync(Id);

            return _mapper.Map<UserDto>(user);
            //return user.Select(p => new UserDto 
            //{ 
            //    Id = p.Id, 
            //    UserName = p.Username, 
            //    FirstName = p.Firstname, 
            //    Gender = p.Gender, 
            //    Email = p.Email 
            //});

        }

        public async Task CreateUserAsync(UserDto userDto)
        {
            var user = _mapper.Map<User>(userDto); // Convert DTO to Entity
            await _userRepositoryDAL.CreateUserAsync(user);
        }

        public async Task UpdateUserAsync(UserDto userDto)
        {
            var user = _mapper.Map<User>(userDto); // Convert DTO to Entity
            await _userRepositoryDAL.UpdateUserAsync(user);
        }

        public async Task DeleteUserAsync(int Id)
        {
            //var user = _mapper.Map<User>(userDto); // Convert DTO to Entity
            await _userRepositoryDAL.DeleteUserAsync(Id);
        }
    }
}
