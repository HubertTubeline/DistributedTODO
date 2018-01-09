using DistributedToDo.BLL.Interfaces;
using DistributedToDo.BLL.Services;
using Ninject.Modules;

namespace DistributedToDo.Web.Infrastructure
{
    public class NinjectRegistrations : NinjectModule
    {
        public override void Load()
        {
            Bind<IUserTaskService>().To<UserTaskService>();
        }
    }
}