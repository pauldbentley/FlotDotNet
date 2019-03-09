namespace FlotDotNet.Web.Controllers
{
    using FlotDotNet.Web.Models.Examples;
    using Microsoft.AspNetCore.Mvc;

    public partial class ExamplesController
    {
        public IActionResult SeriesPie(int? example)
        {
            var model = new SeriesPieViewModel(example.GetValueOrDefault(1));
            return View(model);
        }
    }
}
