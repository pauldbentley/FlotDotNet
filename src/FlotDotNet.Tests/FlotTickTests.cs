namespace FlotDotNet.Tests
{
    using Newtonsoft.Json;
    using Shouldly;
    using Xunit;

    public class FlotTickTests
    {
        [Fact]
        public void WithValue_ShouldSerialize()
        {
            var tick = new FlotTick(1);
            string actual = JsonConvert.SerializeObject(tick, FlotConfiguration.SerializerSettings);
            actual.ShouldBe("1.0");
        }

        [Fact]
        public void WithValueAndLabel_ShouldSerialize()
        {
            var tick = new FlotTick(1, "Tick");
            string actual = JsonConvert.SerializeObject(tick, FlotConfiguration.SerializerSettings);
            actual.ShouldBe("[1.0,\"Tick\"]");
        }

        [Fact]
        public void WithValueAndTimeLabel_ShouldSerialize()
        {
            var tick = new FlotTick(1, 1234);
            string actual = JsonConvert.SerializeObject(tick, FlotConfiguration.SerializerSettings);
            actual.ShouldBe("[1.0,1234.0]");
        }
    }
}
