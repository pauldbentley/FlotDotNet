namespace FlotDotNet.Tests
{
    using Newtonsoft.Json;
    using Shouldly;
    using Xunit;

    public class FlotColorGradientTests
    {
        [Fact]
        public void FlotColor_WithIndex_ShouldSerialize()
        {
            var gradient = new FlotColorGradient(1);
            string actual = JsonConvert.SerializeObject(gradient, FlotConfiguration.SerializerSettings);
            actual.ShouldBe("1");
        }

        [Fact]
        public void FlotColor_WithColor_ShouldSerialize()
        {
            var gradient = new FlotColorGradient("#111");
            string actual = JsonConvert.SerializeObject(gradient, FlotConfiguration.SerializerSettings);
            actual.ShouldBe("\"#111\"");
        }

        [Fact]
        public void FlotColor_WithMultipleColors_ShouldSerialize()
        {
            var gradient = new FlotColorGradient();
            gradient.Add("#111", "#222", "#333");
            string actual = JsonConvert.SerializeObject(gradient, FlotConfiguration.SerializerSettings);
            actual.ShouldBe("{\"colors\":[\"#111\",\"#222\",\"#333\"]}");
        }
    }
}
