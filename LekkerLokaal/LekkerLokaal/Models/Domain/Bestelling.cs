using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LekkerLokaal.Models.Domain
{
    public class Bestelling
    {
        public int BestellingId { get; private set; }
        public DateTime BestelDatum { get; set; }
        public ICollection<BestelLijn> BestelLijnen { get; }
        public decimal BestellingTotaal => BestelLijnen.Sum(b => b.Totaal);

        protected Bestelling()
        {
            BestelLijnen = new HashSet<BestelLijn>();
            BestelDatum = DateTime.Today;
        }

        public Bestelling(Winkelwagen winkelwagen) : this()
        {
            if (!winkelwagen.WinkelwagenLijnen.Any())
                throw new InvalidOperationException("Gelieve één of meerdere cadeaubonnen toe te voegen aan uw winkelwagen alvorens u een bestelling plaatst.");

            foreach (WinkelwagenLijn lijn in winkelwagen.WinkelwagenLijnen)
            {
                for (int i = 1; i <= lijn.Aantal; i++)
                {
                    BestelLijnen.Add(new BestelLijn
                    {
                        Bon = lijn.Bon,
                        Aantal = 1,
                        Prijs = lijn.Prijs,
                        BestellingId = BestellingId,
                        Geldigheid = Geldigheid.Geldig
                    });
                }
            }
        }

        public bool HeeftBesteld(Bon bon) => BestelLijnen.Any(b => b.Bon.Equals(bon));
    }
}
