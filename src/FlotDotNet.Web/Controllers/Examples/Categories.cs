using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace FlotDotNet.Web.Controllers
{
    public partial class ExamplesController
    {
        public IActionResult Categories()
        {
            var chart = new FlotChart
            {
                Bars = new FlotBars
                {
                    Show = true,
                    BarWidth = 0.6,
                    Align = FlotBarAlign.Center
                },
                XAxis = new FlotAxis
                {
                    Mode = FlotAxisMode.Categories,
                    ShowTicks = false,
                    GridLines = false
                }
            };

            var d1 = chart.CreateSeries("d1");
            // d1.Data.AddRange(new List<FlotCategoryData> { { "January", 10 }, { "February", 8 }, { "March", 4 }, { "April", 13 }, { "May", 17 }, { "June", 9 } })

            return View(chart);
        }
    }
}