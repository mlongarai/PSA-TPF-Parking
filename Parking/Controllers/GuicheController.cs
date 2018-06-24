using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Parkin.business;
using Parking.business;
using Parking.Models;
using QRCoder;

namespace Parking.Controllers
{
    public class GuicheController : Controller { 
        Fachada fachada = new Fachada();

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GerarTicketExtraviado()
        {
            Ticket ticket = fachada.emissaoTicketExtraviado();
            ViewData["id"] = ticket.id;
            ViewData["dataEmissao"] = ticket.dataHoraEmissao;
            ViewData["dataValidade"] = ticket.dataHoraEmissao;
            //QRCodeGenerator qrGenerator = new QRCodeGenerator();
            //QRCodeData qrCodeData = qrGenerator.CreateQrCode(""+ticket.id, QRCodeGenerator.ECCLevel.Q);
            //QRCode qrCode = new QRCode(qrCodeData);
            //Bitmap qrCodeImage = qrCode.GetGraphic(20);
            //qrCodeImage.Save(""+ticket.id+".bmp");
            return View();
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
