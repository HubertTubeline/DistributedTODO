using DistributedToDo.DAL.EF;
using DistributedToDo.DAL.Entities;
using DistributedToDo.DAL.Interfaces;
using System.Linq;
using System.Threading.Tasks;

namespace DistributedToDo.DAL.Repositories
{
    public class ClientManager : IClientManager
    {
        public ApplicationContext Database { get; set; }
        public ClientManager(ApplicationContext db)
        {
            Database = db;
        }

        public void Create(ClientProfile item)
        {
            Database.ClientProfiles.Add(item);
            Database.SaveChanges();
        }

        public void Edit(ClientProfile user)
        {
            var item = Database.ClientProfiles.FirstOrDefault(x => x.Email == user.Email);
            if (item != null)
            {
                item.FirstName = user.FirstName;
                item.LastName = user.LastName;
                item.MiddleName = user.MiddleName;
                item.Number = user.Number;
                item.Comment = user.Comment;
                Database.SaveChanges();
            }
            else
            {
                throw new System.Exception("User not found");
            }
        }
        public ClientProfile GetClient(string login)
        {
            ClientProfile clientProfile = Database.ClientProfiles.FirstOrDefault(x => x.Email == login);
            return clientProfile;
        }
        public void Dispose()
        {
            Database.Dispose();
        }

    }
}
