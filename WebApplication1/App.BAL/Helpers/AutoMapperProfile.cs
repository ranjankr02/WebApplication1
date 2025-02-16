using AutoMapper;
using WebApplication1.App.DAL.EntityModel;
using WebApplication1.App.DataTransferLayer.DTOs;

namespace WebApplication1.App.BAL.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile() 
        {
            CreateMap<User, UserDto>().ReverseMap(); // Two-way mapping
        }
    }
}
