using Microsoft.AspNetCore.Mvc;
using RapidBootcamp.BackendAPI.DAL;
using RapidBootcamp.BackendAPI.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RapidBootcamp.BackendAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProduct _product;

        public ProductsController(IProduct product)
        {
            _product = product;
        }

        // GET: api/<ProductsController>
        [HttpGet]
        public IEnumerable<Product> Get()
        {
            var products = _product.GetAll();
            return products;
        }

        // GET api/<ProductsController>/5
        [HttpGet("{id}")]
        public Product Get(int id)
        {
            var product = _product.GetById(id);
            return product;
        }

        // GET api/<ProductsController>/5
        [HttpGet("ByName")]
        public IEnumerable<Product> GetByName(string name)
        {
            var product = _product.GetByProductName(name);
            return product;
        }

        // GET api/<ProductsController>/5
        [HttpGet("WithCategory")]
        public IEnumerable<Product> GetProductWithCategory()
        {
            var product = _product.GetProductsWithCategory();
            return product;
        }

        // POST api/<ProductsController>
        [HttpPost]
        public ActionResult Post(Product product)
        {
            try
            {
                var result = _product.Add(product);
                return CreatedAtAction(nameof(Get), new { id = result.ProductId }, result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<ProductsController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Product product)
        {
            var updateProd = _product.GetById(id);
            if (updateProd != null)
            {
                updateProd.ProductName = product.ProductName;
                updateProd.CategoryId = product.CategoryId;
                updateProd.Stock = product.Stock;
                updateProd.Price = product.Price;
                var result Ok(result);
                return Ok(result);
            }
            else 
            {
                return NotFound();                            
            }
            
        }

        // DELETE api/<ProductsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
