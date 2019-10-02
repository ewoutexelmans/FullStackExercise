using System.Collections.Generic;
using FullStackExercise.Business.Customers.Queries.GetCustomerByPage;

namespace FullStackExercise.Web.Api.Models
{
    public class GetCustomersResponse
    {
        public IList<CustomerLookupDto> Customers { get; set; }
        public int PageCount { get; set; }
    }
}