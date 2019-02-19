namespace FlotDotNet.Tests
{
    using Newtonsoft.Json;
    using Shouldly;
    using Xunit;

    public class FlotTickTests
    {
        [Fact]
        public void FlotColor_WithValue_ShouldSerialize()
        {
            var tick = new FlotTick(1);
            string actual = JsonConvert.SerializeObject(tick, FlotConfiguration.SerializerSettings);
            actual.ShouldBe("1.0");
        }

        [Fact]
        public void FlotColor_WithValueAndLabel_ShouldSerialize()
        {
            var tick = new FlotTick(1, "Tick");
            string actual = JsonConvert.SerializeObject(tick, FlotConfiguration.SerializerSettings);
            actual.ShouldBe("[1.0,\"Tick\"]");
        }
    }
}
