using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using FullStackExercise.Business.Util;
using FullStackExercise.Data.Access;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace FullStackExercise.Business.Customers.Queries.GetCustomerByPage
{
    public class GetCustomersByPageQueryHandler : IRequestHandler<GetCustomersByPageQuery, CustomersListViewModel>
    {
        private readonly AdventureWorksContext _ctx;
        private readonly IMapper _mapper;

        public GetCustomersByPageQueryHandler(AdventureWorksContext ctx, IMapper mapper)
        {
            _ctx = ctx;
            _mapper = mapper;
        }

        public async Task<CustomersListViewModel> Handle(GetCustomersByPageQuery request, CancellationToken cancellationToken)
        {
            var query = _ctx.Customers
                .Include(c => c.Person)
                .Where(c => c.Person != null)
                .Include(c => c.SalesOrderHeader);

            var rowCount = query.Count();
            var pageCount = (int)Math.Ceiling((double)rowCount / request.PageSize);

            var customers = await query
                .Paged(request.Page, request.PageSize)
                .ProjectTo<CustomerLookupDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            var vm = new CustomersListViewModel
            {
                Customers = customers,
                PageCount = pageCount,
            };

            return vm;
        }
    }
}
