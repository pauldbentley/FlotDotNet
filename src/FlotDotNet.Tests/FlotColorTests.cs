namespace FlotDotNet.Tests
{
    using Newtonsoft.Json;
    using Shouldly;
    using Xunit;

    public class FlotColorTests
    {
        [Fact]
        public void WithIndex_ShouldSerialize()
        {
            var color = new FlotColor(1);
            string actual = JsonConvert.SerializeObject(color, FlotConfiguration.SerializerSettings);
            actual.ShouldBe("1");
        }

        [Fact]
        public void WithColor_ShouldSerialize()
        {
            var color = new FlotColor("#333");
            string actual = JsonConvert.SerializeObject(color, FlotConfiguration.SerializerSettings);
            actual.ShouldBe("\"#333\"");
        }
    }
}
