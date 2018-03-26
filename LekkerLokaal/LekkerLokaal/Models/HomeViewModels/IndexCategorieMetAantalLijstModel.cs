using LekkerLokaal.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LekkerLokaal.Models.HomeViewModels
{
    public class IndexCategorieMetAantalLijstModel
    {
        public string CategorieNaam { get; }
        public int Aantal { get; }
        public string Icon { get; }

        public IndexCategorieMetAantalLijstModel()
        {
        }

        public IndexCategorieMetAantalLijstModel(KeyValuePair<Categorie, int> categorieMetAantal)
        {
            CategorieNaam = categorieMetAantal.Key.Naam;
            Aantal = categorieMetAantal.Value;
            Icon = categorieMetAantal.Key.Icon;
        }
    }
}
