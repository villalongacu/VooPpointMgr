using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using VooPPointMgr.DataL;

namespace VooPPointMgr.BLL
{
    public class BLLPPointStatus
    {
        public static tppointstatu[] GetAllPpointStatus()
        {
            return PPointStatusRepository.GetAllPpointStatus();
        }

        public static tppointstatu GetPpointstatus(string PPointid)
        {
            return PPointStatusRepository.GetPpointstatus(PPointid);
        }


        public static tppointstatu CreatePPointStatus(tppointstatu post)
        {
            return PPointStatusRepository.CreatePPointStatus(post);
        }

        public static tppointstatu UpdatePPointStatus(tppointstatu post)
        {
            return PPointStatusRepository.UpdatePPointStatus(post);
        }

        public static void DeletePPointStatus(string PPointid)
        {
            PPointStatusRepository.DeletePPointStatus(PPointid);
        }

    }

}
