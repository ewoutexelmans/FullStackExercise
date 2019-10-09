using MediatR;

namespace FullStackExercise.Business.Customers.Commands.UpdateCustomer
{
    public class UpdateCustomerCommand : IRequest
    {
        public int CustomerId { get; set; }
        public string PersonFirstName { get; set; }
        public string PersonLastName { get; set; }
        public string AccountNumber { get; set; }
    }
}
