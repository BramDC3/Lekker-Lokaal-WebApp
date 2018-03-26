using LekkerLokaal.Models.Domain;
using LekkerLokaal.Models.WinkelwagenViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LekkerLokaal.Models.WinkelwagenViewModels
{
    public class IndexViewModel
    {
        public IEnumerable<IndexBonnenLijstViewModel> WinkelwagenLijst { get; }
        public decimal Totaal { get; }

        public IndexViewModel(IEnumerable<WinkelwagenLijn> winkelWagenLijst, decimal totaal)
        {
            WinkelwagenLijst = winkelWagenLijst.Select(wl => new IndexBonnenLijstViewModel(wl)).ToList();
            Totaal = totaal;
        }
    }

}
