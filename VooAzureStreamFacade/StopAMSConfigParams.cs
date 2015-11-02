using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VooAzureStreamFacade
{
    public class StopAMSConfigParams
    {
        private string _aChannelName;
        private string _aStreamingEndpointName;
   
        public StopAMSConfigParams(string aChannelName, string aStreamingEndpointName)
        {
            _aChannelName = aChannelName;
            _aStreamingEndpointName = aStreamingEndpointName;
        }

        public string AChannelName
        {
            get { return _aChannelName; }
        }

        public string AStreamingEndpointName
        {
            get { return _aStreamingEndpointName; }
        }
    }
}

