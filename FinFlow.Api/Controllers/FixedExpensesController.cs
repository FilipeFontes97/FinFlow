using FinFlow.Application.DTOs.Requests.FixedExpenses;
using FinFlow.Application.Interfaces.FixedExpenses;
using Microsoft.AspNetCore.Mvc;

namespace FinFlow.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FixedExpensesController : Controller
    {
        private readonly IFixedExpensesService _fixedExpensesService;
        public FixedExpensesController(IFixedExpensesService fixedExpensesService)
        {
            _fixedExpensesService = fixedExpensesService;
        }
        [HttpGet("myFixedExpenses")]
        public async Task<IActionResult> GetAllFixedExpenses()
        {
            var fixedExpenses = await _fixedExpensesService.GetAllFixedExpensesAsync();
            return Ok(fixedExpenses);
        }
        [HttpGet("getFixedExpenseById/{id}")]
        public async Task<IActionResult> GetFixedExpenseById(Guid id)
        {
            var fixedExpense = await _fixedExpensesService.GetFixedExpenseByIdAsync(id);
            if (fixedExpense == null) return NotFound();
            return Ok(fixedExpense);
        }
        [HttpPost("createFixedExpense")]
        public async Task<IActionResult> CreateFixedExpense([FromBody] CreateFixedExpenseRequest request)
        {
            var createdFixedExpense = await _fixedExpensesService.CreateDebtAsync(request);
            return CreatedAtAction(nameof(GetFixedExpenseById), new { id = createdFixedExpense.Id }, createdFixedExpense);
        }
        [HttpPut("updateFixedExpense/{id}")]
        public async Task<IActionResult> UpdateFixedExpense(Guid id, [FromBody] UpdateFixeExpenseRequest request)
        {
            var updateFixedExpense = await _fixedExpensesService.UpdateAsync(id, request);
            if (updateFixedExpense == null) return NotFound();
            return Ok(updateFixedExpense);
        }

        [HttpDelete("deleteFixedExpense/{id}")]
        public async Task<IActionResult> DeleteDebt(Guid id)
        {
            var deleted = await _fixedExpensesService.DeleteAsync(id);
            if (!deleted) return NotFound();
            return NoContent();
        }
    }
}