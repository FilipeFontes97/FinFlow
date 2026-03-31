using FinFlow.Application.Interfaces;
using FinFlow.Domain.Models;
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
            var accounts = await _service.GetAllFinancialAccountAsync();
            return Ok(accounts);
        }

        [HttpGet("getFinancialAccountById/{id}")]
        public async Task<IActionResult> GetFinancialAccountById(Guid id)
        {
            var account = await _service.GetFinancialAccountByIdAsync(id);
            if(account == null) { return NotFound(); }
            return Ok(account);
        }

        [HttpPost]
        public async Task<IActionResult> CreateFinancialAccountAsync([FromBody] FinancialAccount account)
        {
            var createdAccount = await _service.CreateFinancialAccountAsync(account);
            return CreatedAtAction(nameof(GetFinancialAccountById), new { id = createdAccount.Id }, createdAccount);
        }

        [HttpPut("updateFinancialAccout/{id}")]
        public async Task<IActionResult> UpdateFinancialAccountAsync(Guid id, [FromBody] FinancialAccount account)
        {
            var updatedAccount = await _service.UpdateAsync(id, account);
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