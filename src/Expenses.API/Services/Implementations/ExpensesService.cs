using Expenses.API.Models;
using Expenses.API.Models.Common;
using Expenses.API.Data.Repositories;
using Expenses.API.Data.Models;

namespace Expenses.API.Services
{
    public class ExpensesService : IExpensesService
	{
        private readonly IExpensesRepository _repository;

		public ExpensesService(IExpensesRepository repository)
		{
            _repository = repository;
		}

        public async Task<ServiceResult> CreateExpense(Expense payload)
        {
            var result = new ServiceResult();
            try
            {
                if(payload.Amount < 0)
                {
                    result.SetErrorMessage("Amount must be a positive number");
                    return result;
                }
                var data = new ExpenseEntity()
                {
                    Amount = payload.Amount,
                    Date = payload.Date,
                    Description = payload.Description,
                    InsertedDate = DateTime.UtcNow
                };
                await _repository.CreateExpense(data);
            }
            catch(Exception ex)
            {
                result.SetErrorMessage(ex);
            }
            return result;
        }

        public async Task<ServiceResult> DeleteExpense(Guid expenseUid)
        {
            var result = new ServiceResult();
            try
            {
                var expense = await _repository.GetExpense(expenseUid);
                if (expense == null)
                {
                    result.SetErrorMessage("Expense not found: " + expenseUid, ErrorCode.NOT_FOUND);
                }
                await _repository.DeleteExpense(expenseUid);
            }
            catch (Exception ex)
            {
                result.SetErrorMessage(ex);
            }
            return result;
        }

        public async Task<ServiceResult<IEnumerable<Expense>>> FindAll()
        {
            var result = new ServiceResult<IEnumerable<Expense>>();
            try
            {
                var entities = await _repository.FindAll();
                result.Data = entities.Select(d => new Expense()
                {
                    ExpenseUid = d.ExpenseUid,
                    Description = d.Description,
                    Date = d.Date,
                    Amount = d.Amount
                });
            }
            catch (Exception ex)
            {
                result.SetErrorMessage(ex);
            }
            return result;
        }

        public async Task<ServiceResult> UpdateExpense(Guid expenseUid, Expense payload)
        {
            var result = new ServiceResult();
            try
            {
                var expense = await _repository.GetExpense(expenseUid);
                if(expense == null)
                {
                    result.SetErrorMessage("Expense not found: " + expenseUid, ErrorCode.NOT_FOUND);
                }
                if (payload.Amount < 0)
                {
                    result.SetErrorMessage("Amount must be a positive number");
                    return result;
                }
                var data = new ExpenseEntity()
                {
                    Amount = payload.Amount,
                    Date = payload.Date,
                    Description = payload.Description,
                    UpdatedDate = DateTime.UtcNow
                };
                await _repository.UpdateExpense(expenseUid, data);
            }
            catch (Exception ex)
            {
                result.SetErrorMessage(ex);
            }
            return result;
        }
    }
}

