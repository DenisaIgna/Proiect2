using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Proiect2.Data;


namespace Proiect2.Models
{
    public class CategoriiMasiniPageModel:PageModel
    {
 public List<AtribuireCategorieData> AtribuireCategorieDataList;
        public void PopulateAtribuireCategorieData(Proiect2Context context,
        Masina masina)
        {
            var toateCategoriile = context.Categorie;
            var CategoriiMasina = new HashSet<int>(
            masina.CategoriiMasina.Select(c => c.MasinaID));
            AtribuireCategorieDataList = new List<AtribuireCategorieData>();
            foreach (var cat in toateCategoriile)
            {
                AtribuireCategorieDataList.Add(new AtribuireCategorieData
                {
                    CategorieID = cat.ID,
                    Nume = cat.NumeCategorie,
                    Atribuire = CategoriiMasina.Contains(cat.ID)
                });
            }
        }
        public void UpdateCategoriiMasina(Proiect2Context context,
        string[] selectedCategorii, Masina masinaToUpdate)
        {
            if (selectedCategorii == null)
            {
                masinaToUpdate.CategoriiMasina = new List<CategorieMasina>();
                return;
            }
            var selectedCategoriiHS = new HashSet<string>(selectedCategorii);
            var CategoriiMasina = new HashSet<int>
            (masinaToUpdate.CategoriiMasina.Select(c => c.Categorie.ID));
            foreach (var cat in context.Categorie)
            {
                if (selectedCategoriiHS.Contains(cat.ID.ToString()))
                {
                    if (!CategoriiMasina.Contains(cat.ID))
                    {
                        masinaToUpdate.CategoriiMasina.Add(
                        new CategorieMasina
                        {
                            MasinaID = masinaToUpdate.ID,
                            CategorieID = cat.ID
                        });
                    }
                }
                else
                {
                    if (CategoriiMasina.Contains(cat.ID))
                    {
                        CategorieMasina courseToRemove
                        = masinaToUpdate
                        .CategoriiMasina
                        .SingleOrDefault(i => i.CategorieID == cat.ID);
                        context.Remove(courseToRemove);
                    }
                }
            }
        }

    }
}
