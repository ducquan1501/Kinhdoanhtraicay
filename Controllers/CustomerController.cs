using Microsoft.AspNetCore.Mvc;
using Kinhdoanhtraicay.Models;

namespace Kinhdoanhtraicay.Controllers
{
    public class CustomerController : Controller
    {
        private QLTCContext qltcContext = new QLTCContext();
        public IActionResult Index()
        {
            List<Customer> customers = qltcContext.Customers.ToList();
            return View(customers);
        }
    }
}
