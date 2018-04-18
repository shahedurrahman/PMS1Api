using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using PMS1Api.Models.ApiModels;
using PMS1Api.Models.EFModels;
using System.Threading.Tasks;

namespace PMS1Api.Controllers
{
    [Route("api/drug")]
    [Produces("application/json")]
    public class DrugController : ControllerBase
    {
        private readonly PMSContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger<DrugController> _logger;

        public DrugController(PMSContext context, IMapper mapper, ILogger<DrugController> logger)
        {
            _context = context;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody]DrugCreateRequest model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var drug = _mapper.Map<Drug>(model);

            await _context.Drug.AddAsync(drug);
            await _context.SaveChangesAsync();

            return CreatedAtRoute("GetDrugById", new { id = drug.DrugId }, drug);
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update([FromBody]DrugUpdateRequest model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var existingDrug = await _context.Drug.SingleOrDefaultAsync(x => x.DrugId == model.DrugId);
            if (existingDrug == null)
                return NotFound();

            var drug = _mapper.Map<Drug>(model);

            _context.Entry(existingDrug).CurrentValues.SetValues(drug);
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
            var item = await _context.Drug.SingleOrDefaultAsync(x => x.DrugId == id);
            if (item == null)
                return NotFound();

            var drug = _mapper.Map<DrugGetResponse>(item);

            return Ok(drug);
        }
    }
}
