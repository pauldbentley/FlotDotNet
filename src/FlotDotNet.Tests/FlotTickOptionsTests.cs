namespace FlotDotNet.Tests
{
    using Shouldly;
    using Xunit;

    public class FlotTickOptionsTests : TestClass
    {
        [Fact]
        public void WithFunction_ShouldSerialize()
        {
            var input = new FlotTickOptions("functionName");
            string actual = SerializeObject(input);
            actual.ShouldBe("functionName");
        }

        [Fact]
        public void WithNumber_ShouldSerialize()
        {
            var input = new FlotTickOptions(1);
            string actual = SerializeObject(input);
            actual.ShouldBe("1");
        }

        [Fact]
        public void WithTicks_ShouldSerialize()
        {
            var input = new FlotTickOptions
            {
                1, 2, 3, 4, 5, 6,
                { 7, "Seven" },
                { 8, "Eight" }
            };

            string actual = SerializeObject(input);
            actual.ShouldBe("[1.0,2.0,3.0,4.0,5.0,6.0,[7.0,\"Seven\"],[8.0,\"Eight\"]]");
        }
    }
}
