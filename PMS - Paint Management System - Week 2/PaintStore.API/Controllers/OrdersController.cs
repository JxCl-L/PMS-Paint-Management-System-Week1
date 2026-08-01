using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PaintStore.Models.Models;


namespace PaintStore.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {

        // mock db data
        private List<Order> Orders;
        
        public OrdersController()
        {
            Orders = new List<Order>();
        }

        [HttpGet("GetAllOrders")]
        public IActionResult GetAllOrders() // without pagination
        {
            return Ok(Orders);
        }

        [HttpGet("GetPaginatedOrders")]
        public IActionResult GetPaginatedOrders([FromQuery] int pageNumber, [FromQuery] int pageSize) // with pagination
        {
            // issue: need to validate pageNumber and pageSize
            if(pageNumber < 1) pageNumber = 1;
            if(pageSize < 1) pageSize = 10;

            List<Order> paginated = Orders.OrderBy(p => p.Id).Skip((pageNumber-1)*pageSize).Take(pageSize).ToList();
            return Ok(paginated);
        }

        [HttpGet("GetOrdersByPriceRange")]
        public IActionResult GetOrdersByPriceRange(int minPrice, int maxPrice)
        {
            List<Order> orders = Orders.Where(p => p.TotalPrice >= minPrice && p.TotalPrice <= maxPrice).ToList();
            return Ok(orders);
        }

        [HttpGet("GetOrdersByPaintId/{paintId}")]
        public IActionResult GetOrdersByPaintId(int paintId)
        {
            // issue: variable shadowing. Outer and inner lambda both use p
            // return Ok(Orders.Where(p => p.PaintProducts.Any(p => p.Id == paintId)).ToList());

            return Ok(Orders.Where(p => p.PaintProducts.Any(o => o.Id == paintId)).ToList());
        }

        [HttpGet("GetOrdersByUserId/{userId}")]
        public IActionResult GetOrdersByUserId(int userId)
        {
            return Ok(Orders.Where(p => p.UserId == userId).ToList());
        }

        [HttpGet("GetLastMonthOrders")]
        public IActionResult GetLastMonthOrders()
        {
            // issue 1 - semantincs: last month means not last month of previous order, but mean prvious calendar month
            // issue 2 - crash on empty list: order[0] throw error when order is empty list

            // List<Order> orders = Orders.OrderByDescending(p => p.CreatedDate).ToList();

            // int month = orders[0].CreatedDate.Month;
            // int year = orders[0].CreatedDate.Year;

            // return Ok(orders.Where(p => p.CreatedDate.Year == year && p.CreatedDate.Month == month).ToList());

            // solution: get first day of last month and this month, take orders in between
            // detail: include first day last month, exlcude first day this month
            DateTime now = DateTime.Now;
            DateTime FirstDayThisMonth = new DateTime(now.Year, now.Month, 1);
            DateTime FirstDayLastMonth = FirstDayThisMonth.AddMonths(-1); // calculate last month 1st day by -1 month on this month 1st day, not now.Month-1
            return Ok(Orders.Where(p => p.CreatedDate >= FirstDayLastMonth && p.CreatedDate < FirstDayThisMonth).ToList());





        }

        [HttpGet("GetOrdersByDate/{dateOnly}")]
        public IActionResult GetOrdersByDate(DateOnly dateOnly)
        {
            // return Ok(Orders.Where(p => (DateOnly)p.CreatedDate == dateOnly).ToList()); // nvalid cast: (DateOnly)p.CreatedDate
            return Ok(Orders.Where(p => DateOnly.FromDateTime(p.CreatedDate) == dateOnly).ToList());
        }
    }
}
