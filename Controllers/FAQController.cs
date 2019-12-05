using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApp.Model;

namespace WebApp.Controllers
{
    [Route("api/[controller]")]
    public class FAQController : Controller
    {
        private readonly S236763DB _context;
        public FAQController(S236763DB context)
        {
            _context = context;
        }

        //GET api/faq
        [HttpGet]
        public JsonResult Get()
        {
            var db = new DBMetoder(_context);
            List<faq> alleFAQ = db.hentAlleFaq();
            return Json(alleFAQ);
        }

        //GET api/faq/id
        [HttpGet("{id}")]
        public JsonResult Get(int id)
        {
            var db = new DBMetoder(_context);
            faq enFaq = db.hentEnFaq(id);
            return Json(enFaq);
        }

        //PUT api/faq/id
        [HttpPut("{id}")]
        public JsonResult Put(int id, [FromBody]faq innFaq)
        {
            if (ModelState.IsValid)
            {
                var db = new DBMetoder(_context);
                bool OK = db.endreEnFaq(id, innFaq);
                if (OK)
                {
                    return Json(innFaq);
                }
            }
            return Json(innFaq);
        }
    }
}
