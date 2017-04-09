using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace entity_framework_core_demo.Models
{
    public class Tag
    {
        public int Id { get; set; }

        // [Required]
        // [MaxLength(100)]
        public string Title { get; set; }
    }
}
