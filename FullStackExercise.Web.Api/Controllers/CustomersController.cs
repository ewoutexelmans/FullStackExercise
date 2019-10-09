using System.Threading.Tasks;
using FullStackExercise.Business.Customers.Commands.UpdateCustomer;
using FullStackExercise.Business.Customers.Queries.GetCustomerByPage;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace FullStackExercise.Web.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CustomersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<GetCustomersByPageResponse>> GetPagedCustomers(
            [FromQuery] GetCustomersByPageQuery request) =>
            Ok(await _mediator.Send(request));

        [HttpPost]
        [SwaggerResponse(204, "Customer updated.")]
        public async Task<ActionResult> UpdateCustomer([FromBody] UpdateCustomerCommand request)
        {
            await _mediator.Send(request);
            return NoContent();
        }
    }
}
