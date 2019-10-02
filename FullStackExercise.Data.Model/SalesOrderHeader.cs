namespace FullStackExercise.Data.Model
{
    public class SalesOrderHeader
    {
        public int SalesOrderId { get; set; }
        public int CustomerId { get; set; }
        public decimal TotalDue { get; set; }
        public Customer Customer { get; set; }
    }
}