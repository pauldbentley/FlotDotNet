namespace FlotDotNet.Tests
{
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;
    using Shouldly;
    using Xunit;

    public class FlotFillTests
    {
        [Fact]
        public void FlotFill_WithFill_ShouldSerialize()
        {
            FlotFill fill = 0.9;
            string actual = JsonConvert.SerializeObject(fill, FlotConfiguration.SerializerSettings);
            actual.ShouldBe("0.9");
        }

        [Fact]
        public void FlotFill_WithFull_ShouldSerialize()
        {
            FlotFill fill = true;
            string actual = JsonConvert.SerializeObject(fill, FlotConfiguration.SerializerSettings);
            actual.ShouldBe("true");
        }
    }
}
