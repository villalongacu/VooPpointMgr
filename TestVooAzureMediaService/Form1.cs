using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VooAzureStreamFacade;

namespace TestVooAzureMediaService
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnCreateLiveInfrastructure_Click(object sender, EventArgs e)
        {

            var configParamStartAms = new StartAMSConfigParams(tbChannelName.Text, tbChannelName.Text,
                tbChannelName.Text, tbAssetlName.Text, tbProgramName.Text, tbStreamingEndpointName.Text,
                TimeSpan.FromHours(6));

            var tempresult = VooAzureStreamFacade.VooAzureStreamFacade.CreateLiveStreamingInfrastructure(configParamStartAms);

            //MessageBox.Show(tempresult.ToString(),"Create Live Streaming infrastructure",MessageBoxButtons.OK, MessageBoxIcon.Information);

            tbIngestURL.Text = VooAzureStreamFacade.VooAzureStreamFacade.ReturnIngestURL(tbChannelName.Text);
            tbPreviewURL.Text = VooAzureStreamFacade.VooAzureStreamFacade.ReturnPreviewURL(tbChannelName.Text);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            var config = new StopAMSConfigParams(tbChannelName.Text, tbStreamingEndpointName.Text);
            bool tempresult =
                VooAzureStreamFacade.VooAzureStreamFacade.ReleaseLiveStreamingInfrastructure(config);

            //  MessageBox.Show(tempresult.ToString(), "Destroy Live Streaming infrastructure", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnUpdateIngestURL_Click(object sender, EventArgs e)
        {
            tbIngestURL.Text = VooAzureStreamFacade.VooAzureStreamFacade.ReturnIngestURL(tbChannelName.Text);

        }

        private void btnUpdatePreviewURL_Click(object sender, EventArgs e)
        {
            tbPreviewURL.Text = VooAzureStreamFacade.VooAzureStreamFacade.ReturnPreviewURL(tbChannelName.Text);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var tempresult = VooAzureStreamFacade.VooAzureStreamFacade.ResetChannel(tbChannelName.Text);
            MessageBox.Show(tempresult.ToString(), "Reset Channel", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnGetMainStreamingURL_Click(object sender, EventArgs e)
        {
            tbMainStreamingURL.Text = VooAzureStreamFacade.VooAzureStreamFacade.ReturnMainStreamingURLs(tbAssetlName.Text).FirstOrDefault().ToString();
        }

        private void btnStartChannel_Click(object sender, EventArgs e)
        {
            VooAzureStreamFacade.VooAzureStreamFacade.StartChannel(tbChannelName.Text);
        }

        private void btnStartLiveStreaming_Click(object sender, EventArgs e)
        {
            var config = new StartLSAMSConfigParams(tbProgramName.Text, tbStreamingEndpointName.Text);
            VooAzureStreamFacade.VooAzureStreamFacade.StartLiveStreaming(config);
        }

        private void btnStartInfrastructure_Click(object sender, EventArgs e)
        {
            var configParamStartAms = new StartAMSConfigParams(tbChannelName.Text, tbChannelName.Text,
             tbChannelName.Text, tbAssetlName.Text, tbProgramName.Text, tbStreamingEndpointName.Text,
             TimeSpan.FromHours(6));

            VooAzureStreamFacade.VooAzureStreamFacade.Start(configParamStartAms);
        }

       
    }
}

