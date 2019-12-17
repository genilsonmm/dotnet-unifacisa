using Demo3.Models;
using Microsoft.AspNetCore.Mvc;

namespace Demo3.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            Message message = new Message("Bem vindos à Demo 3!");
            return View(message);
        }
    }
}