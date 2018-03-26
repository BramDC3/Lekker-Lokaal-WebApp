using LekkerLokaal.Models.Domain;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LekkerLokaal.Models.HomeViewModels
{
    public class DetailViewModel
    {
        [HiddenInput]
        public int BonId { get; }
        public string Naam { get; }
        public decimal MinPrijs { get; }
        public decimal MaxPrijs { get; }
        public string Beschrijving { get; }
        public int AantalBesteld { get; }
        public List<string> getAfbeeldingenPathLijst { get; }
        public string HandelaarNaam { get; }
        public string HandelaarBeschrijving { get; }
        public string FormatedAdress { get; }
        public string Gemeente { get; }
        public string CategorieIcon { get; }
        public string CategorieNaam { get; }

        public DetailViewModel()
        {
        }

        public DetailViewModel(Bon bon)
        {
            BonId = bon.BonId;
            Naam = bon.Naam;
            MinPrijs = bon.MinPrijs;
            MaxPrijs = bon.MaxPrijs;
            Beschrijving = bon.Beschrijving;
            AantalBesteld = bon.AantalBesteld;
            getAfbeeldingenPathLijst = bon.getAfbeeldingenPathLijst();
            HandelaarNaam = bon.Handelaar.Naam;
            HandelaarBeschrijving = bon.Handelaar.Beschrijving;
            FormatedAdress = bon.Postcode + " " + bon.Gemeente + ", " + bon.Straat + " " + bon.Huisnummer;
            Gemeente = bon.Gemeente;
            CategorieIcon = bon.Categorie.Icon;
            CategorieNaam = bon.Categorie.Naam;
        }
    }
}
