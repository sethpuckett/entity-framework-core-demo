using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace entity_framework_core_demo.Models
{
    [NotMapped]
    public class ValidationTracker
    {
        public IEnumerable<string> Warnings { get; set; }

        public IEnumerable<string> Errors { get; set; }
    }
}
