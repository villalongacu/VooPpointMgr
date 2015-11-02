using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using Microsoft.WindowsAzure.MediaServices.Client;

namespace VooAzureStreamFacade.Service
{
 
    [ServiceContract]
    public interface IVooAzureStreamFacadeService
    {
        [OperationContract]
        bool Start(string aChannelName, string aChannelInputName,
                   string aChannelPreviewName, string aAssetlName,
                   string aProgramlName, string aStreamingEndpointName, TimeSpan aDVRWindowsArchiveLength);

        [OperationContract]
        string ReturnIngestURL(string aChannelName);

        [OperationContract]
        string ReturnPreviewURL(string aChannelName);

        [OperationContract]
        System.Collections.Generic.List<System.Uri> ReturnMainStreamingURLs(string aAssetName);

        [OperationContract]
        bool ResetChannel(string aChannelName);

        [OperationContract]
        void CreateNewProgram(string aChannel, string aAssetlName, string aProgramlName, TimeSpan DVR_WindowLength);

        [OperationContract]
        void StartChannel(string aChannelName);

        [OperationContract]
        void StartLiveStreaming(string aProgramName, string aStreamingEndpointName);

        [OperationContract]
        bool CreateLiveStreamingInfrastructure(string aChannelName, string aChannelInputName,
                                               string aChannelPreviewName, string aAssetlName,
                                               string aProgramlName, string aStreamingEndpointName,
                                               TimeSpan aDVRWindowsArchiveLength);

        [OperationContract]
        bool Stop(string aChannelName, string anEndPointName);

        [OperationContract]
        bool ReleaseLiveStreamingInfrastructure(string aChannelName, string anEndPointName);



        [OperationContract]
        string GetData(int value);

        [OperationContract]
        CompositeType GetDataUsingDataContract(CompositeType composite);

        // TODO: Add your service operations here
    }


    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    [DataContract]
    public class CompositeType
    {
        bool boolValue = true;
        string stringValue = "Hello ";

        [DataMember]
        public bool BoolValue
        {
            get { return boolValue; }
            set { boolValue = value; }
        }

        [DataMember]
        public string StringValue
        {
            get { return stringValue; }
            set { stringValue = value; }
        }
    }
}
