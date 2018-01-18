using System;
using System.ComponentModel.DataAnnotations;

namespace DistributedToDo.Web.Models
{
    public class TaskModel
    {
        public string Id { get; set; }

        public bool Checked { get; set; }

        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public TimeSpan Time { get; set; }
    }
}