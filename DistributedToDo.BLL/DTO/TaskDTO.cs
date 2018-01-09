namespace DistributedToDo.BLL.DTO
{
    public class TaskDTO
    {
        public string Id { get; set; }

        public string UserName { get; set; }

        public bool Checked { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }
    }
}
