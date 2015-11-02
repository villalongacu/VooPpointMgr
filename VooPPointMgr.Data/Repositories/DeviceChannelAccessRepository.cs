using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace VooPPointMgr.Data
{
    using System.Data.Entity;
    using System.Linq;

    using VooPPointMgr.Data;

    public class DeviceChannelAccessRepository
    {


        public static tdevicechannelaccess[] GetDeviceChannelAccess()
        {
            using (vooEntities context = new vooEntities())
            {
                return context.tdevicechannelaccesses.ToArray();
            }
        }

        public static tdevicechannelaccess GetDeviceChannelAccess(string deviceid, string channelid)
        {
            int deviceIdentifier;
            int channelIdentifier;

            if (int.TryParse(deviceid, out deviceIdentifier) && (int.TryParse(channelid, out channelIdentifier)))
            {
                using (vooEntities context = new vooEntities())
                {
                    return context.tdevicechannelaccesses.FirstOrDefault(post => post.ID_DEVICE == deviceIdentifier && (post.ID_CHANNEL == channelIdentifier));
                }
            }

            return null;
        }

        public static System.Collections.Generic.IEnumerable<DeviceChannelAccessInfo> GetAllDevicesbyChannel(string channelid)
        {
            int channelIdentifier;

            if (int.TryParse(channelid, out channelIdentifier))
            {
                using (vooEntities context = new vooEntities())
                {
                    var dbQuery = from edcha in context.tdevicechannelaccesses
                                  join ed in context.tencoderdevices on edcha.ID_DEVICE equals ed.ID_ENCODERDEVICE
                                  join ch in context.channels on edcha.ID_CHANNEL equals ch.id
                                  where edcha.ID_CHANNEL == channelIdentifier
                                  select new DeviceChannelAccessInfo() { id = ch.id, name = ch.name, ID_ENCODERDEVICE = ed.ID_ENCODERDEVICE, DEVICE_NAME = ed.DEVICE_NAME };

                    return dbQuery.AsEnumerable().ToArray();

                }
            }
            return null;
        }

        public static System.Collections.Generic.IEnumerable<DeviceChannelAccessInfo> GetAllChannelsByDevice(string deviceid)
        {
            int deviceIdentifier;

            if (int.TryParse(deviceid, out deviceIdentifier))
            {
                using (vooEntities context = new vooEntities())
                {
                    var dbQuery = from edcha in context.tdevicechannelaccesses
                                  join ed in context.tencoderdevices on edcha.ID_DEVICE equals ed.ID_ENCODERDEVICE
                                  join ch in context.channels on edcha.ID_CHANNEL equals ch.id
                                  where edcha.ID_DEVICE == deviceIdentifier
                                  select new DeviceChannelAccessInfo() { id = ch.id, name = ch.name, ID_ENCODERDEVICE = ed.ID_ENCODERDEVICE, DEVICE_NAME = ed.DEVICE_NAME };

                    return dbQuery.AsEnumerable().ToArray();

                }
            }
            return null;
        }

        public static tdevicechannelaccess CreateDeviceChannelAccess(tdevicechannelaccess post)
        {
            using (vooEntities context = new vooEntities())
            {
                context.tdevicechannelaccesses.Add(post);
                context.SaveChanges();
            }

            return post;
        }

        public static tdevicechannelaccess UpdateDeviceChannelAccess(tdevicechannelaccess post)
        {
            using (vooEntities context = new vooEntities())
            {
                context.Entry(post).State = EntityState.Modified;
                context.SaveChanges();
            }

            return post;
        }

        public static void DeleteDeviceChannelAccess(string deviceid, string channelid)
        {
            int deviceIdentifier;
            int channelIdentifier;

            if (int.TryParse(deviceid, out deviceIdentifier) && (int.TryParse(channelid, out channelIdentifier)))
            {
                using (vooEntities context = new vooEntities())
                {
                    var entity = context.tdevicechannelaccesses.FirstOrDefault(post => post.ID_DEVICE == deviceIdentifier && (post.ID_CHANNEL == channelIdentifier));;
                    if (entity != null)
                    {
                        context.tdevicechannelaccesses.Remove(entity);
                        context.SaveChanges();
                    }
                }
            }
        }
    }
}
