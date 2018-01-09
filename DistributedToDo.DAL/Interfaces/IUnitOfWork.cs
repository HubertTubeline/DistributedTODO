using DistributedToDo.DAL.Identity;
using System;
using System.Threading.Tasks;

namespace DistributedToDo.DAL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        ApplicationUserManager UserManager { get; }
        IClientManager ClientManager { get; }
        ApplicationRoleManager RoleManager { get; }
        IUserTasksManager TasksManager { get; }
        Task SaveAsync();
    }
}
