using System.Threading.Tasks;
using AutoMapper;
using FullStackExercise.Business.Customers.Queries.GetCustomerByPage;
using FullStackExercise.Web.Api.Models;
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
        private readonly IMapper _mapper;

        public CustomersController(ILogger<CustomersController> logger, IMediator mediator, IMapper mapper)
        {
            _logger = logger;
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<GetCustomersResponse>> GetPagedCustomers([FromQuery] GetCustomersRequest request)
        {
            var response = await _mediator.Send(
                _mapper.Map<GetCustomersByPageQuery>(request));

            if (response.Success)
            {
                return Ok(_mapper.Map<GetCustomersResponse>(response));
            }

            return BadRequest(response.Error);
        }
    }
}