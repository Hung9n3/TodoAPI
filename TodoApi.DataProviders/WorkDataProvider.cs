using Contracts.DataProviders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoApi.Core.Database;
using TodoApi.Core.Entities;

namespace TodoApi.DataProviders
{
    public class WorkDataProvider : BaseDataProvider<Work>, IWorkDataProvider
    {
        public WorkDataProvider(TodoContext context) : base(context)
        {

        }

        public async Task<List<Work>> GetWorksByUser(int userId)
        {
            var calendar = await _context.Calendars.Where(x => x.Id == userId).Include(x => x.Works).FirstOrDefaultAsync();
            if (calendar is null) return new List<Work>();
            else return calendar.Works.ToList();
        }
    }
}
