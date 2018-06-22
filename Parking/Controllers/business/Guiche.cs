using Parking.business;
using Parking.Controllers.business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Parkin.Controllers.business
{
    public class Guiche
    {
        int idade = 10;
        public Ticket emissaoTicketExtraviado()
        {
            Ticket ticket = new Ticket();
            ticket.especial = true;
            return ticket;
        }

        public float calculaValorTicket(Ticket ticket)
        {
            //Ticket Extraviado
            if (ticket.especial == true)
            {
                return 30;
            }
            DateTime dataHoraAtual = DateTime.Now;
            double permanencia = (dataHoraAtual - ticket.dataHoraEmissao).TotalMinutes;
            //Ticket menos de 3 horas
            if (permanencia <= 180)
            {
                return 5;
            }
            //Ticket pernoite
            if (dataHoraAtual.Day - ticket.dataHoraEmissao.Day == 1)
            {
                return 30;
            }
            if (dataHoraAtual.Day == ticket.dataHoraEmissao.Day && ticket.dataHoraEmissao.Hour < 2 && dataHoraAtual.Hour > 8)
            {
                return 30;
            }
            //Ticket acima de três horas
            if (dataHoraAtual.Date == ticket.dataHoraEmissao.Date && permanencia > 180)
            {
                return 10;
            }
            return 0;
        }

        public void liberacaoTicket(Ticket ticket)
        {
            DateTime dataHoraAtual = DateTime.Now;
            float valorCobrado = calculaValorTicket(ticket);
            if (valorCobrado == 5)
            {
                ticket.dataHoraValidade.AddHours(3);

            }
            else if (ticket.dataHoraEmissao.Hour >= 8 && ticket.dataHoraEmissao.Hour <= 23)
            {
                ticket.dataHoraValidade = Utils.alterarHora(DateTime.Now, 02, 00, 00).AddDays(1);
            }
            else if (ticket.dataHoraEmissao.Hour >= 0 && ticket.dataHoraEmissao.Hour < 2)
            {
                ticket.dataHoraValidade = Utils.alterarHora(DateTime.Now, 02, 00, 00);
            }
        }
    }
}
