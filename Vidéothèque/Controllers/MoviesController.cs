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


        [AllowAnonymous]
        public ActionResult Details(int id, string searchName)
        {
            var movie = _context.Movies.Include(m => m.MovieGenre).SingleOrDefault(m => m.Id == id);


            var rents = _context.Rents.Include(u=>u.Invoice.User).Where(m => m.Invoice.MovieId == movie.Id).ToList();

            var viewModel = new MovieRentsViewModel()
            {
                Movie = movie,
                Rents = rents
            };

            if (searchName != null)
                return RedirectToAction("Index", "Home", new { searchName = searchName });
            return View(viewModel);
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
        public ActionResult Save(Movie movie, IEnumerable<HttpPostedFileBase> file)
        {

            if (movie.Id == 0) //the customer does not exist on the DB which means it's a new Customer
            {

               /* if (file != null && file.ContentLength > 0)
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
               */
                if (file.ElementAt(0) != null && file.ElementAt(1)!=null && file.ElementAt(0).ContentLength > 0 && file.ElementAt(1).ContentLength > 0)
                {

                    //Use Namespace called :  System.IO  
                    string FileName1 = Path.GetFileNameWithoutExtension(file.ElementAt(0).FileName);
                    string FileName2 = Path.GetFileNameWithoutExtension(file.ElementAt(1).FileName);

                    //To Get File Extension  
                    string FileExtension1 = Path.GetExtension(file.ElementAt(0).FileName);
                    string FileExtension2 = Path.GetExtension(file.ElementAt(1).FileName);


                    //Add Current Date To Attached File Name  
                    FileName1 = DateTime.Now.ToString("yyyyMMdd") + "-" + FileName1.Trim() + FileExtension1;
                    FileName2 = DateTime.Now.ToString("yyyyMMdd") + "-" + FileName2.Trim() + FileExtension2;

                    //Get Upload path from Web.Config file AppSettings.  
                    //string UploadPath = ConfigurationManager.AppSettings["ImagePath"].ToString();
                    string path1 = Path.Combine(Server.MapPath("~/Images"), FileName1);
                    string path2 = Path.Combine(Server.MapPath("~/Images"), FileName2);

                    //Its Create complete path to store in server.  
                    movie.ImagePath = FileName1;
                    movie.ImagePoster = FileName2;

                    //To copy and save file into server.  
                    file.ElementAt(0).SaveAs(path1);
                    file.ElementAt(1).SaveAs(path2);

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
                movieInDb.Synopsis = movie.Synopsis;
                movieInDb.Actors = movie.Actors;
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
