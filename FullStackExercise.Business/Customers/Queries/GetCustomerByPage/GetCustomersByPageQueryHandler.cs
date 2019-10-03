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
    public class GetCustomersByPageQueryHandler : IRequestHandler<GetCustomersByPageQuery, GetCustomersByPageResponse>
    {
        private readonly AdventureWorksContext _ctx;
        private readonly IMapper _mapper;

        public GetCustomersByPageQueryHandler(AdventureWorksContext ctx, IMapper mapper)
        {
            _ctx = ctx;
            _mapper = mapper;
        }

        public async Task<GetCustomersByPageResponse> Handle(GetCustomersByPageQuery request,
            CancellationToken cancellationToken)
        {
            if (request.PageSize < 1)
            {
                request.PageSize = 1;
            }

            var query = _ctx.Customers
                .Where(c => c.PersonId != null);

            var rowCount = await query.CountAsync(cancellationToken);
            var pageCount = (int)Math.Ceiling((double)rowCount / request.PageSize);

            if (request.PageIndex >= pageCount)
            {
                request.PageIndex = pageCount - 1;
            }

            var customers = await query.Include(c => c.Person)
                .Include(c => c.SalesOrderHeader)
                .Paged(request.PageIndex, request.PageSize)
                .ProjectTo<CustomerLookupDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return new GetCustomersByPageResponse
            {
                Customers = customers,
                PageCount = pageCount
            };
        }
    }
}