namespace FlotDotNet.Tests
{
    using Shouldly;
    using Xunit;

    public class FlotAxisTests : TestClass
    {
        [Fact]
        public void WhenEmpty_ShouldSerialize()
        {
            var input = new FlotAxis();
            string actual = SerializeObject(input);
            actual.ShouldBe("{}");
        }
    }
}
