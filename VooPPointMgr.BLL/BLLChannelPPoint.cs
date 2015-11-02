using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using VooPPointMgr.DataL;

namespace VooPPointMgr.BLL
{
    public class BLLChannelPPoint
    {
        public static tchannel_ppoint[] GetChannel_Ppoints()
        {
            return ChannelPPointRepository.GetChannel_Ppoints();
        }

        public static tchannel_ppoint GetChannel_Ppoint(string PPointid, string channelid)
        {
            return ChannelPPointRepository.GetChannel_Ppoint(PPointid, channelid);
        }

        public static System.Collections.Generic.IEnumerable<ChannelPpointAccessInfo> GetAllPPointsbyChannel(string channelid)
        {
            return ChannelPPointRepository.GetAllPPointsbyChannel(channelid);
        }

        public static System.Collections.Generic.IEnumerable<ChannelPpointAccessInfo> GetAllChannelsByPPoint(string PPointid)
        {
            return ChannelPPointRepository.GetAllChannelsByPPoint(PPointid);
        }

        public static tchannel_ppoint CreateChannelPPointAccess(tchannel_ppoint post)
        {
            return ChannelPPointRepository.CreateChannelPPointAccess(post);
        }

        public static tchannel_ppoint UpdateChannelPPointAccess(tchannel_ppoint post)
        {
            return ChannelPPointRepository.UpdateChannelPPointAccess(post);
        }

        public static void DeleteChannelPPointAccess(string PPointid, string channelid)
        {
            ChannelPPointRepository.DeleteChannelPPointAccess(PPointid, channelid);
        }
    }
}
