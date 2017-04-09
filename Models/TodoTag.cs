using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace entity_framework_core_demo.Models
{
    public class TodoTag
    {
        public int Id { get; set; }

        public Todo Todo { get; set; }

        public Tag Tag { get; set; }
    }
}
