using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using AutoMapper;
using DistributedToDo.Web.Infrastructure;
using Ninject;
using Ninject.Modules;
using Ninject.Web.Mvc;
using FluentValidation.Mvc;

namespace DistributedToDo.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            //Выполняем инициализацию Fluent Validation
            FluentValidationModelValidatorProvider.Configure();
            //Инициализация маппера
            Mapper.Initialize(cfg => 
            {
                cfg.AddProfile<Web.Infrastructure.MapperUserProfile>();
                cfg.AddProfile<BLL.Infrastructure.MapperUserProfile>();
            });

            //Внедрение зависимостей
            NinjectModule registrations = new NinjectRegistrations();
            NinjectModule bllRegistrations = new BLL.Infrastructure.NinjectRegistrations();
            var kernel = new StandardKernel(registrations, bllRegistrations);
            DependencyResolver.SetResolver(new NinjectDependencyResolver(kernel));
        }
    }
}
