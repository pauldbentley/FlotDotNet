namespace FlotDotNet.Tests
{
    using Shouldly;
    using Xunit;

    public class FlotCategoryTests : TestClass
    {
        [Fact]
        public void WithValue()
        {
            var input = new FlotCategory("The Name", 1);

            bool equals = input == "The Name";
            equals.ShouldBe(true);
        }

        [Fact]
        public void WithoutValue()
        {
            var input = new FlotCategory("The Name");

            bool equals = input == "The Name";
            equals.ShouldBe(true);
        }
    }
}
