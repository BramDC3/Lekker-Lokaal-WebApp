using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LekkerLokaal.Filters;
using LekkerLokaal.Models.CartViewModels;
using LekkerLokaal.Models.Domain;
using Microsoft.AspNetCore.Mvc;

namespace LekkerLokaal.Controllers
{
    [ServiceFilter(typeof(CartSessionFilter))]
    public class WinkelwagenController : Controller
    {
        private readonly ICategorieRepository _categorieRepository;
        private readonly IBonRepository _bonRepository;

        public WinkelwagenController(ICategorieRepository categorieRepository, IBonRepository bonRepository)
        {
            _categorieRepository = categorieRepository;
            _bonRepository = bonRepository;
        }

        public IActionResult Index(Winkelwagen winkelwagen)
        {
            ViewData["AlleCategorien"] = _categorieRepository.GetAll().ToList();
            ViewData["IsLeeg"] = winkelwagen.IsLeeg;
            ViewData["Totaal"] = winkelwagen.TotaleWaarde;
            return View(winkelwagen.WinkelwagenLijnen.Select(w => new IndexViewModel(w)).ToList());
        }

        [HttpGet]
        public IActionResult Add(int id, Winkelwagen winkelwagen)
        {
            Bon bon = _bonRepository.GetByBonId(id);
            if (bon != null)
            {
                decimal prijs = 50;
                int aantal = 1;
                winkelwagen.VoegLijnToe(bon, aantal, prijs);
            }
            return RedirectToAction(nameof(Index), "Home");
        }

        [HttpPost]
        public IActionResult Remove(int id, decimal prijs, Winkelwagen winkelwagen)
        {
            Bon bon = _bonRepository.GetByBonId(id);
            winkelwagen.VerwijderLijn(bon, prijs);
            TempData["message"] = $"Bon {bon.Naam} met bedrag € {prijs} werd verwijderd uit uw winkelwagen.";
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public IActionResult Plus(int id, decimal prijs, Winkelwagen winkelwagen)
        {
            winkelwagen.VerhoogAantal(id, prijs);
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public IActionResult Min(int id, decimal prijs, Winkelwagen winkelwagen)
        {
            winkelwagen.VerlaagAantal(id, prijs);
            return RedirectToAction(nameof(Index));
        }
    }
}