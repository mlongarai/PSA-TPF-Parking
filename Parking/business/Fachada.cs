using Parking.business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Parkin.business
{
    public class Fachada
    {
        public Fachada()
        {

        }
        Cancela cancela = new Cancela();
        Guiche guiche = new Guiche();

        public Ticket gerarTicket()
        {
            return cancela.gerarTicket();
        }

        public bool consultaTicket(int id)
        {
            return cancela.consultaTicket(id);
        }

        public void registraSaida(Ticket ticket)
        {
            cancela.registraSaida(ticket);
        }

        public Ticket emissaoTicketExtraviado()
        {
            return guiche.emissaoTicketExtraviado();
        }

        public float calculaValorTicket(int id)
        {
            return guiche.calculaValorTicket(id);
        }

        public bool liberacaoTicket(int id)
        {
            return guiche.liberacaoTicket(id);
        }
    }
}
