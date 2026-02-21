using System.ComponentModel.DataAnnotations;

namespace Mission6.Models;

public class Movie
{
    // Primary key
    public int MovieId { get; set; }

    // Required: title of the movie
    [Required(ErrorMessage = "Title is required.")]
    public string Title { get; set; } = string.Empty;

    // Optional: genre/category
    public string? Category { get; set; }

    // Required: year released; must be >= 1888 (first film ever made)
    [Required(ErrorMessage = "Year is required.")]
    [Range(1888, int.MaxValue, ErrorMessage = "Year must be 1888 or later.")]
    public int Year { get; set; }

    // Optional: director name
    public string? Director { get; set; }

    // Optional: MPAA rating
    public string? Rating { get; set; }

    // Required: whether the movie has been edited for content
    [Required(ErrorMessage = "Edited status is required.")]
    public bool Edited { get; set; }

    // Required: whether the movie has been copied to Plex
    [Required(ErrorMessage = "Copied to Plex status is required.")]
    public bool CopiedToPlex { get; set; }

    // Optional: who the movie is currently lent to
    public string? LentTo { get; set; }

    // Optional: miscellaneous notes
    public string? Notes { get; set; }
}
