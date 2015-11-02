using System;
using System.Collections.Generic;
using System.Net;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.IO;
using Microsoft.Web.Administration;

namespace VooPPointMgr.BLL
{

    // A publishing point can have a stream state (the status of the encoding stream it is listening to), and archive state (the status of the stream it is archiving to) and a fragment stream that enables insertion of other content to the stream

    public enum State
    {
        Disabled, Started, Stopped, Unknown
    }

    public enum PublishingPointCommand
    {
        Start, Stop, Shutdown
    }

    // The publishing point itself has a more involved list of states

    public enum PublishingPointState
    {
        Idle, Starting, Started, Stopping, Stopped, Shuttingdown, Error, Unknown
    }

    public enum LiveSourceType
    {
        Push, Pull
    }

    // The first few properties are the various states of the nodes and the publishing point itself. The site name is the website it is configured on. This will usually be "Default Web Site." The Path is the virtual path (not the physical path) the publishing point resides in (also known as the Application), and the name is the actual name of the publishing point.


    public class BLLPublishingPoint
    {

        public BLLPublishingPoint()
        {
        }

        public State StreamState { get; set; }

        public State ArchiveState { get; set; }

        public State FragmentState { get; set; }

        public PublishingPointState PubState { get; set; }

        public string SiteName { get; set; }

        public string Path { get; set; }

        public string Name { get; set; }


        // Get the list of Publishing Points

        private const string LIVESTREAMINGSECTION = "system.webServer/media/liveStreaming";

        private const string METHODGETPUBPOINTS = "GetPublishingPoints";

        private const string ATTR_SITENAME = "siteName";

        private const string ATTR_VIRTUALPATH = "virtualPath";

        private const string ATTR_NAME = "name";

        private const string ATTR_ARCHIVES = "archives";

        private const string ATTR_FRAGMENTS = "fragments";

        private const string ATTR_STREAMS = "streams";

        private const string ATTR_STATE = "state";


        //Elimina un publishing point que envia simultaneamente al publishing point del canal en el servidor
        public static bool DeletePublishingPointPTM(string aName, string aServerIP)
        {
            bool tempresult = false;

            try
            {
                if (aServerIP == "")
                {
                    //lo elimino localmente
                    System.IO.File.Delete((@"c:\inetpub\wwwroot\" + aName + ".isml"));
                }
                else
                {
                    //lo elimino en el server remoto
                    string cad = "\\" + aServerIP + @"\Channels\";
                    System.IO.File.Delete(@cad + aName + ".isml");
                    tempresult = true;
                }

                tempresult = true;

            }
            catch (Exception ex)
            {
                tempresult = false;

            }
            return tempresult;
        }

        //Elimina un publishing point que envia simultaneamente al publishing point del canal en el servidor
        public static bool DeletePublishingPointPTM(string aName)
        {
            bool tempresult = false;

            try
            {
                //lo elimino localmente
                System.IO.File.Delete((@"c:\inetpub\wwwroot\" + aName + ".isml"));
                tempresult = true;
            }

            catch (Exception ex)
            {
                tempresult = false;
            }
            return tempresult;
        }

        //Crea un publishing point que envia simultaneamente al publishing point del canal en el servidor
        public static bool CreatePublishingPointPTM(string aName, string aServerIP, List<string> ListaServersIps, bool aStreamtoIOS)
        {
            bool tempresult = false;

            string content = "<?xml version=\"1.0\" encoding=\"utf-8\"?>\n";
            content += "<smil xmlns=\"http://www.w3.org/2001/SMIL20/Language\">\n";
            content += "<head>\n";
            content += "<meta name=\"title\" content=\"\" />\n";
            content += "<meta name=\"module\" content=\"liveSmoothStreaming\" />\n";
            content += "<meta name=\"sourceType\" content=\"Push\" />\n";
            content += "<meta name=\"publishing\" content=\"Fragments;Streams;Archives\" />\n";
            content += "<meta name=\"estimatedTime\" content=\"0\" />\n";
            content += "<meta name=\"lookaheadChunks\" content=\"2\" />\n";
            content += "<meta name=\"manifestWindowLength\" content=\"0\" />\n";
            content += "<meta name=\"startOnFirstRequest\" content=\"False\" />\n";
            content += "<meta name=\"archiveSegmentLength\" content=\"0\" />\n";
            content += "<meta name=\"restartOnEncoderReconnect\" content=\"true\" />\n";
            content += "<meta name=\"filters\" content=\"\" />\n";
            if (aStreamtoIOS == true)
            {
                content += "<meta name=\"formats\" content=\"m3u8-aapl\" />\n";
                content += "<meta name=\"m3u8-aapl-segmentlength\" content=\"10\" />\n";
                content += "<meta name=\"m3u8-aapl-maxbitrate\" content=\"3000000\" />\n";
                content += "<meta name=\"m3u8-aapl-allowcaching\" content=\"False\" />\n";
                content += "<meta name=\"m3u8-aapl-backwardcompatible\" content=\"True\" />\n";
                content += "<meta name=\"m3u8-aapl-enableencryption\" content=\"False\" />\n";
            }

            content += "</head>\n";
            content += "<body>\n";
            content += "<par>\n";

            if (ListaServersIps.Count > 0)
            {
                foreach (string temppp in ListaServersIps)
                {
                    if (temppp != "")
                    {
                        content += " <ref src=\"http://" + temppp + ".isml\" />\n";
                    }
                }
            }

            content += "</par>\n";
            content += "</body>\n";
            content += "</smil>\n";
            //   content += "";

            string[] mystring = content.Split(new char[] { '\n' });

            if (aName == "")
            {
                aName = "Max";
            }

            try
            {
                if (aServerIP == "")
                {
                    //lo creo localmente
                    System.IO.File.WriteAllLines(@"c:\inetpub\wwwroot\" + aName + ".isml", mystring);
                }
                else
                {
                    //lo creo en el server remoto
                    string cad = "\\" + aServerIP + @"\Channels\";
                    System.IO.File.WriteAllLines(@cad + aName + ".isml", mystring);
                    tempresult = true;
                }
            }
            catch (Exception ex)
            {
                tempresult = false;
            }
            return tempresult;
        }

        //Crea un publishing point que envia simultaneamente al publishing point del canal en el servidor
        public static bool CreatePublishingPointPTM(string aName, string AzureURL, bool aStreamtoIOS)
        {
            bool tempresult = false;

            string content = "<?xml version=\"1.0\" encoding=\"utf-8\"?>\n";
            content += "<smil xmlns=\"http://www.w3.org/2001/SMIL20/Language\">\n";
            content += "<head>\n";
            content += "<meta name=\"title\" content=\"\" />\n";
            content += "<meta name=\"module\" content=\"liveSmoothStreaming\" />\n";
            content += "<meta name=\"sourceType\" content=\"Push\" />\n";
            content += "<meta name=\"publishing\" content=\"Fragments;Streams;Archives\" />\n";
            content += "<meta name=\"estimatedTime\" content=\"0\" />\n";
            content += "<meta name=\"lookaheadChunks\" content=\"2\" />\n";
            content += "<meta name=\"manifestWindowLength\" content=\"0\" />\n";
            content += "<meta name=\"startOnFirstRequest\" content=\"False\" />\n";
            content += "<meta name=\"archiveSegmentLength\" content=\"0\" />\n";
            content += "<meta name=\"restartOnEncoderReconnect\" content=\"true\" />\n";
            content += "<meta name=\"filters\" content=\"\" />\n";
            if (aStreamtoIOS == true)
            {
                content += "<meta name=\"formats\" content=\"m3u8-aapl\" />\n";
                content += "<meta name=\"m3u8-aapl-segmentlength\" content=\"10\" />\n";
                content += "<meta name=\"m3u8-aapl-maxbitrate\" content=\"3000000\" />\n";
                content += "<meta name=\"m3u8-aapl-allowcaching\" content=\"False\" />\n";
                content += "<meta name=\"m3u8-aapl-backwardcompatible\" content=\"True\" />\n";
                content += "<meta name=\"m3u8-aapl-enableencryption\" content=\"False\" />\n";
            }

            content += "</head>\n";
            content += "<body>\n";
            content += "<par>\n";

            if (AzureURL != "")
            {
                content += " <ref src=\"http://" + AzureURL + ".isml\" />\n";
            }

            content += "</par>\n";
            content += "</body>\n";
            content += "</smil>\n";
           
            string[] mystring = content.Split(new char[] { '\n' });

            if (aName == "")
            {
                aName = "Max";
            }

            try
            {
               //lo creo localmente
                System.IO.File.WriteAllLines(@"c:\inetpub\wwwroot\" + aName + ".isml", mystring);
            }
            catch (Exception ex)
            {
                tempresult = false;
            }
            return tempresult;
        }

        // Get all the publishing points on a server
        public static List<BLLPublishingPoint> GetPublishingPoints()
        {
            var retVal = new List<BLLPublishingPoint>();
            using (var serverManager = new ServerManager())
            {
                Configuration appHost = serverManager.GetApplicationHostConfiguration();

                try
                {
                    ConfigurationSection liveStreamingConfig = appHost.GetSection(LIVESTREAMINGSECTION);

                    foreach (Site site in serverManager.Sites)
                    {
                        foreach (Application application in site.Applications)
                        {
                            try
                            {
                                ConfigurationMethodInstance instance = liveStreamingConfig.Methods[METHODGETPUBPOINTS].CreateInstance();

                                instance.Input[ATTR_SITENAME] = site.Name;

                                instance.Input[ATTR_VIRTUALPATH] = application.Path;

                                instance.Execute();

                                ConfigurationElement collection = instance.Output.GetCollection();

                                foreach (var item in collection.GetCollection())
                                {
                                    retVal.Add(new BLLPublishingPoint
                                    {
                                        SiteName = site.Name,

                                        Path = application.Path,

                                        Name = item.Attributes[ATTR_NAME].Value.ToString(),

                                        ArchiveState = (State)item.Attributes[ATTR_ARCHIVES].Value,

                                        FragmentState = (State)item.Attributes[ATTR_FRAGMENTS].Value,

                                        StreamState = (State)item.Attributes[ATTR_STREAMS].Value,

                                        PubState = (PublishingPointState)item.Attributes[ATTR_STATE].Value
                                    });
                                }
                            }
                            catch (COMException ce)
                            {
                                Debug.Print(ce.Message);
                            }
                        }
                    }
                }

                catch (COMException ce)
                {
                    Debug.Print(ce.Message);
                }

            }

            return retVal;
        }

        /// <summary>
        ///  Recojo solo el nombre del Publishing point de la ruta completa (Ej. solo extraigo canales.isml de http://38.100.207.193/channels/canales.isml)
        /// </summary>
        /// <param name="aPublishingPointCompleteName"></param>
        /// <returns></returns>
        private static string ParsePublishingPointName(string aPublishingPointCompleteName)
        {
            // Establezco los delimitadores
            // char[] delimiterChars = { ' ', ',', '.', ':', '\t' };
            char[] delimiterChars = { '/' };

            string text = aPublishingPointCompleteName;

            string[] words = text.Split(delimiterChars);

            //Devuelvo la ultima palabra

            return words[words.Length - 1];
        }


        public static BLLPublishingPoint _GetPublishingPointByName(string PublishingPointName)
        {
            List<BLLPublishingPoint> templist = GetPublishingPoints();

            BLLPublishingPoint tempresult = new BLLPublishingPoint();


            // Recojo solo el nombre del Publishing point de la ruta completa (Ej. solo extraigo canales.isml de http://38.100.207.193/channels/canales.isml)
            string ParsedPublishingPointName = ParsePublishingPointName(PublishingPointName);

            foreach (BLLPublishingPoint tempPP in templist)
            {
                if (tempPP.Name == ParsedPublishingPointName)
                {
                    tempresult = tempPP;
                    break;
                }
            }

            if (tempresult.Name != null)
            {
                return tempresult;
            }
            else
            {
                return null;
            }
        }


        public bool _IssueCommand(BLLPublishingPoint publishingPoint, PublishingPointCommand command)
        {
            bool tempresult = true;
            try
            {
                using (var serverManager = new ServerManager())
                {
                    Configuration appHost = serverManager.GetApplicationHostConfiguration();
                    ConfigurationSection liveStreamingConfig = appHost.GetSection(LIVESTREAMINGSECTION);

                    if (liveStreamingConfig == null)
                    {
                        throw new Exception("Couldn't get to the live streaming section.");
                    }
                    ConfigurationMethodInstance instance = liveStreamingConfig.Methods[METHODGETPUBPOINTS].CreateInstance();

                    instance.Input[ATTR_SITENAME] = publishingPoint.SiteName;
                    instance.Input[ATTR_VIRTUALPATH] = publishingPoint.Path;

                    instance.Execute();

                    // Gets the PublishingPointCollection associated with the method output
                    ConfigurationElement collection = instance.Output.GetCollection();

                    foreach (var item in collection.GetCollection())
                    {
                        if (item.Attributes[ATTR_NAME].Value.ToString().Equals(publishingPoint.Name))
                        {
                            var method = item.Methods[command.ToString()];
                            var methodInstance = method.CreateInstance();
                            methodInstance.Execute();
                            break;
                        }
                    }
                }
            }
            catch
            {
                tempresult = false;

            }
            return tempresult;
        }

        public static bool CreateHTMLPlayer(string aPublishingPointtoRetrievefrom, string aMonitorName, string aFilePath)
        {
            bool tempresult = false;
            string content = "<!DOCTYPE html PUBLIC \" -//W3C//DTD XHTML 1.0 Transitional//EN\" \n";
            content += "\"http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd\">\n";
            content += "<html xmlns=\"http://www.w3.org/1999/xhtml\" >\n";
            content += "<head>\n";
            content += "<title></title>\n";
            content += "<style type=\"text/css\">\n";
            content += "html, body {\n";
            content += "height: 100%;\n";
            content += "overflow: auto;\n";
            content += " }\n";
            content += "body {\n";
            content += "padding: 0;\n";
            content += "margin: 0;\n";
            content += " }\n";
            content += " #silverlightControlHost { height: 100%; }\n";
            content += " </style>\n";
            content += " <script type=\"text/javascript\">\n";
            content += " function onSilverlightError(sender, args) {\n";
            content += " var appSource = \"\";\n";
            content += "  if (sender != null && sender != 0) {\n";
            content += " appSource = sender.getHost().Source;\n";
            content += " }\n";
            content += " var errorType = args.ErrorType;\n";
            content += " var iErrorCode = args.ErrorCode;\n";
            content += " var errMsg = \"Unhandled Error in Silverlight Application \" +  appSource + \"\" ;\n";
            content += " errMsg += \"Code: \"+ iErrorCode + \"\" ;\n";
            content += " errMsg += \"Category: \" + errorType + \"\" ;\n";
            content += " errMsg += \"Message: \" + args.ErrorMessage + \"\" ;\n";
            content += " if (errorType == \"ParserError\")\n";
            content += " {\n";
            content += "errMsg += \"File: \" + args.xamlFile + \"\" ;\n";
            content += " errMsg += \"Line: \" + args.lineNumber + \"\" ;\n";
            content += " errMsg += \"Position: \" + args.charPosition + \"\" ;\n";
            content += " }\n";
            content += "else if (errorType == \"RuntimeError\")\n";
            content += " {\n";
            content += " if (args.lineNumber != 0)\n";
            content += " {\n";
            content += " errMsg += \"Line: \" + args.lineNumber + \"\" ;\n";
            content += " errMsg += \"Position: \" +  args.charPosition + \"\" ;\n";
            content += " }\n";
            content += " errMsg += \"MethodName: \" + args.methodName + \"\" ;\n";
            content += " }\n";
            content += "  throw new Error(errMsg);\n";
            content += " }\n";
            content += " </script>\n";

            content += " </head>\n";
            content += " <body>\n";
            content += " <form id=\"form1\" runat=\"server\" style=\"height:100%\">\n";
            content += " <div id=\"silverlightControlHost\">\n";
            content += " <object data=\"data:application/x-silverlight-2,\" type=\"application/x-silverlight-2\" \n";
            content += " width=\"100%\" height=\"100%\">\n";
            content += " 	          <param name=\"source\" value=\"VooPlayer.xap\"/>\n";
            content += " 		  <param name=\"onError\" value=\"onSilverlightError\" />\n";
            content += " 		  <param name=\"background\" value=\"white\" />\n";
            content += " 		  <param name=\"minRuntimeVersion\" value=\"4.0.50401.0\" />\n";
            content += " 		  <param name=\"autoUpgrade\" value=\"true\" />\n";
            content += " 		  <param name=\"enableGPUAcceleration\" value=\"true\" />\n";
            content += " 		  <param name=\"InitParams\" \n";

            //   content += " value=\"mediaurl=http://38.100.207.193/channels/deportes.isml/manifest\" />\n";
            content += " value=\"mediaurl=" + aPublishingPointtoRetrievefrom + "/manifest\" />\n";

            content += " <a href=\"http://go.microsoft.com/fwlink/?LinkID=149156&v=4.0.50401.0\" \n";
            content += " style=\"text-decoration:none\">\n";
            content += " <img src=\"http://go.microsoft.com/fwlink/?LinkId=161376\" alt=\"Get \n";
            content += "Microsoft Silverlight\" style=\"border-style:none\"/>\n";
            content += " </a>\n";
            content += " </object><iframe id=\"_sl_historyFrame\" \n";
            content += "style=\"visibility:hidden;height:0px;width:0px;border:0px\"></iframe></div>\n";
            content += " </form>\n";
            content += " </body>\n";
            content += "</html>\n";

            string[] mystring = content.Split(new char[] { '\n' });
            try
            {

                System.IO.File.WriteAllLines(@"c:\Data\Decoder\" + aMonitorName + ".html", mystring);

                //copio el fichero xap del player, si existe no lo sobrescribo sino que lo reutilizo
                if (!System.IO.File.Exists(@"c:\Data\Decoder\VooPlayer.xap"))
                {
                    System.IO.File.Copy(aFilePath + "\\VooPlayer.xap", @"c:\Data\Decoder\VooPlayer.xap", false);
                }

                tempresult = true;
            }
            catch (Exception)
            {
                tempresult = false;
            }

            return tempresult;
        }

        // Encuesta el publishing point remoto para que cambie su estado dormido a comenzar a recibir senal desde esta caja

        public static void InvokeRemotBoxStartReceivingFrames(string aPublishingPointtoWakeUp)
        {
            WebRequest req = WebRequest.Create(aPublishingPointtoWakeUp + "/manifest");
            req.Timeout = 100;
            try
            {
                HttpWebResponse response = (HttpWebResponse)req.GetResponse();
            }
            catch (Exception)
            {
                //We know its going to fail but that dosent matter!!
            }
        }

        //Crea un Player para IOS en el servidor
        public static bool CreateHtml5PlayerIOS(string aName, string aPPointtoConsumeFrom)
        {
            bool tempresult = false;

            string content = "<html>\n";
            content += " <head>\n";
            content += "   <title> VOO Player IOS</title>\n";
            content += " </head>\n";
            content += "<body>\n";
            content += "<h1>VOO Player IOS</h1>\n";
            content += "<video width=\"640\" \n";
            content += "height=\"480\"\n";
            content += "src=\"" + aPPointtoConsumeFrom + "(format=m3u8-aapl)\"\n";
            content += "poster=\"logo.jpg\"\n";
            content += "autoplay=\"true\" \n";
            content += "controls=\"true\" >VOO Player IOS</video>\n";
            content += "</body>\n";
            content += "</html>";

            string[] mystring = content.Split(new char[] { '\n' });

            if (aName == "")
            {
                aName = "IOS";
            }

            try
            {
                System.IO.File.WriteAllLines(@"c:\inetpub\wwwroot\" + aName + ".htm", mystring);
                tempresult = true;
            }
            catch (Exception)
            {
                tempresult = false;
            }
            return tempresult;
        }
        //verifica si existe Crossdomain.xml, ClientAccessPolicy.xml y cualquier otro archivo futuro de config, si no estan los copia

        public static void VerifyConfigfiles(string aFilePath)
        {

            if ((!System.IO.File.Exists(@"c:\inetpub\wwwroot\crossdomain.xml")) || (!System.IO.File.Exists(@"c:\inetpub\wwwroot\ClientAccessPolicy.xml")) || (!System.IO.File.Exists(@"c:\inetpub\wwwroot\logo.jpg")))
            {

                // Falta un archivo de config, reemplazo el folder
                System.IO.File.Copy(aFilePath + "\\crossdomain.xml", @"c:\inetpub\wwwroot\crossdomain.xml", true);
                System.IO.File.Copy(aFilePath + "\\ClientAccessPolicy.xml", @"c:\inetpub\wwwroot\ClientAccessPolicy.xml", true);
                System.IO.File.Copy(aFilePath + "\\logo.jpg", @"c:\inetpub\wwwroot\logo.jpg", true);

            }
        }

        public void AdicionarIptoStreamto(string anIP)
        {

        }

        public static void CreatePublishingPoint(string aPPName)
        {
            string content = "<?xml version=\"1.0\" encoding=\"utf-8\"?>\n";
            content += "<smil xmlns=\"http://www.w3.org/2001/SMIL20/Language\">\n";
            content += "<head>\n";
            content += "<meta name=\"title\" content=\"\" />\n";
            content += "<meta name=\"module\" content=\"liveSmoothStreaming\" />\n";
            content += "<meta name=\"sourceType\" content=\"Push\" />\n";
            content += "<meta name=\"publishing\" content=\"Fragments;Streams;Archives\" />\n";
            content += "<meta name=\"estimatedTime\" content=\"0\" />\n";
            content += "<meta name=\"lookaheadChunks\" content=\"2\" />\n";
            content += "<meta name=\"manifestWindowLength\" content=\"0\" />\n";
            content += "<meta name=\"startOnFirstRequest\" content=\"False\" />\n";
            content += "<meta name=\"archiveSegmentLength\" content=\"0\" />\n";
            content += "<meta name=\"formats\" content=\"m3u8-aapl\" />\n";
            content += "<meta name=\"m3u8-aapl-segmentlength\" content=\"10\" />\n";
            content += "<meta name=\"m3u8-aapl-maxbitrate\" content=\"3000000\" />\n";
            content += "<meta name=\"m3u8-aapl-allowcaching\" content=\"False\" />\n";
            content += "<meta name=\"m3u8-aapl-backwardcompatible\" content=\"True\" />\n";
            content += "<meta name=\"m3u8-aapl-enableencryption\" content=\"False\" />\n";
            content += "<meta name=\"filters\" content=\"\" />\n";
            content += "</head>\n";
            content += "<body>\n";
            content += "</body>\n";
            content += "</smil>\n";
            //   content += "";

            string[] mystring = content.Split(new char[] { '\n' });


            System.IO.File.WriteAllLines(@"c:\inetpub\wwwroot\" + aPPName + ".isml", mystring);

        }

        public bool CreatePublishingPoint(BLLPublishingPoint publishingPoint, string title, string duration, LiveSourceType type)
        {
            bool retVal = false;

            using (var manager = new ServerManager())
            {
                Site site = manager.Sites[publishingPoint.SiteName];

                Application application = site.Applications[publishingPoint.Path];


                string template = string.Format("TEMPLATE.xml", title, type, duration ?? string.Empty);

                try
                {
                    string path = string.Format(@"{0}\{1}", application.VirtualDirectories[0].PhysicalPath, publishingPoint.Name);

                    File.WriteAllText(path, template);
                    retVal = true;
                }
                catch (Exception ex)
                {
                    Debug.Print(ex.Message);
                }
            }
            return retVal;
        }

        public static bool _ShutdownPublishingPoint(string aPublishingpoint)
        {
            BLLPublishingPoint tempPP = _GetPublishingPointByName(aPublishingpoint);
            bool tempresult = false;

            if (tempPP == null)
            {
                //  Devuelvo falso, el publishing point que busco no existe
            }

            else
            {

                BLLPublishingPoint PP = new BLLPublishingPoint();
                //paro el publishing point
                if (tempPP.PubState == PublishingPointState.Idle)
                {
                    //esta apagado already
                    tempresult = true;
                }
                else
                {    //compruebo que la operacion se realizo
                    if (PP._IssueCommand(tempPP, PublishingPointCommand.Shutdown) == true)
                    {
                        tempresult = true;
                    }
                    else
                    {  //hubo problemas al realizar la operacion

                        tempresult = false;

                    }
                }
            }
            return tempresult;
        }

        public bool _StartPublishingPoint(string aPublishingpoint)
        {
            BLLPublishingPoint tempPP = _GetPublishingPointByName(aPublishingpoint);
            bool tempresult = false;

            if (tempPP == null)
            {
                //  Devuelvo falso, el publishing point que busco no existe
            }

            else
            {

                BLLPublishingPoint PP = new BLLPublishingPoint();
                //paro el publishing point
                if (tempPP.PubState == PublishingPointState.Started)
                {
                    //esta encendido already
                    tempresult = true;
                }
                else
                {    //compruebo que la operacion se realizo
                    if (PP._IssueCommand(tempPP, PublishingPointCommand.Start) == true)
                    {
                        tempresult = true;
                    }
                    else
                    {  //hubo problemas al realizar la operacion

                        tempresult = false;

                    }
                }
            }
            return tempresult;
        }

        public static bool _StopLiveSource_PublishingPoint(string aPublishingpoint)
        {
            BLLPublishingPoint tempPP = _GetPublishingPointByName(aPublishingpoint);
            bool tempresult = false;

            if (tempPP == null)
            {
                //  Devuelvo falso, el publishing point que busco no existe
            }

            else
            {

                BLLPublishingPoint PP = new BLLPublishingPoint();
                //paro el publishing point
                if (tempPP.PubState == PublishingPointState.Started)
                {
                    if (PP._IssueCommand(tempPP, PublishingPointCommand.Stop) == true)
                    {
                        tempresult = true;
                    }
                    //esta apagado already

                }

            }
            return tempresult;
        }


        public static bool _RestartPublishingPoint(string aPublishingPoint)
        {
            bool tempResult = false;
            bool operationresult;
            BLLPublishingPoint tempPP = _GetPublishingPointByName(aPublishingPoint);

            if (tempPP == null)
            {
                //  Devuelvo falso, el publishing point que busco no existe
            }

            else
            {

                BLLPublishingPoint PP = new BLLPublishingPoint();
                //paro el publishing point
                if (tempPP.PubState == PublishingPointState.Idle)
                {
                    //esta apagado already
                }
                else
                {    //compruebo que la operacion se realizo
                    if (PP._IssueCommand(tempPP, PublishingPointCommand.Shutdown) == true)
                    { }
                    else
                    {  //hubo problemas al realizar la operacion

                        tempResult = false;

                    }
                }

                //inicio el publishing point

                if (PP._IssueCommand(tempPP, PublishingPointCommand.Start) == true)
                { }
                else
                {  //hubo problemas al realizar la operacion

                    tempResult = false;

                }

                //encuesto de nuevo el publishing point para asegurarme que esta en estado correcto para recibir transmisiones
                BLLPublishingPoint tempComprobarPP = _GetPublishingPointByName(aPublishingPoint);

                if (tempComprobarPP.PubState == PublishingPointState.Starting)
                {
                    //se reinicio satisfactoriamente
                    tempResult = true;
                }


            }


            return tempResult;

        }
    }
}

