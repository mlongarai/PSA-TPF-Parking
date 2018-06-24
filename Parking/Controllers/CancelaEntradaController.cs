﻿using System;
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
            return Ok(fachada.gerarTicket());
        }

    }
}
