using Microsoft.AspNetCore.Mvc;
using ShoesApp.Data;
using ShoesApp.Dtos;
using ShoesApp.Models;

namespace ShoesApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShoesController : ControllerBase
    {
        private readonly ShoesDbContext _context;

        public ShoesController(ShoesDbContext context)
        {
            _context = context;
        }


        [HttpGet]
        public ActionResult<List<ShoeDto>> GetAllShoes()
        {
            try
            {
                var shoesDb = _context.Shoes.ToList();

                if (shoesDb == null || !shoesDb.Any())
                {
                    return NotFound("No shoes found.");
                }

                var shoesDto = shoesDb.Select(x => new ShoeDto
                {
                    Brand = x.Brand,
                    Model = x.Model,
                    Category = x.Category,
                    Color = x.Color,
                    Price = x.Price,
                    Size = x.Size,
                    ImageUrl = x.ImageUrl
                });

                return Ok(shoesDto);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error retrieving data: {ex.Message}");
            }
        }


        [HttpGet("{id}")]
        public ActionResult<ShoeDto> GetShoeById(int id)
        {
            try
            {
                if (id < 0)
                {
                    return BadRequest("The id can not be negative");
                }

                if (id > _context.Shoes.Count())
                {
                    return NotFound($"Shoe with id {id} not found.");
                }

                var shoeDb = _context.Shoes.Find(id);

                if (shoeDb == null)
                {
                    return NotFound($"Shoe with id {id} not found.");
                }

                var shoeDto = new ShoeDto
                {
                    Brand = shoeDb.Brand,
                    Model = shoeDb.Model,
                    Category = shoeDb.Category,
                    Color = shoeDb.Color,
                    Price = shoeDb.Price,
                    Size = shoeDb.Size,
                    ImageUrl = shoeDb.ImageUrl
                };

                return Ok(shoeDto);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error retrieving data: {ex.Message}");
            }

        }


        [HttpPost]
        public IActionResult PostShoe([FromBody] ShoeDto shoeDto)
        {
            try
            {
                if (string.IsNullOrEmpty(shoeDto.Brand))
                    return BadRequest("Please enter brand");

                if (string.IsNullOrEmpty(shoeDto.Model))
                    return BadRequest("Please enter model");

                if (string.IsNullOrEmpty(shoeDto.Category))
                    return BadRequest("Please enter category");

                if (string.IsNullOrEmpty(shoeDto.Color))
                    return BadRequest("Please enter color");

                if (shoeDto.Price <= 0)
                    return BadRequest("Please enter a valid price");

                if (shoeDto.Size <= 0)
                    return BadRequest("Please enter a valid size");

                if (string.IsNullOrEmpty(shoeDto.ImageUrl))
                    return BadRequest("Please provide an image URL");

                var shoe = new Shoe
                {
                    Brand = shoeDto.Brand,
                    Model = shoeDto.Model,
                    Category = shoeDto.Category,
                    Color = shoeDto.Color,
                    Price = shoeDto.Price,
                    Size = shoeDto.Size,
                    ImageUrl = shoeDto.ImageUrl
                };

                _context.Shoes.Add(shoe);
                _context.SaveChanges();

                return StatusCode(201, "New shoe added");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error creating shoe: {ex.Message}");
            }
        }


        [HttpPut]
        public ActionResult UpdateShoe(Shoe shoe)
        {
            try
            {
                var shoeDb = _context.Shoes.FirstOrDefault(x => x.Id == shoe.Id);

                if (shoeDb == null)
                    return NotFound($"Shoe with id {shoe.Id} not found.");

                if (string.IsNullOrEmpty(shoeDb.Brand))
                    return BadRequest("Please enter brand");

                if (string.IsNullOrEmpty(shoeDb.Model))
                    return BadRequest("Please enter model");

                if (string.IsNullOrEmpty(shoeDb.Category))
                    return BadRequest("Please enter category");

                if (string.IsNullOrEmpty(shoeDb.Color))
                    return BadRequest("Please enter color");

                if (shoeDb.Price <= 0)
                    return BadRequest("Please enter a valid price");

                if (shoeDb.Size <= 0)
                    return BadRequest("Please enter a valid size");

                if (string.IsNullOrEmpty(shoeDb.ImageUrl))
                    return BadRequest("Please provide an image URL");

                shoeDb.Brand = shoe.Brand;
                shoeDb.Model = shoe.Model;
                shoeDb.Category = shoe.Category;
                shoeDb.Color = shoe.Color;
                shoeDb.Price = shoe.Price;
                shoeDb.Size = shoe.Size;
                shoeDb.ImageUrl = shoe.ImageUrl;

                _context.SaveChanges();
                return Ok("Shoe updated successfully");
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error creating shoe: {e.Message}");
            }
        }


        [HttpDelete("{id}")]
        public ActionResult DeleteShoe(int id)
        {
            try
            {
                if (id < 0)
                    return BadRequest("The id can not be negative");

                if (id > _context.Shoes.Count())
                    return NotFound($"Shoe with id {id} not found.");

                var shoeDb = _context.Shoes.FirstOrDefault(x => x.Id == id);

                if (shoeDb == null)
                    return NotFound($"Shoe with id {id} not found.");

                _context.Shoes.Remove(shoeDb);
                _context.SaveChanges();

                return Ok($"Shoe with id {id} deleted successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error deleting shoe: {ex.Message}");
            }
        }
    }
}
