using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace LekkerLokaal.Models.Domain
{
    [JsonObject(MemberSerialization.OptIn)]
    public class Bon
    {
        [JsonProperty]
        public int BonId { get; set; }
        private string _naam;
        public string Naam
        {
            get
            {
                return _naam;
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Een bon heeft een naam nodig");
                if (value.Length > 30)
                    throw new ArgumentException("De naam van een bon mag maximaal 30 karakters lang zijn");
                _naam = value;
            }
        }

        private decimal _minprijs;

        public decimal MinPrijs {
            get { return _minprijs; }
            set
            {
                if (value < 1 || value > 3000)
                    throw new ArgumentException("De prijs van een bon moet tussen € 1 en € 3000 liggen");
                _minprijs = value;
            }
        }

        private decimal _maxprijs;

        public decimal MaxPrijs
        {
            get { return _maxprijs; }
            set
            {
                if (value < 1 || value > 3000)
                    throw new ArgumentException("De prijs van een bon moet tussen € 1 en € 3000 liggen");
                _maxprijs = value;
            }
        }
        public string Beschrijving { get; set; }
        public int AantalBesteld { get; set; }
        public string Afbeelding { get; set; }
        public Handelaar Handelaar { get; set; }

        public Categorie _categorie;
        public Categorie Categorie
        {
            get
            {
                return _categorie;
            }
            set
            {
                _categorie = value ?? throw new ArgumentException("Categorie is verplicht");
            }
        }
        public string Straat { get; set; }
        public string Huisnummer { get; set; }
        public int Postcode { get; set; }
        public string Gemeente { get; set; }
        public Aanbieding Aanbieding { get; set; }

        [JsonConstructor]
        protected Bon() { }

        public Bon(string naam, decimal minprijs, decimal maxprijs, string beschrijving, int aantalBesteld, string afbeelding, Categorie categorie, string straat, string huisnummer, int postcode, string gemeente, Handelaar handelaar, Aanbieding aanbieding) : this()
        {
            Naam = naam;
            MaxPrijs = maxprijs;
            MinPrijs = minprijs;
            Beschrijving = beschrijving;
            AantalBesteld = aantalBesteld;
            Afbeelding = afbeelding;
            Categorie = categorie;
            Straat = straat;
            Huisnummer = huisnummer;
            Postcode = postcode;
            Gemeente = gemeente;
            Handelaar = handelaar;
            Aanbieding = aanbieding;
        }

        
        public String GetThumbPath()
        {
            string path = Afbeelding + "thumb.jpg";
            return path;
        }

        public List<string> getAfbeeldingenPathLijst()
        {
            return Directory.GetFiles(@"wwwroot\" + Afbeelding + @"Afbeeldingen\", "*.JPG").Select(l => l.Replace(@"wwwroot\", "")).ToList();
        }
    }
}
