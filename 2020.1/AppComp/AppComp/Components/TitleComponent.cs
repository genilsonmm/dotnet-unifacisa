using Microsoft.AspNetCore.Mvc;

namespace AppComp.Components
{
    [ViewComponent(Name = "TitleComponent")]
    public class TitleComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
