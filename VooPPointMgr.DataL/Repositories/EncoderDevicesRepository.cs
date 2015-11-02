using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Text;


namespace VooPPointMgr.DataL
{
    public class EncoderDevicesRepository
    {

        public static tencoderdevice[] GetEncoderdevices()
        {
            using (vEntities context = new vEntities())
            {
                return context.tencoderdevices.ToArray();
            }
        }

        public static tencoderdevice Getencoderdevice(string deviceid)
        {
            int deviceIdentifier;
          
            if (int.TryParse(deviceid, out deviceIdentifier) )
            {
                using (vEntities context = new vEntities())
                {
                    return context.tencoderdevices.FirstOrDefault(post => post.ID_ENCODERDEVICE == deviceIdentifier);
                }
            }

            return null;
        }


        public static tencoderdevice CreateEncoderDevice(tencoderdevice post)
        {
            using (vEntities context = new vEntities())
            {
                context.tencoderdevices.Add(post);
                context.SaveChanges();
            }

            return post;
        }

        public static tencoderdevice UpdateEncoderDevice(tencoderdevice post)
        {
            using (vEntities context = new vEntities())
            {
                context.Entry(post).State = EntityState.Modified;
                context.SaveChanges();
            }

            return post;
        }

        public static void DeleteEncoderDevice(string deviceid)
        {
            int deviceIdentifier;
           
            if (int.TryParse(deviceid, out deviceIdentifier))
            {
                using (vEntities context = new vEntities())
                {
                    var entity = context.tencoderdevices.FirstOrDefault(post => post.ID_ENCODERDEVICE == deviceIdentifier); 
                    if (entity != null)
                    {
                        context.tencoderdevices.Remove(entity);
                        context.SaveChanges();
                    }
                }
            }
        }
    }
}
