using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Proiect.Data;
using Proiect.Models;

namespace Proiect.Pages.Produse
{
    public class IndexModel : PageModel
    {
        private readonly Proiect.Data.ProiectContext _context;

        public IndexModel(Proiect.Data.ProiectContext context)
        {
            _context = context;
        }

        public IList<Produs> Produs { get; set; }
        public ProdusData ProdusD { get; set; }
        public int ProdusID { get; set; }
        public int CategorieID { get; set; }
        public async Task OnGetAsync(int? id, int? categoryID)
        {
            ProdusD = new ProdusData();

            ProdusD.Produse = await _context.Produs
            .Include(b => b.Producator)
            .Include(b => b.CategoriiProdus)
            .ThenInclude(b => b.Categorie)
            .AsNoTracking()
            .OrderBy(b => b.Nume)
            .ToListAsync();
            if (id != null)
            {
                ProdusID = id.Value;
                Produs produs = ProdusD.Produse
                .Where(i => i.ID == id.Value).Single();
                ProdusD.Categorii = produs.CategoriiProdus.Select(s => s.Categorie);
            }
        }
    }
}

