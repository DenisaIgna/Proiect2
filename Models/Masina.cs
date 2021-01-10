using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Proiect2.Models
{
    public class Masina
    {
        public int ID { get; set; }
        [Required, StringLength(150, MinimumLength = 3)]
        [Display(Name = "Modelul masinii")]
        public string Model { get; set; }

        public string Marca { get; set; }
        [Range(1, 300)]

        [Column(TypeName = "decimal(6, 3)")]
        public decimal Pret { get; set; }
        [DataType(DataType.Date)]
        public DateTime DataLansarii { get; set; }
        public int ProducatorID { get; set; }
        public Producator Producator { get; set; }
        public ICollection<CategorieMasina> CategoriiMasina { get; set; }
    } //navigation property
}

