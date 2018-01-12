namespace DistributedToDo.Web.Models
{
    public class TaskModel
    {
        public string Id { get; set; }

        public bool Checked { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }
    }
}