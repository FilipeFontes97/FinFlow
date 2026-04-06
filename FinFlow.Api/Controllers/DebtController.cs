using FinFlow.Application.DTOs.Requests.Debt;
using FinFlow.Application.Interfaces.Debts;
using Microsoft.AspNetCore.Mvc;

namespace FinFlow.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DebtController : Controller
    {
        private readonly IDebtService _debtService;
        public DebtController(IDebtService debtService)
        {
            _debtService = debtService;
        }

        [HttpGet("myDebts")]
        public async Task<IActionResult> GetAllDebts()
        {
            var debts = await _debtService.GetAllDebtAsync();
            return Ok(debts);
        }

        [HttpGet("getDebtById/{id}")]
        public async Task<IActionResult> GetDebtById(Guid id)
        {
            var debt = await _debtService.GetDebtByIdAsync(id);
            if (debt == null) return NotFound();
            return Ok(debt);
        }

        [HttpPost("createDebt")]
        public async Task<IActionResult> CreateDebt([FromBody] CreateDebtRequest request)
        {
            var createdDebt = await _debtService.CreateDebtAsync(request);
            return CreatedAtAction(nameof(GetDebtById), new { id = createdDebt.Id }, createdDebt);
        }

        [HttpPut("updateDebt/{id}")]
        public async Task<IActionResult> UpdateDebt(Guid id, [FromBody] UpdateDebtRequest request)
        {
            var updateDebt = await _debtService.UpdateAsync(id, request);
            if (updateDebt == null) return NotFound();
            return Ok(updateDebt);
        }

        [HttpPost("addPayment/{debtId}")]
        public async Task<IActionResult> AddPayment(Guid debtId, [FromBody] decimal amount)
        {
            try
            {
                var updatedDebt = await _debtService.AddPaymentAsync(debtId, amount);
                return Ok(updatedDebt);
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("deleteDebt/{id}")]
        public async Task<IActionResult> DeleteDebt(Guid id)
        {
            var deleted = await _debtService.DeleteAsync(id);
            if (!deleted) return NotFound();
            return NoContent();
        }
    }
}
