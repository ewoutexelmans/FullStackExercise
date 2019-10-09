using System.Linq;
using AutoMapper;
using FullStackExercise.Business.Customers.Commands.UpdateCustomer;
using FullStackExercise.Business.Customers.Queries.GetCustomerByPage;
using FullStackExercise.Data.Model;

namespace FullStackExercise.Business.Mappings
{
    public class CustomerProfile : Profile
    {
        public CustomerProfile()
        {
            CreateMap<Customer, CustomerLookupDto>()
                .ForMember(c => c.SumOfTotalDue,
                    opt => opt.MapFrom(
                        src => src.SalesOrderHeader.Sum(s => s.TotalDue)));
            CreateMap<UpdateCustomerCommand, Customer>();
        }
    }
}