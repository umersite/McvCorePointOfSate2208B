using Microsoft.AspNetCore.Mvc;
using MvsPointOfSale.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.CodeAnalysis.CSharp;


namespace MvsPointOfSale.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ProjectContext context;


        public CustomerController(ProjectContext context) {
            this.context = context;
        }
        public IActionResult Index()
        {


            //var dataset = context.Customers.Include(x => x.Orders).ToList();

            //return View(dataset);

            return View(context.Customers.Include(x=>x.Orders).ToList());
        }
        [HttpPost]
        public JsonResult SaveOrder(String Name, String Address, Order[] Orders) {
            String result = "Error! Order is not Complete";
            if (Name!=null && Address != null && Orders!=null)
            {
                var customerId = Guid.NewGuid();
                Customer obj = new Customer()
                {
                    CustomerId = customerId,
                    Name = Name,
                    Address = Address,
                    OrderDate = DateTime.Now
                };
                context.Customers.Add(obj);
                foreach (var item in Orders)
                {
                    var orderid = Guid.NewGuid();
                    Order order = new Order() { 
                        OrderID = orderid,
                        ProductName = item.ProductName,
                        Quantity = item.Quantity,
                        Price = item.Price,
                        Amount = item.Amount,
                        CustomerId = customerId
                    };
                    context.Orders.Add(order);
                }
                context.SaveChanges();
                result = "Success! Order is completed";

            }

            return Json(result);
        
        }

    }
}
