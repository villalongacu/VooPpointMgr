using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Text;
using VooPPointMgr.Data;

namespace VooPPointMgr.Data
{
    public class ChannelPPointRepository
    {
        public static tchannel_ppoint[] GetChannel_Ppoints()
        {
            using (vooEntities context = new vooEntities())
            {
                return context.tchannel_ppoint.ToArray();
            }
        }

        public static tchannel_ppoint GetChannel_Ppoint(string PPointid, string channelid)
        {
            int PPointIdentifier;
            int channelIdentifier;

            if (int.TryParse(PPointid, out PPointIdentifier) && (int.TryParse(channelid, out channelIdentifier)))
            {
                using (vooEntities context = new vooEntities())
                {
                    return
                        context.tchannel_ppoint.FirstOrDefault(
                            post => post.ID_PPOINT == PPointIdentifier && (post.ID_CHANNEL == channelIdentifier));
                }
            }

            return null;
        }

        public static System.Collections.Generic.IEnumerable<ChannelPpointAccessInfo> GetAllPPointsbyChannel(string channelid)
        {
            int channelIdentifier;

            if (int.TryParse(channelid, out channelIdentifier))
            {
                using (vooEntities context = new vooEntities())
                {
                    var dbQuery = from edcha in context.tchannel_ppoint
                                  join ed in context.tppoints on edcha.ID_PPOINT equals ed.ID_PPOINT
                                  join ch in context.channels on edcha.ID_CHANNEL equals ch.id
                                  where edcha.ID_CHANNEL == channelIdentifier
                                  select
                                      new ChannelPpointAccessInfo()
                                          {
                                              id = ch.id,
                                              name = ch.name,
                                              ID_PPOINT = ed.ID_PPOINT,
                                              IIS_NAME = ed.IIS_NAME,
                                              URL = ed.URL,
                                              AMS_URL = ed.AMS_URL
                                          };

                    return dbQuery.AsEnumerable().ToArray();

                }
            }
            return null;
        }

        public static System.Collections.Generic.IEnumerable<ChannelPpointAccessInfo> GetAllChannelsByPPoint(string PPointid)
        {
            int PPointIdentifier;

            if (int.TryParse(PPointid, out PPointIdentifier))
            {
                using (vooEntities context = new vooEntities())
                {
                    var dbQuery = from edcha in context.tchannel_ppoint
                                  join ed in context.tppoints on edcha.ID_PPOINT equals ed.ID_PPOINT
                                  join ch in context.channels on edcha.ID_CHANNEL equals ch.id
                                  where edcha.ID_PPOINT == PPointIdentifier
                                  select
                                      new ChannelPpointAccessInfo()
                                          {
                                              id = ch.id,
                                              name = ch.name,
                                              ID_PPOINT = ed.ID_PPOINT,
                                              IIS_NAME = ed.IIS_NAME,
                                              URL = ed.URL,
                                              AMS_URL = ed.AMS_URL
                                          };

                    return dbQuery.AsEnumerable().ToArray();

                }
            }
            return null;
        }

        public static tchannel_ppoint CreateChannelPPointAccess(tchannel_ppoint post)
        {
            using (vooEntities context = new vooEntities())
            {
                context.tchannel_ppoint.Add(post);
                context.SaveChanges();
            }

            return post;
        }

        public static tchannel_ppoint UpdateChannelPPointAccess(tchannel_ppoint post)
        {
            using (vooEntities context = new vooEntities())
            {
                context.Entry(post).State = EntityState.Modified;
                context.SaveChanges();
            }

            return post;
        }

        public static void DeleteChannelPPointAccess(string PPointid, string channelid)
        {
            int PPointIdentifier;
            int channelIdentifier;

            if (int.TryParse(PPointid, out PPointIdentifier) && (int.TryParse(channelid, out channelIdentifier)))
            {
                using (vooEntities context = new vooEntities())
                {
                    var entity =
                        context.tchannel_ppoint.FirstOrDefault(
                            post => post.ID_PPOINT == PPointIdentifier && (post.ID_CHANNEL == channelIdentifier));
                    ;
                    if (entity != null)
                    {
                        context.tchannel_ppoint.Remove(entity);
                        context.SaveChanges();
                    }
                }
            }
        }
    }
}
