using Contracts.ProcessingProviders;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TodoApi.DataObjects;


namespace TodoApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class WorkController : ControllerBase
    {
        private readonly IWorkProcessingProvider _workProcessingProvider;
        public WorkController( IWorkProcessingProvider workProcessingProvider)
        {
            _workProcessingProvider = workProcessingProvider;
        }
        [HttpGet]
        public async Task<IActionResult> Get(CancellationToken cancellationToken = default)
        {
            return Ok(await _workProcessingProvider.FindAll(cancellationToken));
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await _workProcessingProvider.FindByIdAsync(id));
        }
        [HttpGet("{userid}")]
        public async Task<IActionResult> GetByUser(int userid)
        {
            return Ok(await _workProcessingProvider.FindByUser(userid));
        }
        [HttpPost]
        public async Task<IActionResult> Create(WorkDTO dto)
        {
            await _workProcessingProvider.Add(dto);
            return Ok();
        }
        [HttpPut]
        public async Task<IActionResult> Update(WorkDTO dto)
        {
            await _workProcessingProvider.Update(dto);
            return Ok();
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(WorkDTO dto)
        {
            await _workProcessingProvider.Delete(dto.Id);
            return Ok();
        }
    }
}
