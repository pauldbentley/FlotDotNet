namespace FlotDotNet.Tests
{
    using Shouldly;
    using Xunit;

    public class FlotColorTests : TestClass
    {
        [Fact]
        public void WithIndex()
        {
            var input = new FlotColor(1);

            string actual = SerializeObject(input);
            actual.ShouldBe("1");

            bool equals = input == 1;
            equals.ShouldBe(true);
        }

        [Fact]
        public void WithColor()
        {
            var input = new FlotColor("#333");

            string actual = SerializeObject(input);
            actual.ShouldBe("\"#333\"");

            bool equals = input == "#333";
            equals.ShouldBe(true);
        }
    }
}
