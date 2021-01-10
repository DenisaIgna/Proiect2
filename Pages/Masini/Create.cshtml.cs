using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Proiect2.Data;
using Proiect2.Models;

namespace Proiect2.Pages.Masini
{
    public class CreateModel : CategoriiMasiniPageModel
    {
        private readonly Proiect2.Data.Proiect2Context _context;

        public CreateModel(Proiect2.Data.Proiect2Context context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["ProducatorID"] = new SelectList(_context.Set<Producator>(), "ID", "NumeProducator");
            var masina = new Masina();
            masina.CategoriiMasina = new List<CategorieMasina>();
            PopulateAtribuireCategorieData(_context, masina);

            return Page();
        }

        [BindProperty]
        public Masina Masina { get; set; }
        public async Task<IActionResult> OnPostAsync(string[] selectedCategorii)
        {
            var newMasina = new Masina();
            if (selectedCategorii != null)
            {
                newMasina.CategoriiMasina = new List<CategorieMasina>();
                foreach (var cat in selectedCategorii)
                {
                    var catToAdd = new CategorieMasina
                    {
                        CategorieID = int.Parse(cat)
                    };
                    newMasina.CategoriiMasina.Add(catToAdd);
                }
            }
            if (await TryUpdateModelAsync<Masina>(
            newMasina,
            "Masina",
            i => i.Model, i => i.Marca,
            i => i.Pret, i => i.DataLansarii, i => i.ProducatorID))
            {
                _context.Masina.Add(newMasina);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            PopulateAtribuireCategorieData(_context, newMasina);
            return Page();
        }
    }

    // To protect from overposting attacks, enable the specific properties you want to bind to, for
    // more details, see https://aka.ms/RazorPagesCRUD.
}
