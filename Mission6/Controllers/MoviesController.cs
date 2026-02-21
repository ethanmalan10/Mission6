using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Mission6.Models;

namespace Mission6.Controllers;

public class MoviesController : Controller
{
    private readonly MovieDbContext _context;

    // Inject the EF Core DbContext via constructor
    public MoviesController(MovieDbContext context)
    {
        _context = context;
    }

    // GET: Movies — display all movies in the collection
    public async Task<IActionResult> Index()
    {
        var movies = await _context.Movies.ToListAsync();
        return View(movies);
    }

    // GET: Movies/Create — show the add movie form
    public IActionResult Create()
    {
        return View();
    }

    // POST: Movies/Create — save new movie to the database
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(Movie movie)
    {
        if (ModelState.IsValid)
        {
            _context.Movies.Add(movie);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        return View(movie);
    }

    // GET: Movies/Edit/5 — show the edit form pre-populated with movie data
    public async Task<IActionResult> Edit(int id)
    {
        var movie = await _context.Movies.FindAsync(id);

        if (movie == null)
        {
            return NotFound();
        }

        return View(movie);
    }

    // POST: Movies/Edit/5 — save updated movie to the database
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, Movie movie)
    {
        if (id != movie.MovieId)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            _context.Movies.Update(movie);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        return View(movie);
    }

    // GET: Movies/Delete/5 — show delete confirmation page
    public async Task<IActionResult> Delete(int id)
    {
        var movie = await _context.Movies.FindAsync(id);

        if (movie == null)
        {
            return NotFound();
        }

        return View(movie);
    }

    // POST: Movies/Delete/5 — remove movie from the database
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var movie = await _context.Movies.FindAsync(id);

        if (movie != null)
        {
            _context.Movies.Remove(movie);
            await _context.SaveChangesAsync();
        }

        return RedirectToAction(nameof(Index));
    }
}
