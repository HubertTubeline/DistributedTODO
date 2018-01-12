using DistributedToDo.DAL.EF;
using DistributedToDo.DAL.Entities;
using DistributedToDo.DAL.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace DistributedToDo.DAL.Repositories
{
    public class UserTasksManager : IUserTasksManager
    {
        public ApplicationContext Database { get; set; }
        public UserTasksManager(ApplicationContext db)
        {
            Database = db;
        }

        public void Create(UserTask task)
        {
            Database.UserTasks.Add(task);
            Database.SaveChanges();
        }

        public void Edit(UserTask task)
        {
            var item = Database.UserTasks.FirstOrDefault(x => x.Id == task.Id);
            if (item != null)
            {
                    item.Name = task.Name;
                    item.Description = task.Description;
                    item.Checked = task.Checked;
                    Database.SaveChanges();
            }
            else
            {
                throw new System.Exception("Task not found");
            }

        }

        public void Delete(UserTask task)
        {
            var item = Database.UserTasks.FirstOrDefault(x => x.Id == task.Id);
            if (item != null)
            {
                Database.UserTasks.Remove(item);
            }
            else
            {
                throw new System.Exception("Task not found");
            }
        }

        public IEnumerable<UserTask> GetTasks(string email)
        {
            var item = Database.UserTasks.Where(x => x.UserName == email).ToList();
            return item;
        }
    }
}
