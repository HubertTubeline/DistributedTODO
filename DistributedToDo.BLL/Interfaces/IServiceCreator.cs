namespace DistributedToDo.BLL.Interfaces
{
    public interface IServiceCreator
    {
        IUserService CreateUserService(string connection);
        IUserTaskService CreateUserTaskService(string connection);
    }
}
