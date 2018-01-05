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
            CreateMap<ClientProfile, UserDTO>();
        }
    }
}
