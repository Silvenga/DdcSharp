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
            var displays = api.GetDisplays();
            var secondary = displays.First(x => x.Availability != MONITORINFOEX_FLAGS.MONITORINFOF_PRIMARY);
            api.GetPysicalMonitors(secondary.MonitorHandler);

            // Assert
        }
    }
}