using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApp.Model;

namespace WebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KategoriController : Controller
    {
        private readonly S236763DB _context;
        public KategoriController(S236763DB context)
        {
            _context = context;
        }

        //GET api/kategori
        [HttpGet]
        public JsonResult Get()
        {
            var db = new DBMetoder(_context);
            List<string> kategorier = db.hentKategorier();
            return Json(kategorier);
        }
    }
}