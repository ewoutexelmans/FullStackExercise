using System.Collections.Generic;

namespace FullStackExercise.Business.Customers.Queries.GetCustomerByPage
{
    public class GetCustomersByPageResponse
    {
        public IList<CustomerLookupDto> Customers { get; set; }
        public int PageCount { get; set; }
    }
}