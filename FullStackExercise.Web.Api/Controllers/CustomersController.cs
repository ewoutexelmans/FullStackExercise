using System.Threading.Tasks;
using AutoMapper;
using FullStackExercise.Business.Customers.Queries.GetCustomerByPage;
using FullStackExercise.Web.Api.Models;
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