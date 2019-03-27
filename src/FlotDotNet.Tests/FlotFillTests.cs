namespace FlotDotNet.Tests
{
    using Shouldly;
    using Xunit;

    public class FlotFillTests : TestClass
    {
        [Fact]
        public void WithFill()
        {
            var input = new FlotFill(0.9);
            string actual = SerializeObject(input);
            actual.ShouldBe("0.9");
        }

        [Fact]
        public void WithFull()
        {
            var input = new FlotFill(true);
            string actual = SerializeObject(input);
            actual.ShouldBe("true");
        }
    }
}
