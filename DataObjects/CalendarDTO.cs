using TodoApi.Core.Entities;

namespace TodoApi.DataObjects
{
    public class CalendarDTO : BaseDTO
    {
        public ICollection<WorkDTO>? Works { get; set; }
    }
}
