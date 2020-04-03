using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AppLivros.Models;
using AppLivros.Dados;

namespace AppLivros.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View(BancoDeDados.Instance().GetAll());
        }
    }
}
