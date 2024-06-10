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

        #region Get All
        // GET: api/<ProductsController>
        [HttpGet]
        public IEnumerable<Product> Get()
        {
            var products = _product.GetAll();
            return products;
        }
        #endregion

        #region Get By ID
        // GET api/<ProductsController>/5
        [HttpGet("{id}")]
        public Product Get(int id)
        {
            var product = _product.GetById(id);
            return product;
        }
        #endregion

        #region Get By Name
        // GET api/<ProductsController>/5
        [HttpGet("ByName")]
        public IEnumerable<Product> GetByName(string name)
        {
            var product = _product.GetByProductName(name);
            return product;
        }
        #endregion

        #region Get By Category ID
        // GET api/<ProductsController>/5
        [HttpGet("ByCategory/{id}")]
        public IEnumerable<Product> GetByCategoryId(int categoryId)
        {
            var product = _product.GetByCategoryId(categoryId);
            return product;
        }
        #endregion

        #region Get By Category Name
        // GET api/<ProductsController>/5
        [HttpGet("ByCategoryName")]
        public IEnumerable<Product> GetByCategoryName(string categoryName)
        {
            var product = _product.GetByCategoryName(categoryName);
            return product;
        }
        #endregion

        #region Get By Product with Category
        // GET api/<ProductsController>/5
        [HttpGet("WithCategory")]
        public IEnumerable<Product> GetProductWithCategory()
        {
            var product = _product.GetProductsWithCategory();
            return product;
        }
        #endregion

        #region Post (Add New Product)
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
        #endregion

        #region Put (Update Product)
        // PUT api/<ProductsController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Product product)
        {
            var updateProd = _product.GetById(id);
            if (updateProd == null)
            {
                return NotFound();                            
            }
            try 
            {
                updateProd.ProductName = product.ProductName;
                updateProd.CategoryId = product.CategoryId;
                updateProd.Stock = product.Stock;
                updateProd.Price = product.Price;
                var result = _product.Update(updateProd);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        #endregion

        #region Delete Product
        // DELETE api/<ProductsController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var deleteProd = _product.GetById(id);
            if ( deleteProd == null )
            {
                return NotFound();
            }
            try
            {
                _product.Delete(id);
                return Ok($"Product {id} berhasil dihapus!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        #endregion
    }
}
