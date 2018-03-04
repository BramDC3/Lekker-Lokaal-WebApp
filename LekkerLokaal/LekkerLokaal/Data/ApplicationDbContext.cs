﻿using LekkerLokaal.Models.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using LekkerLokaal.Models;
using LekkerLokaal.Data.Mappers;

namespace LekkerLokaal.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Bestelling> Bestellingen { get; set; }
        public DbSet<Bon> Bonnen { get; set; }
        public DbSet<Categorie> Categorieen { get; set; }
        public DbSet<Gebruiker> Gebruikers { get; set; }
        public DbSet<Handelaar> Handelaars { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfiguration(new BestelLijnConfiguration());
            builder.Ignore<Winkelwagen>();
            builder.Ignore<WinkelwagenLijn>();
        }
    }
}
