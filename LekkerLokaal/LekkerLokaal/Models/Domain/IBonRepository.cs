﻿using System.Collections.Generic;

namespace LekkerLokaal.Models.Domain
{
    public interface IBonRepository
    {
        IEnumerable<Bon> GetAll();
        IEnumerable<Bon> GetTop3(IEnumerable<Bon> inputlijst);
        IEnumerable<Bon> GetTop30(IEnumerable<Bon> inputlijst);
        IEnumerable<Bon> GetAlles(string zoekKey, IEnumerable<Bon> inputlijst);
        IEnumerable<Bon> GetByLigging(string zoekKey, IEnumerable<Bon> inputlijst);
        IEnumerable<Bon> GetByNaam(string zoekKey, IEnumerable<Bon> inputlijst);
        IEnumerable<Bon> GetByCategorie(string zoekKey, IEnumerable<Bon> inputlijst);
        IEnumerable<Bon> GetByPrijs(int zoekKey, IEnumerable<Bon> inputlijst);
        Bon GetByBonId(int bonId);
    }
}
