using System;
using Microsoft.AspNetCore.Mvc;

namespace FlotDotNet.Web.Controllers
{
    public partial class ExamplesController
    {
        public IActionResult BasicUsage()
        {
            var chart = new FlotChart();

            var d1 = chart.CreateSeries("d1");
            for (double i = 0; i < 14; i += 0.5)
            {
                d1.Data.Add(i, Math.Sin(i));
            }

            var d2 = chart.CreateSeries("d2");
            d2.Data.Add(0, 3);
            d2.Data.Add(4, 8);
            d2.Data.Add(8, 5);
            d2.Data.Add(9, 13);

            // A null signifies separate line segments
            var d3 = chart.CreateSeries("d3");
            d3.Data.Add(0, 12);
            d3.Data.Add(7, 12);
            d3.Data.Add(null);
            d3.Data.Add(7, 2.5);
            d3.Data.Add(12, 2.5);

            return View(chart);
        }
    }
}