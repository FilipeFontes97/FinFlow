using FinFlow.Application.DTOs.Requests.FinancialAccounts;
using FinFlow.Application.Interfaces.FinancialAccounts;
using FinFlow.Application.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace FinFlow.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FinancialAccountController : ControllerBase
    {
        private readonly IFinancialAccountService _service;

        public FinancialAccountController(IFinancialAccountService service)
        {
            _service = service;
        }

        [HttpGet ("myFinancialAccounts")]
        public async Task<IActionResult> GetAllFinancialAccount()
        {
            var result = await _service.GetAllFinancialAccountAsync();

            return Ok(result);
        }

        [HttpGet("getFinancialAccountById/{id}")]
        public async Task<IActionResult> GetFinancialAccountById(Guid id)
        {
            var account = await _service.GetFinancialAccountByIdAsync(id);
            if(account == null) { return NotFound(); }
            return Ok(account);
        }

        [HttpPost]
        public async Task<IActionResult> CreateFinancialAccountAsync([FromBody] CreateFinancialAccountRequest request)
        {
            var createdAccount = await _service.CreateFinancialAccountAsync(request);
            return CreatedAtAction(nameof(GetFinancialAccountById), new { id = createdAccount.Id }, createdAccount);
        }

        [HttpPut("updateFinancialAccout/{id}")]
        public async Task<IActionResult> UpdateFinancialAccountAsync(Guid id, [FromBody] UpdateFinancialAccountRequest request)
        {
            var updatedAccount = await _service.UpdateAsync(id, request);
            if (updatedAccount == null) { return NotFound(); }
            return Ok(updatedAccount);
        }

        [HttpDelete("deleteFinancialAccount/{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            var deleted = await _service.DeleteAsync(id);
            if (!deleted) return NotFound();
            return NoContent();
        }
    }
}