using LekkerLokaal.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LekkerLokaal.Models.HomeViewModels
{
    public class IndexAanbiedingSliderLijstModel
    {
        public string GetThumbPath { get; }
        public int AantalBesteld { get; }
        public string Naam { get; }
        public int BonId { get; }

        public IndexAanbiedingSliderLijstModel()
        {
        }

        public IndexAanbiedingSliderLijstModel(Bon bon)
        {
            Naam = bon.Naam;
            AantalBesteld = bon.AantalBesteld;
            GetThumbPath = bon.GetThumbPath();
            BonId = bon.BonId;
        }
    }
}
