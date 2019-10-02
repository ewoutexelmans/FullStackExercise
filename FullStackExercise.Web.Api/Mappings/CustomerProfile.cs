using AutoMapper;
using FullStackExercise.Business.Customers.Queries.GetCustomerByPage;
using FullStackExercise.Web.Api.Models;

namespace FullStackExercise.Web.Api.Mappings
{
    public class CustomerProfile : Profile
    {
        public CustomerProfile()
        {
            CreateMap<GetCustomersRequest, GetCustomersByPageQuery>();
            CreateMap<GetCustomersByPageResponse, GetCustomersResponse>();
        }
    }
}
