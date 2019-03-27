namespace FlotDotNet.Tests
{
    using System.Collections.Generic;
    using Shouldly;
    using Xunit;

    public class FlotBarsTests : TestClass
    {
        [Fact]
        public void Empty()
        {
            var input = new FlotBars();
            string actual = SerializeObject(input);
            actual.ShouldBe("{}");
        }

        [Fact]
        public void WithFillColor()
        {
            var input = new FlotBars
            {
                FillColor = "#333"
            };
            string actual = SerializeObject(input);
            actual.ShouldBe("{\"fillColor\":\"#333\"}");
        }

        [Fact]
        public void WithFillGradient()
        {
            var input = new FlotBars
            {
                FillGradient = new List<FlotScaling>
                {
                    { 0.1, 0.2 },
                    { 0.3, 0.4 }
                }
            };
            string actual = SerializeObject(input);
            actual.ShouldBe("{\"fillColor\":{\"colors\":[{\"opacity\":0.1,\"brightness\":0.2},{\"opacity\":0.3,\"brightness\":0.4}]}}");
        }
    }
}
