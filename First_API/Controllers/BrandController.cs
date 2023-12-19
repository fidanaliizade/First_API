using First_API.DAL;
using First_API.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace First_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandController : ControllerBase
    {
        private readonly AppDbContext _context;

        public BrandController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            List<Brand> brands = await _context.Brands.ToListAsync();
            return StatusCode(StatusCodes.Status200OK,brands);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            if(id<=0) return StatusCode(StatusCodes.Status400BadRequest);
            var brands = await _context.Brands.FirstOrDefaultAsync(b=>b.Id==id);
            if (id == null) return StatusCode(StatusCodes.Status404NotFound);
            return StatusCode(StatusCodes.Status200OK, brands);
        }
    }
}
