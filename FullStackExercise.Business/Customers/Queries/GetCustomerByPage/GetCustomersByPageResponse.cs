using System.Collections.Generic;

namespace FullStackExercise.Business.Customers.Queries.GetCustomerByPage
{
    public class GetCustomersByPageResponse
    {
        public IList<CustomerLookupDto> Customers { get; set; }
        public int PageCount { get; set; }
        public bool Success { get; set; }
        public string Error { get; set; }
    }
}