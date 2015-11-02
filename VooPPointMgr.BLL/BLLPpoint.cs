using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using VooPPointMgr.DataL;

namespace VooPPointMgr.BLL
{
    public class BLLPpoint
    {
        public static tppoint[] GetPPoints()
        {
            return PpointRepository.GetPPoints();
        }

        public static List<tppoint> SearchPPointByName(string ppointName)
        {
            return PpointRepository.SearchPPointByName(ppointName);
        }
 
        public static tppoint GetAvailablePPoint()
        {
            return PpointRepository.GetAvailablePPoint();
        }

        public static tppoint GetPPoint(string PPointid)
        {
            return PpointRepository.GetPPoint(PPointid);
        }

        public static bool GetPPointStatus(string PPointid)
        {
            return PpointRepository.GetPPointStatus(PPointid);
        }

        public static bool CreatePPoint(tppoint post)
        {
            PpointRepository.CreatePPoint(post);
            return BLLPublishingPoint.CreatePublishingPointPTM(post.IIS_NAME,post.AMS_URL,true);
        }

        public static tppoint UpdatePPoint(tppoint post)
        {
            return PpointRepository.UpdatePPoint(post);
        }

        public static bool DeletePPoint(string PPointid)
        {
           var ppoint = PpointRepository.GetPPoint(PPointid);

            PpointRepository.DeletePPoint(PPointid);
            
            return BLLPublishingPoint.DeletePublishingPointPTM(ppoint.IIS_NAME);
        }

    }
}
