using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using ProjMovie.Models.DTO;

namespace ProjMovie.Controllers
{
    public class DetailController : Controller
    {
        public IActionResult Index()
        {
            
            return View();
        }
    }
    //TODO: hämta den specifika filmen man klickat på och lägga in den i detail page. Endpoint har ett id som matchar filmens id. Går det att plocka ut det?
}
