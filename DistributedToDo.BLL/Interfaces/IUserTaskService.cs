using DistributedToDo.BLL.DTO;
using DistributedToDo.BLL.Infrastructure;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DistributedToDo.BLL.Interfaces
{
    public interface IUserTaskService
    {
        OperationDetails Create(TaskDTO taskDto);
        IEnumerable<TaskDTO> GetTasks(string email);
        OperationDetails Edit(TaskDTO taskDto);
        OperationDetails Delete(TaskDTO taskDto);
        TaskDTO GetTask(string taskId);
    }
}