using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidéothèque.Models;
using Vidéothèque.ViewModels;
using System.Data.Entity;

namespace Vidéothèque.Controllers
{
    [Authorize(Roles = RoleName.Admin)]

    public class CustomersController : Controller
    {
        // GET: Customers
        /*
            public List<Customer> customers = new List<Customer>
            {
                new Customer { Id = 0, Name = "John", Surname = "Smith" },
                new Customer { Id = 1, Name = "John", Surname = "Snow" },
                new Customer { Id = 2, Name = "John", Surname = "Travolta"}
            };
        */

        private ApplicationDbContext _context;

        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
       
        public ActionResult Index()
        {

            //var customers = _context.Customers.Include(c => c.Membership).ToList();

            //return View(customers);
            return View();
        }

        public ActionResult Details(int id)
        {
            var customer = _context.Customers.SingleOrDefault(cust => cust.Id == id);

            return View(customer);
        }

        public ActionResult Edit(int id)
        {
            var customer = _context.Customers.SingleOrDefault(cust => cust.Id == id);

            if (customer == null)
                return HttpNotFound();

            var viewModel = new CustomerFormViewModel
            {
                Customer = customer,
                MembershipTypes = _context.MembershipTypes.ToList()
            };

            return View("CustomerForm", viewModel);
        }


        public ActionResult CustomerForm()
        {

            var membershipTypes = _context.MembershipTypes.ToList();

            var viewModel = new CustomerFormViewModel
            {
                Customer = new Customer(),
                MembershipTypes = membershipTypes
            };
            return View("CustomerForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Customer customer)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new CustomerFormViewModel
                {
                    Customer = customer,
                    MembershipTypes = _context.MembershipTypes.ToList()
                };

                return View("CustomerForm", viewModel);
            }
            
            if (customer.Id == 0) //the customer does not exist on the DB which means it's a new Customer
                _context.Customers.Add(customer);
            else
            {
                var customerInDb = _context.Customers.Single(c => c.Id == customer.Id);

                //AutoMapper
                // Mapper.Map(customer, customerInDb);
                customerInDb.Name = customer.Name;
                customerInDb.Surname = customer.Surname;
                customerInDb.isSubscribedToNewletter = customer.isSubscribedToNewletter;
                customerInDb.MembershipTypeId = customer.MembershipTypeId;
            }

            _context.SaveChanges();
            
            return RedirectToAction("Index", "Customers");
        }


    }
}