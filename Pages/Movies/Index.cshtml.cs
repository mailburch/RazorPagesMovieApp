using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorPagesMovieApp.Data;
using RazorPagesMovieApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace RazorPagesMovieApp.Pages.Movies
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public IndexModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Movie> Movie { get;set; } = new List<Movie>();

        [BindProperty(SupportsGet = true)]
        public string? SearchString { get; set; }

        public async Task OnGetAsync()
        {
            var query = _context.Movie.AsQueryable();

            if (!string.IsNullOrEmpty(SearchString))
            {
                query = query.Where(m => m.Title.Contains(SearchString) || m.Genre.Contains(SearchString));
            }

            Movie = await query.ToListAsync();
        }
    }
}
