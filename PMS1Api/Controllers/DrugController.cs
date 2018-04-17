using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using PMS1Api.Models.EFModels;
using System.Threading.Tasks;

namespace PMS1Api.Controllers
{
    [Route("api/drug")]
    [Produces("application/json")]
    public class DrugController : ControllerBase
    {
        private readonly PMSContext _context;
        private readonly ILogger<DrugController> _logger;

        public DrugController(PMSContext context, ILogger<DrugController> logger)
        {
            _context = context;
            _logger = logger;
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody]Drug model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _context.Drug.AddAsync(model);
            await _context.SaveChangesAsync();

            return CreatedAtRoute("GetDrugById", new { id = model.DrugId }, model);
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update([FromBody]Drug model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var existingDrug = await _context.Drug.SingleOrDefaultAsync(x => x.DrugId == model.DrugId);
            if (existingDrug == null)
                return NotFound();

            _context.Entry(existingDrug).CurrentValues.SetValues(model);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpGet("getall")]
        public async Task<IActionResult> GetAll()
        {
            var list = await _context.Drug.ToListAsync();
            return Ok(list);
        }

        [HttpGet("get/{id}", Name = "GetDrugById")]
        public async Task<IActionResult> Get(int id)
        {
            var item = await _context.Drug.FirstOrDefaultAsync(x => x.DrugId == id);
            if (item == null)
                return NotFound();

            return Ok(item);
        }
    }
}
