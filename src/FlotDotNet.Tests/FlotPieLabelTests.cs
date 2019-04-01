namespace FlotDotNet.Tests
{
    using Shouldly;
    using Xunit;

    public class FlotPieLabelTests : TestClass
    {
        [Fact]
        public void Empty()
        {
            var input = new FlotPieLabel();

            string actual = SerializeObject(input);
            actual.ShouldBe("{}");
        }

        [Fact]
        public void Formatter()
        {
            var input = new FlotPieLabel
            {
                Formatter = "formatFunction"
            };

            string actual = SerializeObject(input);
            actual.ShouldBe("{\"formatter\":formatFunction}");
        }

        [Fact]
        public void Background()
        {
            var input = new FlotPieLabel();
            input.Background.Color = "#333";

            string actual = SerializeObject(input);
            actual.ShouldBe("{\"background\":{\"color\":\"#333\"}}");
        }
    }
}
