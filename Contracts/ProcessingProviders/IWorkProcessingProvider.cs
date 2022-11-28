using Contracts.DataProviders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoApi.Core.Entities;
using TodoApi.DataObjects;

namespace Contracts.ProcessingProviders
{
    public interface IWorkProcessingProvider : IBaseProcessingProvider<Work,WorkDTO>
    {
        Task<List<WorkDTO>> FindByUser(int userId);
    }
}
