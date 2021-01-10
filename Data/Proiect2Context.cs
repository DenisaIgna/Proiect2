using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Proiect2.Models;

namespace Proiect2.Data
{
    public class Proiect2Context : DbContext
    {
        public Proiect2Context (DbContextOptions<Proiect2Context> options)
            : base(options)
        {
        }

        public DbSet<Proiect2.Models.Masina> Masina { get; set; }

        public DbSet<Proiect2.Models.Producator> Producator { get; set; }

        public DbSet<Proiect2.Models.Categorie> Categorie { get; set; }
    }
}
