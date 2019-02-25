using System;
using System.Collections.Generic;
using System.Linq;

namespace FlotDotNet.Web.Models.Examples
{
    public class SeriesPieViewModel
    {
        public SeriesPieViewModel(int example)
        {
            Chart.PlaceholderId = "placeholder";
            Chart.Pie.Show = true;

            int dataCount = Convert.ToInt32(Math.Floor(new Random().NextDouble() * 6)) + 3;

            var dataRandom = new Random();
            for (int i = 0; i < dataCount; i++)
            {
                var series = Chart.CreateSeries("d" + (i + 1));
                series.Label = "Series" + (i + 1);
                series.Data.Add(1, Math.Floor(dataRandom.NextDouble() * 100) + 1);
            }

            var setup = Examples.ElementAt(example - 1);
            setup();
        }

        public FlotChart Chart { get; } = new FlotChart();

        public string Title { get; private set; }

        public string Description { get; private set; }

        public IEnumerable<string> Code { get; private set; }

        private IEnumerable<Action> Examples
        {
            get
            {
                yield return Example1;
                yield return Example2;
            }
        }

        private void Example1()
        {
            Title = "Default pie chart";
            Description = "The default pie chart with no options set.";
            Code = new[]
            {
                "$.plot('#placeholder', data, {",
                "    series: {",
                "        pie: {",
                "            show: true",
                "        }",
                "    }",
                "});"
            };
        }

        private void Example2()
        {
            Title = "Default without legend";
            Description = "The default pie chart when the legend is disabled. Since the labels would normally be outside the container, the chart is resized to fit.";
            Code = new[]
            {
                "$.plot('#placeholder', data, {",
                "    series: {",
                "        pie: {",
                "            show: true",
                "        }",
                "    },",
                "    legend: {",
                "        show: false",
                "    }",
                "});"
            };

            Chart.Legend.Show = false;
        }
    }
}
