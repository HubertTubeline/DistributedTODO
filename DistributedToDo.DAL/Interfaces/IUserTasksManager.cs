using DistributedToDo.DAL.Entities;
using System.Collections.Generic;

namespace DistributedToDo.DAL.Interfaces
{
    public interface IUserTasksManager
    {
        void Create(UserTask task);
        IEnumerable<UserTask> GetTasks(string email);
        void Edit(UserTask task);
        void Delete(UserTask task);
    }
}
