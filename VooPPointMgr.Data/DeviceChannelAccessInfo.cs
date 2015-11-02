using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VooPPointMgr.Data
{
    public class DeviceChannelAccessInfo
    {
        public long id { get; set; }
        public string name { get; set; }
        public int ID_ENCODERDEVICE { get; set; }
        public string DEVICE_NAME { get; set; }

        public DeviceChannelAccessInfo(long aChannelid, string aChannelName, int aIdEncoderDevice, string aDeviceName)
        {
            id = aChannelid;
            name = aChannelName;
            ID_ENCODERDEVICE = aIdEncoderDevice;
            DEVICE_NAME = aDeviceName;
        }

        public DeviceChannelAccessInfo()
        {

        }
    }
}

