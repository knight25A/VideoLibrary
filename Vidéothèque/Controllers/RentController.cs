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
using System.Data.Entity;
using System.Web.Security;

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



        [System.Web.Http.Authorize(Roles = RoleName.Admin)]
        public ActionResult Index(string sortOrder, string searchString, string searchName)
        {
            List<Rent> rents = new List<Rent> { };

            if (sortOrder != null)
            {
                if (sortOrder == "Title")
                    rents = _context.Rents.Include(r => r.Invoice.Movie).OrderBy(m => m.Invoice.Movie.Title).ToList();

                else if (sortOrder == "Email")
                    rents = _context.Rents.Include(r => r.Invoice.Movie).OrderBy(m => m.Invoice.User.Email).ToList();
                else if (sortOrder == "UserName")
                    rents = _context.Rents.Include(r => r.Invoice.Movie).OrderBy(m => m.Invoice.User.Name).ToList();
                else 
                    rents = _context.Rents.Include(r => r.Invoice.Movie).OrderBy(m => m.ExpectedReturnDate).ToList(); 
            }else
                rents = _context.Rents.Include(r => r.Invoice.Movie).ToList();


            if (!String.IsNullOrEmpty(searchString))
            {
                rents = _context.Rents.Include(r => r.Invoice.Movie).Where(s => s.Invoice.Movie.Title.Contains(searchString) || s.Invoice.User.Email.Contains(searchString) || s.Invoice.User.Name.Contains(searchString)).ToList();
            }
            else if (!String.IsNullOrEmpty(searchName))
            {
                return RedirectToAction("Index", "Home", new { searchName = searchName });

            }

            List<Invoice> invoices = new List<Invoice> { };

            foreach (var rent in rents)
            {
                var invoice = _context.Invoices.SingleOrDefault(i => i.Id == rent.InvoiceId);
                invoices.Add(invoice);
            }

            var genres = _context.Genres.ToList();
            var users = _context.Users.ToList();
            var movies = _context.Movies.ToList();


            var viewModel = new AllRentsViewModel
            {
                Movies = movies,
                Rents = rents,
                Users = users,
                Invoices = invoices
            };

           
            return View("Index", viewModel);
        }

        [System.Web.Http.Authorize(Roles = RoleName.Admin)]
        public ActionResult ChangeStatusReturned(int id)
        {
            var rent = _context.Rents.SingleOrDefault(i => i.Id == id);
            if (rent == null)
            {
                return HttpNotFound();
            }
            rent.Status = "returned";
            _context.SaveChanges();

            return RedirectToAction("Index", "Rent");
        }

        [System.Web.Http.Authorize(Roles = RoleName.Admin)]
        public ActionResult ChangeStatusLoaned(int id)
        {
            var rent = _context.Rents.SingleOrDefault(i => i.Id == id);

            
            if (rent == null)
            {
                return HttpNotFound();
            }

            rent.Status = "loaned";
            var rentInDb = _context.Rents.Single(c => c.Id == rent.Id);
            
            rentInDb.Status = rent.Status;

            try
            {
                _context.SaveChanges();

            }
            catch (DbEntityValidationException e)
            {
                Console.WriteLine(e);
            }

            return RedirectToAction("Index", "Rent");
        }


        public ActionResult Rent(int id, int quantity)
        {
            
            var movie = _context.Movies.SingleOrDefault(m => m.Id == id);
            if (movie == null)
                return HttpNotFound();
            
            var user = _context.Users.SingleOrDefault(u => u.UserName == User.Identity.Name);

            var invoice = new Invoice { MovieId = movie.Id, UserId = user.Id, DateLocation = DateTime.Today, Quantity = quantity, TotalPrice = movie.Price*quantity };
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
            var user = _context.Users.SingleOrDefault(u => u.Id == invoice.UserId);
            var movie = _context.Movies.SingleOrDefault(m => m.Id == invoice.MovieId);

            movie.NumberInStock = movie.NumberInStock - invoice.Quantity;

            var rent = new Rent { InvoiceId = id, IdUser = user.Id, DateLocation = invoice.DateLocation, ExpectedReturnDate = invoice.DateLocation.AddMonths(1), Status = "reserved"};
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
