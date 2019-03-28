using System;
using Microsoft.AspNetCore.Mvc;

namespace FlotDotNet.Web.Controllers
{
    public partial class ExamplesController
    {
        public IActionResult Stacking()
        {
            var chart = new FlotChart();

            var random = new Random();

            var d1 = chart.CreateSeries("d1");
            for (double i = 0; i < 10; i += 1)
            {
                d1.Data.Add(i, Convert.ToInt32(random.NextDouble() * 30));
            }

            var d2 = chart.CreateSeries("d2");
            for (double i = 0; i < 10; i += 1)
            {
                d2.Data.Add(i, Convert.ToInt32(random.NextDouble() * 30));
            }

            var d3 = chart.CreateSeries("d3");
            for (double i = 0; i < 10; i += 1)
            {
                d3.Data.Add(i, Convert.ToInt32(random.NextDouble() * 30));
            }

            chart.Stack = 0;

            chart.Bars.Show = true;
            chart.Bars.BarWidth = 0.6;

            chart.Lines.Show = false;
            chart.Lines.Fill = true;
            chart.Lines.Steps = false;

            chart.YAxis.AutoScale = FlotAxisAutoScale.Exact;

            return View(chart);
        }
    }
}