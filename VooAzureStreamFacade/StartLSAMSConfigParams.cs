using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VooAzureStreamFacade
{
    public class StartLSAMSConfigParams
    {
        private string _aProgramlName;
        private string _aStreamingEndpointName;
   
        public StartLSAMSConfigParams(string aProgramlName, string aStreamingEndpointName)
        {
            _aProgramlName = aProgramlName;
            _aStreamingEndpointName = aStreamingEndpointName;
        }
        public string AProgramlName
        {
            get { return _aProgramlName; }
        }

        public string AStreamingEndpointName
        {
            get { return _aStreamingEndpointName; }
        }
    }
}

