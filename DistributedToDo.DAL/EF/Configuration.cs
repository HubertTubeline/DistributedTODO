using System.Data.Entity.Migrations;

namespace DistributedToDo.DAL.EF
{
    public sealed class Configuration : DbMigrationsConfiguration<ApplicationContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(ApplicationContext context)
        {

        }
    }
}
