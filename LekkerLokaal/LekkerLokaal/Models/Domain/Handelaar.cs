using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LekkerLokaal.Models.Domain
{
    public class Handelaar
    {
        public int HandelaarId { get; private set; }
        public string Naam { get; set; }
        public string Emailadres { get; set; }
        public string Beschrijving { get; set; }
        public string BTW_Nummer { get; set; }
        public ICollection<Bon> Cadeaubonnen { get; private set; }
        public string Afbeelding { get; set; }
        public string Straat { get; set; }
        public string Huisnummer { get; set; }
        public int Postcode { get; set; }
        public string Gemeente { get; set; }

        protected Handelaar()
        {

        }

        public Handelaar(string naam, string emailadres, string beschrijving, string btw_nummer, string afbeelding, string straat, string huisnummer, int postcode, string gemeente)
        {
            Naam = naam;
            Emailadres = emailadres;
            Beschrijving = beschrijving;
            BTW_Nummer = btw_nummer;
            Afbeelding = afbeelding;
            Straat = straat;
            Huisnummer = huisnummer;
            Postcode = postcode;
            Gemeente = gemeente;
            Cadeaubonnen = new HashSet<Bon>();
        }

        public void VoegBonToe(Bon bon)
        {
            Cadeaubonnen.Add(bon);
        }
    }
}
