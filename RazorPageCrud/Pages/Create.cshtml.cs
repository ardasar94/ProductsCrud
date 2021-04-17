using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPageCrud.Models;

namespace RazorPageCrud.Pages
{
    public class CreateModel : PageModel
    {
        private readonly UrunlerDbContext _db;
        [BindProperty]
        public Urun Urun { get; set; }
        public CreateModel(UrunlerDbContext db)
        {
            _db = db;
        }
        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                _db.Urunler.Add(Urun);
                _db.SaveChanges();
                return RedirectToPage("./Index");
            }

            return Page();
        }
    }
}
