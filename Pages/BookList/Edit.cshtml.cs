using ASP.netCore1.Data;
using ASP.netCore1.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;

namespace ASP.netCore1.Pages.BookList
{
    public class EditModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        public EditModel(ApplicationDbContext context)
        {
            _context = context;
        }
        [BindProperty]
        public Book Book { get; set; }

        public async Task OnGet(int id)
        {
            Book = await _context.Books.FindAsync(id);
        }
        public async Task<IActionResult> OnPost(/*Book book*/)
        {
            if(Book == null) return NotFound();
            if (ModelState.IsValid)
            {
                _context.Books.Update(Book);
                await _context.SaveChangesAsync();
                return RedirectToPage(nameof(Index));
            }
            return Page();
        }
    }
}
