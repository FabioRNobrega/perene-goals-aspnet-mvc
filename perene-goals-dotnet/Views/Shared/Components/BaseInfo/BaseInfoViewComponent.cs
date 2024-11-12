using Microsoft.AspNetCore.Mvc;

namespace perene_goals_dotnet.Views.Shared.Components
{
    public class BaseInfoViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke(string title, List<string> message, string align)
        {
            var model = new BaseInfoModel 
            {
                Title = title,
                Message = message,
                Align = align
            };

            return View("Default", model);
        }

    }

    public class BaseInfoModel 
    {
        public List<string> Message { get; set;} = new List<string>();
        public string Title { get; set;} = string.Empty;
        public string Align {get; set;} = "justify";
    }
}
