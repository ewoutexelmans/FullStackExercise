using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using FullStackExercise.Business.Util;
using FullStackExercise.Data.Access;
using FullStackExercise.Data.Model;
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

            if (request.PageIndex < 0)
            {
                request.PageIndex = 0;
            }

            var query = _ctx.Customers.Where(c => c.PersonId != null);

            if (!string.IsNullOrEmpty(request.KeyWord))
            {
                query = BuildFilteredQuery(query, request.Filters, request.KeyWord);
            }

            var rowCount = await query.CountAsync(cancellationToken);
            var pageCount = (int)Math.Ceiling((double)rowCount / request.PageSize);

            if (request.PageIndex >= pageCount)
            {
                request.PageIndex = pageCount > 0 ? pageCount - 1 : 0;
            }

            var projectedQuery = query
                  .Include(c => c.Person)
                  .Include(c => c.SalesOrderHeader)
                  .OrderBy(c => c.CustomerId)
                  .ProjectTo<CustomerLookupDto>(_mapper.ConfigurationProvider);

            if (request.HigherLower != null)
            {
                projectedQuery = request.HigherLower.Value ? projectedQuery.Where(c => c.SumOfTotalDue >= request.SumComparison) : projectedQuery.Where(c => c.SumOfTotalDue <= request.SumComparison);
            }

            var customers = await projectedQuery
                .Paged(request.PageIndex, request.PageSize)
                .ToListAsync(cancellationToken);

            return new GetCustomersByPageResponse
            {
                Customers = customers,
                PageIndex = request.PageIndex,
                PageCount = pageCount
            };
        }

        private static IQueryable<Customer> BuildFilteredQuery(IQueryable<Customer> query,
            IReadOnlyCollection<FilterType> filters, string keyWord)
        {
            var predicate = PredicateBuilder.New<Customer>();
            keyWord = keyWord.ToLower();

            var filterAll = filters == null || filters.Count == 0;

            if (filterAll || filters.Any(type => type == FilterType.FirstName))
            {
                predicate = predicate.Or(c => c.Person.FirstName.ToLower().Contains(keyWord));
            }

            if (filterAll || filters.Any(type => type == FilterType.LastName))
            {
                predicate = predicate.Or(c => c.Person.LastName.ToLower().Contains(keyWord));
            }

            if (filterAll || filters.Any(type => type == FilterType.AccountNumber))
            {
                predicate = predicate.Or(c => c.AccountNumber.ToLower().Contains(keyWord));
            }

            return query.Where(predicate);
        }
    }
}