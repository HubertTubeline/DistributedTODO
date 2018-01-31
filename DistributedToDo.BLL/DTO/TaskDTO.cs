using System;

namespace DistributedToDo.BLL.DTO
{
    public class TaskDTO
    {
        public string Id { get; set; }

        public string UserName { get; set; }

        public bool Checked { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }

        public DateTime Date { get; set; }
        public TimeSpan Time { get; set; }

        public string GeoLong { get; set; } // долгота - для карт google
        public string GeoLat { get; set; } // широта - для карт google
    }
}
