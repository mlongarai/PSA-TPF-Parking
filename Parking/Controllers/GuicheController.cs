using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Parkin.business;
using Parking.business;
using Parking.Models;

namespace Parking.Controllers
{
    public class GuicheController : Controller { 
        Fachada fachada = new Fachada();

        public IActionResult GerarTicketExtraviado()
        {
            Ticket ticket = fachada.emissaoTicketExtraviado();
            return Ok(ticket);
        }

        public IActionResult calculaValorTicket(int id)
        {
            float valor = fachada.calculaValorTicket(id);
            return Ok(valor);
        }

        public IActionResult liberacaoTicket(int id)
        {
            fachada.liberacaoTicket(id);
            return Ok();
        }
    }
}
