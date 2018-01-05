using DistributedToDo.BLL.DTO;
using DistributedToDo.BLL.Infrastructure;
using System;
using System.Security.Claims;
using System.Threading.Tasks;

namespace DistributedToDo.BLL.Interfaces
{
    public interface IUserService : IDisposable
    {
        Task<OperationDetails> Create(UserDTO userDto);
        Task<ClaimsIdentity> Authenticate(UserDTO userDto);
        UserDTO GetUser(string Email);
        OperationDetails Edit(UserDTO userDto);
    }
}
