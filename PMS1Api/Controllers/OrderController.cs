using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PMS1Api.Models.EFModels;
using System.Threading.Tasks;

namespace PMS1Api.Controllers
{
    [Route("api/order")]
    public class OrderController : ControllerBase
    {
        private readonly PMSContext _context;

        public OrderController(PMSContext context)
        {
            _context = context;
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody]Order model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _context.Order.AddAsync(model);
            await _context.SaveChangesAsync();

            return CreatedAtRoute("GetOrderById", new { id = model.OrderId }, model);
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update([FromBody]Order model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var existingOrder = await _context.Order.SingleOrDefaultAsync(x=>x.OrderId == model.OrderId);
            if (existingOrder == null)
                return NotFound();

            _context.Entry(existingOrder).CurrentValues.SetValues(model);
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

            return Ok(item);
        }
    }
}