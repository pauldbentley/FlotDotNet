namespace FlotDotNet.Tests
{
    using Shouldly;
    using Xunit;

    public class FlotChartOptionsSeriesTests : TestClass
    {
        [Fact]
        public void Empty()
        {
            var input = new FlotChartOptionsSeries();
            string actual = SerializeObject(input);
            actual.ShouldBe("{}");
        }

        [Fact]
        public void WithValues()
        {
            var input = new FlotChartOptionsSeries
            {
                Bars = new FlotBars
                {
                    Show = true
                },
                Lines = new FlotLines
                {
                    Show = true,
                },
                Points = new FlotPoints
                {
                    Show = true
                },
                Stack = true
            };
            string actual = SerializeObject(input);
            actual.ShouldBe("{\"bars\":{\"show\":true},\"lines\":{\"show\":true},\"points\":{\"show\":true},\"stack\":true}");
        }
    }
}
