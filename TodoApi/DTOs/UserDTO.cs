using System.ComponentModel.DataAnnotations;
using TodoApi.Core.Entities;

namespace TodoApi.DTOs
{
    public class UserDTO : BaseDTO
    {
        public string Name { get; set; } = "";
        [Required]
        public string Email { get; set; } = "";
        [Required]
        public string Password { get; set; } = "";
        public CalendarDTO Calendar { get; set; } = new();
    }
}
