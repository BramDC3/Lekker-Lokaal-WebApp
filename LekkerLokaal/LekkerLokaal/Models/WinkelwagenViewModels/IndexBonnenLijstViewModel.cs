using LekkerLokaal.Models.Domain;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LekkerLokaal.Models.WinkelwagenViewModels
{
    public class IndexBonnenLijstViewModel
    {
        [HiddenInput]
        public int BonId { get; }

        public int Aantal { get; }

        public string Bon { get; }

        public String GetThumbPath { get; }

        public string Categorie { get; }

        public decimal Prijs { get; }

        public decimal SubTotaal { get; }

        public IndexBonnenLijstViewModel(WinkelwagenLijn winkelwagenLijn)
        {
            BonId = winkelwagenLijn.Bon.BonId;
            Aantal = winkelwagenLijn.Aantal;
            Bon = winkelwagenLijn.Bon.Naam;
            Categorie = winkelwagenLijn.Bon.Categorie.Naam;
            Prijs = winkelwagenLijn.Prijs;
            SubTotaal = winkelwagenLijn.Totaal;
            GetThumbPath = winkelwagenLijn.Bon.GetThumbPath();
        }
    }
}
