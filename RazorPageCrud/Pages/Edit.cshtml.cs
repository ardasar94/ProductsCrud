using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorPageCrud.Models;

namespace RazorPageCrud.Pages
{
    public class EditModel : PageModel
    {
        private readonly UrunlerDbContext _db;

        [BindProperty]
        public Urun Urun { get; set; }

        public EditModel(UrunlerDbContext db)
        {
            _db = db;
        }
        public IActionResult OnGet(int id)
        {
            Urun = _db.Urunler.Find(id);
            if (Urun == null)
            {
                return RedirectToPage("./Index");
            }
            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            //_db.Attach(Urun).State = EntityState.Modified; // Update Dene
            _db.Urunler.Update(Urun);
            try
            {
                _db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {

                throw new Exception($"Urun: {Urun.Id} bulunamadı!"); ;
            }

            return RedirectToPage("./Index");
        }
    }
}
