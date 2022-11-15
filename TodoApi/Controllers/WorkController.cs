using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TodoApi.DTOs;
using TodoApi.Helpers.Data;

namespace TodoApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class WorkController : ControllerBase
    {
        private readonly WorkDataHelpers _workDataHelpers;
        public WorkController( WorkDataHelpers workDataHelpers)
        {
            _workDataHelpers = workDataHelpers;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _workDataHelpers.FindAll());
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await _workDataHelpers.FindByIdAsync(id));
        }
        [HttpGet("{userid}")]
        public async Task<IActionResult> GetByUser(int userid)
        {
            return Ok(await _workDataHelpers.FindByUser(userid));
        }
        [HttpPost]
        public async Task<IActionResult> Create(WorkDTO dto)
        {
            await _workDataHelpers.Create(dto);
            await _workDataHelpers.SaveAsync();
            return Ok();
        }
        [HttpPut]
        public async Task<IActionResult> Update(WorkDTO dto)
        {
            await _workDataHelpers.Update(dto);
            await _workDataHelpers.SaveAsync();

            return Ok();
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(WorkDTO dto)
        {
            await _workDataHelpers.Delete(dto.Id);
            await _workDataHelpers.SaveAsync();

            return Ok();
        }
    }
}
