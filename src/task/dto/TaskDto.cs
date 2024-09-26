using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PruebaDotnet.src.task.dto
{
    public class TaskDto
    {
        public string title { get; set; }

        public string description { get; set; }
        public DateTime expiration_date { get; set; }
        public bool state { get; set; }
    }
}