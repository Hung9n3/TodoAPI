using AutoMapper;
using Contracts.DataProviders;
using Contracts.ProcessingProviders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoApi.Core.Entities;
using TodoApi.DataObjects;

namespace TodoApi.ProcessingProvider
{
    public class WorkProcessingProvider : BaseProcessingProvider<Work, WorkDTO, IWorkDataProvider>, IWorkProcessingProvider
    {
        public WorkProcessingProvider(IWorkDataProvider dataProvider, IMapper mapper) : base(dataProvider, mapper)
        {
        }

        public async Task<List<WorkDTO>> FindByUser(int userId)
        {
            return MapToListDTO(await _dataProvider.GetWorksByUser(userId));
        }
    }
}
