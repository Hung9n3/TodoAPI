using TodoApi.Core.Entities;

namespace TodoApi.DTOs
{
    public class CalendarDTO : BaseDTO
    {
        public ICollection<WorkDTO>? Works { get; set; }
    }
}
