using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorPagesMovieApp.Data;
using RazorPagesMovieApp.Models;
using System.Threading.Tasks;

namespace RazorPagesMovieApp.Pages.Movies
{
    public class EditModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public EditModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Movie Movie { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            Movie = await _context.Movie.FindAsync(id);

            if (Movie == null)
            {
                return NotFound();
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var movieToUpdate = await _context.Movie.FindAsync(id);

            if (movieToUpdate == null)
            {
                return NotFound();
            }

            if (await TryUpdateModelAsync<Movie>(
                movieToUpdate,
                "Movie",
                m => m.Title, m => m.ReleaseDate, m => m.Genre, m => m.Price,
                m => m.Rating, m => m.Poster, m => m.Director))
            {
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }

            return Page();
        }
    }
}
