using System;
using Microsoft.AspNetCore.Mvc;

namespace FlotDotNet.Web.Controllers
{
    public partial class ExamplesController
    {
        public IActionResult Annotating()
        {
            var chart = new FlotChart();

            var d1 = chart.CreateSeries("d1", "Pressure");
            d1.Color = "#333";

            for (double i = 0; i < 20; ++i)
            {
                d1.Data.Add(i, Math.Sin(i));
            }

            d1.Bars.Show = true;
            d1.Bars.BarWidth = 0.5;
            d1.Bars.Fill = 0.9;

            chart.XAxis.Show = false;

            chart.YAxis.Min = -2;
            chart.YAxis.Max = 2;
            chart.YAxis.AutoScale = FlotAxisAutoScale.None;

            chart.Grid.Markings = new FlotGridMarkingCollection
            {
                new FlotGridMarking { Color = "#f6f6f6", YAxis = new FlotMarking { From = 1 } },
                new FlotGridMarking { Color = "#f6f6f6", YAxis = new FlotMarking { To = -1 } },
                new FlotGridMarking { Color = "#000", LineWidth = 1, XAxis = new FlotMarking { From = 2, To = 2 } },
                new FlotGridMarking { Color = "#000", LineWidth = 1, XAxis = new FlotMarking { From = 8, To = 8 } }
            };

            return View(chart);
        }
    }
}