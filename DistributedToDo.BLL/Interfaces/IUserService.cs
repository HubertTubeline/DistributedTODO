using DistributedToDo.BLL.DTO;
using DistributedToDo.BLL.Infrastructure;
using System;
using System.Security.Claims;
using System.Threading.Tasks;

namespace DistributedToDo.BLL.Interfaces
{
    public interface IUserService : IDisposable
    {
        Task<OperationDetails> CreateAsync(UserDTO userDto);
        Task<ClaimsIdentity> Authenticate(UserDTO userDto);
        UserDTO GetUser(string Email);
        int GetUsersCount();
        OperationDetails Edit(UserDTO userDto);
    }
}
