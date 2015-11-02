using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.MediaServices.Client;

namespace VooAzureStreamFacade
{
    public class CreateProgramAMSConfigParams
    {
        private IChannel _channel;
        private string _aAssetlName;
        private string _aProgramlName;
        private TimeSpan _dvrWindowLength;

        public CreateProgramAMSConfigParams(IChannel channel, string aAssetlName, string aProgramlName, TimeSpan DVR_WindowLength)
        {
            _channel = channel;
            _aAssetlName = aAssetlName;
            _aProgramlName = aProgramlName;
            _dvrWindowLength = DVR_WindowLength;
        }

        public IChannel Channel
        {
            get { return _channel; }
        }

        public string AAssetlName
        {
            get { return _aAssetlName; }
        }

        public string AProgramlName
        {
            get { return _aProgramlName; }
        }

        public TimeSpan DvrWindowLength
        {
            get { return _dvrWindowLength; }
        }
    }

}
