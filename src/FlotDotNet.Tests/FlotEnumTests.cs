namespace FlotDotNet.Tests
{
    using Shouldly;
    using Xunit;

    public class FlotEnumTests : TestClass
    {
        [Fact]
        public void ShouldSerialize()
        {
            var input = FlotAxisMode.Decimal;
            string actual = SerializeObject(input);
            actual.ShouldBe("\"decimal\"");
        }
    }
}
