using AutoMapper;
using DistributedToDo.BLL.DTO;
using DistributedToDo.Web.Models;

namespace DistributedToDo.Web.Infrastructure
{
    public class MapperUserProfile : Profile
    {
        public MapperUserProfile()
        {
            CreateMap<UserDTO, AccountModel>();
            CreateMap<UserDTO, RegisterModel>();
            CreateMap<UserDTO, LoginModel>();

            CreateMap<AccountModel, UserDTO>();

            CreateMap<RegisterModel, UserDTO>()
            .ForAllMembers(x => x.AllowNull());
            CreateMap<LoginModel, UserDTO>()
            .ForMember("Id", opt => opt.Ignore())
            .ForMember("Role", opt => opt.Ignore());
        }
    }
}