namespace FlotDotNet.Tests
{
    using System.Collections.Generic;
    using System.Runtime.Serialization;
    using Shouldly;
    using Xunit;

    public class FlotAxisTests : TestClass
    {
        [Fact]
        public void Empty()
        {
            var input = new FlotAxis();

            string actual = SerializeObject(input);
            actual.ShouldBe("{}");
        }

        [Fact]
        public void WithTickFormatter()
        {
            var input = new FlotAxis
            {
                TickFormatter = "tickFormatFunction"
            };

            string actual = SerializeObject(input);
            actual.ShouldBe("{\"tickFormatter\":tickFormatFunction}");
        }

        [Fact]
        public void WithTickTransform()
        {
            var input = new FlotAxis
            {
                Transform = "transformFunction"
            };

            string actual = SerializeObject(input);
            actual.ShouldBe("{\"transform\":transformFunction}");
        }

        [Fact]
        public void WithTickInverseTransform()
        {
            var input = new FlotAxis
            {
                InverseTransform = "inverseTransformFunction"
            };

            string actual = SerializeObject(input);
            actual.ShouldBe("{\"inverseTransform\":inverseTransformFunction}");
        }

        [Fact]
        public void WithMonthNames()
        {
            var input = new FlotAxis
            {
                MonthNames = new List<string> { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12" }
            };

            string actual = SerializeObject(input);
            actual.ShouldBe("{\"monthNames\":[\"1\",\"2\",\"3\",\"4\",\"5\",\"6\",\"7\",\"8\",\"9\",\"10\",\"11\",\"12\"]}");
        }

        [Fact]
        public void WithDayNames()
        {
            var input = new FlotAxis
            {
                DayNames = new List<string> { "1", "2", "3", "4", "5", "6", "7" }
            };

            string actual = SerializeObject(input);
            actual.ShouldBe("{\"dayNames\":[\"1\",\"2\",\"3\",\"4\",\"5\",\"6\",\"7\"]}");
        }
    }
}
