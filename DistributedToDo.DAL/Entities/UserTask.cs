using System.ComponentModel.DataAnnotations;

namespace DistributedToDo.DAL.Entities
{
    public class UserTask
    {
        [Key]
        public string Id { get; set; }

        public string UserName { get; set; }

        public bool Checked { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }
    }
}
