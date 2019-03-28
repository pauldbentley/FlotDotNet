using System;
using Microsoft.AspNetCore.Mvc;

namespace FlotDotNet.Web.Controllers
{
    public partial class ExamplesController
    {
        public IActionResult SeriesTypes()
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

            var d3 = chart.CreateSeries("d3");
            for (double i = 0; i < 14; i += 0.5)
            {
                d3.Data.Add(i, Math.Cos(i));
            }

            var d4 = chart.CreateSeries("d4");
            for (double i = 0; i < 14; i += 0.1)
            {
                d4.Data.Add(i, Math.Sqrt(i * 10));
            }

            var d5 = chart.CreateSeries("d5");
            for (double i = 0; i < 14; i += 0.5)
            {
                d5.Data.Add(i, Math.Sqrt(i));
            }

            var d6 = chart.CreateSeries("d6");
            for (double i = 0; i < 14; i += 0.5 + new Random().NextDouble())
            {
                d6.Data.Add(i, Math.Sqrt(2 * i + Math.Sin(i) + 5));
            }

            d1.Lines.Show = true;
            d1.Lines.Fill = true;

            d2.Bars.Show = true;

            d3.Points.Show = true;

            d4.Lines.Show = true;

            d5.Lines.Show = true;
            d5.Points.Show = true;

            d6.Lines.Show = true;
            d6.Lines.Steps = true;

            return View(chart);
        }
    }
}