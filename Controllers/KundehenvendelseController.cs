using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApp.Model;

namespace WebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KundehenvendelseController : Controller
    {
        private readonly S236763DB _context;
        public KundehenvendelseController(S236763DB context)
        {
            _context = context;
        }

        // POST api/Kundehenvendelse
        [HttpPost]
        public JsonResult Post([FromBody]kundehenvendelse innKunde)
        {
            try 
            {
                MailAddress m = new MailAddress(innKunde.epost);
            }

            catch (FormatException)
            {
                return Json("Epost er ikke en gyldig epostadresse");
            }

            Regex regex = new Regex("[0-9a-zA-ZøæåØÆÅ\\-.\\?!@:,() ]{2,300}");

            if (string.IsNullOrEmpty(innKunde.henvendelse))
            {
                return Json("Henvendelse må fylles ut");
            }

            else if (!regex.IsMatch(innKunde.henvendelse))
            {
                return Json("Henvendelse kan ikke inneholde ulovlige spesialtegn");
            }

            if (ModelState.IsValid)
            {
                var db = new DBMetoder(_context);
                bool OK = db.leggTilKundehenvendelse(innKunde);
                if (OK)
                {
                    return Json("Din henvendelse er mottatt og blir behandlet av kundeservice");
                }
            }
            return Json("Kunne ikke ta i mot henvendelsen");
        }
    }
}