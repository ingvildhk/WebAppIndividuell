using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Model
{
    public class kundehenvendelse
    {
        public int id;
        [Required]
        [RegularExpression(".+\\@.+\\..+")]
        public string epost;
        [Required]
        [RegularExpression("[0-9a-zA-ZøæåØÆÅ\\-.\\?!@ ]{2,300}")]
        public string henvendelse;
    }
}
