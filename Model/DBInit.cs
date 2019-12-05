using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Model
{
    public static class DBInit
    {
        public static void Initialize(S236763DB context)
        {
            context.Database.EnsureCreated();

            if (context.FAQ.Any())
            {
                return;
            }

            var faq = new FAQ[]
            {
                new FAQ
                {
                    kategori = "Bestilling",
                    spm = "Kan jeg endre billetten min?",
                    svar = "Du kan endre dato og klokkeslett, men ikke reisestrekningen. Om det er høyere pris på den nye avgangen må du betale mellomlegget",
                    tommelNed = 3,
                    tommelOpp = 10
                },
                new FAQ
                {
                    kategori = "Bestilling",
                    spm = "Kan jeg avbestille billetten min?",
                    svar = "Kjøpte billetter anulleres ikke. Ta kontakt med kundeservice om du har flere spørsmål",
                    tommelNed = 8,
                    tommelOpp = 2
                },
                new FAQ
                {
                    kategori = "Bagasje",
                    spm = "Hvor mye bagasje kan jeg ha med?",
                    svar = "Du kan ta med deg inntil 30 kilo fordelt på maksimum 3 kolli. Har du mer enn dette og skal reise mellom Oslo og Voss/Bergen eller Trondheim, kan du benytte bagasjetransport.",
                    tommelNed = 1,
                    tommelOpp = 7
                },
                new FAQ
                {
                    kategori = "Bagasje",
                    spm = "Kan jeg ha med kjæledyr?",
                    svar = "Dyrene som får bli med på tog er hund, katt, gnagere i bur, burfugl og små skilpadder. Du kan ta med akvariefisk så lenge de er forsvarlig pakket. Andre dyr er ikke ønsket på toget.",
                    tommelNed = 3,
                    tommelOpp = 3
                }
                ,
                new FAQ
                {
                    kategori = "Internett og strøm",
                    spm = "Er det internett om bord?",
                    svar = "I utgangspunktet skal alle våre regiontog ha gratis internett om bord, samtidig som vi nå også tilbyr dette på de fleste lokaltog. Unntakene er enkelte tog på Ski-lokalen, Bratsbergbanen, Arendalsbanen, Jærbanen, Spikkestad–Asker–Lillestrøm og Stabekk–Moss. På Gjøvikbanen er det kun tilgang til internett på vogner med setereservasjon.",
                    tommelNed = 4,
                    tommelOpp = 5
                },
                new FAQ
                {
                    kategori = "Internett og strøm",
                    spm = "Er det strømuttak om bord?",
                    svar = "På eldre lokaltog er det ikke strømuttak, mens på nye lokaltog (Flirt) er det strømuttak ved alle seter.",
                    tommelNed = 3,
                    tommelOpp = 3
                }
                ,
                new FAQ
                {
                    kategori = "Trafikk og ruter",
                    spm = "Hvordan finner jeg ut om toget mitt er i rute?",
                    svar = "Sjekk om toget ditt er i rute på vy.no, søk på avgangen i appen eller abonner på pushvarsling om avvik i appen. Ellers skal du også få beskjed på tavler og over høyttaler på stasjonen om eventuelle avvik. Personalet om bord skal også holde deg informert.",
                    tommelNed = 1,
                    tommelOpp = 3
                },
                new FAQ
                {
                    kategori = "Trafikk og ruter",
                    spm = "Hvorfor er det så fullt på toget?",
                    svar = "I rushtidene er alt vi har av tilgjengelig materiell i bruk. Vi forsøker å matche etterspørselen med «riktig» kapasitet så langt det lar seg gjøre, likevel er det ikke mulig å tilby sitteplasser til alle. Vi får stadig flere togsett levert fra fabrikk så på sikt øker det muligheten til å kjøre flere avganger med doble togsett.",
                    tommelNed = 6,
                    tommelOpp = 2
                }
            };

            foreach(FAQ f in faq)
            {
                context.FAQ.Add(f);
            }
            context.SaveChanges();
        }

       

    }
}
