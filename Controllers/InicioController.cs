﻿using Microsoft.AspNetCore.Mvc;

namespace ProyectoMedexcard.Controllers
{
    public class InicioController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
