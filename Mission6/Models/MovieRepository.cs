namespace Mission6.Models;

public class MovieRepository
{
    private static List<Movie> _movies = new();
    private static int _nextId = 1;

    public IEnumerable<Movie> GetAllMovies()
    {
        return _movies;
    }

    public Movie? GetMovieById(int id)
    {
        return _movies.FirstOrDefault(m => m.MovieId == id);
    }

    public void AddMovie(Movie movie)
    {
        movie.MovieId = _nextId++;
        _movies.Add(movie);
    }

    public void UpdateMovie(Movie movie)
    {
        var existingMovie = GetMovieById(movie.MovieId);
        if (existingMovie != null)
        {
            existingMovie.Title = movie.Title;
            existingMovie.Category = movie.Category;
            existingMovie.Year = movie.Year;
            existingMovie.Director = movie.Director;
            existingMovie.Rating = movie.Rating;
            existingMovie.Edited = movie.Edited;
            existingMovie.LentTo = movie.LentTo;
            existingMovie.Notes = movie.Notes;
        }
    }

    public void DeleteMovie(int id)
    {
        var movie = GetMovieById(id);
        if (movie != null)
        {
            _movies.Remove(movie);
        }
    }
}
