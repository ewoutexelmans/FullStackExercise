namespace FullStackExercise.Business.Customers.Queries.GetCustomerByPage
{
    public class CustomerLookupDto
    {
        public int CustomerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string AccountNumber { get; set; }
        public decimal SumOfTotalDue { get; set; }
    }
}
