using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using System.Data.Entity;
using Vidly.ViewsModels;

namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {
        // GET: Customers
        private readonly ApplicationDbContext _context;

        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool Dispose) { _context.Dispose(); }

        public ActionResult New()
        {
            var membershipTypes = _context.MembershipTypes.ToList();
            var formCustomerViewModel = new FormCustomerViewModel
            {
                Customer = new Customer(),
                MembershipTypes = membershipTypes
            };
            return View("CustomerForm", formCustomerViewModel);
        }

        public ActionResult Edit(int id)
        {
            var customer = _context.Customers.SingleOrDefault(m => m.Id == id);
            if (customer == null)
                return HttpNotFound();
            var membershipTypes = _context.MembershipTypes.ToList();
            var formCustomerViewModel = new FormCustomerViewModel
            {
                MembershipTypes = membershipTypes,
                Customer = customer
            };

            return View("CustomerForm", formCustomerViewModel);
        }

        public ActionResult CustomerForm()
        {
            return RedirectToAction("Index", "Customers");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Customer customer)
        {
            if(!ModelState.IsValid)
            {
                var customerFormViewModel = new FormCustomerViewModel()
                {
                    Customer = customer,
                    MembershipTypes = _context.MembershipTypes.ToList(),

                };
                return View("CustomerForm", customerFormViewModel);
            }
            if (customer.Id == 0)
            {
                _context.Customers.Add(customer);
            }
            else
            {
                var customerInDb = _context.Customers.Single(c => c.Id == customer.Id);
                customerInDb.Name = customer.Name;
                customerInDb.MembershipTypeId = customer.MembershipTypeId;
                customerInDb.IsSubscribedToNewslatter = customer.IsSubscribedToNewslatter;
                customerInDb.Birthdate = customer.Birthdate;
            }
            _context.SaveChanges();


            return RedirectToAction("Index", "Customers");
        }

        public ViewResult Index()
        {
            var customers = _context.Customers.Include(c => c.MembershipType).ToList();
            return View(customers);
        }


        public ActionResult Details(int id)
        {
          
            var customer = _context.Customers.Include(c => c.MembershipType).SingleOrDefault(c => c.Id == id);
            if (customer == null)
                return HttpNotFound();
            return View(customer);
        }
    }
}