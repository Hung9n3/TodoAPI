using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoApi.Core.Entities
{
    public class Work : BaseEntity
    {
        public string Name { get; set; } = "Unnamed";
        [Required]
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public string Description { get; set; } = "";
        [Required]
        public string Color { get; set; } = "";
        [ForeignKey("CalendarId")]
        public int CalendarId { get; set; }
    }
}
