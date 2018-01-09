using AutoMapper;
using DistributedToDo.BLL.DTO;
using DistributedToDo.DAL.Entities;

namespace DistributedToDo.BLL.Infrastructure
{
    public class MapperUserProfile : Profile
    {
        public MapperUserProfile()
        {
            CreateMap<UserDTO,ClientProfile>();
            CreateMap<TaskDTO, UserTask>();

            CreateMap<ClientProfile, UserDTO>();
            CreateMap<UserTask, TaskDTO>();
        }
    }
}
