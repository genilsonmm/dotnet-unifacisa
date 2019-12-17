using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using GitHubApp.Models;
using GitHubApp.Service;

namespace GitHubApp.Controllers
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
            catch
            {
                return NotFound();
            }

            return View(users);
        }
    }
}
