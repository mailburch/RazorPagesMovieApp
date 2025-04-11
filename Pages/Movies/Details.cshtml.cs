
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPagesMovieApp.Data;
using RazorPagesMovieApp.Models;
using System.Threading.Tasks;

namespace RazorPagesMovieApp.Pages.Movies
{
    public class DetailsModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public DetailsModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public Movie Movie { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null) return NotFound();

            Movie = await _context.Movie.FindAsync(id);
            if (Movie == null) return NotFound();

            return Page();
        }
    }
}
