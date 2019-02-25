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
                yield return Example3;
                yield return Example4;
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

        private void Example3()
        {
            Title = "Custom Label Formatter";
            Description = "Added a semi-transparent background to the labels and a custom labelFormatter function.";
            Code = new[]
            {
                "$.plot('#placeholder', data, {",
                "    series: {",
                "        pie: {",
                "            show: true,",
                "            radius: 1,",
                "            label: {",
                "                show: true,",
                "                radius: 1,",
                "                formatter: labelFormatter,",
                "                background: {",
                "                    opacity: 0.8",
                "                }",
                "            }",
                "        }",
                "    },",
                "    legend: {",
                "        show: false",
                "    }",
                "});"
            };

            Chart.Legend.Show = false;
            Chart.Pie.Radius = 1;

            var label = Chart.Pie.Label;
            label.Show = true;
            label.Radius = 1;
            label.Formatter = "labelFormatter";
            label.Background.Opacity = 0.8;
        }

        private void Example4()
        {
            Title = "Label Radius";
            Description = "Slightly more transparent label backgrounds and adjusted the radius values to place them within the pie.";
            Code = new[]
            {
                "$.plot('#placeholder', data, {",
                "    series: {",
                "        pie: {",
                "            show: true,",
                "            radius: 1,",
                "            label: {",
                "                show: true,",
                "                radius: 3/4,",
                "                formatter: labelFormatter,",
                "                background: {",
                "                    opacity: 0.5",
                "                }",
                "            }",
                "        }",
                "    },",
                "    legend: {",
                "        show: false",
                "    }",
                "});"
            };

            Chart.Legend.Show = false;
            Chart.Pie.Radius = 1;

            var label = Chart.Pie.Label;
            label.Show = true;
            label.Radius = 3 / 4d;
            label.Formatter = "labelFormatter";
            label.Background.Opacity = 0.5;
        }
    }
}
