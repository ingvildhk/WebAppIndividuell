using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Model;

namespace WebApp
{
    public class DBMetoder
    {
        private readonly S236763DB _context;

        public DBMetoder(S236763DB context)
        {
            _context = context;
        }

        public List<faq> hentAlleFaq()
        {
            using (_context)
            {
                List<faq> alleFaq = _context.FAQ.Select(f => new faq()
                {
                    id = f.id,
                    kategori = f.kategori,
                    spm = f.spm,
                    svar = f.svar,
                    tommelNed = f.tommelNed,
                    tommelOpp = f.tommelOpp
                }).ToList();

                return alleFaq;
            }
        }

        
        public List<string> hentKategorier()
        {
            using (_context)
            {
                List<string> kategorier = new List<string>();
                foreach (FAQ f in _context.FAQ)
                {
                    if (!kategorier.Contains(f.kategori))
                    {
                        kategorier.Add(f.kategori);
                    }
                }
                return kategorier;
            }
        }

       

        public faq hentEnFaq(int id)
        {
            using (_context)
            {
                FAQ enDBFAQ = _context.FAQ.FirstOrDefault(f => f.id == id);

                var enFaq = new faq()
                {
                    id = enDBFAQ.id,
                    kategori = enDBFAQ.kategori,
                    spm = enDBFAQ.spm,
                    svar = enDBFAQ.svar,
                    tommelNed = enDBFAQ.tommelNed,
                    tommelOpp = enDBFAQ.tommelOpp
                };
                return enFaq;
            }
        }

        public bool endreEnFaq(int id, faq innFaq)
        {
            using (_context)
            {
                FAQ funnetFAQ = _context.FAQ.FirstOrDefault(f => f.id == id);
                if (funnetFAQ == null)
                {
                    return false;
                }

                funnetFAQ.tommelNed = innFaq.tommelNed;
                funnetFAQ.tommelOpp = innFaq.tommelOpp;

                try
                {
                    _context.SaveChanges();
                }
                catch (Exception feil)
                {
                    return false;
                }
                return true;
            }
        }

        public bool leggTilKundehenvendelse(kundehenvendelse innKunde)
        {
            using (_context)
            {
                var kunde = new Kundehenvendelse
                {
                    epost = innKunde.epost,
                    henvendelse = innKunde.henvendelse
                };

                try
                {
                    _context.Kundehenvendelser.Add(kunde);
                    _context.SaveChanges();
                }

                catch (Exception feil)
                {
                    return false;
                }
                return true;
            }
        }

        /*
        public List<faq> hentKategoriInnhold(string kategori)
        {
            using (_context)
            {
                List<FAQ> riktigKategori = _context.FAQ.Where(o => o.kategori == kategori).ToList();
                List<faq> riktigKategoriInnhold = new List<faq>();
                foreach(FAQ f in riktigKategori)
                {
                    faq faq = new faq
                    {
                        id = f.id,
                        kategori = f.kategori,
                        spm = f.spm,
                        svar = f.svar,
                        tommelNed = f.tommelNed,
                        tommelOpp = f.tommelOpp
                    };
                    riktigKategoriInnhold.Add(faq);
                }
                return riktigKategoriInnhold;
            }
        }*/
    }
}
