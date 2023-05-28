using Kinhdoanhtraicay.Models;
using Microsoft.AspNetCore.Mvc;

namespace Kinhdoanhtraicay.Controllers
{
    public class OrdersController : Controller
    {
        private QLTCContext qLTCContext = new QLTCContext();
        public IActionResult Index()
        {
            List<Order> orders= qLTCContext.Orders.ToList();
            return View(orders);
        }
    }
}
