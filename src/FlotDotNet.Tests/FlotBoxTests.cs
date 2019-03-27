namespace FlotDotNet.Tests
{
    using Shouldly;
    using Xunit;

    public class FlotBoxTests : TestClass
    {
        [Fact]
        public void SingleValue()
        {
            var input = new FlotBox<int>(1);

            string actual = SerializeObject(input);
            actual.ShouldBe("1");
        }

        [Fact]
        public void TopBottomLeftRight()
        {
            var input = new FlotBox<int>(1, 2);

            string actual = SerializeObject(input);
            actual.ShouldBe("{\"top\":1,\"right\":2,\"bottom\":1,\"left\":2}");
        }

        [Fact]
        public void AllBorders()
        {
            var input = new FlotBox<int>(1, 2, 3, 4);

            string actual = SerializeObject(input);
            actual.ShouldBe("{\"top\":1,\"right\":2,\"bottom\":3,\"left\":4}");
        }

        [Fact]
        public void AllNull()
        {
            var input = new FlotBox<int?>(null);

            string actual = SerializeObject(input);
            actual.ShouldBe("{}");
        }
    }
}
