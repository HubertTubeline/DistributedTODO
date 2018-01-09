using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DistributedToDo.Web.Models
{
    public class TaskModel
    {
        public bool Checked { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }
    }
}