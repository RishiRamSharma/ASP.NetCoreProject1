using ASP.netCore1.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Net.Http;

namespace ASP.netCore1.Controlles
{
    [Route("api/[controller]")] //api/book
    [ApiController]
    public class BookCtlController : Controller
    {
        private readonly ApplicationDbContext _context;
        public BookCtlController (ApplicationDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var bookList = _context.Books.ToList();
            return Json(new { data = bookList });
        }

       

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var bookInDb = _context.Books.Find(id);
            if(bookInDb == null)
             return Json(new { success = false, message = "Something went worng!!" });
            _context.Books.Remove(bookInDb);
            _context.SaveChanges();
            return Json(new { success = true, message = "Data Delete Successfully." });
        }
       

       
        
    }
}
