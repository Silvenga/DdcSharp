using System.Linq;

using DdcSharp.Models;

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
            var displays = api.GetDisplays().ToList();

            // Assert
        }
    }
}