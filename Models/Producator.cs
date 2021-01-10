using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proiect2.Models
{
    public class Producator
    {
        public int ID { get; set; }
        public string NumeProducator { get; set; }
        public ICollection<Masina> Masini { get; set; } //navigation property
    }
}
