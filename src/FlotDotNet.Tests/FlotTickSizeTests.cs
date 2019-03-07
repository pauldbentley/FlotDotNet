namespace FlotDotNet.Tests
{
    using Shouldly;
    using Xunit;

    public class FlotTickSizeTests : TestClass
    {
        [Fact]
        public void WithTickSize_ShouldSerialize()
        {
            var input = new FlotTickSize(10);
            string actual = SerializeObject(input);
            actual.ShouldBe("10");
        }

        [Fact]
        public void WithTimeUnit_ShouldSerialize()
        {
            var input = new FlotTickSize(10, FlotTickUnit.Hour);
            string actual = SerializeObject(input);
            actual.ShouldBe("[10,\"hour\"]");
        }
    }
}
