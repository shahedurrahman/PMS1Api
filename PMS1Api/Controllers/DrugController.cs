using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace PMS1Api.Controllers
{
    [Route("api/drug")]
    public class DrugController : ControllerBase
    {
        private readonly PMSContext _context;

        public DrugController(PMSContext context)
        {
            _context = context;
        }

        [HttpGet("getall")]
        public async Task<IActionResult> GetAll()
        {
            var list = await _context.Drug.ToListAsync();
            return Ok(list);
        }
    }
}
