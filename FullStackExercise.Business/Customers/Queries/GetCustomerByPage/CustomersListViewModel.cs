using System.Collections.Generic;

namespace FullStackExercise.Business.Customers.Queries.GetCustomerByPage
{
    public class CustomersListViewModel
    {
        public IList<CustomerLookupDto> Customers { get; set; }
        public int PageCount { get; set; }
    }
}
