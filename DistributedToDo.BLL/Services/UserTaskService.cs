using AutoMapper;
using DistributedToDo.BLL.DTO;
using DistributedToDo.BLL.Infrastructure;
using DistributedToDo.BLL.Interfaces;
using DistributedToDo.DAL.Entities;
using DistributedToDo.DAL.Interfaces;
using System;
using System.Collections.Generic;

namespace DistributedToDo.BLL.Services
{
    public class UserTaskService : IUserTaskService
    {
        IUnitOfWork Database { get; set; }

        public UserTaskService(IUnitOfWork uow)
        {
            Database = uow;
        }

        public OperationDetails Create(TaskDTO taskDto)
        {

            UserTask task = Mapper.Map<TaskDTO, UserTask>(taskDto);
            try
            {
                Database.TasksManager.Create(task);
                Database.SaveAsync();
            }
            catch
            {
                return new OperationDetails(false, "Ошибка создания задачи", "");
            }
            return new OperationDetails(true, "Задача успешно создана.", "");
        }
        public IEnumerable<TaskDTO> GetTasks(string email)
        {
            var tasks =  Database.TasksManager.GetTasks(email);
            return Mapper.Map<IEnumerable<UserTask>, IEnumerable<TaskDTO>>(tasks);
        }
        public OperationDetails Edit(TaskDTO taskDto)
        {
            try
            {
                Database.TasksManager.Edit(Mapper.Map<TaskDTO, UserTask>(taskDto));
            }
            catch
            {
                return new OperationDetails(false, "Ошибка изменения данных.","");
            }
            return new OperationDetails(true,"Данные успешно изменены.","");
        }
        public OperationDetails Delete(TaskDTO taskDto)
        {
            try
            {
                Database.TasksManager.Delete(Mapper.Map<TaskDTO, UserTask>(taskDto));
            }
            catch
            {
                return new OperationDetails(false, "Ошибка удаления задачи.", "");
            }
            return new OperationDetails(true, "Задача успешно удалена.", "");
        }
    }
}
