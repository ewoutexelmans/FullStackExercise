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
                        src => src.SalesOrderHeader.Sum(s => s.TotalDue)))
                .ForMember(c => c.FirstName,
                    opt => opt.MapFrom(
                        src => src.Person.FirstName))
                .ForMember(c => c.LastName,
                    opt => opt.MapFrom(
                        src => src.Person.LastName));
            CreateMap<UpdateCustomerCommand, Customer>()
                .ForPath(c => c.Person.FirstName,
                    opt => opt.MapFrom(
                        src => src.FirstName))
                .ForPath(c => c.Person.LastName,
                    opt => opt.MapFrom(
                        src => src.LastName));
        }
    }
}
