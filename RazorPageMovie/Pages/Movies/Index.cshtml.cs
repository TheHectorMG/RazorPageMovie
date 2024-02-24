using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RazorPageMovie.Data;
using RazorPageMovie.Models;

namespace RazorPageMovie.Pages.Movies
{
    public class IndexModel : PageModel
    {
        private readonly RazorPageMovie.Data.RazorPageMovieContext _context;

        public IndexModel(RazorPageMovie.Data.RazorPageMovieContext context)
        {
            _context = context;
        }

        public IList<Movie> Movie { get; set; } = default!;
        [BindProperty(SupportsGet = true)]

        public string? SearchString { get; set; }

        public SelectList? Generes { get; set; }
        [BindProperty(SupportsGet = true)]

        public string? MovieGenere { get; set; }
 
        public async Task OnGetAsync()
        {

            //Movie = await _context.Movie.ToListAsync();
            IQueryable<string> genereQuery = from m in _context.Movie
                                             orderby m.Genere
                                             select m.Genere;

            var movies = from m in _context.Movie
                         select m;

            if (!string.IsNullOrEmpty(SearchString))
            {
                movies = movies.Where(s => s.Title.Contains(SearchString));
            }

            if (!string.IsNullOrEmpty(MovieGenere))
            {
                movies = movies.Where(x => x.Genere == MovieGenere);
            }

            if (_context.Movie != null)
            {
                Generes = new SelectList(await genereQuery.Distinct().ToListAsync());
                Movie = await movies.ToListAsync();
            }

        }
    }
}
