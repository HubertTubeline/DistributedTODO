using DistributedToDo.DAL.Interfaces;
using DistributedToDo.DAL.Repositories;
using Ninject.Modules;

namespace DistributedToDo.DAL.Infrastructure
{
    public class NinjectRegistrations : NinjectModule
    {
        public override void Load()
        {
            Bind<IUnitOfWork>().To<UnitOfWork>();
        }
    }
}
