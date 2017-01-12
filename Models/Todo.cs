using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace entity_framework_core_demo.Models
{
    public class Todo
    {
        public int Id;

        public string Title { get; set; }

        public string Description { get; set; }

        public ICollection<TodoTag> TodoTags { get; set; }

        public Status Status { get; set; }
    }
}
