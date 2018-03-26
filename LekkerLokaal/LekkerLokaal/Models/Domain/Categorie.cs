using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LekkerLokaal.Models.Domain
{
    [JsonObject(MemberSerialization.OptIn)]
    public class Categorie
    {
        [JsonProperty]
        public int CategorieId { get; private set; }

        private string _naam;

        public string Icon { get; set; }

        public string Naam
        {
            get
            {
                return _naam;
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Een categorie heeft een naam nodig");
                if (value.Length > 20)
                    throw new ArgumentException("De naam van een categorie mag maximaal 20 karakters lang zijn");
                _naam = value;
            }
        }
        public ICollection<Bon> Bonnen { get; private set;  }

        protected Categorie() {
            Bonnen = new HashSet<Bon>();
        }

        public Categorie(string name, String icon) : this()
        {
            Naam = name;
            Icon = icon;
        }
    }
}
