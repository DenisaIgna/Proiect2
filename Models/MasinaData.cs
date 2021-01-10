using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proiect2.Models
{
    public class MasinaData
    {
        public IEnumerable<Masina> Masini { get; set; }
        public IEnumerable<Categorie> Categorii { get; set; }
        public IEnumerable<CategorieMasina> CategoriiMasina { get; set; }
    }
}
