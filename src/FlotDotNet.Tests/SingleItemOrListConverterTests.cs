namespace FlotDotNet.Tests
{
    using System.Collections.Generic;
    using FlotDotNet.Infrastruture;
    using Newtonsoft.Json;
    using Shouldly;
    using Xunit;

    public class SingleItemOrListConverterTests
    {
        [Fact]
        public void FlotThreshold_Empty_ShouldSerialize()
        {
            var input = new TestObject();
            string actual = JsonConvert.SerializeObject(input);
            actual.ShouldBe("{\"DataItems\":null}");
        }

        [Fact]
        public void FlotThreshold_SingleItem_ShouldSerialize()
        {
            var input = new TestObject();
            input.DataItems.Add("Value1");
            string actual = JsonConvert.SerializeObject(input);
            actual.ShouldBe("{\"DataItems\":\"Value1\"}");
        }

        [Fact]
        public void FlotThreshold_List_ShouldSerialize()
        {
            var input = new TestObject();
            input.DataItems.Add("Value1");
            input.DataItems.Add("Value2");
            string actual = JsonConvert.SerializeObject(input);
            actual.ShouldBe("{\"DataItems\":[\"Value1\",\"Value2\"]}");
        }

        private class TestObject
        {
            [JsonConverter(typeof(SingleItemOrListConverter))]
            public List<string> DataItems { get; } = new List<string>();
        }
    }
}
