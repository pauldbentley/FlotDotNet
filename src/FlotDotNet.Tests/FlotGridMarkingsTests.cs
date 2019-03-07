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
                    Color = "#333",
                    LineWidth = 5
                },
                new FlotGridMarking
                {
                    XAxis = new FlotMarking(6, 7, 8),
                    YAxis = new FlotMarking(9, 10, 11),
                    Color = "#444",
                    LineWidth = 12
                }
            };
            string actual = SerializeObject(input);
            actual.ShouldBe("[{\"xaxis\":{\"from\":1,\"to\":2},\"yaxis\":{\"from\":3,\"to\":4},\"color\":\"#333\",\"lineWidth\":5},{\"x6axis\":{\"from\":7,\"to\":8},\"y9axis\":{\"from\":10,\"to\":11},\"color\":\"#444\",\"lineWidth\":12}]");
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
