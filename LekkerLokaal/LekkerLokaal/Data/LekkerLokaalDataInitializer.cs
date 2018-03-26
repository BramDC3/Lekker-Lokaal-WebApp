using Microsoft.AspNetCore.Identity;
using LekkerLokaal.Models.Domain;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using LekkerLokaal.Models;

namespace LekkerLokaal.Data
{
    public class LekkerLokaalDataInitializer
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly UserManager<ApplicationUser> _userManager;

        public LekkerLokaalDataInitializer(ApplicationDbContext dbContext, UserManager<ApplicationUser> userManager)
        {
            _dbContext = dbContext;
            _userManager = userManager;
        }

        public async Task InitializeData()
        {
            _dbContext.Database.EnsureDeleted();
            if (_dbContext.Database.EnsureCreated())
            {
                Categorie eten_drinken = new Categorie("Eten & drinken", "fa-utensils");
                Categorie fitness = new Categorie("Fitness", "fa-heartbeat");
                Categorie uitstappen = new Categorie("Uitstappen", "fa-plane");
                Categorie huis_tuin = new Categorie("Huis & Tuin", "fa-home");
                Categorie events = new Categorie("Events", "fa-calendar");
                Categorie beauty = new Categorie("Beauty", "fa-female");
                Categorie interieur = new Categorie("Interieur", "fa-image");
                Categorie kledij = new Categorie("Kledij", "fa-umbrella");
                Categorie multimedia = new Categorie("Multimedia", "fa-laptop");
                Categorie generiek = new Categorie("Generiek", "fa-gift");

                var categories = new List<Categorie>
                {
                    eten_drinken, events, beauty, fitness, interieur, kledij, multimedia, uitstappen, huis_tuin, generiek
                };
                _dbContext.Categorieen.AddRange(categories);


                Handelaar Handelaar01 = new Handelaar("Restaurant Lekker", "lekker@gmail.com", "Met deze bon kan u lekker komen eten in ons restaurant genaamd Restaurant Lekker.", "BE 458 110 637", @"images\handelaar\1\thumb.jpg", "Arbeidstraat", "14", 9300, "Aalst");
                Handelaar Handelaar02 = new Handelaar("Bontinck", "bontinck@gmail.com", "Met deze bon kan u onze met passie gemaakte dessertjes komen proeven.", "BE 476 452 406", @"images\handelaar\2\thumb.jpg", "Paepestraat", "178", 9260, "Wichelen");
                Handelaar Handelaar03 = new Handelaar("Schets", "schets@gmail.com", "Alle lokale bieren zijn hier te vinden! Er kan ook plaatselijk geproefd worden.", "BE 260 147 662", @"images\handelaar\3\thumb.jpg", "Ravensteinstraat", "50", 1000, "Brussel");
                Handelaar Handelaar04 = new Handelaar("De Coninck's", "coninck@gmail.com", "De lekkerste cocktails zijn hier te vinden. Alleen hier te vinden tegen een goed prijs!", "BE 568 718 486", @"images\handelaar\4\thumb.jpg", "Sint-Pietersnieuwstraat", "124", 9000, "Gent");
                Handelaar Handelaar05 = new Handelaar("Wijnproeverij Handelaar01", "Handelaar01@gmail.com", "Met deze bon kan je bij wijnproeverij Handelaar01 genieten van een gezellige avond. Je zal er meer uitleg krijgen over de verschillende soorten wijnen en van elke soort mogen proeven, allen vergezeld met een passend hapje. Eens de sessie over is kan met de bon, wijn gekocht worden. Enkele merken die je hier kan verwachten zijn: Francis Ford Coppola, Franschhoek Cellar, Fushs Reinhardt, Gran Sasso, Grande Provence, Guadalupe, Guillamen I Muri, ..."
                    , "BE 305 678 557", @"images\handelaar\5\thumb.jpg", "Arbeidstraat", "14", 9300, "Aalst");
                Handelaar Handelaar06 = new Handelaar("'t Sandwichke", "sandwich@gmail.com", "Voor al uw vegatarische noden kan u bij ons terecht.", "BE 360 874 067", @"images\handelaar\6\thumb.jpg", "Arbeidstraat", "14", 9300, "Aalst");
                Handelaar Handelaar07 = new Handelaar("McDonalds", "mc@gmail.com", "Voor een snelle hap moet u bij ons zijn!", "BE 686 045 577", @"images\handelaar\7\thumb.jpg", "Arbeidstraat", "14", 9300, "Aalst");
                Handelaar Handelaar08 = new Handelaar("SOS Piet", "sospiet@gmail.com", "Het echte restaurant van SOS Piet. Altijd de beste maatlijd voor een gezonde prijs!", "BE 035 212 186", @"images\handelaar\8\thumb.jpg", "Paepestraat", "178", 9260, "Wichelen");
                Handelaar Handelaar09 = new Handelaar("CoBoSh", "cobosh@gmail.com", "Voor de beste wijnen moet je bij ons zijn! Hierbij kan altijd een hapje geserveerd worden.", "BE 570 261 327", @"images\handelaar\9\thumb.jpg", "Arbeidstraat", "14", 9300, "Aalst");

                Handelaar Handelaar11 = new Handelaar("Sanitas", "sanitas@gmail.com", "Bekenste fitness van Wichelen.", "BE 652 760 933", @"images\handelaar\10\thumb.jpg", "Paepestraat", "178", 9260, "Wichelen");
                Handelaar Handelaar12 = new Handelaar("Fitness Basic-Fit", "basicfit@gmail.com", "Bekenste fitness van België met vestigingen over het hele land.", "BE 652 760 204", @"images\handelaar\11\thumb.jpg", "Ravensteinstraat", "50", 1000, "Brussel");

                Handelaar Handelaar21 = new Handelaar("Aalst", "aalst@gmail.com", "De recreatiedienst van Aalst staat in voor tal van speciale activiteiten.", "BE 656 564 542", @"images\handelaar\11\thumb.jpg", "Arbeidstraat", "14", 9300, "Aalst");
                Handelaar Handelaar22 = new Handelaar("Walibi", "walibi@gmail.com", "Een pretpark voor klein en groot.", "BE 557 481 167", @"images\handelaar\12\thumb.jpg", "Mechelsesteenweg ", "138", 9200, "Dendermonde");
                Handelaar Handelaar23 = new Handelaar("NMBS", "trein@gmail.com", "De spoorwegdienst van België. Staakt liever dan te werken.", "BE 815 755 657", @"images\handelaar\13\thumb.jpg", "Torhoutsesteenweg", "611", 8400, "Oostende");
                Handelaar Handelaar24 = new Handelaar("Disneyland Paris", "parijs@gmail.com", "Een van de grootste pretparken in Frankrijk.", "BE 802 726 432", @"images\handelaar\14\thumb.jpg", "Leopoldlaan", "1", 1930, "Zaventem");
                Handelaar Handelaar25 = new Handelaar("Hamme", "hamme@gmail.com", "Stad Hamme", "BE 263 282 287", @"images\handelaar\15\thumb.jpg", "Rue Joseph Lamotte", "2", 5580, "Han-sur-Lesse");
                Handelaar Handelaar26 = new Handelaar("Breemdonk", "breemdonk@gmail.com", "Gemeente Breemdonk", "BE 703 431 007", @"images\handelaar\16\thumb.jpg", "Brandstraat", "57", 2830, "Willebroek");

                Handelaar Handelaar31 = new Handelaar("Brenk", "brenk@gmail.com", "Stel zelf uw setje bloemen samen met deze bon.", "BE 680 614 508", @"images\handelaar\17\thumb.jpg", "Arbeidstraat", "14", 9300, "Aalst");
                Handelaar Handelaar32 = new Handelaar("De Mol", "molleken@gmail.com", "Heb je grond nodig voor in een pot", "BE 415 655 144", @"images\handelaar\18\thumb.jpg", "Kasteeldreef", "15", 9340, "Lede");
                Handelaar Handelaar33 = new Handelaar("Schelfhout", "schelfhout@gmail.com", "Schelfhout, waar moet je andes zijn!", "BE 376 468 351", @"images\handelaar\19\thumb.jpg", "Arbeidstraat", "14", 9300, "Aalst");
                Handelaar Handelaar34 = new Handelaar("Liesje", "lies@gmail.com", "Lies, verkoopt ook wel een madelief", "BE 368 526 450", @"images\handelaar\20\thumb.jpg", "Sint-Pietersnieuwstraat", "124", 9000, "Gent");
                Handelaar Handelaar35 = new Handelaar("Funa Lima", "funa_lima@gmail.com", "Vissen, fonteinen, dieraccesoire...", "BE 146 730 153", @"images\handelaar\21\thumb.jpg", "Kasteeldreef", "15", 9340, "Lede");
                Handelaar Handelaar36 = new Handelaar("Blub", "blub@gmail.com", "Blub, de winkel voor vis enthousiasten", "BE 227 103 604", @"images\handelaar\22\thumb.jpg", "Arbeidstraat", "14", 9300, "Aalst");
                Handelaar Handelaar37 = new Handelaar("G-Bont", "grasb@gmail.com", "Jaren ervaring in het snoeien van alle gazons", "BE 250 653 443", @"images\handelaar\23\thumb.jpg", "Paepestraat", "178", 9260, "Wichelen");
                Handelaar Handelaar38 = new Handelaar("Aveve", "aveve@gmail.com", "Bij de boerenbond vind je altijd wat je zoekt", "BE 262 005 555", @"images\handelaar\24\thumb.jpg", "Arbeidstraat", "14", 9300, "Aalst");
                Handelaar Handelaar39 = new Handelaar("Groener Gras", "groengras@gmail.com", "Gazon voorzieningen voor iedereen die een groen gazon wil!", "BE 773 202 200", @"images\handelaar\25\thumb.jpg", "Cooppallaan ", "40", 9230, "Wetteren");

                Handelaar Handelaar41 = new Handelaar("Pukkelpop", "ppk@gmail.com", "Tickets of coupons voor pukkelpok.", "BE 146 815 077", @"images\handelaar\26\thumb.jpg", "Paepestraat", "178", 9260, "Wichelen");
                Handelaar Handelaar42 = new Handelaar("Bierfeesten", "bierfeesten@gmail.com", "De veste feesten in Lokeren: De Lokerse Bierfeesten!", "BE 146 815 077", @"images\handelaar\26\thumb.jpg", "Kleine Dam", "1", 9160, "Lokeren");
                Handelaar Handelaar43 = new Handelaar("Gentse Feesten", "feesten-gent@gmail.com", "Het grootste feest in Gent!", "BE 241 543 268", @"images\handelaar\28\thumb.jpg", "Sint-Pietersnieuwstraat", "124", 9000, "Gent");
                Handelaar Handelaar44 = new Handelaar("Gameforce", "games@gmail.com", "Grootste game beurs in België. Nu ook kortingsbonnen verkrijgbaar!", "BE 027 033 486", @"images\handelaar\29\thumb.jpg", "Ravensteinstraat", "50", 1000, "Brussel");
                Handelaar Handelaar45 = new Handelaar("Garage Ferrari", "ferfer@gmail.com", "Beste cadeau voor een Ferrari liefhebber!", "BE 022 334 837", @"images\handelaar\30\thumb.jpg", "Paepestraat", "178", 9260, "Wichelen");
                Handelaar Handelaar46 = new Handelaar("Facts", "facts@gmail.com", "Een van de grootste cosplay beurzen van België.", "BE 721 088 160", @"images\handelaar\31\thumb.jpg", "Sint-Pietersnieuwstraat", "124", 9000, "Gent");

                Handelaar Handelaar51 = new Handelaar("Nude", "nude@gmail.com", "Het bekendste merk voor beauty producten!", "BE 736 764 083", @"images\handelaar\32\thumb.jpg", "Paepestraat", "178", 9260, "Wichelen");
                Handelaar Handelaar52 = new Handelaar("Restaurant Lekker", "lekker@gmail.com", "korte beschrijving", "BE 705 084 728", @"images\handelaar\33\thumb.jpg", "Arbeidstraat", "14", 9300, "Aalst");
                Handelaar Handelaar53 = new Handelaar("Ici Paris", "ici-paris@gmail.com", "Voor een parfum moet je bij ons zijn!", "BE 780 260 577", @"images\handelaar\34\thumb.jpg", "Arbeidstraat", "14", 9300, "Aalst");

                Handelaar Handelaar61 = new Handelaar("Sofa & Co", "sofaco@gmail.com", "Vind de gepaste sofa bij ons!", "BE 047 046 168", @"images\handelaar\35\thumb.jpg", "Arbeidstraat", "14", 9300, "Aalst");
                Handelaar Handelaar62 = new Handelaar("Deba", "deba@gmail.com", "Voor elk interieur stuk kan u bij ons terecht!", "BE 442 622 757", @"images\handelaar\36\thumb.jpg", "Arbeidstraat", "14", 9300, "Aalst");
                Handelaar Handelaar63 = new Handelaar("Ikea", "ikea@gmail.com", "Hebt u iets nodig tegen een lage prijs dan kan u altijd bij ons terecht.", "BE 578 162 528", @"images\handelaar\37\thumb.jpg", "Paepestraat", "178", 9260, "Wichelen");
                Handelaar Handelaar64 = new Handelaar("Leen Bakker", "leen-bakker@gmail.com", "Iets kopen dan bent u op de juiste plaats.", "BE 365 006 747", @"images\handelaar\38\thumb.jpg", "Sint-Pietersnieuwstraat", "124", 9000, "Gent");
                Handelaar Handelaar65 = new Handelaar("Salon Ballon", "salon-ballon@gmail.com", "De speciaal zaak die u zocht.", "BE 063 225 184", @"images\handelaar\39\thumb.jpg", "Sint-Pietersnieuwstraat", "124", 9000, "Gent");
                Handelaar Handelaar66 = new Handelaar("Donald", "donald-keukens@gmail.com", "Keuken nodig kom dan bij ons!", "BE 206 664 777", @"images\handelaar\40\thumb.jpg", "Arbeidstraat", "14", 9300, "Aalst");
                Handelaar Handelaar67 = new Handelaar("Modern Gent", "gent-modern@gmail.com", "Modern interieur tegen een prijsje.", "BE 140 378 850", @"images\handelaar\41\thumb.jpg", "Sint-Pietersnieuwstraat", "124", 9000, "Gent");
                Handelaar Handelaar68 = new Handelaar("Kunst & Kitch", "kunst-kitch@gmail.com", "Kunst hoeft niet altijd lelijk te zijn.", "BE 466 753 428", @"images\handelaar\42\thumb.jpg", "Paepestraat", "178", 9260, "Wichelen");
                Handelaar Handelaar69 = new Handelaar("Gill", "gill@gmail.com", "Interieur tegen een prijsje.", "BE 171 663 118", @"images\handelaar\43\thumb.jpg", "Arbeidstraat", "14", 9300, "Aalst");

                Handelaar Handelaar71 = new Handelaar("C&A", "cena@gmail.com", "De Kleding winkel van Aalst.", "BE 081 135 314", @"images\handelaar\44\thumb.jpg", "Arbeidstraat", "14", 9300, "Aalst");
                Handelaar Handelaar72 = new Handelaar("AS Adventure", "as-adventure@gmail.com", "Outdoor kleding en alles voor je outdoor ervaring.", "BE 266 553 200", @"images\handelaar\45\thumb.jpg", "Paepestraat", "178", 9260, "Wichelen");
                Handelaar Handelaar73 = new Handelaar("Ultra Wet", "ultra-wet@gmail.com", "De kldeingspecialist voor droog en nat.", "BE 446 384 070", @"images\handelaar\46\thumb.jpg", "Arbeidstraat", "14", 9300, "Aalst");
                Handelaar Handelaar74 = new Handelaar("Holiday", "holiday@gmail.com", "Voor al uw feestkledij.", "BE 313 402 666", @"images\handelaar\47\thumb.jpg", "Sint-Pietersnieuwstraat", "124", 9000, "Gent");
                Handelaar Handelaar75 = new Handelaar("Bram's Fashion", "bram@gmail.com", "Voor ieder wat wilds.", "BE 402 156 543", @"images\handelaar\48\thumb.jpg", "Paepestraat", "178", 9260, "Wichelen");
                Handelaar Handelaar76 = new Handelaar("Bontinck Panther's", "panther@gmail.com", "Pants from Bontinck are dreams for legs.", "BE 521 001 106", @"images\handelaar\49\thumb.jpg", "Arbeidstraat", "14", 9300, "Aalst");
                Handelaar Handelaar77 = new Handelaar("Bre Bra", "bre-bra@gmail.com", "Van A tot Z  u vindt het bij ons.", "BE 521 001 103", @"images\handelaar\49\thumb.jpg", "Sint-Pietersnieuwstraat", "124", 9000, "Gent");
                Handelaar Handelaar78 = new Handelaar("Pikantje", "pikant@gmail.com", "Eroiek u vindt het bij ons.", "BE 214 232 134", @"images\handelaar\50\thumb.jpg", "Arbeidstraat", "14", 9300, "Aalst");

                Handelaar Handelaar81 = new Handelaar("Fnac", "fnac@gmail.com", "De multimedia specialist in Europa.", "BE 588 137 284", @"images\handelaar\51\thumb.jpg", "Arbeidstraat", "14", 9300, "Aalst");
                Handelaar Handelaar82 = new Handelaar("Mediamarkt", "mediamarkt@gmail.com", "Electronica tegen een spot prijs.", "BE 812 573 731", @"images\handelaar\52\thumb.jpg", "Mechelsesteenweg", "138", 9200, "Dendermonde");
                Handelaar Handelaar83 = new Handelaar("Van Den Borre", "vandenborre@gmail.com", "Koffiezets voor 12€.", "BE 253 500 301", @"images\handelaar\53\thumb.jpg", "Sint-Pietersnieuwstraat", "124", 9000, "Gent");
                Handelaar Handelaar84 = new Handelaar("Bontinck IT", "bontinck-it@gmail.com", "Een probleempje groot of klein, dan moet je bij IT Lennert zijn.", "BE 561 032 078", @"images\handelaar\54\thumb.jpg", "Maalse Steenweg", "50", 8310, "Brugge");
                Handelaar Handelaar85 = new Handelaar("Schets Apple Premium", "schets-apple@gmail.com", "Alle laatste Apple producten moet u bij ons zijn.", "BE 786 056 478", @"images\handelaar\55\thumb.jpg", "Paepestraat", "178", 9260, "Wichelen");
                Handelaar Handelaar86 = new Handelaar("Lab9", "lab-9@gmail.com", "Officiele Apple reseller.", "BE 075 881 157", @"images\handelaar\56\thumb.jpg", "Arbeidstraat", "14", 9300, "Aalst");
                Handelaar Handelaar87 = new Handelaar("De Conincks Screen Repair", "screenrepair@gmail.com", "Een ongelukje is snel gebeurd.", "BE 068 276 242", @"images\handelaar\57\thumb.jpg", "Paepestraat", "178", 9260, "Wichelen");
                Handelaar Handelaar88 = new Handelaar("Medion Custom", "medion@gmail.com", "Medion laptop op maat gemaakt", "BE 116 728 241", @"images\handelaar\58\thumb.jpg", "Sint-Pietersnieuwstraat", "124", 9000, "Gent");
                Handelaar Handelaar89 = new Handelaar("Dell Dinosaur", "dell@gmail.com", "MS Dos specialist", "BE 774 855 608", @"images\handelaar\59\thumb.jpg", "Paepestraat", "178", 9260, "Wichelen");


                Handelaar Handelaar91 = new Handelaar("Generiek", "generiek@gmail.com", "generiek", "BE 774 123 518", @"images\handelaar\59\thumb.jpg", "Ravensteinstraat", "50", 1000, "Brussel");

                Handelaar Handelaar10 = new Handelaar("ChaCha", "chacha@gmail.com", "Voor de beste wijnen moet je bij ons zijn! Hierbij kan altijd een hapje geserveerd worden.", "BE 570 261 847", @"images\handelaar\60\thumb.jpg", "straat", "huisnummer", 0101, "STAD");
                var handelaars = new List<Handelaar>
                {
                    Handelaar01, Handelaar02, Handelaar03, Handelaar04, Handelaar05, Handelaar06, Handelaar07, Handelaar08, Handelaar09, Handelaar10, Handelaar11, Handelaar21, Handelaar22, Handelaar23, Handelaar24, Handelaar25, Handelaar26, Handelaar31, Handelaar32, Handelaar33, Handelaar34, Handelaar35, Handelaar36, Handelaar37, Handelaar38, Handelaar39, Handelaar41, Handelaar42, Handelaar43, Handelaar44, Handelaar45, Handelaar46, Handelaar51, Handelaar52, Handelaar53, Handelaar61, Handelaar62, Handelaar63, Handelaar64, Handelaar65, Handelaar66, Handelaar67, Handelaar68, Handelaar69, Handelaar71, Handelaar72, Handelaar73, Handelaar74, Handelaar75, Handelaar76, Handelaar77, Handelaar78, Handelaar81, Handelaar82, Handelaar83, Handelaar84, Handelaar85, Handelaar86, Handelaar87, Handelaar88, Handelaar89, Handelaar91
                };

                _dbContext.Handelaars.AddRange(handelaars);

                Bon bon01 = new Bon("Restaurant lekker", 25, 50, "3 sterren resaurant in het centrum van Aalst.", 17, @"images\bon\1\", eten_drinken, "Arbeidstraat", "14", 9300, "Aalst", Handelaar01, Aanbieding.Geen);
                Bon bon02 = new Bon("Dessertbar chez Bontinck", 5, 30, "Met passie gemaakte dessertjes in het mooie Schellebelle.", 242, @"images\bon\2\", eten_drinken, "Paepestraat", "178", 9260, "Wichelen", Handelaar02, Aanbieding.Slider);
                Bon bon03 = new Bon("Bierspecialist Schets", 10, 20, "Meer dan 70 Belgische bieren in een gezellige kroeg.", 42, @"images\bon\3\", eten_drinken, "Ravensteinstraat", "50", 1000, "Brussel", Handelaar03, Aanbieding.Geen);
                Bon bon04 = new Bon("De Coninck's cocktail", 5, 15, "Een VIP cocktailbar met live optredens van lokale muzikanten.", 24, @"images\bon\4\", eten_drinken, "Sint-Pietersnieuwstraat", "124", 9000, "Gent", Handelaar04, Aanbieding.Geen);
                Bon bon05 = new Bon("Wijnproeverij BraLenBre", 45, 75, "Keuze uit verschillende wijnen vergezeld met een hapje.", 124, @"images\bon\5\", eten_drinken, "Arbeidstraat", "14", 9300, "Aalst", Handelaar05, Aanbieding.Slider);
                Bon bon06 = new Bon("Veggiebar 't Sandwichke", 15, 30, "Het bewijs dat vegetarisch eten lekker kan zijn.", 45, @"images\bon\6\", eten_drinken, "Arbeidstraat", "14", 9300, "Aalst", Handelaar06, Aanbieding.Geen);
                Bon bon07 = new Bon("Fastfood McDonalds", 1, 5, "De keten met keuzes voor iedereen.", 98, @"images\bon\7\", eten_drinken, "Arbeidstraat", "14", 9300, "Aalst", Handelaar07, Aanbieding.Geen);
                Bon bon08 = new Bon("Restaurant SOS Piet", 75, 150, "5 sterren restaurant met de enige echte SOS Piet als kok.", 21, @"images\bon\8\", eten_drinken, "Paepestraat", "178", 9260, "Wichelen", Handelaar08, Aanbieding.Geen);
                Bon bon09 = new Bon("Wijnproeverij CoBoSh", 25, 75, "Keuze uit verschillende wijnen vergezeld met een hapje.", 47, @"images\bon\9\", eten_drinken, "Arbeidstraat", "14", 9300, "Aalst", Handelaar09, Aanbieding.Geen);
                Bon bon10 = new Bon("Wijnproeverij chacha", 22, 75, "Hapje drankje favoriet muziekje.", 22, @"images\bon\10\", eten_drinken, "Ravensteinstraat", "50", 1000, "Brussel", Handelaar10, Aanbieding.Geen);


                Bon bon11 = new Bon("Sanitas Wichelen", 5, 30, "Ideale fitness voor oud en jong", 83, @"images\bon\11\", fitness, "Paepestraat", "178", 9260, "Wichelen", Handelaar11, Aanbieding.Geen);
                Bon bon12 = new Bon("Fitness Basic-Fit Aalst", 5, 30, "Bekenste fitness van België met vestigingen over het hele land.", 75, @"images\bon\12\", fitness, "Arbeidstraat", "14", 9300, "Aalst", Handelaar12, Aanbieding.Geen);
                Bon bon13 = new Bon("Fitness Basic-Fit Gent", 4, 30, "Bekenste fitness van België met vestigingen over het hele land.", 8, @"images\bon\13\", fitness, "Sint-Pietersnieuwstraat", "124", 9000, "Gent", Handelaar12, Aanbieding.Geen);
                Bon bon14 = new Bon("Fitness Basic-Fit Brussel", 6, 30, "Bekenste fitness van België met vestigingen over het hele land.", 53, @"images\bon\14\", fitness, "Ravensteinstraat", "50", 1000, "Brussel", Handelaar12, Aanbieding.Geen);
                Bon bon15 = new Bon("Fitness Basic-Fit Brugge", 8, 30, "Bekenste fitness van België met vestigingen over het hele land.", 53, @"images\bon\15\", fitness, "Maalse Steenweg", "50", 8310, "Brugge", Handelaar12, Aanbieding.Geen);
                Bon bon16 = new Bon("Fitness Basic-Fit Sint-Truiden", 5, 30, "Bekenste fitness van België met vestigingen over het hele land.", 72, @"images\bon\16\", fitness, "Luikersteenweg ", "40", 3800, "Sint-Truiden", Handelaar12, Aanbieding.Geen);
                Bon bon17 = new Bon("Fitness Basic-Fit Wetteren", 6, 30, "Bekenste fitness van België met vestigingen over het hele land.", 65, @"images\bon\17\", fitness, "Cooppallaan ", "40", 9230, "Wetteren", Handelaar12, Aanbieding.Geen);
                Bon bon18 = new Bon("Fitness Basic-Fit Wichelen", 4, 30, "Bekenste fitness van België met vestigingen over het hele land.", 22, @"images\bon\18\", fitness, "Paepestraat", "178", 9260, "Wichelen", Handelaar12, Aanbieding.Geen);
                Bon bon19 = new Bon("Fitness Basic-Fit Lede", 8, 30, "Bekenste fitness van België met vestigingen over het hele land.", 75, @"images\bon\19\", fitness, "Kasteeldreef", "15", 9340, "Lede", Handelaar12, Aanbieding.Geen);


                Bon bon20 = new Bon("Nachtwandeling Aalst at night", 5, 10, "Geniet van de sterrenhemel in de mooie streken van Aalst (met gids).", 63, @"images\bon\20\", uitstappen, "Arbeidstraat", "14", 9300, "Aalst", Handelaar21, Aanbieding.Geen);
                Bon bon21 = new Bon("Dagje wallibi in Dendermonde", 25, 142, "Wat is er nu leuker dan een dagje wallibi met vrienden", 34, @"images\bon\21\", uitstappen, "Mechelsesteenweg ", "138", 9200, "Dendermonde", Handelaar22, Aanbieding.Geen);
                Bon bon22 = new Bon("Met de trein naar Oostende", 36, 159, "Spring zong er al over dus wat houd je tegen het te doen", 45, @"images\bon\22\", uitstappen, "Torhoutsesteenweg", "611", 8400, "Oostende", Handelaar23, Aanbieding.Geen);
                Bon bon23 = new Bon("Weekendje disneyland parijs", 29, 251, "Disneyland de bestemming voor groot en klein", 35, @"images\bon\23\", uitstappen, "Leopoldlaan", "1", 1930, "Zaventem", Handelaar24, Aanbieding.Geen);
                Bon bon24 = new Bon("De grotten van Han", 50, 264, "Het liedje zit ongetwijfeld al in je hoofd dus ga nu gewoon", 86, @"images\bon\24\", uitstappen, "Rue Joseph Lamotte", "2", 5580, "Han-sur-Lesse", Handelaar25, Aanbieding.Geen);
                Bon bon25 = new Bon("Historisch bezoek Breemdonk", 6, 185, "Voor de oorlog fanaten een must", 35, @"images\bon\25\", uitstappen, "Brandstraat", "57", 2830, "Willebroek", Handelaar26, Aanbieding.Geen);


                Bon bon26 = new Bon("Bloemencenter Brenk", 1, 35, "Stel zelf uw setje bloemen samen met deze bon.", 43, @"images\bon\26\", huis_tuin, "Arbeidstraat", "14", 9300, "Aalst", Handelaar31, Aanbieding.Geen);
                Bon bon27 = new Bon("Potgrond De Mol in Lede", 22, 233, "Heb je grond nodig voor in een pot", 68, @"images\bon\27\", huis_tuin, "Kasteeldreef", "15", 9340, "Lede", Handelaar32, Aanbieding.Geen);
                Bon bon28 = new Bon("Schelfhout Ten Aalst", 36, 345, "Schelfhout, waar moet je andes zijn!", 75, @"images\bon\28\", huis_tuin, "Arbeidstraat", "14", 9300, "Aalst", Handelaar33, Aanbieding.Geen);
                Bon bon29 = new Bon("Bloemetje liesje in Gent", 13, 468, "Lies, verkoopt ook wel een madelief ", 25, @"images\bon\29\", huis_tuin, "Sint-Pietersnieuwstraat", "124", 9000, "Gent", Handelaar34, Aanbieding.Geen);
                Bon bon30 = new Bon("Funa Lima tuincentrum Lede", 26, 232, "Vissen, fonteinen, dieraccesoire...", 14, @"images\bon\30\", huis_tuin, "Kasteeldreef", "15", 9340, "Lede", Handelaar35, Aanbieding.Geen);
                Bon bon31 = new Bon("Vijvervoorziening Blub", 30, 404, "Blub, de winkel voor vis enthousiasten", 35, @"images\bon\31\", huis_tuin, "Arbeidstraat", "14", 9300, "Aalst", Handelaar36, Aanbieding.Geen);
                Bon bon32 = new Bon("Grasmaaiers Bontinck", 25, 89, "Jaren ervaring in het snoeien", 76, @"images\bon\32\", huis_tuin, "Paepestraat", "178", 9260, "Wichelen", Handelaar37, Aanbieding.Geen);
                Bon bon33 = new Bon("Aveve boerenbond te Aalst", 31, 416, "Bij de boerenbond vind je altijd wat je zoekt", 75, @"images\bon\33\", huis_tuin, "Arbeidstraat", "14", 9300, "Aalst", Handelaar38, Aanbieding.Geen);
                Bon bon34 = new Bon("Groener Gras In Wetteren", 12, 526, "Gazon voorzieningen", 14, @"images\bon\34\", huis_tuin, "Cooppallaan ", "40", 9230, "Wetteren", Handelaar39, Aanbieding.Geen);

                Bon bon35 = new Bon("Pukkelpop weekend tickets", 21, 513, "Pukkelpop, dat moet je gedaan hebben", 57, @"images\bon\35\", events, "Paepestraat", "178", 9260, "Wichelen", Handelaar41, Aanbieding.Geen);
                Bon bon36 = new Bon("Lokerse bierfeesten", 44, 393, "Bierfanaten kunnen dit niet missen", 75, @"images\bon\36\", events, "Kleine Dam", "1", 9160, "Lokeren", Handelaar42, Aanbieding.Geen);
                Bon bon37 = new Bon("Gentse feesten eetfestijn", 42, 464, "Drinken en eten, meer moet dat niet zijn", 25, @"images\bon\37\", events, "Sint-Pietersnieuwstraat", "124", 9000, "Gent", Handelaar43, Aanbieding.Geen);
                Bon bon38 = new Bon("Gameforce in de Nekkerhalle", 38, 179, "Voor elke nerd wat wils", 14, @"images\bon\38\", events, "Ravensteinstraat", "50", 1000, "Brussel", Handelaar44, Aanbieding.Geen);
                Bon bon39 = new Bon("Drive A Ferrari Day", 8, 318, "Ideal geshenk voor een autofanaat", 38, @"images\bon\39\", events, "Paepestraat", "178", 9260, "Wichelen", Handelaar45, Aanbieding.Geen);
                Bon bon40 = new Bon("Facts: trein en eten", 34, 197, "Cosplay, eten en vervoer", 18, @"images\bon\40\", events, "Sint-Pietersnieuwstraat", "124", 9000, "Gent", Handelaar46, Aanbieding.Geen);

                Bon bon41 = new Bon("Makeup pallete Nude", 29, 374, "Het bekendste merk zijn palette", 67, @"images\bon\41\", beauty, "Paepestraat", "178", 9260, "Wichelen", Handelaar51, Aanbieding.Geen);
                Bon bon42 = new Bon("Ici Paris verwenbon", 15, 500, "Een parfum kan je nooit mee misdoen", 17, @"images\bon\42\", beauty, "Arbeidstraat", "14", 9300, "Aalst", Handelaar52, Aanbieding.Geen);
                Bon bon43 = new Bon("Lipstick Lover Aalst", 8, 404, "Voor de lippen lovers", 86, @"images\bon\43\", beauty, "Arbeidstraat", "14", 9300, "Aalst", Handelaar53, Aanbieding.Geen);

                Bon bon44 = new Bon("Sofa en Co", 18, 389, "Relax in een sofa van sofa en co", 71, @"images\bon\44\", interieur, "Arbeidstraat", "14", 9300, "Aalst", Handelaar61, Aanbieding.Geen);
                Bon bon45 = new Bon("Deba meubelen", 36, 202, "Verkoopt al uw interieur", 37, @"images\bon\45\", interieur, "Arbeidstraat", "14", 9300, "Aalst", Handelaar62, Aanbieding.Geen);
                Bon bon46 = new Bon("Ikea huisvoorzieningen", 40, 375, "Meubelspiaclist sinds 74", 71, @"images\bon\46\", interieur, "Paepestraat", "178", 9260, "Wichelen", Handelaar63, Aanbieding.Geen);
                Bon bon47 = new Bon("Leenbakker", 34, 335, "Om te kopen, niet te lenen", 37, @"images\bon\47\", interieur, "Sint-Pietersnieuwstraat", "124", 9000, "Gent", Handelaar64, Aanbieding.Geen);
                Bon bon48 = new Bon("Salon Ballon Gent", 13, 352, "Sallon Ballon is een speciaalzaak te Gent", 76, @"images\bon\48\", interieur, "Sint-Pietersnieuwstraat", "124", 9000, "Gent", Handelaar65, Aanbieding.Geen);
                Bon bon49 = new Bon("Keukens Donald", 45, 244, "Al 8 jaar maak ik keukens alsof ze voor mezelf zijn", 46, @"images\bon\49\", interieur, "Arbeidstraat", "14", 9300, "Aalst", Handelaar66, Aanbieding.Geen);
                Bon bon50 = new Bon("Modern Gent", 31, 510, "Modern interieur hoeft niet duur te zijn", 75, @"images\bon\50\", interieur, "Sint-Pietersnieuwstraat", "124", 9000, "Gent", Handelaar67, Aanbieding.Geen);
                Bon bon51 = new Bon("Kunst & Kitch", 18, 186, "Een beetje kunst, een beetje kitch", 46, @"images\bon\51\", interieur, "Paepestraat", "178", 9260, "Wichelen", Handelaar68, Aanbieding.Geen);
                Bon bon52 = new Bon("Moderne interieur Gill", 5, 60, "Op maat gemaakt interieur tegen een zacht prijsje", 45, @"images\bon\52\", interieur, "Arbeidstraat", "14", 9300, "Aalst", Handelaar69, Aanbieding.Geen);

                Bon bon53 = new Bon("C&A Aalst", 24, 480, "De kledingwinkel in Aalst en omstreken", 42, @"images\bon\53\", kledij, "Arbeidstraat", "14", 9300, "Aalst", Handelaar71, Aanbieding.Geen);
                Bon bon54 = new Bon("AS Advantures", 48, 373, "Kledie om een avontuur mee aan te gaan", 47, @"images\bon\54\", kledij, "Paepestraat", "178", 9260, "Wichelen", Handelaar72, Aanbieding.Geen);
                Bon bon55 = new Bon("Ultra Wet", 41, 413, "De kledingspecialist voor droog en nat", 71, @"images\bon\55\", kledij, "Arbeidstraat", "14", 9300, "Aalst", Handelaar73, Aanbieding.Geen);
                Bon bon56 = new Bon("Holiday", 24, 489, "Voor al uw feestkledij", 17, @"images\bon\56\", kledij, "Sint-Pietersnieuwstraat", "124", 9000, "Gent", Handelaar74, Aanbieding.Geen);
                Bon bon57 = new Bon("Bram's Fashion", 23, 86, "Voor ieder wat wilds", 73, @"images\bon\57\", kledij, "Paepestraat", "178", 9260, "Wichelen", Handelaar75, Aanbieding.Standaard);
                Bon bon58 = new Bon("Bontinck's Panthers", 30, 453, "Pants from Bontinck are dreams for legs", 72, @"images\bon\58\", kledij, "Arbeidstraat", "14", 9300, "Aalst", Handelaar76, Aanbieding.Geen);
                Bon bon59 = new Bon("Bre Bra", 29, 478, "Van A tot Z, u vindt het bij ons", 92, @"images\bon\59\", kledij, "Sint-Pietersnieuwstraat", "124", 9000, "Gent", Handelaar77, Aanbieding.Standaard);
                Bon bon69 = new Bon("Pikantje", 34, 402, "Erotische kledingwinkel", 9, @"images\bon\69\", kledij, "Arbeidstraat", "14", 9300, "Aalst", Handelaar78 , Aanbieding.Geen);

                Bon bon61 = new Bon("Fnac Aalst", 3, 377, "De multimedia specialist in Europa", 54, @"images\bon\61\", multimedia, "Arbeidstraat", "14", 9300, "Aalst", Handelaar81, Aanbieding.Geen);
                Bon bon62 = new Bon("Mediamarkt Dendermonde", 46, 433, "Electronica tegen een spot prijs", 45, @"images\bon\62\", multimedia, "Mechelsesteenweg", "138", 9200, "Dendermonde", Handelaar82, Aanbieding.Geen);
                Bon bon63 = new Bon("Van Den Borre Gent", 31, 181, "Koffiezets voor 12€", 15, @"images\bon\63\", multimedia, "Sint-Pietersnieuwstraat", "124", 9000, "Gent", Handelaar83, Aanbieding.Geen);
                Bon bon64 = new Bon("Bontinck IT brugge", 36, 539, "Een probleempje groot of klein, dan moet je bij IT Lennert zijn", 67, @"images\bon\64\", multimedia, "Maalse Steenweg", "50", 8310, "Brugge", Handelaar84, Aanbieding.Standaard);
                Bon bon65 = new Bon("Schets Apple Premium", 49, 124, "U vindt alle laatste Apple producten hier", 78, @"images\bon\65\", multimedia, "Paepestraat", "178", 9260, "Wichelen", Handelaar85, Aanbieding.Geen);
                Bon bon66 = new Bon("Lab9 Aalst", 7, 340, "Officiele Apple reseller", 64, @"images\bon\66\", multimedia, "Arbeidstraat", "14", 9300, "Aalst", Handelaar86, Aanbieding.Geen);
                Bon bon67 = new Bon("De Conincks Screen Repair", 38, 536, "Een ongelukje is rap gebeurd", 75, @"images\bon\67\", multimedia, "Paepestraat", "178", 9260, "Wichelen", Handelaar87, Aanbieding.Geen);
                Bon bon68 = new Bon("Medion Custom", 40, 316, "Medion laptop op maat gemaakt", 24, @"images\bon\68\", multimedia, "Sint-Pietersnieuwstraat", "124", 9000, "Gent", Handelaar88, Aanbieding.Geen);
                Bon bon60 = new Bon("Dell Dinosaur", 27, 311, "MS Dos specialist", 30, @"images\bon\60\", multimedia, "Paepestraat", "178", 9260, "Wichelen", Handelaar89, Aanbieding.Geen);


                Bon bon70 = new Bon("Generieke cadeaubon", 1, 50, "Niet zeker welke bon u juist wilt, dan is deze generieke bon iets voor u!", 457, @"images\bon\70\", generiek, "Arbeidstraat", "14", 9300, "Aalst", Handelaar91, Aanbieding.Slider);
                var bonnen = new List<Bon>
                {
                   bon01, bon02, bon03, bon04, bon05, bon06, bon07, bon08, bon09, bon10, bon11, bon12, bon13, bon14, bon15, bon16, bon17, bon18, bon19, bon20, bon21, bon22, bon23, bon24, bon25, bon26, bon27, bon28, bon29, bon30, bon31, bon32, bon33, bon34, bon35, bon36, bon37, bon38, bon39, bon40, bon41, bon42, bon43, bon44, bon45, bon46, bon47, bon48, bon49, bon50, bon51, bon52, bon53, bon54, bon55, bon56, bon57, bon58, bon59, bon60, bon61, bon62, bon63, bon64, bon65, bon66, bon67, bon68, bon69, bon70
                };

                _dbContext.Bonnen.AddRange(bonnen);

                Gebruiker user01 = new Gebruiker { Voornaam = "Brent", Familienaam = "Schets", Geslacht = Geslacht.Man, Emailadres = "brent@schets.com" };
                Gebruiker user02 = new Gebruiker { Voornaam = "Bram", Familienaam = "De Coninck", Geslacht = Geslacht.Man, Emailadres = "bram@bramdeconinck.com" };
                Gebruiker user03 = new Gebruiker { Voornaam = "Lennert", Familienaam = "Bontinck", Geslacht = Geslacht.Man, Emailadres = "lennert@lennertbontinck.com" };

                var personen = new List<Gebruiker>
                {
                    user01, user02, user03
                };

                _dbContext.Gebruikers.AddRange(personen);

                await CreateUser("admin@sportsstore.be", "admin@sportsstore.be", "P@ssword1!", "Admin");
                _dbContext.SaveChanges();
            }
        }

        private async Task CreateUser(string userName, string email, string password, string role)
        {
            var user = new ApplicationUser { UserName = userName, Email = email };
            await _userManager.CreateAsync(user, password);
            await _userManager.AddClaimAsync(user, new Claim(ClaimTypes.Role, role));
        }
    }
}
