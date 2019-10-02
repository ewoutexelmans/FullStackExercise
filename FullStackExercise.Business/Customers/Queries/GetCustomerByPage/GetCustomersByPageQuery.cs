using MediatR;

namespace FullStackExercise.Business.Customers.Queries.GetCustomerByPage
{
    public class GetCustomersByPageQuery : IRequest<GetCustomersByPageResponse>
    {
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
    }
}