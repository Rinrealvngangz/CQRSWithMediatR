using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using demoCQRS.Command;
using demoCQRS.Models;
using demoCQRS.Query;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace demoCQRS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IMediator _mediator;
        public OrderController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet("")]
        public  async Task<IActionResult> GetAll()
        {
            var query = new GetAllOrdersQuery();
            var result = _mediator.Send(query);
            return Ok(result);
        }
        
        [HttpGet("{id}")]
        public  async Task<IActionResult> GetById(int id)
        {
            var query = new GetOrderByIdQuery(id); 
            var result = _mediator.Send(query);
            return Ok(result);
        }
        
        [HttpPost]
        public  async Task<IActionResult> Create(OrderRequest orderRequest)
        {
            var command = new CreateOrderCommand(orderRequest);
            var result = _mediator.Send(command);
            return Ok(result);
        }
        
        [HttpDelete("{id}")]
        public  async Task<IActionResult> Create(int id)
        {
            var command = new DeleteOrderCommand(id);
            var result = _mediator.Send(command);
            return Ok(result);
        }
    }
}