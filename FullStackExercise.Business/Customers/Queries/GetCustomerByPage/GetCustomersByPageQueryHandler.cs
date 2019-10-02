using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using FullStackExercise.Business.Infrastructure;
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

        public async Task<GetCustomersByPageResponse> Handle(GetCustomersByPageQuery request, CancellationToken cancellationToken)
        {
            var validationBag = new ValidationBag();

            if (request.PageIndex < 0)
            {
                validationBag.AddError("Give a valid page number starting with 0");
            }

            if (!(request.PageSize > 0))
            {
                validationBag.AddError("Page size needs to be larger than 0");
            }

            if (!validationBag.IsValid)
            {
                return new GetCustomersByPageResponse
                {
                    Error = validationBag.ErrorMessage
                };
            }

            var query = _ctx.Customers
                .Include(c => c.Person)
                .Where(c => c.Person != null)
                .Include(c => c.SalesOrderHeader);

            var rowCount = await query.CountAsync(cancellationToken);
            var pageCount = (int)Math.Ceiling((double)rowCount / request.PageSize);

            if (request.PageIndex >= pageCount)
            {
                validationBag.AddError($"Page number can't be higher than {pageCount - 1}");
            }

            if (!validationBag.IsValid)
            {
                return new GetCustomersByPageResponse
                {
                    Error = validationBag.ErrorMessage
                };
            }

            var customers = await query
                .Paged(request.PageIndex, request.PageSize)
                .ProjectTo<CustomerLookupDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return new GetCustomersByPageResponse
            {
                Customers = customers,
                PageCount = pageCount,
                Success = customers != null,
                Error = customers != null ? "" : "An unknown error has occured."
            };
        }
    }
}
