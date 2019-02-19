using System;
using Microsoft.AspNetCore.Mvc;

namespace FlotDotNet.Web.Controllers
{
    public class ExamplesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

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

            chart.XAxis.Ticks.Add(0);
            chart.XAxis.Ticks.Add(Math.PI / 2, "\u03c0/2");
            chart.XAxis.Ticks.Add(Math.PI, "\u03c0");
            chart.XAxis.Ticks.Add(Math.PI * 3 / 2, "3\u03c0/2");
            chart.XAxis.Ticks.Add(Math.PI * 2, "2\u03c0");

            chart.YAxis.Ticks = 10;
            chart.YAxis.Min = -2;
            chart.YAxis.Max = 2;
            chart.YAxis.TickDecimals = 3;

            chart.Grid.BorderWidth = 1;
            chart.Grid.BackgroundColor = new[] { "#fff", "#eee" };

            chart.Grid.BorderWidth.Left = 2;
            chart.Grid.BorderWidth.Bottom = 2;

            return View(chart);
        }

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

            chart.XAxis.Ticks = 0;
            chart.XAxis.AutoscaleMargin = 0.02;

            chart.YAxis.Min = -2;
            chart.YAxis.Max = 2;

            return View(chart);
        }

        public IActionResult SeriesToggle()
        {
            var chart = new FlotChart();

            var usa = chart.CreateSeries("usa", "USA");
            usa.Data = new FlotDataPointCollection { { 1988, 483994 }, { 1989, 479060 }, { 1990, 457648 }, { 1991, 401949 }, { 1992, 424705 }, { 1993, 402375 }, { 1994, 377867 }, { 1995, 357382 }, { 1996, 337946 }, { 1997, 336185 }, { 1998, 328611 }, { 1999, 329421 }, { 2000, 342172 }, { 2001, 344932 }, { 2002, 387303 }, { 2003, 440813 }, { 2004, 480451 }, { 2005, 504638 }, { 2006, 528692 } };

            var russia = chart.CreateSeries("russia", "Russia");
            russia.Data = new FlotDataPointCollection { { 1988, 218000 }, { 1989, 203000 }, { 1990, 171000 }, { 1992, 42500 }, { 1993, 37600 }, { 1994, 36600 }, { 1995, 21700 }, { 1996, 19200 }, { 1997, 21300 }, { 1998, 13600 }, { 1999, 14000 }, { 2000, 19100 }, { 2001, 21300 }, { 2002, 23600 }, { 2003, 25100 }, { 2004, 26100 }, { 2005, 31100 }, { 2006, 34700 } };

            var uk = chart.CreateSeries("uk", "UK");
            uk.Data = new FlotDataPointCollection { { 1988, 62982 }, { 1989, 62027 }, { 1990, 60696 }, { 1991, 62348 }, { 1992, 58560 }, { 1993, 56393 }, { 1994, 54579 }, { 1995, 50818 }, { 1996, 50554 }, { 1997, 48276 }, { 1998, 47691 }, { 1999, 47529 }, { 2000, 47778 }, { 2001, 48760 }, { 2002, 50949 }, { 2003, 57452 }, { 2004, 60234 }, { 2005, 60076 }, { 2006, 59213 } };

            var germany = chart.CreateSeries("germany", "Germany");
            germany.Data = new FlotDataPointCollection { { 1988, 55627 }, { 1989, 55475 }, { 1990, 58464 }, { 1991, 55134 }, { 1992, 52436 }, { 1993, 47139 }, { 1994, 43962 }, { 1995, 43238 }, { 1996, 42395 }, { 1997, 40854 }, { 1998, 40993 }, { 1999, 41822 }, { 2000, 41147 }, { 2001, 40474 }, { 2002, 40604 }, { 2003, 40044 }, { 2004, 38816 }, { 2005, 38060 }, { 2006, 36984 } };

            var denmark = chart.CreateSeries("denmark", "Denmark");
            denmark.Data = new FlotDataPointCollection { { 1988, 3813 }, { 1989, 3719 }, { 1990, 3722 }, { 1991, 3789 }, { 1992, 3720 }, { 1993, 3730 }, { 1994, 3636 }, { 1995, 3598 }, { 1996, 3610 }, { 1997, 3655 }, { 1998, 3695 }, { 1999, 3673 }, { 2000, 3553 }, { 2001, 3774 }, { 2002, 3728 }, { 2003, 3618 }, { 2004, 3638 }, { 2005, 3467 }, { 2006, 3770 } };

            var sweden = chart.CreateSeries("sweden", "Sweden");
            sweden.Data = new FlotDataPointCollection { { 1988, 6402 }, { 1989, 6474 }, { 1990, 6605 }, { 1991, 6209 }, { 1992, 6035 }, { 1993, 6020 }, { 1994, 6000 }, { 1995, 6018 }, { 1996, 3958 }, { 1997, 5780 }, { 1998, 5954 }, { 1999, 6178 }, { 2000, 6411 }, { 2001, 5993 }, { 2002, 5833 }, { 2003, 5791 }, { 2004, 5450 }, { 2005, 5521 }, { 2006, 5271 } };

            var norway = chart.CreateSeries("norway", "Norway");
            norway.Data = new FlotDataPointCollection { { 1988, 4382 }, { 1989, 4498 }, { 1990, 4535 }, { 1991, 4398 }, { 1992, 4766 }, { 1993, 4441 }, { 1994, 4670 }, { 1995, 4217 }, { 1996, 4275 }, { 1997, 4203 }, { 1998, 4482 }, { 1999, 4506 }, { 2000, 4358 }, { 2001, 4385 }, { 2002, 5269 }, { 2003, 5066 }, { 2004, 5194 }, { 2005, 4887 }, { 2006, 4891 } };

            // hard-code color indices to prevent them from shifting as
            // countries are turned on/off
            int i = 0;
            foreach (var series in chart.Series)
            {
                series.Color = i;
                ++i;
            }

            chart.YAxis.Min = 0;
            chart.XAxis.TickDecimals = 0;

            return View(chart);
        }
    }
}