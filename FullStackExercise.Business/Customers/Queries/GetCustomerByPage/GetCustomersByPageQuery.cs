using MediatR;

namespace FullStackExercise.Business.Customers.Queries.GetCustomerByPage
{
    public class GetCustomersByPageQuery : IRequest<CustomersListViewModel>
    {
        public int Page { get; set; }
        public int PageSize { get; set; }
    }
}
