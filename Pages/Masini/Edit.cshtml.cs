using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Proiect2.Data;
using Proiect2.Models;

namespace Proiect2.Pages.Masini
{
    public class EditModel : CategoriiMasiniPageModel
    {
        private readonly Proiect2.Data.Proiect2Context _context;

        public EditModel(Proiect2.Data.Proiect2Context context)
        {
            _context = context;
        }

        [BindProperty]
        public Masina Masina { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Masina = await _context.Masina
                .Include(b => b.Producator)
                .Include(b => b.CategoriiMasina).ThenInclude(b => b.Categorie)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.ID == id);


            Masina = await _context.Masina.FirstOrDefaultAsync(m => m.ID == id);

            if (Masina == null)
            {
                return NotFound();
            }
            PopulateAtribuireCategorieData(_context, Masina);
            ViewData["ProducatorID"] = new SelectList(_context.Set<Producator>(), "ID", "NumeProducator");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(int? id, string[]
selectedCategorii)
        {
            if (id == null)
            {
                return NotFound();
            }
            var masinaToUpdate = await _context.Masina
            .Include(i => i.Producator)
            .Include(i => i.CategoriiMasina)
            .ThenInclude(i => i.Categorie)
            .FirstOrDefaultAsync(s => s.ID == id);
            if (masinaToUpdate == null)
            {
                return NotFound();
            }
            if (await TryUpdateModelAsync<Masina>(
            masinaToUpdate,
            "Masina",
            i => i.Model, i => i.Marca,
            i => i.Pret, i => i.DataLansarii, i => i.Producator))
            {
                UpdateCategoriiMasina(_context, selectedCategorii, masinaToUpdate);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            //Apelam UpdateBookCategories pentru a aplica informatiile din checkboxuri la entitatea Books care
            //este editata
            UpdateCategoriiMasina(_context, selectedCategorii, masinaToUpdate);
            PopulateAtribuireCategorieData(_context, masinaToUpdate);
            return Page();
        }
    }
}
        
