using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;
using Vidéothèque.Models;
using Vidéothèque.ViewModels;

namespace Vidéothèque.Controllers
{
    [System.Web.Http.Authorize]

    public class RentController : Controller
    {
        private ApplicationDbContext _context;

        public RentController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ActionResult Rent(int id, int quantity)
        {
            
            var movie = _context.Movies.SingleOrDefault(m => m.Id == id);
            if (movie == null)
                return HttpNotFound();
            
            var user = _context.Users.SingleOrDefault(u => u.UserName == User.Identity.Name);

            var invoice = new Invoice { IdFilm = movie.Id, IdUser = user.Id, DateLocation = DateTime.Today, Quantity = quantity, TotalPrice = movie.Price*quantity };
            _context.Invoices.Add(invoice);
            try
            {
                _context.SaveChanges();

            }
            catch (DbEntityValidationException e)
            {
                Console.WriteLine(e);
            }

            var viewModel = new InvoiceViewModel
            {
                Movie = movie,
                Invoice = invoice,
                User = user
            };

            return View("Invoices", viewModel);
        }

        public ActionResult CancelRent(int id)
        {
            var invoice = _context.Invoices.SingleOrDefault(i => i.Id == id);
            if (invoice == null)
            {
                return HttpNotFound();
            }
            _context.Invoices.Remove(invoice);
            _context.SaveChanges();

            return RedirectToAction("Index", "Home");
        }
        public ActionResult SaveRent(int id)
        {
            var invoice = _context.Invoices.SingleOrDefault(i => i.Id == id);
            if (invoice == null)
            {
                return HttpNotFound();
            }
            var user = _context.Users.SingleOrDefault(u => u.Id == invoice.IdUser);
            var movie = _context.Movies.SingleOrDefault(m => m.Id == invoice.IdFilm);

            movie.NumberInStock = movie.NumberInStock - invoice.Quantity;

            var rent = new Rent { IdInvoice = id, IdUser = user.Id, DateLocation = invoice.DateLocation, ExpectedReturnDate = invoice.DateLocation.AddMonths(1), Status = "reserved"};
            _context.Rents.Add(rent);

            if(user.Rents == null)
            {
                user.Rents = new List<Rent> { rent };
            }
            else
            {
                user.Rents.Add(rent);
            }
            
            try
            {
                _context.SaveChanges();

            }
            catch (DbEntityValidationException e)
            {
                Console.WriteLine(e);
            }

            return RedirectToAction("Index", "Home");
        }
    }
}
