using MediatR;

namespace FullStackExercise.Business.Customers.Queries.GetCustomerByPage
{
    public class GetCustomersByPageQuery : IRequest<GetCustomersByPageResponse>
    {
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public string KeyWord { get; set; }
        public FilterType[] Filters { get; set; }
    }
}