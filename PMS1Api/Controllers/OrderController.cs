using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using PMS1Api.Models.ApiModels;
using PMS1Api.Models.EFModels;
using System.Threading.Tasks;

namespace PMS1Api.Controllers
{
    [Route("api/order")]
    public class OrderController : ControllerBase
    {
        private readonly PMSContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger<OrderController> _logger;

        public OrderController(PMSContext context, IMapper mapper, ILogger<OrderController> logger)
        {
            _context = context;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody]OrderCreateRequest model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var order = _mapper.Map<Order>(model);

            await _context.Order.AddAsync(order);
            await _context.SaveChangesAsync();

            return CreatedAtRoute("GetOrderById", new { id = order.OrderId }, order);
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update([FromBody]OrderUpdateRequest model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var existingOrder = await _context.Order.SingleOrDefaultAsync(x=>x.OrderId == model.OrderId);
            if (existingOrder == null)
                return NotFound();

            var order = _mapper.Map<Order>(model);

            _context.Entry(existingOrder).CurrentValues.SetValues(order);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpGet("getall")]
        public async Task<IActionResult> GetAll()
        {
            var list = await _context.Order.ToListAsync();
            return Ok(list);
        }

        [HttpGet("get/{id}", Name = "GetOrderById")]
        public async Task<IActionResult> Get(int id)
        {
            var item = await _context.Order.SingleOrDefaultAsync(x => x.OrderId == id);
            if (item == null)
                return NotFound();

            var order = _mapper.Map<OrderGetResponse>(item);

            return Ok(order);
        }
    }
}