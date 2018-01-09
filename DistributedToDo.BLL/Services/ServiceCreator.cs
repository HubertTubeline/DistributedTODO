using DistributedToDo.BLL.Interfaces;
using DistributedToDo.DAL.Repositories;

namespace DistributedToDo.BLL.Services
{
    public class ServiceCreator : IServiceCreator
    {
        public IUserService CreateUserService(string connection)
        {
            return new UserService(new UnitOfWork(connection));
        }

        public IUserTaskService CreateUserTaskService(string connection)
        {
            return new UserTaskService(new UnitOfWork(connection));
        }
    }
}
