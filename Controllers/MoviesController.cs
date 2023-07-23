using Microsoft.AspNetCore.Mvc;
using Movies__CRUD_Operations_.Models;
using Movies__CRUD_Operations_.Repository;
using Movies__CRUD_Operations_.ViewModels;
using NToastNotify;
using System.Reflection.Metadata;

namespace Movies__CRUD_Operations_.Controllers
{
    public class MoviesController : Controller
    {
        private readonly MovieRepo MovieRepo;
        private readonly GenreRepo GenreRepo;
        private readonly IToastNotification toastNotification;
        public MoviesController(MovieRepo _movieRepo, GenreRepo _genreRepo, IToastNotification _toastNotification)
        {
            MovieRepo = _movieRepo;
            GenreRepo = _genreRepo;
            toastNotification = _toastNotification;
        }
        public IActionResult Index()
        {
            List<Movie>movies= MovieRepo.GetAll();
            return View(movies);
        }
        public IActionResult Creat()
        {
            List<Genre> genre = GenreRepo.GetAll();
            ViewBag.go = genre;
            return View();
        }
        [HttpPost]
        public IActionResult Creat(Movie movie)
        {
            if (!ModelState.IsValid)
            {
                List<Genre> genre = GenreRepo.GetAll();
                ViewBag.go = genre;
                 return View(movie);
            }
            if (movie.Year > DateTime.Now)
            {
                ModelState.AddModelError("Year","Date of publication must must be now or in the past");
                List<Genre> genre = GenreRepo.GetAll();
                ViewBag.go = genre;
                return View(movie);
            }
            MovieRepo.Creat(movie);
            toastNotification.AddSuccessToastMessage("Movie created successfully");
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Edit(int? id)
        {
            if (id == null) return BadRequest();
            Movie movie = MovieRepo.GetById(id);
            if (movie == null) return NotFound();
            List<Genre> genre = GenreRepo.GetAll();
            ViewBag.go = genre;
            return View("Creat",movie);
        }
        [HttpPost]
        public IActionResult Edit(Movie movie)
        {
            if (movie.Year > DateTime.Now)
            {
                ModelState.AddModelError("Year", "Date of publication must must be now or in the past");
                List<Genre> genre = GenreRepo.GetAll();
                ViewBag.go = genre;
                return View("Creat",movie);
            }
            MovieRepo.Update(movie);
            toastNotification.AddSuccessToastMessage("Movie Updated successfully");
            return RedirectToAction(nameof(Index)); 
        }
        public IActionResult Delete(int? id)
        {
            if (id == null) return BadRequest();
            Movie movie = MovieRepo.GetById(id);
            MovieRepo.Delete(id);
            toastNotification.AddSuccessToastMessage("Movie Deleted successfully");
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Details(int? id)
        {
            if (id == null) return BadRequest();
            Movie movie = MovieRepo.GetById(id);
            if (movie == null) return NotFound();
     
            Genre genre = GenreRepo.GetById(movie.GenreId);
            ViewBag.g = genre.Name;
            return View(movie);
        }
    }
}
