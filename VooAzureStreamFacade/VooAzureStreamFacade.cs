using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.MediaServices.Client;
using System.ServiceModel;
using Newtonsoft.Json.Linq;

namespace VooAzureStreamFacade
{
    public class VooAzureStreamFacade
    {
      
        // Read values from the App.config file.
        public static readonly string _mediaServicesAccountName =
            ConfigurationManager.AppSettings["MediaServicesAccountName"];

        public static readonly string _mediaServicesAccountKey =
            ConfigurationManager.AppSettings["MediaServicesAccountKey"];

        // Field for service context.
        public static CloudMediaContext _context = null;
        public static MediaServicesCredentials _cachedCredentials = null;

        //Field for Default VOD output folder
        private static string _outputFilesFolder = @"c:\";

       
        #region LiveStreaming Section

        /// <summary>
        /// Creates Live Streaming infrastructure and starts everything
        /// </summary>
        /// <returns></returns>
        public static bool Start(StartAMSConfigParams configParams)
        {
            bool tempresult = true;

            try
            {
                //Create Live Streaming infrastructure
                CreateLiveStreamingInfrastructure(configParams);
                //Starts the aChannelName to allow incoming streams
                StartChannel(configParams.AChannelName);


                //Publishes the streaming
                var StartLSConfigParams = new StartLSAMSConfigParams(configParams.AProgramlName,
                    configParams.AStreamingEndpointName);
                StartLiveStreaming(StartLSConfigParams);
            }

            catch (Exception ex)
            {
                tempresult = false;
            }
            return tempresult;
        }

        /// <summary>
        /// Stop the aChannelName and clean up the resources
        /// </summary>
        /// <returns></returns>
        public static bool Stop(StopAMSConfigParams configParams)
        {
            bool tempresult = true;

            try
            {
                ReleaseLiveStreamingInfrastructure(configParams);
            }

            catch (Exception ex)
            {
                tempresult = false;
            }
            return tempresult;
        }


       public static bool CreateLiveStreamingInfrastructure(StartAMSConfigParams configParams)
        {
            bool tempresult = true;

            try
            {
                //Set Azure credentials
                if (_context== null)
                SetMediaServicesCredentials();

                IChannel channel = CreateChannel(configParams.AChannelName, configParams.AChannelInputName, configParams.AChannelPreviewName);

                // Set the Live Encoder to point to the aChannelName's input endpoint:
                string ingestUrl = channel.Input.Endpoints.FirstOrDefault().Url.ToString();

                // Use the previewEndpoint to preview and verify 
                // that the input from the encoder is actually reaching the Channel. 
                string previewEndpoint = channel.Preview.Endpoints.FirstOrDefault().Url.ToString();

                // Once you previewed your stream and verified that it is flowing into your Channel, 
                // you can create an event by creating an Asset, Program, and Streaming Locator. 

                IProgram program = CreateProgram(new CreateProgramAMSConfigParams(channel, configParams.AAssetlName, configParams.AProgramlName, configParams.ADvrWindowsArchiveLength));
                ILocator locator = CreateLocatorForAsset(program.Asset, program.ArchiveWindowLength);
           //     IStreamingEndpoint streamingEndpoint = CreateStreamingEndpoint(configParams.AStreamingEndpointName);

                //Start the whole infrastructure (from this point I get billed for the time they are in running state)
               
      //          StartChannel(aChannelName);
      //          StartLiveStreaming(program,streamingEndpoint);

           //     GetLocatorsInAllStreamingEndpoints(program.Asset);
                
            }
            catch (Exception ex)
            {
                tempresult = false;
            }
            return tempresult;
        }



        public static bool CreateandPublishLiveStreamingInfrastructure(StartAMSConfigParams configParams)
        {
            bool tempresult = true;

            try
            {
                //Set Azure credentials
                if (_context == null)
                    SetMediaServicesCredentials();

                IChannel channel = CreateChannel(configParams.AChannelName, configParams.AChannelInputName, configParams.AChannelPreviewName);

                // Set the Live Encoder to point to the aChannelName's input endpoint:
                string ingestUrl = channel.Input.Endpoints.FirstOrDefault().Url.ToString();

                // Use the previewEndpoint to preview and verify 
                // that the input from the encoder is actually reaching the Channel. 
                string previewEndpoint = channel.Preview.Endpoints.FirstOrDefault().Url.ToString();

                // Once you previewed your stream and verified that it is flowing into your Channel, 
                // you can create an event by creating an Asset, Program, and Streaming Locator. 

                IProgram program = CreateProgram(new CreateProgramAMSConfigParams(channel, configParams.AAssetlName, configParams.AProgramlName, configParams.ADvrWindowsArchiveLength));
                ILocator locator = CreateLocatorForAsset(program.Asset, program.ArchiveWindowLength);
                //     IStreamingEndpoint streamingEndpoint = CreateStreamingEndpoint(configParams.AStreamingEndpointName);

                //Start the whole infrastructure (from this point I get billed for the time they are in running state)

                //          StartChannel(aChannelName);
                //          StartLiveStreaming(program,streamingEndpoint);

                //     GetLocatorsInAllStreamingEndpoints(program.Asset);

            }
            catch (Exception ex)
            {
                tempresult = false;
            }
            return tempresult;
        }

        public static string ReturnIngestURL(string aChannelName)
        {
            //Set Azure credentials
            if (_context == null)
                SetMediaServicesCredentials();
            
            return
                _context.Channels.Where(c => c.Name == aChannelName).FirstOrDefault().Input.Endpoints.
                    FirstOrDefault().Url.ToString();
        }
       
        public static string ReturnPreviewURL(string aChannelName)
        {
            //Set Azure credentials
            if (_context == null)
                SetMediaServicesCredentials();
            return
                _context.Channels.Where(c => c.Name == aChannelName).FirstOrDefault().Preview.Endpoints.
                    FirstOrDefault().Url.ToString();
        }
        
       public static System.Collections.Generic.List<System.Uri> ReturnMainStreamingURLs(string aChannelName)
        {
            //Set Azure credentials
            if (_context == null)
                SetMediaServicesCredentials();

        //    _context.Assets.Where(a => a.Name == aAssetName).FirstOrDefault();

          //  var asset = _context.Assets.Where(a => a.Name == aAssetName).FirstOrDefault();
           
          var asset = _context.Channels.Where(c => c.Name == aChannelName).FirstOrDefault().Programs.FirstOrDefault().Asset;
                //context.Channels.Where(c=> c.Name == aChannelName).FirstOrDefault().Programs.FirstOrDefault().Asset;
            var locators = asset.Locators.Where(l => l.Type == LocatorType.OnDemandOrigin);
            var ismFile = asset.AssetFiles.AsEnumerable().FirstOrDefault(a => a.Name.EndsWith(".ism"));
            var template = new UriTemplate("{contentAccessComponent}/{ismFileName}/manifest");
            
            return locators.SelectMany(l =>
                                      _context
                                          .StreamingEndpoints
                                          .AsEnumerable()
                                          .Where(se => se.State == StreamingEndpointState.Running)
                                          .Select(
                                              se =>
                                              template.BindByPosition(new Uri("http://" + se.HostName),
                                                                      l.ContentAccessComponent,
                                                                      ismFile.Name)))
           .ToList();

        }

        public static bool ResetChannel (string aChannelName)
        {
            bool tempresult = false;
            //Set Azure credentials
            if (_context == null)
                SetMediaServicesCredentials();
     
            var channel = _context.Channels.Where(c => c.Name == aChannelName).FirstOrDefault();

            if (channel!=null)
            {
             foreach (var program in channel.Programs)
                {
                  if (program.State == ProgramState.Running)
                    {
                        program.Stop();
                    }
                    
                 }

                if (channel.State == ChannelState.Running)
                { channel.Reset(); }

                tempresult = true;
            }
            return tempresult;
        }

        private static void SetMediaServicesCredentials()
        {
            // Create and cache the Media Services credentials in a static class variable.
            _cachedCredentials = new MediaServicesCredentials(
                _mediaServicesAccountName,
                _mediaServicesAccountKey);
            // Used the cached credentials to create CloudMediaContext.
            _context = new CloudMediaContext(_cachedCredentials);
        }

        public static bool ReleaseLiveStreamingInfrastructure(StopAMSConfigParams configParams)
        {
            bool tempresult = true;
            try
            {
                //Set Azure credentials
                if (_context == null)
                    SetMediaServicesCredentials();

                 IChannel channel = _context.Channels.Where(c => c.Name == configParams.AChannelName).FirstOrDefault();
                 IStreamingEndpoint streamingEndpoint = _context.StreamingEndpoints.Where(s => s.Name == configParams.AStreamingEndpointName).FirstOrDefault();;
               
                // Once you are done streaming, clean up your resources.
                Cleanup(streamingEndpoint, channel.Name);
            }
            catch (Exception ex)
            {
                tempresult = false;
            }
            return tempresult;
        }

        public static IChannel CreateChannel(string aChannelName, string aChannelInputName, string aChannelPreviewName)
        {
            ChannelCreationOptions options = new ChannelCreationOptions
                    {
                        EncodingType = ChannelEncodingType.None, 
                        Name = aChannelName, 
                        Input = CreateChannelInput(aChannelInputName),
                        Preview = CreateChannelPreview(aChannelPreviewName),
                        Output = CreateChannelOutput(),
                        Encoding = CreateChannelEncoding()
                };

            IOperation channelCreateOperation = _context.Channels.SendCreateOperation(options);

            IChannel channel = _context.Channels.Where(c => c.Id == aChannelName).FirstOrDefault();

            string channelId = TrackOperation(channelCreateOperation, "Channel create");
            //   Console.WriteLine("Starting Channel " + aChannelName);
            return channel;
        }

        /// <summary>
        ///  // When Live Encoding is enabled, you can now get a preview of the live feed as it reaches the Channel. 
        // This can be a valuable tool to check whether your live feed is actually reaching the Channel. 
        // The thumbnail is exposed via the same end-point as the Channel Preview URL.
        /// </summary>
        /// <returns></returns>
        public static string GetLivePreviewThumbnailUri(string aChannel)
        {
            var channel = _context.Channels.FirstOrDefault(c => c.Name == aChannel);

            string thumbnailUri = new UriBuilder
                                  {
                                      Scheme = Uri.UriSchemeHttps,
                                      Host = channel.Preview.Endpoints.FirstOrDefault().Url.Host,
                                      Path = "thumbnails/input.jpg"
                                  }.Uri.ToString();
            return thumbnailUri;
        }

        public static void StopSlates(IChannel channel)
        {
        }

        public static void StartStopSlates(IChannel channel, TimeSpan aDuration)
        {

            int cueId = new Random().Next(int.MaxValue);
            var path = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\\..\\SlateJPG\\DefaultAzurePortalSlate.jpg"));

            //("Creating asset");
            var slateAsset = _context.Assets.Create("Slate test asset " + DateTime.Now.ToString("yyyy-MM-dd HH-mm"), AssetCreationOptions.None);
            //("Slate asset created", slateAsset.Id);

            //("Uploading file");
            var assetFile = slateAsset.AssetFiles.Create("DefaultAzurePortalSlate.jpg");
            assetFile.Upload(path);
            assetFile.IsPrimary = true;
            assetFile.Update();

            //("Showing slate");
            var showSlateOpeartion = channel.SendShowSlateOperation(aDuration, slateAsset.Id);

            //("Hiding slate");
            var hideSlateOperation = channel.SendHideSlateOperation();

            //("Deleting slate asset");
            slateAsset.Delete();
        }


        public static void StartStopAds(IChannel channel, TimeSpan aDuration)
        {
            int cueId = new Random().Next(int.MaxValue);
            var path = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\\..\\SlateJPG\\DefaultAzurePortalSlate.jpg"));
            
            //("Starting ad");
            var startAdOperation = channel.SendStartAdvertisementOperation(aDuration, cueId, false);
        
            //("Ending ad");
            var endAdOperation = channel.SendEndAdvertisementOperation(cueId);
         
        }

        /// <summary>
        /// Create channel encoding, used in channel creation options. 
        /// </summary>
        /// <returns></returns>
        private static ChannelEncoding CreateChannelEncoding()
        {
            return new ChannelEncoding
            {
                SystemPreset = "Default720p",
                IgnoreCea708ClosedCaptions = false,
                AdMarkerSource = AdMarkerSource.Api
                // You can only set audio if streaming protocol is set to StreamingProtocol.RTPMPEG2TS.
             //   AudioStreams = new List<AudioStream> { new AudioStream { Index = 103, Language = "eng" } }.AsReadOnly()
            };
        }

        private static ChannelInput CreateChannelInput(string aChannelInput)
        {
            return new ChannelInput
                       {
                           StreamingProtocol = StreamingProtocol.FragmentedMP4,
                           AccessControl = new ChannelAccessControl
                                               {
                                                   IPAllowList = new List<IPRange>
                                                                     {
                                                                         new IPRange
                                                                             {
                                                                                 Name = aChannelInput,
                                                                                 Address = IPAddress.Parse("0.0.0.0"),
                                                                                 SubnetPrefixLength = 0
                                                                             }
                                                                     }
                                               }
                       };
        }

        private static ChannelPreview CreateChannelPreview(string aChannelPreview)
        {
            return new ChannelPreview
                       {
                           AccessControl = new ChannelAccessControl
                                               {
                                                   IPAllowList = new List<IPRange>
                                                                     {
                                                                         new IPRange
                                                                             {
                                                                                 Name = aChannelPreview,
                                                                                 Address = IPAddress.Parse("0.0.0.0"),
                                                                                 SubnetPrefixLength = 0
                                                                             }
                                                                     }
                                               }
                       };
        }

        private static ChannelOutput CreateChannelOutput()
        {
            return new ChannelOutput
                       {
                           Hls = new ChannelOutputHls {FragmentsPerSegment = 1}
                       };
        }

        public static void UpdateCrossSiteAccessPoliciesForChannel(IChannel channel)
        {
            var clientPolicy =
                @"<?xml version=""1.0"" encoding=""utf-8""?>
            <access-policy>
                <cross-domain-access>
                    <policy>
                        <allow-from http-request-headers=""*"" http-methods=""*"">
                            <domain uri=""*""/>
                        </allow-from>
                        <grant-to>
                           <resource path=""/"" include-subpaths=""true""/>
                        </grant-to>
                    </policy>
                </cross-domain-access>
            </access-policy>";

            var xdomainPolicy =
                @"<?xml version=""1.0"" ?>
            <cross-domain-policy>
                <allow-access-from domain=""*"" />
            </cross-domain-policy>";

            channel.CrossSiteAccessPolicies.ClientAccessPolicy = clientPolicy;
            channel.CrossSiteAccessPolicies.CrossDomainPolicy = xdomainPolicy;

            channel.Update();
        }

  
        public static IProgram CreateProgram(CreateProgramAMSConfigParams createProgramAmsConfigParams)
        {
            IAsset asset = _context.Assets.Create(createProgramAmsConfigParams.AAssetlName, AssetCreationOptions.None);

            // Create a Program on the Channel. You can have multiple Programs that overlap or are sequential;
            // however each Program must have a unique name within your Media Services account.
            IProgram program = createProgramAmsConfigParams.Channel.Programs.Create(createProgramAmsConfigParams.AProgramlName, createProgramAmsConfigParams.DvrWindowLength, asset.Id);
          
            Console.WriteLine("Starting Program "); //+ program.ProgramlName);
            return program;
        }

        public static void CreateNewProgram(string aChannelName, string aAssetlName, string aProgramlName, TimeSpan DVR_WindowLength)
        {
            //Set Azure credentials
            if (_context == null)
                SetMediaServicesCredentials();

            IAsset asset = _context.Assets.Create(aAssetlName, AssetCreationOptions.None);

            // Create a Program on the Channel. You can have multiple Programs that overlap or are sequential;
            // however each Program must have a unique name within your Media Services account.

            IChannel aChann1 = _context.Channels.Where(ch=> ch.Name == aChannelName).FirstOrDefault();

            IProgram program = aChann1.Programs.Create(aProgramlName, DVR_WindowLength, asset.Id);
            
        }

        public static ILocator CreateLocatorForAsset(IAsset asset, TimeSpan ArchiveWindowLength)
        {
            var locator = _context.Locators.CreateLocator
                (
                    LocatorType.OnDemandOrigin,
                    asset,
                    _context.AccessPolicies.Create
                        (
                            "Live Stream Policy",
                            ArchiveWindowLength,
                            AccessPermissions.Read
                        )
                );

            return locator;
        }


        public static bool StartChannel(string aChannelName)
        {
            //Set Azure credentials
            if (_context == null)
                SetMediaServicesCredentials();
            bool tempresult = false;

            try
            {
                //    IChannel ch = _context.Channels.FirstOrDefault(c => c.Name == aChannelName);

                IChannel channel = _context.Channels.Where(c => c.Name == aChannelName).FirstOrDefault();
                //Starts the Channel
                var channelStartOperation = channel.SendStartOperation();
                
                TrackOperation(channelStartOperation, "Channel start");
             
                //return result
                tempresult = true;
            }
            catch (Exception ex)
            {
                
            }

            return tempresult;
        }


        public static bool StartLiveStreaming(StartLSAMSConfigParams configParams)
        {
            bool tempresult = false;
            //Set Azure credentials
            if (_context == null)
                SetMediaServicesCredentials();
            try
            {

            //Start the Program
            IProgram aProgram = _context.Programs.Where(p => p.Name == configParams.AProgramlName).FirstOrDefault();
            if (aProgram.State != ProgramState.Running)
            {
                aProgram.SendStartOperation();
            }

           //Start the Streaming Endpoint
            IStreamingEndpoint aStreamingEndpoint = _context.StreamingEndpoints.Where(s => s.Name == configParams.AStreamingEndpointName).FirstOrDefault();
            if (aStreamingEndpoint.State != StreamingEndpointState.Running)
            {
                aStreamingEndpoint.SendStartOperation();
            }
          
               // return result
                tempresult = true;
            }
            catch (Exception ex)
            {
                
            }

            return tempresult;
        }

        public static IStreamingEndpoint CreateStreamingEndpoint(string aStreamingEndPointName)
        {
            var options = new StreamingEndpointCreationOptions
                              {
                                  Name = aStreamingEndPointName,
                                  ScaleUnits = 1,
                                  AccessControl = GetAccessControl(),
                                  CacheControl = GetCacheControl()
                              };

            IStreamingEndpoint streamingEndpoint = _context.StreamingEndpoints.Create(options);

            //TODO: remove following line to just create endpoint 
            streamingEndpoint.Start();

            return streamingEndpoint;
        }

        private static StreamingEndpointAccessControl GetAccessControl()
        {
            return new StreamingEndpointAccessControl
                       {
                           IPAllowList = new List<IPRange>
                                             {
                                                 new IPRange
                                                     {
                                                         Name = "Allow all",
                                                         Address = IPAddress.Parse("0.0.0.0"),
                                                         SubnetPrefixLength = 0
                                                     }
                                             },

                           AkamaiSignatureHeaderAuthenticationKeyList = new List<AkamaiSignatureHeaderAuthenticationKey>
                                                                            {
                                                                                new AkamaiSignatureHeaderAuthenticationKey
                                                                                    {
                                                                                        Identifier = "My key",
                                                                                        Expiration =
                                                                                            DateTime.UtcNow +
                                                                                            TimeSpan.FromDays(365),
                                                                                        Base64Key =
                                                                                            Convert.ToBase64String(
                                                                                                GenerateRandomBytes(16))
                                                                                    }
                                                                            }
                       };
        }

        /// <summary>
        /// Track long running operations.
        /// </summary>
        /// <param name="operation"></param>
        /// <param name="description"></param>
        /// <returns></returns>
        public static string TrackOperation(IOperation operation, string description)
        {
            string entityId = null;
            bool isCompleted = false;

            Log("starting to track ", null, operation.Id);
            while (isCompleted == false)
            {
                operation = _context.Operations.GetOperation(operation.Id);
                isCompleted = IsCompleted(operation, out entityId);
                System.Threading.Thread.Sleep(TimeSpan.FromSeconds(30));
            }
            // If we got here, the operation succeeded.
            Log(description + " in completed", operation.TargetEntityId, operation.Id);

            return entityId;
        }

        /// <summary> 
        /// Checks if the operation has been completed. 
        /// If the operation succeeded, the created entity Id is returned in the out parameter.
        /// </summary> 
        /// <param name="operationId">The operation Id.</param> 
        /// <param name="channel">
        /// If the operation succeeded, 
        /// the entity Id associated with the sucessful operation is returned in the out parameter.</param>
        /// <returns>Returns false if the operation is still in progress; otherwise, true.</returns> 
        private static bool IsCompleted(IOperation operation, out string entityId)
        {

            bool completed = false;

            entityId = null;

            switch (operation.State)
            {
                case OperationState.Failed:
                    // Handle the failure. 
                    // For example, throw an exception. 
                    // Use the following information in the exception: operationId, operation.ErrorMessage.
                    Log("operation failed", operation.TargetEntityId, operation.Id);
                    break;
                case OperationState.Succeeded:
                    completed = true;
                    entityId = operation.TargetEntityId;
                    break;
                case OperationState.InProgress:
                    completed = false;
                    Log("operation in progress", operation.TargetEntityId, operation.Id);
                    break;
            }
            return completed;
        }
        
        private static void Log(string action, string entityId = null, string operationId = null)
        {
            Console.WriteLine(
                "{0,-21}{1,-51}{2,-51}{3,-51}",
                DateTime.Now.ToString("yyyy'-'MM'-'dd HH':'mm':'ss"),
                action,
                entityId ?? string.Empty,
                operationId ?? string.Empty);
        }

        private static byte[] GenerateRandomBytes(int length)
        {
            var bytes = new byte[length];
            using (var rng = new RNGCryptoServiceProvider())
            {
                rng.GetBytes(bytes);
            }

            return bytes;
        }

        private static StreamingEndpointCacheControl GetCacheControl()
        {
            return new StreamingEndpointCacheControl
                       {
                           MaxAge = TimeSpan.FromSeconds(1000)
                       };
        }

        public static void UpdateCrossSiteAccessPoliciesForStreamingEndpoint(IStreamingEndpoint streamingEndpoint)
        {
            var clientPolicy =
                @"<?xml version=""1.0"" encoding=""utf-8""?>
            <access-policy>
                <cross-domain-access>
                    <policy>
                        <allow-from http-request-headers=""*"" http-methods=""*"">
                            <domain uri=""*""/>
                        </allow-from>
                        <grant-to>
                           <resource path=""/"" include-subpaths=""true""/>
                        </grant-to>
                    </policy>
                </cross-domain-access>
            </access-policy>";

            var xdomainPolicy =
                @"<?xml version=""1.0"" ?>
            <cross-domain-policy>
                <allow-access-from domain=""*"" />
            </cross-domain-policy>";

            streamingEndpoint.CrossSiteAccessPolicies.ClientAccessPolicy = clientPolicy;
            streamingEndpoint.CrossSiteAccessPolicies.CrossDomainPolicy = xdomainPolicy;

            streamingEndpoint.Update();
        }

        public static void GetLocatorsInAllStreamingEndpoints(IAsset asset)
        {
            var locators = asset.Locators.Where(l => l.Type == LocatorType.OnDemandOrigin);
            var ismFile = asset.AssetFiles.AsEnumerable().FirstOrDefault(a => a.Name.EndsWith(".ism"));
            var template = new UriTemplate("{contentAccessComponent}/{ismFileName}/manifest");
            var urls = locators.SelectMany(l =>
                                           _context
                                               .StreamingEndpoints
                                               .AsEnumerable()
                                               .Where(se => se.State == StreamingEndpointState.Running)
                                               .Select(
                                                   se =>
                                                   template.BindByPosition(new Uri("http://" + se.HostName),
                                                                           l.ContentAccessComponent,
                                                                           ismFile.Name)))
                .ToArray();

            foreach (var url in urls)
            {
                Console.WriteLine(url);
            }

        }

        public static void Cleanup(IStreamingEndpoint streamingEndpoint,string achannelName)
        {
         
           if (streamingEndpoint != null)
            {
                if (streamingEndpoint.State == StreamingEndpointState.Running)
                {  streamingEndpoint.Stop();}

                {
                    streamingEndpoint.Delete(); 
                }
            }
            
            IAsset asset;
            var channel = _context.Channels.Where(c => c.Name == achannelName).FirstOrDefault();

            if (channel != null)
            {
                foreach (var program in channel.Programs)
                {
                    asset = _context.Assets.Where(se => se.Id == program.AssetId)
                        .FirstOrDefault();
                   
                    if (program.State == ProgramState.Running)
                    {
                        program.Stop();
                    }
                    program.Delete();

                    if (asset != null)
                    {
                        foreach (var l in asset.Locators)
                            l.Delete();

                        asset.Delete();
                    }
                }

                if (channel.State == ChannelState.Running)
                { channel.Stop(); }
                
                channel.Delete();
            }
        }

        #endregion


        #region VOD Section

        /// <summary>
        /// Example where I encode 2 video files (_singleWMVInputFilePath.wmv and 2.mp4)
        /// </summary>
        /// <param name="aOutputFileFolder"></param>
        /// <returns></returns>
        public static bool CreateandEncodeOnDemandFile(string aOutputFileFolder, string _singleMP4InputFilePath, string _singleWMVInputFilePath)
        {
            bool tempresult = true;
            try
            {
                // Create and cache the Media Services credentials in a static class variable.
                _cachedCredentials = new MediaServicesCredentials(
                    _mediaServicesAccountName,
                    _mediaServicesAccountKey);
                // Used the chached credentials to create CloudMediaContext.
                _context = new CloudMediaContext(_cachedCredentials);

                IAsset singleWMVAsset = CreateAssetAndUploadSingleFile(AssetCreationOptions.None,
                                                                       _singleWMVInputFilePath);

                // EncodeToH264 creates a job with one task
                // that converts a mezzanine file (in this case interview1.wmv)
                // into an MP4 file (in this case, "H264 Broadband 720p").
                IAsset MP4Asset = CreateEncodingJob(singleWMVAsset, "H264 Broadband 720p", aOutputFileFolder);


                // BuildSasUrlForMP4File creates a SAS Locator
                // and builds the SAS Url that can be used to 
                // progressively download the MP4 file.
                string fullSASURL = BuildSasUrlForMP4File(MP4Asset);

                Console.WriteLine("Progressive download URL: {0}", fullSASURL);

                // Download all the files in the asset locally
                // (that includes the mainifest.xml file).
                DownloadAssetToLocal(MP4Asset, _outputFilesFolder);

                Console.WriteLine();

                IAsset singleMP4Asset = CreateAssetAndUploadSingleFile(AssetCreationOptions.None,
                                                                       _singleMP4InputFilePath);
                // EncodeToAdaptiveBitrate creates a job with one task
                // that encodes a mezzanine file (in this case BigBuckBunny.mp4)
                // into an adaptive bitrate MP4 set (in this case, "H264 Adaptive Bitrate MP4 Set 720p").
                IAsset adaptiveBitrateAsset = CreateEncodingJob(singleMP4Asset, "H264 Adaptive Bitrate MP4 Set 720p", aOutputFileFolder);

                // Get the Streaming Origin Locator URL.
                string streamingURL = GetStreamingOriginLocatorURL(adaptiveBitrateAsset);

                // Add Smooth Streaming, HLS, and DASH format to the streaming URL.  
                // NOTE: To be able to play these streams based on the 
                // adaptiveBitrateAsset asset, you MUST have at least one
                // On-demand Streaming reserved unit. 
                // For more information, see: 
                //    Dynamic Packaging (http://msdn.microsoft.com/en-us/library/azure/jj889436.aspx)
                Console.WriteLine("Smooth Streaming format:");
                Console.WriteLine("{0}", streamingURL + "/Manifest");
                Console.WriteLine("Apple HLS format:");
                Console.WriteLine("{0}", streamingURL + "/Manifest(format=m3u8-aapl)");
                Console.WriteLine("MPEG DASH format:");
                Console.WriteLine("{0}", streamingURL + "/Manifest(format=mpd-time-csf)");
            }
            catch (Exception)
            {
                tempresult = false;
            }
            return tempresult;
        }

        /// <summary>
        /// Creates an asset and uploads a single file.
        /// </summary>
        /// <param name="assetCreationOptions">Asset creation options.</param>
        /// <param name="singleFilePath">File path.</param>
        /// <returns></returns>
        public static IAsset CreateAssetAndUploadSingleFile(AssetCreationOptions assetCreationOptions,
                                                            string singleFilePath)
        {
            var assetName = "UploadSingleFile_" + DateTime.UtcNow.ToString();
            var asset = _context.Assets.Create(assetName, assetCreationOptions);

            var fileName = Path.GetFileName(singleFilePath);

            var assetFile = asset.AssetFiles.Create(fileName);

            Console.WriteLine("Created assetFile {0}", assetFile.Name);

            var accessPolicy = _context.AccessPolicies.Create(assetName, TimeSpan.FromDays(30),
                                                              AccessPermissions.Write | AccessPermissions.List);

            var locator = _context.Locators.CreateLocator(LocatorType.Sas, asset, accessPolicy);

            Console.WriteLine("Upload {0}", assetFile.Name);

            assetFile.Upload(singleFilePath);
            Console.WriteLine("Done uploading {0}", assetFile.Name);

            locator.Delete();
            accessPolicy.Delete();

            return asset;
        }

        /// <summary>
        /// Creates an encoding job using the specified preset.
        /// </summary>
        /// <param name="asset">The source asset.</param>
        /// <param name="preset">Preset name.</param>
        /// <returns></returns>
        public static IAsset CreateEncodingJob(IAsset asset, string preset, string _outputFilesFolder)
        {
            // Declare a new job.
            IJob job = _context.Jobs.Create(preset + " encoding job");
            // Get a media processor reference, and pass to it the name of the 
            // processor to use for the specific task.
            var mediaProcessors =
                _context.MediaProcessors.Where(p => p.Name.Contains("Media Encoder")).ToList();

            var latestMediaProcessor =
                mediaProcessors.OrderBy(mp => new Version(mp.Version)).LastOrDefault();


            // Create a task with the encoding details, using a string preset.
            ITask task = job.Tasks.AddNew(preset + " encoding task",
                                          latestMediaProcessor,
                                          preset,
                                          Microsoft.WindowsAzure.MediaServices.Client.TaskOptions.ProtectedConfiguration);

            // Specify the input asset to be encoded.
            task.InputAssets.Add(asset);
            // Add an output asset to contain the results of the job. 
            // This output is specified as AssetCreationOptions.None, which 
            // means the output asset is not encrypted. 
            task.OutputAssets.AddNew("Output asset",
                                     AssetCreationOptions.None);

            // Use the following event handler to check job progress.  
            job.StateChanged += new
                EventHandler<JobStateChangedEventArgs>(StateChanged);

            // Launch the job.
            job.Submit();

            // Optionally log job details. This displays basic job details
            // to the console and saves them to a JobDetails-{JobId}.txt file 
            // in your output folder.
            LogJobDetails(job.Id);

            // Check job execution and wait for job to finish. 
            Task progressJobTask = job.GetExecutionProgressTask(CancellationToken.None);
            progressJobTask.Wait();

            // If job state is Error the event handling 
            // method for job progress should log errors.  Here we check 
            // for error state and exit if needed.
            if (job.State == JobState.Error)
            {
                throw new Exception("\nExiting method due to job error.");
            }

            return job.OutputMediaAssets[0];
        }

        /// <summary>
        /// Create an origin locator in order to get the streaming URLs.
        /// </summary>
        /// <param name="assetToStream"></param>
        /// <returns></returns>
        public static string GetStreamingOriginLocatorURL(IAsset assetToStream)
        {
            // Get a reference to the streaming manifest file from the  
            // collection of files in the asset. 
            var theManifest =
                from f in assetToStream.AssetFiles
                where f.Name.EndsWith(".ism")
                select f;

            // Cast the reference to a true IAssetFile type. 
            IAssetFile manifestFile = theManifest.First();

            // Create a 30-day readonly access policy. 
            IAccessPolicy policy = _context.AccessPolicies.Create("Streaming policy",
                                                                  TimeSpan.FromDays(30),
                                                                  AccessPermissions.Read);

            // Create a locator to the streaming content on an origin. 
            ILocator originLocator = _context.Locators.CreateLocator(LocatorType.OnDemandOrigin,
                                                                     assetToStream,
                                                                     policy,
                                                                     DateTime.UtcNow.AddMinutes(-5));

            // Display the base path to the streaming asset on the origin server.
            Console.WriteLine("Streaming asset base path on origin: ");
            Console.WriteLine(originLocator.Path);
            Console.WriteLine();

            // Create a full URL to the manifest file. 
            return originLocator.Path + manifestFile.Name;
        }

        /// <summary>
        /// Builds a SAS URL for the specified asset.
        /// The SAS URL is used to download files.
        /// </summary>
        /// <param name="asset"></param>
        /// <returns></returns>
        public static string BuildSasUrlForMP4File(IAsset asset)
        {
            // Declare an access policy for permissions on the asset. 
            // You can call an async or sync create method. 
            IAccessPolicy policy =
                _context.AccessPolicies.Create("My 30 days readonly policy",
                                               TimeSpan.FromDays(30),
                                               AccessPermissions.Read);

            // Create a SAS locator to enable direct access to the asset 
            // in blob storage. You can call a sync or async create method.  
            // You can set the optional startTime param as 5 minutes 
            // earlier than Now to compensate for differences in time  
            // between the client and server clocks. 

            ILocator locator = _context.Locators.CreateLocator(LocatorType.Sas,
                                                               asset,
                                                               policy,
                                                               DateTime.UtcNow.AddMinutes(-5));

            var mp4File = asset.AssetFiles.ToList().
                Where(f => f.Name.EndsWith(".mp4", StringComparison.OrdinalIgnoreCase)).
                FirstOrDefault();


            // Take the locator path, add the file name, and build 
            // a full SAS URL to access this file. This is the only 
            // code required to build the full URL.
            var uriBuilder = new UriBuilder(locator.Path);
            uriBuilder.Path += "/" + mp4File.Name;

            Console.WriteLine("Full URL to file: ");
            Console.WriteLine(uriBuilder.Uri.AbsoluteUri);
            Console.WriteLine();

            //Return the SAS URL.
            return uriBuilder.Uri.AbsoluteUri;
        }

        /// <summary>
        /// Download the asset to a local folder.
        /// The download progress is displayed in the console window.
        /// </summary>
        /// <param name="asset"></param>
        /// <param name="outputFolder"></param>
        /// <returns></returns>
        public static IAsset DownloadAssetToLocal(IAsset asset, string outputFolder)
        {
            IAccessPolicy accessPolicy = _context.AccessPolicies.Create("File Download Policy", TimeSpan.FromDays(30),
                                                                        AccessPermissions.Read);
            ILocator locator = _context.Locators.CreateLocator(LocatorType.Sas, asset, accessPolicy);
            BlobTransferClient blobTransfer = new BlobTransferClient
                                                  {
                                                      NumberOfConcurrentTransfers = 10,
                                                      ParallelTransferThreadCount = 10
                                                  };

            Console.WriteLine("Files will be downloaded to:");
            Console.WriteLine("{0}", outputFolder);
            Console.WriteLine();

            var downloadTasks = new List<Task>();
            foreach (IAssetFile outputFile in asset.AssetFiles)
            {
                // Use the following event handler to check download progress.
                outputFile.DownloadProgressChanged += DownloadProgress;

                string localDownloadPath = Path.Combine(outputFolder, outputFile.Name);

                downloadTasks.Add(outputFile.DownloadAsync(Path.GetFullPath(localDownloadPath), blobTransfer, locator,
                                                           CancellationToken.None));

                outputFile.DownloadProgressChanged -= DownloadProgress;
            }

            Task.WaitAll(downloadTasks.ToArray());

            return asset;
        }

        //////////////////////////////////////////////////
        // Delete tasks
        //////////////////////////////////////////////////

        public static void DeleteAsset(IAsset asset)
        {
            // Delete Asset's locators before
            // deleting the asset.
            foreach (var l in asset.Locators)
            {
                Console.WriteLine("Deleting the Locator {0}", l.Id);
                l.Delete();
            }

            Console.WriteLine("Deleting the Asset {0}", asset.Id);
            // delete the asset
            asset.Delete();
        }

        public static void DeleteAccessPolicy(string existingPolicyId)
        {
            // To delete a specific access policy, get a reference to the policy.  
            // based on the policy Id passed to the method.
            var policy = _context.AccessPolicies.
                Where(p => p.Id == existingPolicyId).FirstOrDefault();

            Console.WriteLine("Deleting policy {0}", existingPolicyId);
            policy.Delete();

        }

        //////////////////////////////////////////////////
        // Private helper methods.
        //////////////////////////////////////////////////

        private static void DownloadProgress(object sender, Microsoft.WindowsAzure.MediaServices.Client.DownloadProgressChangedEventArgs e)
        {
            Console.WriteLine(string.Format("{0} % download progress. ", e.Progress));
        }


        private static void StateChanged(object sender, JobStateChangedEventArgs e)
        {
            Console.WriteLine("Job state changed event:");
            Console.WriteLine("  Previous state: " + e.PreviousState);
            Console.WriteLine("  Current state: " + e.CurrentState);

            switch (e.CurrentState)
            {
                case JobState.Finished:
                    Console.WriteLine();
                    Console.WriteLine("********************");
                    Console.WriteLine("Job is finished.");
                    Console.WriteLine("Please wait while local tasks or downloads complete...");
                    Console.WriteLine("********************");
                    Console.WriteLine();
                    Console.WriteLine();
                    break;
                case JobState.Canceling:
                case JobState.Queued:
                case JobState.Scheduled:
                case JobState.Processing:
                    Console.WriteLine("Please wait...\n");
                    break;
                case JobState.Canceled:
                case JobState.Error:
                    // Cast sender as a job.
                    IJob job = (IJob) sender;
                    // Display or log error details as needed.
                    LogJobStop(job.Id);
                    break;
                default:
                    break;
            }
        }

        private static void LogJobStop(string jobId)
        {
            StringBuilder builder = new StringBuilder();
            IJob job = _context.Jobs.Where(j => j.Id == jobId).FirstOrDefault();

            builder.AppendLine("\nThe job stopped due to cancellation or an error.");
            builder.AppendLine("***************************");
            builder.AppendLine("Job ID: " + job.Id);
            builder.AppendLine("Job Name: " + job.Name);
            builder.AppendLine("Job State: " + job.State.ToString());
            builder.AppendLine("Job started (server UTC time): " + job.StartTime.ToString());
            builder.AppendLine("Media Services account name: " + _mediaServicesAccountName);
            // Log job errors if they exist.  
            if (job.State == JobState.Error)
            {
                builder.Append("Error Details: \n");
                foreach (ITask task in job.Tasks)
                {
                    foreach (ErrorDetail detail in task.ErrorDetails)
                    {
                        builder.AppendLine("  Task Id: " + task.Id);
                        builder.AppendLine("    Error Code: " + detail.Code);
                        builder.AppendLine("    Error Message: " + detail.Message + "\n");
                    }
                }
            }
            builder.AppendLine("***************************\n");
            // Write the output to a local file and to the console. The template 
            // for an error output file is:  JobStop-{JobId}.txt
            string outputFile = _outputFilesFolder + @"\JobStop-" + JobIdAsFileName(job.Id) + ".txt";
            WriteToFile(outputFile, builder.ToString());
            Console.Write(builder.ToString());
        }

        private static void LogJobDetails(string jobId)
        {
            StringBuilder builder = new StringBuilder();
            IJob job = _context.Jobs.Where(j => j.Id == jobId).FirstOrDefault();

            builder.AppendLine("\nJob ID: " + job.Id);
            builder.AppendLine("Job Name: " + job.Name);
            builder.AppendLine("Job submitted (client UTC time): " + DateTime.UtcNow.ToString());
            builder.AppendLine("Media Services account name: " + _mediaServicesAccountName);

            // Write the output to a local file and to the console. The template 
            // for an error output file is:  JobDetails-{JobId}.txt
            string outputFile = _outputFilesFolder + @"\JobDetails-" + JobIdAsFileName(job.Id) + ".txt";
            WriteToFile(outputFile, builder.ToString());
            Console.Write(builder.ToString());
        }

        private static void WriteToFile(string outFilePath, string fileContent)
        {
            StreamWriter sr = File.CreateText(outFilePath);
            sr.Write(fileContent);
            sr.Close();
        }

        private static string JobIdAsFileName(string jobID)
        {
            return jobID.Replace(":", "_");
        }
    }

    #endregion
} 

    

