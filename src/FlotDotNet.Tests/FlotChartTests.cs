namespace FlotDotNet.Tests
{
    using Shouldly;
    using Xunit;

    public class FlotChartTests : TestClass
    {
        [Fact]
        public void Empty()
        {
            var input = new FlotChart();

            string actual = SerializeObject(input);
            actual.ShouldContain("\"options\":{}");
            actual.ShouldContain("\"plot\":null");
            actual.ShouldContain("\"placeholder\":\"#chart_placeholder\"");
            actual.ShouldContain("\"plotChart\":function");
            actual.ShouldContain("\"data\":{}");
        }
    }
}
