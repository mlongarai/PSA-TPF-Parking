using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Parking.business
{
    public class Cancela
    {
        public Ticket gerarTicket()
        {
            Ticket ticket = new Ticket();
            ticket.dataHoraEmissao = DateTime.Now;
            ticket.dataHoraValidade = ticket.dataHoraEmissao.AddMinutes(15);
            ticket.especial = false;
            return ticket;
        }

        public bool consultaTicket(Ticket ticket)
        {
            DateTime dataHoraAtual = DateTime.Now;
            if (dataHoraAtual <= ticket.dataHoraValidade)
                return true;
            else
                return false;
        }

        public void registraSaida(Ticket ticket)
        {
            //Falta isso
        }
    }
}
