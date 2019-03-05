namespace FlotDotNet.Tests
{
    using Newtonsoft.Json;
    using Shouldly;
    using Xunit;

    public class FlotThresholdTests
    {
        [Fact]
        public void ShouldSerialize()
        {
            var threshold = new FlotThreshold(5, "#333");
            string actual = JsonConvert.SerializeObject(threshold, FlotConfiguration.SerializerSettings);
            actual.ShouldBe("{\"below\":5.0,\"color\":\"#333\"}");
        }
    }
}
