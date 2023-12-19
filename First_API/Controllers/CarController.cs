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
        public async Task<IActionResult> GetAll()
        {
           List<Car> cars =  await _context.Cars.ToListAsync(); 
            return StatusCode(StatusCodes.Status200OK, cars);
        }

        [HttpGet]

        [Route("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            if(id<=0) return StatusCode(StatusCodes.Status400BadRequest);
            var cars = await _context.Cars.FirstOrDefaultAsync(c => c.Id == id);
            if(id == null) return StatusCode(StatusCodes.Status404NotFound);
            return StatusCode(StatusCodes.Status200OK, cars);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Car car)
        {
            await _context.Cars.AddAsync(car);  
            await _context.SaveChangesAsync();
            return StatusCode(StatusCodes.Status201Created,car);
        }

        [HttpPut]
        public async Task<IActionResult> Update(int id, Car updatedcar)
        {
            if (id <= 0) return StatusCode(StatusCodes.Status400BadRequest);
            var cars = await _context.Cars.FirstOrDefaultAsync(c => c.Id == id);
            if (id == null) return StatusCode(StatusCodes.Status404NotFound);


            cars.ModelYear=updatedcar.ModelYear;
            cars.DailyPrice=updatedcar.DailyPrice;
            cars.Description=updatedcar.Description;

            await _context.SaveChangesAsync();
            return StatusCode(StatusCodes.Status200OK,cars);

        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete(int id)
        {
            var car = _context.Cars.Find(id);
            if(car==null) return StatusCode(StatusCodes.Status404NotFound);
             _context.Cars.Remove(car); 
             _context.SaveChanges();
            return StatusCode(StatusCodes.Status200OK);
        }
    }
}
