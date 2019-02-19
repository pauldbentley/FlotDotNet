namespace FlotDotNet.Tests
{
    using Newtonsoft.Json;
    using Shouldly;
    using Xunit;

    public class FlotFillTests
    {
        [Fact]
        public void FlotFill_WithFill_ShouldSerialize()
        {
            var fill = new FlotFill(0.9);
            string actual = JsonConvert.SerializeObject(fill, FlotConfiguration.SerializerSettings);
            string expected = JsonConvert.SerializeObject(fill.Number, FlotConfiguration.SerializerSettings);
            actual.ShouldBe(expected);
        }

        [Fact]
        public void FlotFill_WithFull_ShouldSerialize()
        {
            var fill = new FlotFill(true);
            string actual = JsonConvert.SerializeObject(fill, FlotConfiguration.SerializerSettings);
            actual.ShouldBe("true");
        }
    }
}
