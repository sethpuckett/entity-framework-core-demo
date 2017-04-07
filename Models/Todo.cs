using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace entity_framework_core_demo.Models
{
    public class Todo
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public ICollection<TodoTag> TodoTags { get; set; }

        public Status Status { get; set; }

        [NotMapped]
        public bool Processing {get; set;}
    }
}
