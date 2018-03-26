using LekkerLokaal.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LekkerLokaal.Models.HomeViewModels
{
    public class ZoekViewModel
    {
        public string Naam { get; }
        public decimal MinPrijs { get; }
        public decimal MaxPrijs { get; }
        public string Beschrijving { get; }
        public string Gemeente { get; }
        public string CategorieIcon { get; }
        public string CategorieNaam { get; }
        public int AantalBesteld { get; }
        public int BonId { get; }
        public string GetThumbPath { get; }

        public ZoekViewModel()
        {
        }

        public ZoekViewModel(Bon bon)
        {
            Naam = bon.Naam;
            MinPrijs = bon.MinPrijs;
            MaxPrijs = bon.MaxPrijs;
            Beschrijving = bon.Beschrijving;
            AantalBesteld = bon.AantalBesteld;
            GetThumbPath = bon.GetThumbPath();
            Gemeente = bon.Gemeente;
            BonId = bon.BonId;
            CategorieIcon = bon.Categorie.Icon;
            CategorieNaam = bon.Categorie.Naam;
        }
    }
}
