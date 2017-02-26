using DdcSharp.Core;

using FluentAssertions;

using Xunit;

namespace DdcSharp.Tests.IntergrationTests
{
    public class MonitorApiTests
    {
        [Fact]
        public void Works()
        {
            var api = new MonitorApi();

            // Act
            var displays = api.GetDisplays();

            // Assert

            displays.Should().HaveCount(2);
        }
    }
}