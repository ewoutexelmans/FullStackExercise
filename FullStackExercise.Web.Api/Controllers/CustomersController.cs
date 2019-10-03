using System.Threading.Tasks;
using AutoMapper;
using FullStackExercise.Business.Customers.Queries.GetCustomerByPage;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FullStackExercise.Web.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomersController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public CustomersController(IMapper mapper, IMediator mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<GetCustomersByPageResponse>> GetPagedCustomers([FromQuery] GetCustomersByPageQuery request)
        {
            return Ok(await _mediator.Send(request));
        }
    }
}