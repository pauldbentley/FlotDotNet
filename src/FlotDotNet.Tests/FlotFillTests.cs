namespace FlotDotNet.Tests
{
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;
    using Shouldly;
    using Xunit;

    public class FlotFillTests
    {
        [Fact]
        public void WithFill_ShouldSerialize()
        {
            var fill = new FlotFill(0.9);
            string actual = JsonConvert.SerializeObject(fill, FlotConfiguration.SerializerSettings);
            actual.ShouldBe("0.9");
        }

        [Fact]
        public void WithFull_ShouldSerialize()
        {
            var fill = new FlotFill(true);
            string actual = JsonConvert.SerializeObject(fill, FlotConfiguration.SerializerSettings);
            actual.ShouldBe("true");
        }
    }
}
