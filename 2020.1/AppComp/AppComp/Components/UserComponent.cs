using AppComp.Models;
using Microsoft.AspNetCore.Mvc;

namespace AppComp.Components
{
    [ViewComponent(Name = "UserComponent")]
    public class UserComponent : ViewComponent
    {
        public IViewComponentResult Invoke(User user)
        {
            return View("UserView", user);
        }
    }
}
