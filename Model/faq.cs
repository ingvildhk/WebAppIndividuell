using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Model
{
    public class faq
    {
        public int id;
        public string kategori { get; set; }
        public string spm { get; set; }
        public string svar { get; set; }
        public int tommelOpp { get; set; }
        public int tommelNed { get; set; }
    }
}
