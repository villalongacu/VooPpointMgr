using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VooAzureStreamFacade
{
    public class StartAMSConfigParams
    {
        private string _aChannelName;
        private string _aChannelInputName;
        private string _aChannelPreviewName;
        private string _aAssetlName;
        private string _aProgramlName;
        private string _aStreamingEndpointName;
        private TimeSpan _aDvrWindowsArchiveLength;

        public StartAMSConfigParams(string aChannelName, string aChannelInputName, string aChannelPreviewName,
            string aAssetlName, string aProgramlName, string aStreamingEndpointName, TimeSpan aDVRWindowsArchiveLength)
        {
            _aChannelName = aChannelName;
            _aChannelInputName = aChannelInputName;
            _aChannelPreviewName = aChannelPreviewName;
            _aAssetlName = aAssetlName;
            _aProgramlName = aProgramlName;
            _aStreamingEndpointName = aStreamingEndpointName;
            _aDvrWindowsArchiveLength = aDVRWindowsArchiveLength;
        }

        public string AChannelName
        {
            get { return _aChannelName; }
        }

        public string AChannelInputName
        {
            get { return _aChannelInputName; }
        }

        public string AChannelPreviewName
        {
            get { return _aChannelPreviewName; }
        }

        public string AAssetlName
        {
            get { return _aAssetlName; }
        }

        public string AProgramlName
        {
            get { return _aProgramlName; }
        }

        public string AStreamingEndpointName
        {
            get { return _aStreamingEndpointName; }
        }

        public TimeSpan ADvrWindowsArchiveLength
        {
            get { return _aDvrWindowsArchiveLength; }
        }
    }
}

