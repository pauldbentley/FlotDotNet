namespace FlotDotNet.Tests
{
    using Shouldly;
    using Xunit;

    public class FlotEnumTests : TestClass
    {
        [Fact]
        public void ShouldSerialize()
        {
            var input = new TestEnum("TestEnum");
            string actual = SerializeObject(input);
            actual.ShouldBe("\"testenum\"");
        }
    }
}
