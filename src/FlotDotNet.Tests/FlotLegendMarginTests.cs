namespace FlotDotNet.Tests
{
    using Shouldly;
    using Xunit;

    public class FlotLegendMarginTests : TestClass
    {
        [Fact]
        public void SingleMargin()
        {
            var input = new FlotLegendMargin(10);
            string actual = SerializeObject(input);
            actual.ShouldBe("10");
        }

        [Fact]
        public void MultipleMargins()
        {
            var input = new FlotLegendMargin(10, 20);
            string actual = SerializeObject(input);
            actual.ShouldBe("[10,20]");
        }
    }
}
