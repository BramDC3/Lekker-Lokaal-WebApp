﻿using LekkerLokaal.Models.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LekkerLokaal.Data.Repositories
{
    public class GebruikerRepository : IGebruikerRepository
    {
        private readonly DbSet<Gebruiker> _gebruikers;
        private readonly ApplicationDbContext _dbContext;

        public GebruikerRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
            _gebruikers = dbContext.Gebruikers;
        }

        public void Add(Gebruiker gebruiker)
        {
            _gebruikers.Add(gebruiker);
        }

        public Gebruiker GetBy(string email)
        {
            return _gebruikers.Include(g => g.Bestellingen).Include(g => g.Geslacht).SingleOrDefault(g => g.Emailadres == email);
        }

        public void SaveChanges()
        {
            _dbContext.SaveChanges();
        }
    }
}
