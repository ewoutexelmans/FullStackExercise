using System.Threading.Tasks;
using FullStackExercise.Business.Customers.Queries.GetCustomerByPage;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace FullStackExercise.Web.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomersController : ControllerBase
    {
        private readonly ILogger<CustomersController> _logger;
        private readonly IMediator _mediator;

        public CustomersController(ILogger<CustomersController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<GetCustomersByPageResponse>> GetPagedCustomers(int page, int pageSize)
        {
            var response = await _mediator.Send(new GetCustomersByPageQuery {Page = page, PageSize = pageSize});

            if (response.Success)
            {
                return Ok(new
                {
                    response.Customers,
                    response.PageCount
                });
            }

            return BadRequest(response.Error);
        }
    }
}