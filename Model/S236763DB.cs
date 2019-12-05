using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace WebApp.Model
{
    public class FAQ
    {
        [Key]
        public int id { get; set; }
        public string kategori { get; set; }
        public string spm { get; set; }
        public string svar { get; set; }
        public int tommelOpp { get; set; }
        public int tommelNed { get; set; }
    }

    public class Kundehenvendelse
    {
        [Key]
        public int id { get; set; }
        public string epost { get; set; }
        public string henvendelse { get; set; }
    }

    public class S236763DB : DbContext
    {
        public S236763DB(DbContextOptions<S236763DB> options)
            : base(options) { }

        public DbSet<FAQ> FAQ { get; set; }
        public DbSet<Kundehenvendelse> Kundehenvendelser { get; set; }
    }
}
