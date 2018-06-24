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
    public class CancelaEntradaController : Controller
    {
        Fachada fachada = new Fachada();
        // 
        // GET: /CancelaEntrada/GerarTicket

        public IActionResult GerarTicket()
        {
            Ticket ticket = ParkingContext.Ti
            ViewData["id"] = ticket.id;
            ViewData["dataHoraEmissao"] = ticket.dataHoraEmissao;
            ViewData["dataHoraValidade"] = ticket.dataHoraValidade;
            return View();
        }

        // 
        // GET: /CancelaController/

        public IActionResult Index()
        {
            return View();
        }

        // 
        // GET: /CancelaController/Welcome/ 

        public IActionResult Welcome(string name, int numTimes = 1)
        {
            ViewData["Message"] = "Hello " + name;
            ViewData["NumTimes"] = numTimes;

            return View();
        }
    }
}
