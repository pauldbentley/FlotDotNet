namespace FlotDotNet.Tests
{
    using Shouldly;
    using Xunit;

    public class FlotSeriesTests : TestClass
    {
        [Fact]
        public void WhenEmpty()
        {
            var input = new FlotSeries("d1");
            string actual = SerializeObject(input);
            actual.ShouldBe("{\"data\":[]}");
        }
    }
}
