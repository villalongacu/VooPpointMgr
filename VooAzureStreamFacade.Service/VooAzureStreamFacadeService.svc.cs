using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System;
using Microsoft.WindowsAzure.MediaServices.Client;
using VooAzureStreamFacade;

namespace VooAzureStreamFacade.Service
{
    public class VooAzureStreamFacadeService : IVooAzureStreamFacadeService
    {
        public bool Start(string aChannelName, string aChannelInputName, string aChannelPreviewName, string aAssetlName, string aProgramlName, string aStreamingEndpointName, TimeSpan aDVRWindowsArchiveLength)
        {
            var configParamStartAms = new StartAMSConfigParams(aChannelName, aChannelName,
              aChannelName, aAssetlName, aProgramlName, aStreamingEndpointName, aDVRWindowsArchiveLength);

            return VooAzureStreamFacade.Start(configParamStartAms);
        }

        public string ReturnIngestURL(string aChannelName)
        {
            return VooAzureStreamFacade.ReturnIngestURL(aChannelName);
        }

        public string ReturnPreviewURL(string aChannelName)
        {
            return VooAzureStreamFacade.ReturnPreviewURL(aChannelName);
        }

        public List<Uri> ReturnMainStreamingURLs(string aAssetName)
        {
            return VooAzureStreamFacade.ReturnMainStreamingURLs(aAssetName);
        }

        public bool ResetChannel(string aChannelName)
        {
            return VooAzureStreamFacade.ResetChannel(aChannelName);
        }

        public void CreateNewProgram(string aChannelName, string aAssetlName, string aProgramlName, TimeSpan DVR_WindowLength)
        {
            VooAzureStreamFacade.CreateNewProgram(aChannelName, aAssetlName,aProgramlName,DVR_WindowLength);
        }

        public void StartChannel(string aChannelName)
        {
            VooAzureStreamFacade.StartChannel(aChannelName);
        }

        public void StartLiveStreaming(string aProgramName, string aStreamingEndpointName)
        {
            var config = new StartLSAMSConfigParams(aProgramName,aStreamingEndpointName);
            VooAzureStreamFacade.StartLiveStreaming(config);
        }

        public bool CreateLiveStreamingInfrastructure(string aChannelName, string aChannelInputName, string aChannelPreviewName, string aAssetlName, string aProgramlName, string aStreamingEndpointName, TimeSpan aDVRWindowsArchiveLength)
        {
            var configParamStartAms = new StartAMSConfigParams(aChannelName, aChannelName,
               aChannelName, aAssetlName, aProgramlName, aStreamingEndpointName, aDVRWindowsArchiveLength);

            return VooAzureStreamFacade.CreateLiveStreamingInfrastructure(configParamStartAms);
        }

        public bool Stop(string aChannelName, string anEndPointName)
        {
            var config = new StopAMSConfigParams(aChannelName, anEndPointName);

            return VooAzureStreamFacade.Stop(config);
        }

        public bool ReleaseLiveStreamingInfrastructure(string aChannelName, string anEndPointName)
        {
            var config = new StopAMSConfigParams(aChannelName, anEndPointName);
            return VooAzureStreamFacade.ReleaseLiveStreamingInfrastructure(config);
        }


        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }
    }
}
