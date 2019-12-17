using GitHubApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace GitHubApp.Components
{
    [ViewComponent(Name = "UserComponent")]
    public class UserViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke(User user)
        {
            return View("UserView", user);
        }
    }
}
