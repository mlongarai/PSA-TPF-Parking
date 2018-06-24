using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Parkin.business;
using Parking.business;
using Parking.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Parking.Controllers
{
    public class CancelaSaidaController : Controller
    {
        Fachada fachada = new Fachada();
        // 
        // GET: /CancelaEntrada/GerarTicket

        public IActionResult ConsultaTicket(int id)
        {
            return Ok(fachada.consultaTicket(id));
        }

    }
}
