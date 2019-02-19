namespace FlotDotNet.Tests
{
    using Newtonsoft.Json;
    using Shouldly;
    using Xunit;

    public class FlotTickOptionsTests
    {
        [Fact]
        public void FlotTickOptions_WithFunction_ShouldSerialize()
        {
            var options = new FlotTickOptions("functionName");
            string actual = JsonConvert.SerializeObject(options, FlotConfiguration.SerializerSettings);
            actual.ShouldBe("functionName");
        }

        [Fact]
        public void FlotTickOptions_WithNumber_ShouldSerialize()
        {
            var options = new FlotTickOptions(1);
            string actual = JsonConvert.SerializeObject(options, FlotConfiguration.SerializerSettings);
            actual.ShouldBe("1");
        }

        [Fact]
        public void FlotTickOptions_WithTicks_ShouldSerialize()
        {
            var options = new FlotTickOptions(1, 2, 3);
            options.Add(4, 5, 6);
            options.Add(7, "Seven");
            options.Add(8, "Eight");
            string actual = JsonConvert.SerializeObject(options, FlotConfiguration.SerializerSettings);
            actual.ShouldBe("[1.0,2.0,3.0,4.0,5.0,6.0,[7.0,\"Seven\"],[8.0,\"Eight\"]]");
        }
    }
}
