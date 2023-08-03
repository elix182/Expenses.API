namespace Expenses.API.Models
{
	public class Expense
	{
		public Guid ExpenseUid { get; set; }
        public string Description { get; set; }
		public decimal Amount { get; set; }
		public DateTime Date { get; set; }
	}
}

