using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoApi.Core.Entities
{
    public class Calendar : BaseEntity
    {
        public ICollection<Work> Works { get; set; } = new List<Work>();
        public int UserId { get; set; }
    }
}
