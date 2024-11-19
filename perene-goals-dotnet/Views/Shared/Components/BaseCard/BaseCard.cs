using Microsoft.AspNetCore.Mvc;

namespace perene_goals_dotnet.Views.Shared.Components
{
    public class BaseCardViewComponent : ViewComponent
    {
         public IViewComponentResult Invoke()
        {

            return View("BaseCard");
        }
    }
}