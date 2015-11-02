using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using VooPPointMgr.DataL;

namespace VooPPointMgr.BLL
{
    class BLLEncoderDevices
    {

        public static tencoderdevice[] GetEncoderdevices()
        {
            return EncoderDevicesRepository.GetEncoderdevices();
        }

        public static tencoderdevice Getencoderdevice(string deviceid)
        {
            return EncoderDevicesRepository.Getencoderdevice(deviceid);
        }

        public static tencoderdevice CreateEncoderDevice(tencoderdevice post)
        {
            return EncoderDevicesRepository.CreateEncoderDevice(post);
        }

        public static tencoderdevice UpdateEncoderDevice(tencoderdevice post)
        {
            return EncoderDevicesRepository.UpdateEncoderDevice(post);
        }

        public static void DeleteEncoderDevice(string deviceid)
        {
            EncoderDevicesRepository.DeleteEncoderDevice(deviceid);
        }
    }
}
