using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Parkin.business;
using Parking.Models;

namespace Parking.Controllers
{
    public class GerenteController : Controller
    {
        Fachada fachada = new Fachada();
        public IActionResult Index()
        {
            //ViewData ["tickets"] = fachada.listarTickets();
            return View(fachada.listarTickets());
        }

        public IActionResult tickets(String dataEntrada, String dataSaida)
        {
            
            return Ok(fachada.listarTickets());
        }
    }
}
