using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using AppComp.Models;

namespace AppComp.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            List<User> users = new List<User>();
            users.Add(new User() { Id = 1, Name = "Maria", Email = "maria@gmail.com" });
            users.Add(new User() { Id = 2, Name = "João", Email = "joao@gmail.com" });
            users.Add(new User() { Id = 3, Name = "Pedro", Email = "pedro@gmail.com" });
            users.Add(new User() { Id = 4, Name = "Marcos", Email = "marcos@gmail.com" });

            return View(users);
        }
    }
}
