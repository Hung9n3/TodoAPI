using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoApi.Core.Entities;

namespace Contracts.DataProviders
{
    public interface IWorkDataProvider : IBaseDataProvider<Work>
    {
        Task<List<Work>> GetWorksByUser(int userId); 
    }
}
