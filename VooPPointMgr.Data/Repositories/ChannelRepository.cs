using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Text;


namespace VooPPointMgr.Data
{
    public class ChannelRepository
    {

        public static channel[] GetChannels()
        {
            using (vooEntities context = new vooEntities())
            {
                return context.channels.ToArray();
            }
        }

        public static channel GetChannel(string channelid)
        {
            int channelIdentifier;

            if (int.TryParse(channelid, out channelIdentifier))
            {
                using (vooEntities context = new vooEntities())
                {
                    return context.channels.FirstOrDefault(post => post.id == channelIdentifier);
                }
            }

            return null;
        }


        public static channel CreateChannel(channel post)
        {
            using (vooEntities context = new vooEntities())
            {
                context.channels.Add(post);
                context.SaveChanges();
            }

            return post;
        }

        public static channel UpdateChannel(channel post)
        {
            using (vooEntities context = new vooEntities())
            {
                context.Entry(post).State = EntityState.Modified;
                context.SaveChanges();
            }

            return post;
        }

        public static void DeleteChannel(string channelid)
        {
            int channelIdentifier;

            if (int.TryParse(channelid, out channelIdentifier))
            {
                using (vooEntities context = new vooEntities())
                {
                    var entity = context.channels.FirstOrDefault(post => post.id == channelIdentifier);
                    if (entity != null)
                    {
                        context.channels.Remove(entity);
                        context.SaveChanges();
                    }
                }
            }
        }
    }
}
