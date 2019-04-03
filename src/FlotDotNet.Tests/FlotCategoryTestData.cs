namespace FlotDotNet.Tests
{
    using Shouldly;
    using Xunit;

    public class FlotCategoryTestData : TestClass
    {
        [Fact]
        public void DataArray()
        {
            var input = new FlotCategoryData("Testing", 123);

            string actual = SerializeObject(input);
            actual.ShouldBe("[\"Testing\",123.0]");
        }
    }
}
