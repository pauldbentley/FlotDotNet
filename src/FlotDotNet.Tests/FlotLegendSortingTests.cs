namespace FlotDotNet.Tests
{
    using Shouldly;
    using Xunit;

    public class FlotLegendSortingTests : TestClass
    {
        [Fact]
        public void WithBoolean()
        {
            var input = new FlotLegendSorting(true);

            string actual = SerializeObject(input);
            actual.ShouldBe("true");
        }

        [Fact]
        public void Ascending()
        {
            var input = FlotLegendSorting.Ascending;

            string actual = SerializeObject(input);
            actual.ShouldBe("\"ascending\"");
        }

        [Fact]
        public void Descending()
        {
            var input = FlotLegendSorting.Descending;

            string actual = SerializeObject(input);
            actual.ShouldBe("\"descending\"");
        }

        [Fact]
        public void Reverse()
        {
            var input = FlotLegendSorting.Reverse;

            string actual = SerializeObject(input);
            actual.ShouldBe("\"reverse\"");
        }

        [Fact]
        public void Comparator()
        {
            FlotLegendSorting input = "comparatorFunction";

            string actual = SerializeObject(input);
            actual.ShouldBe("comparatorFunction");
        }
    }
}
