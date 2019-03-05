namespace FlotDotNet.Tests
{
    using Newtonsoft.Json;
    using Shouldly;
    using Xunit;

    public class FlotEnumTests
    {
        [Fact]
        public void ShouldSerialize()
        {
            var testEnum = new TestEnum("TestEnum");
            string actual = JsonConvert.SerializeObject(testEnum, FlotConfiguration.SerializerSettings);
            actual.ShouldBe("\"testenum\"");
        }
    }
}
