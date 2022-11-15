using System.ComponentModel.DataAnnotations;

namespace TodoApi.DTOs
{
    public class WorkDTO : BaseDTO
    {
        public string Name { get; set; } = "Unnamed";
        [Required]
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public string Description { get; set; } = "";
        [Required]
        public string Color { get; set; } = "";
        [Required]
        public int CalendarId { get; set; }
    }
}
