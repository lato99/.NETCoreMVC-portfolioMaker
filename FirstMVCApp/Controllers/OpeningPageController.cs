﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PortfolioMakerApp.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PortfolioMakerApp.Controllers
{
    public class OpeningPageController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index(int int1)
        {
            return View("/Views/OpeningPage/UserPage.cshtml");
        }
    }



    }


















