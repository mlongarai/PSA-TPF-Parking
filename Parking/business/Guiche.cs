using Parking.business;
using Parking.Controllers;
using Parking.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Parkin.business
{
    public class Guiche
    {
        ParkingContext bd = new ParkingContext();
        public Ticket emissaoTicketExtraviado()
        {
            Ticket ticket = new Ticket();
            ticket.dataHoraEmissao = DateTime.Now;
            ticket.dataHoraValidade = DateTime.Now;
            ticket.especial = true;
            bd.Tickets.Add(ticket);
            bd.SaveChanges();
            return ticket;
        }

        public float calculaValorTicket(int id)
        {
            DateTime dataHoraAtual = DateTime.Now;
            Ticket ticket = bd.Tickets.Find(id);
            if (ticket == null)
                return -1;
            //Ticket Extraviado
            if (ticket.especial == true)
            {
                return 30;
            }
            //Ticket valido
            if (ticket.dataHoraValidade >= dataHoraAtual)
                return 0;
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
            return -1;
        }

        public bool liberacaoTicket(int id)
        {
            Ticket ticket = bd.Tickets.Find(id);
            DateTime dataHoraAtual = DateTime.Now;
            float valorCobrado = calculaValorTicket(id);
            if (valorCobrado == 5)
            {
                ticket.dataHoraValidade = ticket.dataHoraValidade.AddMinutes(180);

            }
            else if (ticket.dataHoraEmissao.Hour >= 8 && ticket.dataHoraEmissao.Hour <= 23)
            {
                ticket.dataHoraValidade = Utils.alterarHora(DateTime.Now, 02, 00, 00).AddDays(1);
            }
            else if (ticket.dataHoraEmissao.Hour >= 0 && ticket.dataHoraEmissao.Hour < 2)
            {
                ticket.dataHoraValidade = Utils.alterarHora(DateTime.Now, 02, 00, 00);
            }
            ticket.valorCobrado = valorCobrado;
            bd.Tickets.Update(ticket);
            bd.SaveChanges();
            return true;
        }
    }
}
