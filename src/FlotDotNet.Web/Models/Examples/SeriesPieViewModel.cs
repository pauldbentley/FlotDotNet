using System;
using System.Collections.Generic;

namespace FlotDotNet.Web.Models.Examples
{
    public class SeriesPieViewModel
    {
        public SeriesPieViewModel(int example)
        {
            int dataCount = Convert.ToInt32(Math.Floor(new Random().NextDouble() * 6)) + 3;

            var dataRandom = new Random();
            for (int i = 0; i < dataCount; i++)
            {
                var series = Chart.CreateSeries("Series" + (i + 1));
                series.Data.Add(1, Math.Floor(dataRandom.NextDouble() * 100) + 1);
            }

            Examples = SetupExamples();
            var setup = Examples[example - 1];
            setup();
        }

        public FlotChart Chart { get; } = new FlotChart();

        public string Title { get; private set; }

        public string Description { get; private set; }

        public IEnumerable<string> Code { get; private set; }

        private List<Action> Examples { get; }

        private List<Action> SetupExamples()
        {
            return new List<Action>
            {
                Example1
            };
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

            Chart.Pie.Show = true;
        }
    }
}
