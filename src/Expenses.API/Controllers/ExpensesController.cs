using Expenses.API.Models;
using Expenses.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace Expenses.API.Controllers
{
    [ApiController]
	[Route("[controller]")]
	public class ExpensesController : ControllerBase
	{
		private readonly IExpensesService _service;

		public ExpensesController(IExpensesService service)
		{
			_service = service;
		}

		[HttpGet]
		public async Task<IActionResult> FindAllExpenses()
		{
			var result = await _service.FindAll();
			if (result.IsError)
			{
				return BadRequest(result);
			}
			return Ok(result);
		}

		[HttpPost]
		public async Task<IActionResult> RegisterNewExpense([FromBody] Expense payload)
		{
			var result = await _service.CreateExpense(payload);
            if (result.IsError)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        [HttpPut("{expenseUid}")]
        public async Task<IActionResult> UpdateExpense([FromRoute] Guid expenseUid, [FromBody] Expense payload)
        {
            var result = await _service.UpdateExpense(expenseUid, payload);
            if (result.IsError)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        [HttpDelete("{expenseUid}")]
        public async Task<IActionResult> DeleteExpense([FromRoute] Guid expenseUid)
        {
            var result = await _service.DeleteExpense(expenseUid);
            if (result.IsError)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
    }
}

