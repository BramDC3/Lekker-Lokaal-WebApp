using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LekkerLokaal.Models.Domain
{
    public class BestelLijn : WinkelwagenLijn
    {
        public int BestelLijnId { get; private set; }
        public int BestellingId { get; private set; }
        public int BonId { get; private set; }
        public Geldigheid Geldigheid { get; set; }
    }
}
