using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using FullStackExercise.Data.Access;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace FullStackExercise.Business.Customers.Commands.UpdateCustomer
{
    public class UpdateCustomerCommandHandler : AsyncRequestHandler<UpdateCustomerCommand>
    {
        private readonly AdventureWorksContext _ctx;
        private readonly IMapper _mapper;

        public UpdateCustomerCommandHandler(AdventureWorksContext ctx, IMapper mapper)
        {
            _ctx = ctx;
            _mapper = mapper;
        }

        protected override async Task Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
        {
            var customer = await _ctx.Customers.Include(c => c.Person)
                .FirstOrDefaultAsync(c => c.CustomerId == request.CustomerId, cancellationToken);
            if (customer != null)
            {
                _mapper.Map(request, customer);
                await _ctx.SaveChangesAsync(cancellationToken);
            }
        }
    }
}
