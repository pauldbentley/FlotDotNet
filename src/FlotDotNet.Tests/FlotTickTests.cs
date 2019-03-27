namespace FlotDotNet.Tests
{
    using Shouldly;
    using Xunit;

    public class FlotTickTests : TestClass
    {
        [Fact]
        public void WithValue()
        {
            var input = new FlotTick(1);
            string actual = SerializeObject(input);
            actual.ShouldBe("1.0");
        }

        [Fact]
        public void WithValueAndLabel()
        {
            var input = new FlotTick(1, "Tick");
            string actual = SerializeObject(input);
            actual.ShouldBe("[1.0,\"Tick\"]");
        }

        [Fact]
        public void WithValueAndTimeLabel()
        {
            var input = new FlotTick(1, 1234);
            string actual = SerializeObject(input);
            actual.ShouldBe("[1.0,1234.0]");
        }
    }
}
