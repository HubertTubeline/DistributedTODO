using DistributedToDo.DAL.Entities;
using Microsoft.AspNet.Identity;

namespace DistributedToDo.DAL.Identity
{
    public class ApplicationUserManager : UserManager<ApplicationUser>
    {
        public ApplicationUserManager(IUserStore<ApplicationUser> store)
                : base(store)
        {
        }
    }
}
