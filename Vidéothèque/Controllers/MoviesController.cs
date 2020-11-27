using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Vidéothèque.Models;
using Vidéothèque.ViewModels;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.IO;
using System.Configuration;
using System.Web;

namespace Vidéothèque.Controllers
{
    public class MoviesController : Controller
    {
        // GET: Movies

        private ApplicationDbContext _context;

        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }



        [Authorize(Roles = RoleName.Admin)]
        public ActionResult Index()
        {

            //var movies = _context.Movies.Include(m => m.MovieGenre).ToList();
            //return View(movies);
            return View();

        }


        [HttpPost]
        [Authorize(Roles = RoleName.Admin)]
        public ActionResult Index(string searchName)
        {

            return RedirectToAction("Index", "Home", new { searchName = searchName });

        }


        [Route("movies/released/{year:regex(\\d{4})}/{month:regex(\\d{2}):range(1,12)}")]
        public ActionResult ByReleaseDate(int year, int month)
        {
            return Content(year + "/" + month);
        }

        public ActionResult Details(int id)
        {
            var customer = _context.Movies.Include(m => m.MovieGenre).SingleOrDefault(cust => cust.Id == id);

            return View(customer);
        }

        [HttpPost]
        [AllowAnonymous]

        public ActionResult Details(string searchName)
        {
            return RedirectToAction("Index", "Home", new { searchName = searchName });

        }

        [Authorize(Roles = RoleName.Admin)]
        public ActionResult Edit(int id)
        {
            var movie = _context.Movies.Include(m => m.MovieGenre).SingleOrDefault(m => m.Id == id);

            if (movie == null)
                return HttpNotFound();

            var viewModel = new MovieFormViewModel
            {
                Movie = movie,
                Genres = _context.Genres.ToList()
            };

            return View("MovieForm", viewModel);
        }

        [Authorize(Roles = RoleName.Admin)]
        public ActionResult MovieForm()
        {

            var genres = _context.Genres.ToList();

            var viewModel = new MovieFormViewModel
            {
                Genres = genres
            };
            return View("MovieForm", viewModel);
        }

        [HttpPost]
        [Authorize(Roles = RoleName.Admin)]
        public ActionResult Save(Movie movie, HttpPostedFileBase file)
        {

            if (movie.Id == 0) //the customer does not exist on the DB which means it's a new Customer
            {

                if (file != null && file.ContentLength > 0)
                {
                    //Use Namespace called :  System.IO  
                    string FileName = Path.GetFileNameWithoutExtension(file.FileName);

                    //To Get File Extension  
                    string FileExtension = Path.GetExtension(file.FileName);

                    //Add Current Date To Attached File Name  
                    FileName = DateTime.Now.ToString("yyyyMMdd") + "-" + FileName.Trim() + FileExtension;

                    //Get Upload path from Web.Config file AppSettings.  
                    //string UploadPath = ConfigurationManager.AppSettings["ImagePath"].ToString();
                    string path = Path.Combine(Server.MapPath("~/Images"), FileName);

                    //Its Create complete path to store in server.  
                    movie.ImagePath = FileName;

                    //To copy and save file into server.  
                    file.SaveAs(path);
                }
                movie.DateAdded = DateTime.Now;
                _context.Movies.Add(movie);
            }
            else
            {
                var movieInDb = _context.Movies.Include(m => m.MovieGenre).Single(c => c.Id == movie.Id);

                //AutoMapper
                // Mapper.Map(customer, customerInDb);
                movieInDb.Title = movie.Title;
                movieInDb.NumberInStock = (int)movie.NumberInStock;
                movieInDb.Price = (int)movie.Price;
                movieInDb.ReleaseDate = movie.ReleaseDate;
                movieInDb.DateAdded = movie.DateAdded;
                movieInDb.GenreId = movie.GenreId;
            }

            try
            {
                _context.SaveChanges();

            }
            catch (DbEntityValidationException e)
            {
                Console.WriteLine(e);
            }
            return RedirectToAction("Index", "Movies");
        }


    }
}
