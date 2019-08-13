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
    public class MoviesController : Controller
    {
        // GET: Movies

        private readonly ApplicationDbContext _context;
        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }


        public ActionResult Random()
        {
            var movie = new Movie() { Name = "Bad boys" };
            return View(movie);
        }
        public ActionResult Index()
        {

            var movies = _context.Movies.Include(m => m.Genre).ToList();
            return View(movies);
        }

        public ActionResult New()
        {
            var genres = _context.Genres.ToList();

            var formMovieViewModel = new FormMovieViewModel()
            {
                Genres = genres
            };
            return View("MovieForm",formMovieViewModel);
        }

        public ActionResult MovieForm()
        {
            return RedirectToAction("Index", "Movies");
        }

        public ActionResult Edit(int id)
        {
            var movie = _context.Movies.SingleOrDefault(m => m.Id == id);
            if (movie == null)
                return HttpNotFound();
            var genres = _context.Genres.ToList();
            var formMovieViewModel = new FormMovieViewModel(movie)
            {
                Genres = genres,
            };

            return View("MovieForm", formMovieViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Movie movie)
        {
            if (!ModelState.IsValid)
            {
                var formMovieViewModel = new FormMovieViewModel(movie)
                {
                    Genres = _context.Genres.ToList()
                };

                return View("MovieForm", formMovieViewModel);
            }
            if (movie.Id == 0)
            {
                movie.DateAdded = DateTime.Now;
                _context.Movies.Add(movie);
            }
            else
            {
                var movieinDb = _context.Movies.Single(m => m.Id == movie.Id);
                movieinDb.Name = movie.Name;
                movieinDb.NumberInStock = movie.NumberInStock;
                movieinDb.ReleaseDate = movie.ReleaseDate;
                movieinDb.GenreId = movie.GenreId;
            }

            _context.SaveChanges();


            return RedirectToAction("Index","Movies");
        }

        public ActionResult Details(int id)
        {
            var movie = _context.Movies.Include(m => m.Genre).SingleOrDefault(m => m.Id == id);
            if (movie == null)
                return HttpNotFound();
            return View(movie);
        }
    }
}