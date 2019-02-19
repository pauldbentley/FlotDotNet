namespace FlotDotNet.Tests
{
    using Newtonsoft.Json;
    using Shouldly;
    using Xunit;

    public class FlotAxisTests
    {
        [Fact]
        public void FlotAxis_Empty_ShouldSerialize()
        {
            var axis = new FlotAxis();
            string actual = JsonConvert.SerializeObject(axis, FlotConfiguration.SerializerSettings);
            actual.ShouldBe("{}");
        }
    }
}
