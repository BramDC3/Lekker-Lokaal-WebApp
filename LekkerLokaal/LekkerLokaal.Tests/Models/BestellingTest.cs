using LekkerLokaal.Models.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace LekkerLokaal.Tests.Models
{
    public class BestellingTest
    {
        //Voor de testen van de klasse Bestelling maken we vanzelfsprekend een bestelling aan alsook drie cadeaubonnen.
        private readonly Bestelling _bestelling;
        private readonly Bon _bon1;
        private readonly Bon _bon2;
        private readonly Bon _bon3;

        public BestellingTest()
        {
            //Drie handelaars die cadeaubonnen hebben die vallen onder dezelfde categorie, genomen uit de LekkerLokaalDataInitializer + een lege winkelmand.
            Handelaar Handelaar81 = new Handelaar("Fnac", "fnac@gmail.com", "De multimedia specialist in Europa.", "BE 588 137 284", @"images\handelaar\51\thumb.jpg", "Arbeidstraat", "14", 9300, "Aalst");
            Handelaar Handelaar82 = new Handelaar("Mediamarkt", "mediamarkt@gmail.com", "Electronica tegen een spot prijs.", "BE 812 573 731", @"images\handelaar\52\thumb.jpg", "Mechelsesteenweg", "138", 9200, "Dendermonde");
            Handelaar Handelaar83 = new Handelaar("Van Den Borre", "vandenborre@gmail.com", "Koffiezets voor 12€.", "BE 253 500 301", @"images\handelaar\53\thumb.jpg", "Sint-Pietersnieuwstraat", "124", 9000, "Gent");
            Categorie multimedia = new Categorie("Multimedia", "fa-laptop");
            Winkelwagen winkelwagen = new Winkelwagen();

            _bon1 = new Bon("Fnac Aalst", 3, 377, "De multimedia specialist in Europa", 54, @"images\bon\61\", multimedia, "Arbeidstraat", "14", 9300, "Aalst", Handelaar81, Aanbieding.Geen);
            _bon2 = new Bon("Mediamarkt Dendermonde", 46, 433, "Electronica tegen een spot prijs", 45, @"images\bon\62\", multimedia, "Mechelsesteenweg", "138", 9200, "Dendermonde", Handelaar82, Aanbieding.Geen);
            _bon3 = new Bon("Van Den Borre Gent", 31, 181, "Koffiezets voor 12€", 15, @"images\bon\63\", multimedia, "Sint-Pietersnieuwstraat", "124", 9000, "Gent", Handelaar83, Aanbieding.Geen);

            winkelwagen.VoegLijnToe(_bon1, 5, 10);
            winkelwagen.VoegLijnToe(_bon2, 3, 30);

            _bestelling = new Bestelling(winkelwagen);
        }

        [Fact]
        public void BestellingTotaal_RetourneertSomVanTotaalVanBestellijnen()
        {
            Assert.Equal(140, _bestelling.BestellingTotaal);
        }

        [Fact]
        public void HeeftBesteld_ProductZitInBestelling_RetourneertTrue()
        {
            Assert.True(_bestelling.HeeftBesteld(_bon1));
            Assert.True(_bestelling.HeeftBesteld(_bon2));
        }

        [Fact]
        public void HeeftBesteld_ProductZitNietInBestelling_RetourneertFalse()
        {
            Assert.False(_bestelling.HeeftBesteld(_bon3));
        }
    }
}
