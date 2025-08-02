using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.Messaging.Messages;

namespace MauiApp1.Messages
{
    class DeviceAddedMessage : ValueChangedMessage<DeviceTester>
    {
        public DeviceAddedMessage(DeviceTester value) : base(value) { }
    }
}
