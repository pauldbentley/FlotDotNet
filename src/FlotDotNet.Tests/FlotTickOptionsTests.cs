namespace FlotDotNet.Tests
{
    using Newtonsoft.Json;
    using Shouldly;
    using Xunit;

    public class FlotTickOptionsTests
    {
        [Fact]
        public void WithFunction_ShouldSerialize()
        {
            var options = new FlotTickOptions("functionName");
            string actual = JsonConvert.SerializeObject(options, FlotConfiguration.SerializerSettings);
            actual.ShouldBe("functionName");
        }

        [Fact]
        public void WithNumber_ShouldSerialize()
        {
            var options = new FlotTickOptions(1);
            string actual = JsonConvert.SerializeObject(options, FlotConfiguration.SerializerSettings);
            actual.ShouldBe("1");
        }

        [Fact]
        public void WithTicks_ShouldSerialize()
        {
            var options = new FlotTickOptions
            {
                1, 2, 3, 4, 5, 6,
                { 7, "Seven" },
                { 8, "Eight" }
            };

            string actual = JsonConvert.SerializeObject(options, FlotConfiguration.SerializerSettings);
            actual.ShouldBe("[1.0,2.0,3.0,4.0,5.0,6.0,[7.0,\"Seven\"],[8.0,\"Eight\"]]");
        }
    }
}
