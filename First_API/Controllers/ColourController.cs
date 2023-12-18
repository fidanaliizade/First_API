using First_API.DAL;
using First_API.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace First_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ColourController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ColourController (AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            List<Colour> colours = await _context.Colors.ToListAsync();
            return StatusCode(StatusCodes.Status200OK, colours);
        }

        [HttpGet]

        [Route("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var colours = await _context.Colors.FirstOrDefaultAsync(c => c.Id == id);
            return StatusCode(StatusCodes.Status200OK, colours);
        }
    }
}
