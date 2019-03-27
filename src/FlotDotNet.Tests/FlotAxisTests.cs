namespace FlotDotNet.Tests
{
    using Shouldly;
    using Xunit;

    public class FlotAxisTests : TestClass
    {
        [Fact]
        public void Empty()
        {
            var input = new FlotAxis();
            string actual = SerializeObject(input);
            actual.ShouldBe("{}");
        }

        [Fact]
        public void WithTickFormatter()
        {
            var input = new FlotAxis
            {
                TickFormatter = "tickFormatFunction"
            };
            string actual = SerializeObject(input);
            actual.ShouldBe("{\"tickFormatter\":tickFormatFunction}");
        }

        [Fact]
        public void WithTickTransform()
        {
            var input = new FlotAxis
            {
                Transform = "transformFunction"
            };
            string actual = SerializeObject(input);
            actual.ShouldBe("{\"transform\":transformFunction}");
        }

        [Fact]
        public void WithTickInverseTransform()
        {
            var input = new FlotAxis
            {
                InverseTransform = "inverseTransformFunction"
            };
            string actual = SerializeObject(input);
            actual.ShouldBe("{\"inverseTransform\":inverseTransformFunction}");
        }
    }
}
