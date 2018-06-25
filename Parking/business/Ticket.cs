using Parking.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Parking.business
{
    public class Ticket
    {
        ParkingContext bd = new ParkingContext();
        public int id { get; set; }
        public DateTime dataHoraEmissao { get; set; }
        public DateTime dataHoraValidade { get; set; }
        public Boolean especial { get; set; }

        public List<Ticket> listarTickets()
        {
            return bd.Tickets.ToList();
        }
    }
}
