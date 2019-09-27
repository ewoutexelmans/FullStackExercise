namespace FullStackExercise.Business.Customers.Queries.GetCustomerByPage
{
    public class CustomerLookupDto
    {
        public string PersonFirstName { get; set; }
        public string PersonLastName { get; set; }
        public string AccountNumber { get; set; }
        public decimal SumOfTotalDue { get; set; }
    }
}
