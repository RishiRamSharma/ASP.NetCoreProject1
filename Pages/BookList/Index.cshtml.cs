using ASP.netCore1.Data;
using ASP.netCore1.Model;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.netCore1.Pages.BookList
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        public IndexModel (ApplicationDbContext context)
        {
            _context = context;
        }
        public IEnumerable <Book> Books { get; set; }
        public async Task OnGet()
        {
            Books = await _context.Books.ToListAsync();
        }
        public async Task<IActionResult> OnPostDelete(int id)
        {
            var bookInDb = await _context.Books.FindAsync(id);
            if (bookInDb == null) return NotFound();
            _context.Books.Remove(bookInDb);
            await _context.SaveChangesAsync();
            return RedirectToPage("Index");
        }
        
    }
}
