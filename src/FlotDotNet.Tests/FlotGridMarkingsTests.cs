namespace FlotDotNet.Tests
{
    using Shouldly;
    using Xunit;

    public class FlotGridMarkingsTests : TestClass
    {
        [Fact]
        public void WhenEmpty_ShouldSerialize()
        {
            var input = new FlotGridMarkings();
            string actual = SerializeObject(input);
            actual.ShouldBe("[]");
        }

        [Fact]
        public void WithEmptyMarking_ShouldSerialize()
        {
            var input = new FlotGridMarkings
            {
                new FlotGridMarking()
            };
            string actual = SerializeObject(input);
            actual.ShouldBe("[{}]");
        }

        [Fact]
        public void WithData_ShouldSerialize()
        {
            var input = new FlotGridMarkings
            {
                new FlotGridMarking
                {
                    XAxis = new FlotMarking(1, 2),
                    YAxis = new FlotMarking(3, 4),
                    Color = "#333"
                },
                new FlotGridMarking
                {
                    XAxis = new FlotMarking(2, 5, 6),
                    YAxis = new FlotMarking(3, 7, 8),
                    Color = "#444"
                }
            };
            string actual = SerializeObject(input);
            actual.ShouldBe("[{\"xaxis\":{\"from\":1,\"to\":2},\"yaxis\":{\"from\":3,\"to\":4},\"color\":\"#333\"},{\"x2axis\":{\"from\":5,\"to\":6},\"y3axis\":{\"from\":7,\"to\":8},\"color\":\"#444\"}]");
        }

        [Fact]
        public void WithFunction_ShouldSerialize()
        {
            var input = new FlotGridMarkings("functionName");
            string actual = SerializeObject(input);
            actual.ShouldBe("functionName");
        }
    }
}
