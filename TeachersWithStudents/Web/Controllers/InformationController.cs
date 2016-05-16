using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BL.DTO;
using BL.Facades;
using Web.Models;

namespace Web.Controllers
{
    [Authorize]
    public class InformationController : Controller
    {
        CustomerFacade customerFacade = new CustomerFacade();

        [AllowAnonymous]
        public ActionResult Greet(string name)
        {
            return Content(name);
        }

        public ActionResult Redirect()
        {
            return Redirect("http://google.sk");
            //return RedirectToAction("Greet", "Information", new { name = "AHOJ"});
        }

        public ActionResult Index()
        {
            var model = new InformationModel {Name = "Martin", Surname = "Macak"};
            return View(model);
        }

        [HttpPost]
        public ActionResult Index(FormCollection collection)
        {
            var model = new InformationModel {Name = "Peter", Surname = "Hrivnak"};
            return View(model);
        }

        [Authorize(Roles = "Admin")]
        public ActionResult Customers()
        {
            var model = customerFacade.GetAllCustomers();
            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(CustomerDTO customer)
        {
            customerFacade.CreateCustomer(customer);
            return RedirectToAction("Customers");
        }

        public ActionResult Delete(int id)
        {
            customerFacade.DeleteCustomerViaSql(id);
            return RedirectToAction("Customers");
        }

        public ActionResult Edit(int id)
        {
            var customer = customerFacade.GetCustomerById(id);
            return View(customer);
        }

        [HttpPost]
        public ActionResult Edit(int id, CustomerDTO customer)
        {
            if (ModelState.IsValid)
            {
                var originalCustomer = customerFacade.GetCustomerById(id);
                originalCustomer.Mail = customer.Mail;
                originalCustomer.Name = customer.Name;
                originalCustomer.Password = customer.Password;

                customerFacade.UpdateCustomer(originalCustomer);

                return RedirectToAction("Customers");
            }
            return View(customer);

        }
    }
}