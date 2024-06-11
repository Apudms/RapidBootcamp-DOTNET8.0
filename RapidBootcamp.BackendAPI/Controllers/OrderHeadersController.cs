using Microsoft.AspNetCore.Mvc;
using RapidBootcamp.BackendAPI.DAL;
using RapidBootcamp.BackendAPI.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RapidBootcamp.BackendAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderHeadersController : ControllerBase
    {
        private readonly IOrderHeader _order;
        private readonly IOrderDetail _orderDetail;

        public OrderHeadersController(IOrderHeader orderHeader, IOrderDetail orderDetail)
        {
            _order = orderHeader;
            _orderDetail = orderDetail;
        }

        // GET: api/<OrderHeadersController>
        [HttpGet]
        public IEnumerable<OrderHeader> Get()
        {
            var orders = _order.GetAll();
            foreach (var order in orders)
            {
                order.OrderDetails = _orderDetail.GetDetailsByHeaderId(order.OrderHeaderId);
            }
            return orders;
        }

        // GET api/<OrderHeadersController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            //var order = _order.GetById(id);
            //return order;

            return "value";
        }

        // POST api/<OrderHeadersController>
        [HttpPost]
        public IActionResult Post([FromBody] OrderHeader orderHeader)
        {   
            try
            {
                string lastOrderHeaderId = _order.GetOrderLastHeaderId();

                lastOrderHeaderId = lastOrderHeaderId.Substring(4, 4);
                int newOrderHeaderId = Convert.ToInt32(lastOrderHeaderId) + 1;
                string newOrderHeaderIdString = "INV-" + newOrderHeaderId.ToString().PadLeft(4, '0');
                orderHeader.OrderHeaderId = newOrderHeaderIdString;
                var result = _order.Add(orderHeader);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<OrderHeadersController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<OrderHeadersController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
