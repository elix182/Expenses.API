using System;
using Expenses.API.Models;
using Expenses.API.Models.Common;

namespace Expenses.API.Services
{
	public interface IExpensesService
	{
		Task<ServiceResult<IEnumerable<Expense>>> FindAll();
        Task<ServiceResult> CreateExpense(Expense payload);
        Task<ServiceResult> UpdateExpense(Guid expenseUid, Expense payload);
        Task<ServiceResult> DeleteExpense(Guid expenseUid);
    }
}

