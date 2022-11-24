using ASP.netCore1.Data;
using ASP.netCore1.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace ASP.netCore1.Pages.BookList
{
    public class UpsertModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        public UpsertModel(ApplicationDbContext context)
        {
            _context = context;
        }
        [BindProperty]
        public Book Book { get; set; }
        public async Task<IActionResult> OnGet(int? id)
        {
            Book = new Book();
            if (id == null) return Page();  // Create

            //Edit
            Book = await _context.Books.FindAsync(id);
            if (Book == null) return NotFound();
            return Page();
        }
        public async Task<IActionResult> OnPost()
        {
            if(Book == null) return NotFound();
            if(!ModelState.IsValid) return Page();
            if (Book.Id == 0)
                await _context.Books.AddAsync(Book);
            else 
                _context.Books.Update(Book);
            await _context.SaveChangesAsync();
            return RedirectToPage(nameof(Index));
        }

    }
}
