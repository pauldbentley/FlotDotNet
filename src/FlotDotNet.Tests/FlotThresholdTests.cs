namespace FlotDotNet.Tests
{
    using Newtonsoft.Json;
    using Shouldly;
    using Xunit;

    public class FlotThresholdTests
    {
        [Fact]
        public void FlotThreshold_ShouldSerialize()
        {
            var threshold = new FlotThreshold(5, "#333");
            string actual = JsonConvert.SerializeObject(threshold, FlotConfiguration.SerializerSettings);
            actual.ShouldBe("{\"below\":5.0,\"color\":\"#333\"}");
        }

        [Fact]
        public void FlotThresholdCollection_SingleItem_ShouldSerialize()
        {
            var thresholds = new FlotThresholdCollection
            {
                { 5, "#333" }
            };

            string actual = JsonConvert.SerializeObject(thresholds, FlotConfiguration.SerializerSettings);
            actual.ShouldBe("{\"below\":5.0,\"color\":\"#333\"}");
        }

        [Fact]
        public void FlotThresholdCollection_List_ShouldSerialize()
        {
            var thresholds = new FlotThresholdCollection
            {
                { 5, "#333" },
                { 10, "#fff" }
            };

            string actual = JsonConvert.SerializeObject(thresholds, FlotConfiguration.SerializerSettings);
            actual.ShouldBe("[{\"below\":5.0,\"color\":\"#333\"},{\"below\":10.0,\"color\":\"#fff\"}]");
        }
    }
}
