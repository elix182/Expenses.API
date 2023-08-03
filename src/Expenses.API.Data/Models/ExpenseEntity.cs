namespace Expenses.API.Data.Models
{
	public class ExpenseEntity
	{
		public Guid ExpenseUid { get; set; }
        public string Description { get; set; }
		public decimal Amount { get; set; }
		public DateTime Date { get; set; }
		public DateTime? InsertedDate { get; set; }
		public string InsertedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string UpdatedBy { get; set; }
    }
}

