using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using VooPPointMgr.DataL;

namespace VooPPointMgr.BLL
{
    public class BLLChannel
    {

        public static channel[] GetChannels()
        {
            return ChannelRepository.GetChannels();
        }

        public static channel GetChannel(string channelid)
        {
            return ChannelRepository.GetChannel(channelid);
        }


        public static channel CreateChannel(channel post)
        {
            return ChannelRepository.CreateChannel(post);
        }

        public static channel UpdateChannel(channel post)
        {
            return ChannelRepository.UpdateChannel(post);
        }

        public static void DeleteChannel(string channelid)
        {
           ChannelRepository.DeleteChannel(channelid);
        }
    }
}
