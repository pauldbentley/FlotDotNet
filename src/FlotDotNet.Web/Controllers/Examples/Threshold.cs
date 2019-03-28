using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace FlotDotNet.Web.Controllers
{
    public partial class ExamplesController
    {
        public IActionResult Threshold()
        {
            var chart = new FlotChart();

            var d1 = chart.CreateSeries("d1");
            d1.Color = "rgb(30, 180, 20)";
            d1.Lines.Steps = true;

            var random = new Random();

            for (var i = 0; i <= 60; i += 1)
            {
                d1.Data.Add(i, Convert.ToInt32((random.NextDouble() * 30) - 10));
            }

            d1.Thresholds = new List<FlotThreshold>
            {
                { 0, "rgb(200, 20, 30)" }
            };

            return View(chart);
        }
    }
}