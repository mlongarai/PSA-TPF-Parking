using Parking.business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Parkin.Controllers.business
{
    public class Guiche
    {
        public Ticket emissaoTicketExtraviado()
        {
            Ticket ticket = new Ticket();
            ticket.especial = true;
            return ticket;
        }

        public float calculaValorTicket (Ticket ticket)
        {
            if (ticket.especial = true)
            {
                return 30;
            }
            DateTime dataHoraAtual = DateTime.Now;
            double permanencia = (dataHoraAtual - ticket.dataHoraEmissao).TotalMinutes;
            if (permanencia <= 180)
            {
                return 5;
            } else if ()

        }

        public void liberacaoTicket ()
        {

        }
    }
}
