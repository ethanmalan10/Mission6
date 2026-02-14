using Microsoft.AspNetCore.Mvc;
using Mission6.Models;  

namespace Mission6.Controllers; 

public class MoviesController : Controller
{
    private readonly MovieRepository _repository;

    public MoviesController(MovieRepository repository)
    {
        _repository = repository;
    }

    // GET: Movies
    public IActionResult Index()
    {
        var movies = _repository.GetAllMovies();
        return View(movies);
    }

    // GET: Movies/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: Movies/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(Movie movie)
    {
        if (ModelState.IsValid)
        {
            _repository.AddMovie(movie);
            return RedirectToAction(nameof(Index));
        }
        return View(movie);
    }

    // GET: Movies/Edit/5
    public IActionResult Edit(int id)
    {
        var movie = _repository.GetMovieById(id);
        if (movie == null)
        {
            return NotFound();
        }
        return View(movie);
    }

    // POST: Movies/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Edit(int id, Movie movie)
    {
        if (id != movie.MovieId)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            _repository.UpdateMovie(movie);
            return RedirectToAction(nameof(Index));
        }
        return View(movie);
    }

    // GET: Movies/Delete/5
    public IActionResult Delete(int id)
    {
        var movie = _repository.GetMovieById(id);
        if (movie == null)
        {
            return NotFound();
        }
        return View(movie);
    }

    // POST: Movies/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public IActionResult DeleteConfirmed(int id)
    {
        _repository.DeleteMovie(id);
        return RedirectToAction(nameof(Index));
    }
}

