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
    public class WorkProcessingProvider : BaseProcessingProvider<Work, WorkDTO>, IWorkProcessingProvider
    {
        protected IWorkDataProvider _workDataProvider;
        public WorkProcessingProvider(IBaseDataProvider<Work> dataProvider, IMapper mapper, IWorkDataProvider workDataProvider) : base(dataProvider, mapper)
        {
            _workDataProvider = workDataProvider;
        }

        public async Task<List<WorkDTO>> FindByUser(int userId)
        {
            return MapToListDTO(await _workDataProvider.GetWorksByUser(userId));
        }
    }
}
