namespace FlotDotNet.Tests
{
    using Shouldly;
    using Xunit;

    public class FlotDataPointTests : TestClass
    {
        [Fact]
        public void XY_ShouldSerialize()
        {
            var input = new FlotDataPoint(1, 2);
            string actual = SerializeObject(input);
            actual.ShouldBe("[1.0,2.0]");
        }

        [Fact]
        public void XYBottom_ShouldSerialize()
        {
            var input = new FlotDataPoint(1, 2, 3);
            string actual = SerializeObject(input);
            actual.ShouldBe("[1.0,2.0,3.0]");
        }
    }
}
