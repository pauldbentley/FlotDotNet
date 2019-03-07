namespace FlotDotNet.Tests
{
    using Shouldly;
    using Xunit;

    public class FlotBoxTests : TestClass
    {
        [Fact]
        public void SingleValue_ShouldSerialize()
        {
            var input = new FlotBox<int>(1);
            string actual = SerializeObject(input);
            actual.ShouldBe("1");
        }

        [Fact]
        public void TopBottomLeftRight_ShouldSerialize()
        {
            var input = new FlotBox<int>(1, 2);
            string actual = SerializeObject(input);
            actual.ShouldBe("{\"top\":1,\"right\":2,\"bottom\":1,\"left\":2}");
        }

        [Fact]
        public void AllBorders_ShouldSerialize()
        {
            var input = new FlotBox<int>(1, 2, 3, 4);
            string actual = SerializeObject(input);
            actual.ShouldBe("{\"top\":1,\"right\":2,\"bottom\":3,\"left\":4}");
        }
    }
}
