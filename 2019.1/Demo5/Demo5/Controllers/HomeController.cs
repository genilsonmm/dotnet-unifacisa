using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Demo5.Models;
using Demo5.Services;
using Microsoft.AspNetCore.Mvc;

namespace Demo5.Controllers
{
    public class HomeController : Controller
    {
        private readonly GitHubService _gitHubService;

        public HomeController(GitHubService gitHubService)
        {
            _gitHubService = gitHubService;
        }

        public async Task<IActionResult> Index()
        {
            List<User> users = new List<User>();

            try
            { 
                users = await _gitHubService.GetUsers();
            }
            catch (HttpRequestException)
            {
                return NotFound();
            }

            return View(users);
        }
    }
}