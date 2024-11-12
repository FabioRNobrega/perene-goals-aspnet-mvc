using Microsoft.AspNetCore.Mvc;

namespace perene_goals_dotnet.Views.Shared.Components
{
    public class BottomNavbarViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke(string controller, string action, string icon)
        {
            var model = new BottomNavbarModel 
            {
                Controller = controller,
                Action = action,
                Icon = icon
            };

            return View("BottomNavbar", model);
        }
    }

    public class BottomNavbarModel 
    {
        public string Controller { get; set;} = string.Empty;
        public string Action { get; set;} = string.Empty;
        public string Icon {get; set;} = string.Empty;
    }
}