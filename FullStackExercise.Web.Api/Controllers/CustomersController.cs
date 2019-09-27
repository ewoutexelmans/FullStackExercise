using System.Threading.Tasks;
using FullStackExercise.Business.Customers.Queries.GetCustomerByPage;
using FullStackExercise.Web.Api.Infrastructure;
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
        public async Task<ActionResult<CustomersListViewModel>> GetPagedCustomers(int page, int pageSize)
        {
            var validationBag = new ValidationBag();
            if (page < 0)
            {
                validationBag.AddError("Give a valid page number starting with 0");
            }

            if (!(pageSize > 0))
            {
                validationBag.AddError("Page size needs to be larger then 0");
            }

            if (!validationBag.IsValid)
            {
                return BadRequest(validationBag.ErrorMessage);
            }

            var customers = await _mediator.Send(new GetCustomersByPageQuery { Page = page, PageSize = pageSize });
            return Ok(customers);
        }
    }
}
