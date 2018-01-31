using DistributedToDo.DAL.Interfaces;
using DistributedToDo.DAL.Repositories;
using Ninject.Modules;

namespace DistributedToDo.BLL.Infrastructure
{
    public class NinjectRegistrations : NinjectModule
    {
        public override void Load()
        {
            Bind<IUnitOfWork>().To<UnitOfWork>().WithConstructorArgument("connectionString", "Users");
        }
    }
}
