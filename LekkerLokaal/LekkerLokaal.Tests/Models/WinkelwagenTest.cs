using LekkerLokaal.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace LekkerLokaal.Tests.Models
{
    public class WinkelwagenTest
    {
        //Voor de testen van de klasse Winkelwagen maken we vanzelfsprekend een winkelwagen aan alsook twee cadeaubonnen.
        private readonly Winkelwagen _winkelwagen;
        private readonly Bon _bon1;
        private readonly Bon _bon2;

        public WinkelwagenTest()
        {
            //Twee handelaars die cadeaubonnen hebben die vallen onder dezelfde categorie, genomen uit de LekkerLokaalDataInitializer.
            Handelaar Handelaar81 = new Handelaar("Fnac", "fnac@gmail.com", "De multimedia specialist in Europa.", "BE 588 137 284", @"images\handelaar\51\thumb.jpg", "Arbeidstraat", "14", 9300, "Aalst");
            Handelaar Handelaar82 = new Handelaar("Mediamarkt", "mediamarkt@gmail.com", "Electronica tegen een spot prijs.", "BE 812 573 731", @"images\handelaar\52\thumb.jpg", "Mechelsesteenweg", "138", 9200, "Dendermonde");
            Categorie multimedia = new Categorie("Multimedia", "fa-laptop");

            //Merk op: we gebruiken slechts twee verschillende bonnen omdat bij het toevoegen van een bon aan de winkelwagen het gewenste bedrag meegegeven wordt.
            _winkelwagen = new Winkelwagen();
            _bon1 = new Bon("Fnac Aalst", 3, 377, "De multimedia specialist in Europa", 54, @"images\bon\61\", multimedia, "Arbeidstraat", "14", 9300, "Aalst", Handelaar81, Aanbieding.Geen);
            _bon2 = new Bon("Mediamarkt Dendermonde", 46, 433, "Electronica tegen een spot prijs", 45, @"images\bon\62\", multimedia, "Mechelsesteenweg", "138", 9200, "Dendermonde", Handelaar82, Aanbieding.Geen);

            //Normaal gezien krijgen cadeaubonnen automatisch een id toegewezen in de databank maar om te testen moeten we dit manueel doen.
            _bon1.BonId = 1;
            _bon2.BonId = 2;
        }

        [Fact]
        public void NieuweWinkelwagen_IsLeeg()
        {
            Assert.Equal(0, _winkelwagen.AantalBonnen);
            Assert.True(_winkelwagen.IsLeeg);
        }

        [Fact]
        public void VoegLijnToe_VoegtBonToeAanWinkelwagen()
        {
            _winkelwagen.VoegLijnToe(_bon1, 1, 50);
            _winkelwagen.VoegLijnToe(_bon1, 15, 100);
            _winkelwagen.VoegLijnToe(_bon2, 5, 30);
            _winkelwagen.VoegLijnToe(_bon2, 10, 15);

            Assert.Equal(31, _winkelwagen.AantalBonnen);
            Assert.Equal(4, _winkelwagen.WinkelwagenLijnen.Count());

            Assert.Single(_winkelwagen.WinkelwagenLijnen.Where(w => w.Bon.BonId == _bon1.BonId && w.Prijs == 50));
            Assert.Single(_winkelwagen.WinkelwagenLijnen.Where(w => w.Bon.BonId == _bon1.BonId && w.Prijs == 100));
            Assert.Single(_winkelwagen.WinkelwagenLijnen.Where(w => w.Bon.BonId == _bon2.BonId && w.Prijs == 30));
            Assert.Single(_winkelwagen.WinkelwagenLijnen.Where(w => w.Bon.BonId == _bon2.BonId && w.Prijs == 15));

            Assert.Equal(1, _winkelwagen.WinkelwagenLijnen.SingleOrDefault(w => w.Bon.BonId == _bon1.BonId && w.Prijs == 50).Aantal);
            Assert.Equal(15, _winkelwagen.WinkelwagenLijnen.SingleOrDefault(w => w.Bon.BonId == _bon1.BonId && w.Prijs == 100).Aantal);
            Assert.Equal(5, _winkelwagen.WinkelwagenLijnen.SingleOrDefault(w => w.Bon.BonId == _bon2.BonId && w.Prijs == 30).Aantal);
            Assert.Equal(10, _winkelwagen.WinkelwagenLijnen.SingleOrDefault(w => w.Bon.BonId == _bon2.BonId && w.Prijs == 15).Aantal);
        }

        [Fact]
        public void VoegLijnToe_ZelfdeBonZelfdePrijs_VoegtAantalToeAanBestaandeWinkelwagenlijn()
        {
            _winkelwagen.VoegLijnToe(_bon1, 1, 50);
            _winkelwagen.VoegLijnToe(_bon1, 9, 50);
            _winkelwagen.VoegLijnToe(_bon2, 8, 100);
            _winkelwagen.VoegLijnToe(_bon2, 6, 100);

            Assert.Equal(24, _winkelwagen.AantalBonnen);
            Assert.Equal(2, _winkelwagen.WinkelwagenLijnen.Count());

            Assert.Equal(10, _winkelwagen.WinkelwagenLijnen.SingleOrDefault(w => w.Bon.BonId == _bon1.BonId && w.Prijs == 50).Aantal);
            Assert.Equal(14, _winkelwagen.WinkelwagenLijnen.SingleOrDefault(w => w.Bon.BonId == _bon2.BonId && w.Prijs == 100).Aantal);
        }

        [Fact]
        public void VerwijderLijn_BonZitInWinkelWagen_VerwijdertBonUitWinkelwagen()
        {
            _winkelwagen.VoegLijnToe(_bon1, 9, 50);
            _winkelwagen.VoegLijnToe(_bon2, 8, 100);
            _winkelwagen.VoegLijnToe(_bon2, 6, 75);

            _winkelwagen.VerwijderLijn(_bon2, 100);

            Assert.Equal(15, _winkelwagen.AantalBonnen);
            Assert.Equal(2, _winkelwagen.WinkelwagenLijnen.Count());
            Assert.Single(_winkelwagen.WinkelwagenLijnen.Where(w => w.Bon.BonId == _bon1.BonId && w.Prijs == 50));
            Assert.Single(_winkelwagen.WinkelwagenLijnen.Where(w => w.Bon.BonId == _bon2.BonId && w.Prijs == 75));
        }

        [Fact]
        public void MaakLeeg_BonnenInWinkelwagen_MaaktWinkelwagenLeeg()
        {
            _winkelwagen.VoegLijnToe(_bon1, 9, 50);
            _winkelwagen.VoegLijnToe(_bon2, 8, 100);
            _winkelwagen.VoegLijnToe(_bon2, 6, 75);

            _winkelwagen.MaakLeeg();

            Assert.Equal(0, _winkelwagen.AantalBonnen);
            Assert.True(_winkelwagen.IsLeeg);
        }

        [Fact]
        public void TotaleWaarde_IsSomVanTotalenVanWinkelwagenlijnen()
        {
            _winkelwagen.VoegLijnToe(_bon1, 1, 50);
            _winkelwagen.VoegLijnToe(_bon1, 2, 50);
            _winkelwagen.VoegLijnToe(_bon1, 3, 75);
            _winkelwagen.VoegLijnToe(_bon2, 4, 100);
            _winkelwagen.VoegLijnToe(_bon2, 5, 100);
            _winkelwagen.VoegLijnToe(_bon2, 6, 10);

            Assert.Equal((3 * 50 + 3 * 75 + 9 * 100 + 6 * 10), _winkelwagen.TotaleWaarde);
        }

        [Fact]
        public void VerhoogAantal_BestaandeWinkelwagenlijn_VerhoogtAantalMet1()
        {
            _winkelwagen.VoegLijnToe(_bon1, 10, 50);
            Assert.Equal(10, _winkelwagen.WinkelwagenLijnen.SingleOrDefault(w => w.Bon.BonId == _bon1.BonId && w.Prijs == 50).Aantal);

            _winkelwagen.VerhoogAantal(_bon1.BonId, 50);
            Assert.Equal(11, _winkelwagen.WinkelwagenLijnen.SingleOrDefault(w => w.Bon.BonId == _bon1.BonId && w.Prijs == 50).Aantal);
        }

        [Fact]
        public void VerlaagAantal_BestaandeWinkelwagenlijn_VerlaagtAantalMet1()
        {
            _winkelwagen.VoegLijnToe(_bon1, 10, 50);
            Assert.Equal(10, _winkelwagen.WinkelwagenLijnen.SingleOrDefault(w => w.Bon.BonId == _bon1.BonId && w.Prijs == 50).Aantal);

            _winkelwagen.VerlaagAantal(_bon1.BonId, 50);
            Assert.Equal(9, _winkelwagen.WinkelwagenLijnen.SingleOrDefault(w => w.Bon.BonId == _bon1.BonId && w.Prijs == 50).Aantal);
        }

        [Fact]
        public void VerlaagAantal_BestaandeWinkelwagenlijnMetAantal1_VerwijdertWinkelwagenlijn()
        {
            _winkelwagen.VoegLijnToe(_bon1, 1, 50);
            Assert.Equal(1, _winkelwagen.WinkelwagenLijnen.SingleOrDefault(w => w.Bon.BonId == _bon1.BonId && w.Prijs == 50).Aantal);

            _winkelwagen.VerlaagAantal(_bon1.BonId, 50);
            Assert.Equal(0, _winkelwagen.AantalBonnen);
            Assert.True(_winkelwagen.IsLeeg);
        }
    }
}
