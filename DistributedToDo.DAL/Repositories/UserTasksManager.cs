using DistributedToDo.DAL.EF;
using DistributedToDo.DAL.Entities;
using DistributedToDo.DAL.Interfaces;
using System;
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
            task.Id = Guid.NewGuid().ToString();
            Database.UserTasks.Add(task);
            Database.SaveChanges();
        }

        public void Edit(UserTask userTask)
        {
            UserTask item = Database.UserTasks.FirstOrDefault(x => x.Id == userTask.Id && x.UserName == userTask.UserName);
            if (item != null)
            {
                item.Name = userTask.Name;
                item.Description = userTask.Description;
                item.Checked = userTask.Checked;
                if (userTask.Date != new DateTime(0001,01,01)) item.Date = userTask.Date;
                if (userTask.Time.ToString() != "00:00:00") item.Time = userTask.Time;
                Database.SaveChanges();
            }
            else
            {
                throw new System.Exception("Task not found");
            }

        }

        public void Delete(UserTask userTask)
        {
            UserTask item = Database.UserTasks.FirstOrDefault(x => x.Id == userTask.Id && x.UserName == userTask.UserName);
            if (item != null)
            {
                Database.UserTasks.Remove(item);
                Database.SaveChanges();
            }
            else
            {
                throw new System.Exception("Task not found");
            }
        }

        public IEnumerable<UserTask> GetTasks(string email)
        {
            return Database.UserTasks.Where(x => x.UserName == email).ToList();
        }

        public UserTask GetTask(string taskId)
        {
            return Database.UserTasks.FirstOrDefault(x => x.Id == taskId);
        }
    }
}
