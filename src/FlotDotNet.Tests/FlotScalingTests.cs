namespace FlotDotNet.Tests
{
    using System;
    using System.Collections.Generic;
    using Newtonsoft.Json;
    using Shouldly;
    using Xunit;

    public class FlotScalingTests
    {
        [Fact]
        public void WithOpacity_ShouldSerialize()
        {
            var scaling = new FlotScaling(0.9, null);
            string actual = JsonConvert.SerializeObject(scaling, FlotConfiguration.SerializerSettings);
            actual.ShouldBe("{\"opacity\":0.9}");
        }

        [Fact]
        public void WithBrightness_ShouldSerialize()
        {
            var scaling = new FlotScaling(null, 0.9);
            string actual = JsonConvert.SerializeObject(scaling, FlotConfiguration.SerializerSettings);
            actual.ShouldBe("{\"brightness\":0.9}");
        }

        [Fact]
        public void WithOpacityAndBrightness_ShouldSerialize()
        {
            var scaling = new FlotScaling(0.8, 0.9);
            string actual = JsonConvert.SerializeObject(scaling, FlotConfiguration.SerializerSettings);
            actual.ShouldBe("{\"opacity\":0.8,\"brightness\":0.9}");
        }

        [Fact]
        public void NoValues_ShouldThrow()
        {
            Should
                .Throw<ArgumentOutOfRangeException>(() => new FlotScaling(null, null));
        }
    }
}
