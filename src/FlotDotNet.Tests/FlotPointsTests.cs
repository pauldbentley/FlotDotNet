namespace FlotDotNet.Tests
{
    using Shouldly;
    using Xunit;

    public class FlotPointsTests : TestClass
    {
        [Fact]
        public void WhenEmpty_ShouldSerialize()
        {
            var input = new FlotPoints();
            string actual = SerializeObject(input);
            actual.ShouldBe("{}");
        }

        [Fact]
        public void WithCircle_ShouldSerialize()
        {
            var input = new FlotPoints
            {
                Radius = 10,
                Fill = true,
                FillColor = "#333",
                LineWidth = 1,
                Show = true,
                Symbol = "circle"
            };

            string actual = SerializeObject(input);
            actual.ShouldBe("{\"radius\":10,\"fillColor\":\"#333\",\"symbol\":\"circle\",\"show\":true,\"lineWidth\":1,\"fill\":true}");
        }

        [Fact]
        public void WithFunction_ShouldSerialize()
        {
            var input = new FlotPoints
            {
                Radius = 10,
                Fill = true,
                FillColor = "#333",
                LineWidth = 1,
                Show = true,
                Symbol = "crossSymbol"
            };

            string actual = SerializeObject(input);
            actual.ShouldBe("{\"radius\":10,\"fillColor\":\"#333\",\"symbol\":crossSymbol,\"show\":true,\"lineWidth\":1,\"fill\":true}");
        }
    }
}
