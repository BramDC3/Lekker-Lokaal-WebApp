﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LekkerLokaal.Models;
using LekkerLokaal.Models.Domain;
using Microsoft.AspNetCore.Authorization;
using LekkerLokaal.Models.HomeViewModels;

namespace LekkerLokaal.Controllers
{
    public class HomeController : Controller
    {
        private readonly IBonRepository _bonRepository;
        private readonly ICategorieRepository _categorieRepository;
        private readonly IHandelaarRepository _handelaarRepository;
        public HomeController(IBonRepository bonRepository, ICategorieRepository categorieRepository, IHandelaarRepository handelaarRepository)
        {
            _bonRepository = bonRepository;
            _categorieRepository = categorieRepository;
            _handelaarRepository = handelaarRepository;
        }

        public IActionResult Index()
        {
            ViewData["AlleBonnen"] = _bonRepository.GetAll().ToList();
            ViewData["Top3Bonnen"] = _bonRepository.GetTop3(_bonRepository.GetAll().ToList()).ToList();
            ViewData["AlleCategorien"] = _categorieRepository.GetAll().ToList();
            ViewData["Top9CategorieMetAantal"] = _categorieRepository.GetTop9WithAmount();

            return View();
        }

        public IActionResult About()
        {
            ViewData["AlleCategorien"] = _categorieRepository.GetAll().ToList();
            return View();
        }

        public IActionResult Error()
        {
            ViewData["AlleCategorien"] = _categorieRepository.GetAll().ToList();
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult Zoeken(string ZoekSoort = null, string ZoekKey = null, string Categorie = null, string Ligging = null, string MaxStartPrijs = null )
        {
            ViewData["AlleCategorien"] = _categorieRepository.GetAll().ToList();
            IEnumerable<Bon> GefilterdeBonnen;


            if (!string.IsNullOrEmpty(ZoekKey))

            {
                switch (ZoekSoort)
                {
                    case "Alles":
                        GefilterdeBonnen = _bonRepository.GetAlles(ZoekKey, _bonRepository.GetAll());
                        break;
                    case "Ligging":
                        GefilterdeBonnen = _bonRepository.GetByLigging(ZoekKey, _bonRepository.GetAll());
                        break;
                    case "Naam":
                        GefilterdeBonnen = _bonRepository.GetByNaam(ZoekKey, _bonRepository.GetAll());
                        break;
                    case "Categorie":
                        GefilterdeBonnen = _bonRepository.GetByCategorie(ZoekKey, _bonRepository.GetAll());
                        break;
                    default:
                        GefilterdeBonnen = _bonRepository.GetAll();
                        break;
                }
                ViewData["ZoekOpdracht"] = ZoekKey + " in " + ZoekSoort;

                if (!string.IsNullOrEmpty(Categorie) && Categorie != "*")
                {
                    string input = Categorie;
                    GefilterdeBonnen = _bonRepository.GetByCategorie(input, GefilterdeBonnen);
                    ViewData["ZoekOpdracht"] = ViewData["ZoekOpdracht"] + ", met categorie " + input;
                }
                if (!string.IsNullOrEmpty(Ligging) && Ligging != "*")
                {
                    string input = Ligging;
                    GefilterdeBonnen = _bonRepository.GetByLigging(input, GefilterdeBonnen);
                    ViewData["ZoekOpdracht"] = ViewData["ZoekOpdracht"] + ", met ligging " + input;
                }
                if (!string.IsNullOrEmpty(MaxStartPrijs))
                {
                    int input = int.Parse(MaxStartPrijs);
                    GefilterdeBonnen = _bonRepository.GetByPrijs(input, GefilterdeBonnen);
                    ViewData["ZoekOpdracht"] = ViewData["ZoekOpdracht"] + ", met maximum prijs €" + input;
                }
            }
            else
            {
                GefilterdeBonnen = _bonRepository.GetAll();
                ViewData["ZoekOpdracht"] = "Overzicht van alle bons";

                if (!string.IsNullOrEmpty(Categorie) && Categorie != "*")
                {
                    string input = Categorie;
                    GefilterdeBonnen = _bonRepository.GetByCategorie(input, GefilterdeBonnen);
                    ViewData["ZoekOpdracht"] = ViewData["ZoekOpdracht"] + ", met categorie " + input;
                }
                if (!string.IsNullOrEmpty(Ligging) && Ligging != "*")
                {
                    string input = Ligging;
                    GefilterdeBonnen = _bonRepository.GetByLigging(input, GefilterdeBonnen);
                    ViewData["ZoekOpdracht"] = ViewData["ZoekOpdracht"] + ", met ligging " + input;
                }
                if (!string.IsNullOrEmpty(MaxStartPrijs))
                {
                    int input = int.Parse(MaxStartPrijs);
                    GefilterdeBonnen = _bonRepository.GetByPrijs(input, GefilterdeBonnen);
                    ViewData["ZoekOpdracht"] = ViewData["ZoekOpdracht"] + ", met maximum prijs " + input;
                }

            }

            return View(GefilterdeBonnen.Select(b => new ZoekViewModel(b)).ToList());
        }

        
        public IActionResult Detail(int Id)
        {
            Bon aangeklikteBon = _bonRepository.GetByBonId(Id);
            ViewData["AlleCategorien"] = _categorieRepository.GetAll().ToList();
            return View(new DetailViewModel(aangeklikteBon));
        }
    }
}
