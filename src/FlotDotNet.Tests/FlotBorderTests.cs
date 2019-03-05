namespace FlotDotNet.Tests
{
    using Newtonsoft.Json;
    using Shouldly;
    using Xunit;

    public class FlotBorderTests
    {
        [Fact]
        public void SingleValue_ShouldSerialize()
        {
            var input = new FlotGridBorder(1);
            string actual = JsonConvert.SerializeObject(input, FlotConfiguration.SerializerSettings);
            actual.ShouldBe("1");
        }

        [Fact]
        public void TopBottomLeftRight_ShouldSerialize()
        {
            var input = new FlotGridBorder(1, 2);
            string actual = JsonConvert.SerializeObject(input, FlotConfiguration.SerializerSettings);
            actual.ShouldBe("{\"top\":1,\"right\":2,\"bottom\":1,\"left\":2}");
        }

        [Fact]
        public void AllBorders_ShouldSerialize()
        {
            var input = new FlotGridBorder(1, 2, 3, 4);
            string actual = JsonConvert.SerializeObject(input, FlotConfiguration.SerializerSettings);
            actual.ShouldBe("{\"top\":1,\"right\":2,\"bottom\":3,\"left\":4}");
        }
    }
}
