﻿using System.Linq;

using DdcSharp.Core;

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

            var pys = displays.First().PhysicalDisplays.First();
            
            //NativeApi.SetMonitorBrightness(pys.Handle, 40);

            // Assert
        }
    }
}