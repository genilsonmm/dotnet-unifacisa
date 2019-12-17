using Demo5.Models;
using Microsoft.AspNetCore.Mvc;

namespace Demo5.Components
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
