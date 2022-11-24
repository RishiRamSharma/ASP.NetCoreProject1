using ASP.netCore1.Data;
using ASP.netCore1.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Security.AccessControl;
using System.Threading.Tasks;

namespace ASP.netCore1.Pages.BookList
{
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        public CreateModel(ApplicationDbContext context)
        {
            _context = context;
        }
        [BindProperty]
        public Book Book { get; set; }
        public void OnGet()
        {

        }
        public async Task<IActionResult> OnPost(/*Book book*/)
        {
            if(Book == null) return NotFound();
            if (ModelState.IsValid)
            {
                await _context.Books.AddAsync(Book);
                await _context.SaveChangesAsync();
                return RedirectToPage(nameof(Index));
                
            }
            return Page();
        }
        
    }
}
