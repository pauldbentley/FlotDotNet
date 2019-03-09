namespace FlotDotNet.Tests
{
    using System;
    using Shouldly;
    using Xunit;

    public class FlotScalingTests : TestClass
    {
        [Fact]
        public void NoValues_ShouldThrow()
        {
            Should
                .Throw<ArgumentOutOfRangeException>(() => new FlotScaling(null, null));
        }
    }
}
