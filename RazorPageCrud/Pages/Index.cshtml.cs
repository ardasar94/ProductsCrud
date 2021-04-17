using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using RazorPageCrud.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RazorPageCrud.Pages
{
    public class IndexModel : PageModel
    {
        private readonly UrunlerDbContext _db;
        public IList<Urun> Urun { get; set; }

        public IndexModel(UrunlerDbContext db)
        {
            _db = db;
        }

        public void OnGet()
        {
            Urun = _db.Urunler.ToList();
        }

        public IActionResult OnPostDelete(int id)
        {
            var urun = _db.Urunler.Find(id);

            if (urun != null)
            {
                _db.Urunler.Remove(urun);
                _db.SaveChanges();
            }

            return RedirectToPage("./Index");
        }
    }
}
