using Microsoft.AspNetCore.Mvc;

namespace Demo5.Components
{
    [ViewComponent(Name = "TitleComponent")]
    public class TitleViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
