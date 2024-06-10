using Microsoft.AspNetCore.Mvc;
using RapidBootcamp.BackendAPI.DAL;
using RapidBootcamp.BackendAPI.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RapidBootcamp.BackendAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategory _category;

        public CategoriesController(ICategory category)
        {
            _category = category;
        }

        // GET: api/<CategoriesController>
        [HttpGet]
        public IEnumerable<Category> Get()
        {
            //List<Category> categories = new List<Category>()
            //{
            //    new Category { CategoryId = 1, CategoryName = "Laptop Gaming" },
            //    new Category { CategoryId = 2, CategoryName = "Laptop Office" },
            //};
            //return categories;

            var categories = _category.GetAll();
            return categories;
        }

        // GET api/<CategoriesController>/5
        [HttpGet("{id}")]
        public Category Get(int id)
        {
            var category = _category.GetById(id);
            return category;
        }

        // GET api/<CategoriesController>/5
        //[HttpGet("ByName/{name}")]
        [HttpGet("ByName")]
        public IEnumerable<Category> GetByName(string name)
        {
            var categories = _category.GetByCategoryName(name);
            return categories;
        }

        // POST api/<CategoriesController>
        [HttpPost]
        public IActionResult Post(Category category)
        {
            try
            {
                var result = _category.Add(category);
                return CreatedAtAction(nameof(Get),
                    new { id = category.CategoryId },
                    category);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<CategoriesController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, Category category)
        {
            var updateCateg = _category.GetById(id);
            try
            {
                if (updateCateg != null)
                {
                    updateCateg.CategoryName = category.CategoryName;
                    var result = _category.Update(updateCateg);
                    return Ok(result);
                }
                return BadRequest($"Category {category.CategoryName} not found");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE api/<CategoriesController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var deleteCateg = _category.GetById(id);
                if (deleteCateg != null)
                {
                    _category.Delete(deleteCateg.CategoryId);
                    return Ok($"Data Category ID {id} berhasil di hapus!");
                }
                return BadRequest($"Data Category ID {id} tidak ditemukan!");
            }
            catch (Exception ex)
            {
                return BadRequest($"Could not delete {ex.Message}");
            }
        }
    }
}
