using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proiect2.Models
{
    public class CategorieMasina
    {
        public int ID { get; set; }
        public int MasinaID { get; set; }
        public Masina Masina { get; set; }
        public int CategorieID { get; set; }
        public Categorie Categorie { get; set; }
    }
}
