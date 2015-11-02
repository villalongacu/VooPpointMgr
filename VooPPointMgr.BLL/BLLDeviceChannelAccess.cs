using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace VooPPointMgr.BLL
{
    using System.Data.Entity;
    using System.Linq;

    using VooPPointMgr.DataL;

    public class BLLDeviceChannelAccess
    {

        public static tdevicechannelaccess[] GetDeviceChannelAccess()
        {
            return DeviceChannelAccessRepository.GetDeviceChannelAccess();
        }

        public static tdevicechannelaccess GetDeviceChannelAccess(string deviceid, string channelid)
        {
            return DeviceChannelAccessRepository.GetDeviceChannelAccess(deviceid, channelid);
        }

        public static System.Collections.Generic.IEnumerable<DeviceChannelAccessInfo> GetAllDevicesbyChannel(string channelid)
        {
            return DeviceChannelAccessRepository.GetAllDevicesbyChannel(channelid);
        }

        public static System.Collections.Generic.IEnumerable<DeviceChannelAccessInfo> GetAllChannelsByDevice(string deviceid)
        {
            return DeviceChannelAccessRepository.GetAllChannelsByDevice(deviceid);
        }

        public static tdevicechannelaccess CreateDeviceChannelAccess(tdevicechannelaccess post)
        {
            return DeviceChannelAccessRepository.CreateDeviceChannelAccess(post);
        }

        public static tdevicechannelaccess UpdateDeviceChannelAccess(tdevicechannelaccess post)
        {
            return DeviceChannelAccessRepository.UpdateDeviceChannelAccess(post);
        }

        public static void DeleteDeviceChannelAccess(string deviceid, string channelid)
        {
            DeviceChannelAccessRepository.DeleteDeviceChannelAccess(deviceid, channelid);
        }
    }
}
