using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Proiect2.Data;
using Proiect2.Models;

namespace Proiect2.Pages.Masini
{
    public class IndexModel : PageModel
    {
        private readonly Proiect2.Data.Proiect2Context _context;

        public IndexModel(Proiect2.Data.Proiect2Context context)
        {
            _context = context;
        }
        public MasinaData MasinaD { get; set; }
        public int MasinaID { get; set; }
        public int CategorieID { get; set; }
        public async Task OnGetAsync(int? id, int? categorieID)
        {
            MasinaD = new MasinaData();

            MasinaD.Masini = await _context.Masina
            .Include(b => b.Producator)
            .Include(b => b.CategoriiMasina)
            .ThenInclude(b => b.Categorie)
            .AsNoTracking()
            .OrderBy(b => b.Model)
            .ToListAsync();
            if (id != null)
            {
                MasinaID = id.Value;
                Masina masina = MasinaD.Masini
                .Where(i => i.ID == id.Value).Single();
                MasinaD.Categorii = masina.CategoriiMasina.Select(s => s.Categorie);
            }
        }

        public IList<Masina> Masina { get;set; }
    }
}
