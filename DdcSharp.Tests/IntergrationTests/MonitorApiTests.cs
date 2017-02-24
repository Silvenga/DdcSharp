using System.Linq;

using DdcSharp.Native;

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

            var pys = displays.First().PhysicalDisplays.First();
            
            NativeApi.SetMonitorBrightness(pys.Handle, 40);

            // Assert
        }
    }
}