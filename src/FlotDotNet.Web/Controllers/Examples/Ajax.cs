using Microsoft.AspNetCore.Mvc;

namespace FlotDotNet.Web.Controllers
{
    public partial class ExamplesController
    {
        public IActionResult Ajax()
        {
            var chart = new FlotChart();

            chart.Lines.Show = true;
            chart.Lines.LineWidth = 2;
            chart.Points.Show = true;
            chart.XAxis.TickDecimals = 0;
            chart.XAxis.TickSize = 1;

            return View(chart);
        }
    }
}