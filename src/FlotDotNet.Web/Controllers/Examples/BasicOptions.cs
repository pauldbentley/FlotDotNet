using System;
using Microsoft.AspNetCore.Mvc;

namespace FlotDotNet.Web.Controllers
{
    public partial class ExamplesController
    {
        public IActionResult BasicOptions()
        {
            var chart = new FlotChart();

            var d1 = chart.CreateSeries("d1", "sin(x)");
            d1.Lines.Show = true;
            d1.Points.Show = true;

            for (double i = 0; i < Math.PI * 2; i += 0.25)
            {
                d1.Data.Add(i, Math.Sin(i));
            }

            var d2 = chart.CreateSeries("d2", "cos(x)");
            d2.Lines.Show = true;
            d2.Points.Show = true;

            for (double i = 0; i < Math.PI * 2; i += 0.25)
            {
                d2.Data.Add(i, Math.Cos(i));
            }

            var d3 = chart.CreateSeries("d3", "tan(x)");
            d3.Lines.Show = true;
            d3.Points.Show = true;

            for (double i = 0; i < Math.PI * 2; i += 0.1)
            {
                d3.Data.Add(i, Math.Tan(i));
            }

            chart.XAxis.AutoScale = FlotAxisAutoScale.Exact;
            chart.XAxis.Ticks = new FlotTickOptions
            {
                0,
                { Math.PI / 2, "\u03c0/2" },
                { Math.PI, "\u03c0" },
                { Math.PI * 3 / 2, "3\u03c0/2" },
                { Math.PI * 2, "2\u03c0" }
            };

            chart.YAxis.AutoScale = FlotAxisAutoScale.None;
            chart.YAxis.Ticks = 10;
            chart.YAxis.Min = -2;
            chart.YAxis.Max = 2;
            chart.YAxis.TickDecimals = 3;

            chart.Grid.BorderWidth = 1;
            chart.Grid.BackgroundGradient.AddRange(new[] { "#fff", "#eee" });

            chart.Grid.BorderWidth.Left = 2;
            chart.Grid.BorderWidth.Bottom = 2;

            return View(chart);
        }
    }
}