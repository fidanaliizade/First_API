using First_API.DAL;
using First_API.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace First_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarController : ControllerBase
    {
        private readonly AppDbContext _context;

        public CarController(AppDbContext context) 
        {
            _context = context;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
           List<Car> cars =  await _context.Cars.ToListAsync(); 
            return StatusCode(StatusCodes.Status200OK, cars);
        }

        [HttpGet]

        [Route("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var cars = await _context.Cars.FirstOrDefaultAsync(c => c.Id == id);
            return StatusCode(StatusCodes.Status200OK, cars);
        }
    }
}
