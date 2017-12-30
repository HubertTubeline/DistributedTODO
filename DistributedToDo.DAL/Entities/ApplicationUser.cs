using Microsoft.AspNet.Identity.EntityFramework;

namespace DistributedToDo.DAL.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public virtual ClientProfile ClientProfile { get; set; }
    }
}
