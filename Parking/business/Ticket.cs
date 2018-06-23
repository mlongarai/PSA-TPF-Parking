using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Parking.business
{
    public class Ticket
    {
        public int id { get; set; }
        public DateTime dataHoraEmissao { get; set; }
        public DateTime dataHoraValidade { get; set; }
        public Boolean especial { get; set; }
    }
}
