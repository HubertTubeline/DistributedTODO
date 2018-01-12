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
            CreateMap<TaskDTO, TaskModel>();

            CreateMap<AccountModel, UserDTO>();
            CreateMap<RegisterModel, UserDTO>();
            CreateMap<LoginModel, UserDTO>();
            CreateMap<TaskModel, TaskDTO>();
        }
    }
}