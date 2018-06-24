using Parking.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Parking.business
{
    public class Cancela { 
        ParkingContext bd = new ParkingContext();
        public Ticket gerarTicket()
        {
            Ticket ticket = new Ticket();
            ticket.dataHoraEmissao = DateTime.Now;
            ticket.dataHoraValidade = ticket.dataHoraEmissao.AddMinutes(15);
            ticket.especial = false;
            bd.Tickets.Add(ticket);
            bd.SaveChanges();
            return ticket;
        }

        public bool consultaTicket(int id)
        {
            Ticket ticket = bd.Tickets.Find(id);
            DateTime dataHoraAtual = DateTime.Now;
            if (ticket == null)
                return false;
            if (dataHoraAtual <= ticket.dataHoraValidade)
            {
                registraSaida(ticket);
                return true;
            }
            else
                return false;
        }

        public void registraSaida(Ticket ticket)
        {
            //Falta criar log disso!
        }
    }
}
