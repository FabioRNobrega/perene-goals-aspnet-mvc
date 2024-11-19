using Microsoft.AspNetCore.Mvc;

namespace perene_goals_dotnet.Views.Shared.Components
{
    public class BaseHeroViewComponent : ViewComponent
    {
         public IViewComponentResult Invoke(string author, string quote)
        {
            var model = new BaseHeroModel{
                Author = author,
                Quote = quote
            };

            return View("BaseHero", model);
        }
    }

    public class BaseHeroModel 
    {
        public string Author { get; set;} = string.Empty;
        public string Quote { get; set;} = string.Empty;
    }
}