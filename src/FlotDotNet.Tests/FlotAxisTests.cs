namespace FlotDotNet.Tests
{
    using FlotDotNet.Infrastruture;
    using Shouldly;
    using Xunit;

    public class FlotAxisTests
    {
        [Fact]
        public void WhenEmpty_ShouldNotSerialize()
        {
            var axis = new FlotAxis();
            bool actual = SerializationHelper.ShouldSerialize(axis);
            actual.ShouldBe(false);
        }
    }
}
