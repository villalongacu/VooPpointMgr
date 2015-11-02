namespace TestVooAzureMediaService
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnStartLiveStreaming = new System.Windows.Forms.Button();
            this.btnStartChannel = new System.Windows.Forms.Button();
            this.btnGetMainStreamingURL = new System.Windows.Forms.Button();
            this.lbMainStreamingURL = new System.Windows.Forms.Label();
            this.tbMainStreamingURL = new System.Windows.Forms.TextBox();
            this.button3 = new System.Windows.Forms.Button();
            this.btnUpdatePreviewURL = new System.Windows.Forms.Button();
            this.btnUpdateIngestURL = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.tbPreviewURL = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tbIngestURL = new System.Windows.Forms.TextBox();
            this.lbProgramName = new System.Windows.Forms.Label();
            this.tbProgramName = new System.Windows.Forms.TextBox();
            this.lbAssetlName = new System.Windows.Forms.Label();
            this.tbAssetlName = new System.Windows.Forms.TextBox();
            this.lbChannelName = new System.Windows.Forms.Label();
            this.tbChannelName = new System.Windows.Forms.TextBox();
            this.lbStreamingEndpointName = new System.Windows.Forms.Label();
            this.tbStreamingEndpointName = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.btnCreateLiveInfrastructure = new System.Windows.Forms.Button();
            this.btnStartInfrastructure = new System.Windows.Forms.Button();
            this.btnStopInfrastructure = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnStartLiveStreaming
            // 
            this.btnStartLiveStreaming.Location = new System.Drawing.Point(625, 525);
            this.btnStartLiveStreaming.Name = "btnStartLiveStreaming";
            this.btnStartLiveStreaming.Size = new System.Drawing.Size(224, 36);
            this.btnStartLiveStreaming.TabIndex = 43;
            this.btnStartLiveStreaming.Text = "Start Live Streaming";
            this.btnStartLiveStreaming.UseVisualStyleBackColor = true;
            this.btnStartLiveStreaming.Click += new System.EventHandler(this.btnStartLiveStreaming_Click);
            // 
            // btnStartChannel
            // 
            this.btnStartChannel.Location = new System.Drawing.Point(384, 525);
            this.btnStartChannel.Name = "btnStartChannel";
            this.btnStartChannel.Size = new System.Drawing.Size(224, 36);
            this.btnStartChannel.TabIndex = 42;
            this.btnStartChannel.Text = "Allow Streaming Ingest";
            this.btnStartChannel.UseVisualStyleBackColor = true;
            this.btnStartChannel.Click += new System.EventHandler(this.btnStartChannel_Click);
            // 
            // btnGetMainStreamingURL
            // 
            this.btnGetMainStreamingURL.Location = new System.Drawing.Point(774, 452);
            this.btnGetMainStreamingURL.Name = "btnGetMainStreamingURL";
            this.btnGetMainStreamingURL.Size = new System.Drawing.Size(75, 26);
            this.btnGetMainStreamingURL.TabIndex = 41;
            this.btnGetMainStreamingURL.Text = "Update";
            this.btnGetMainStreamingURL.UseVisualStyleBackColor = true;
            this.btnGetMainStreamingURL.Click += new System.EventHandler(this.btnGetMainStreamingURL_Click);
            // 
            // lbMainStreamingURL
            // 
            this.lbMainStreamingURL.AutoSize = true;
            this.lbMainStreamingURL.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbMainStreamingURL.Location = new System.Drawing.Point(115, 414);
            this.lbMainStreamingURL.Name = "lbMainStreamingURL";
            this.lbMainStreamingURL.Size = new System.Drawing.Size(200, 24);
            this.lbMainStreamingURL.TabIndex = 40;
            this.lbMainStreamingURL.Text = "Main Streaming URL";
            // 
            // tbMainStreamingURL
            // 
            this.tbMainStreamingURL.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbMainStreamingURL.Location = new System.Drawing.Point(116, 452);
            this.tbMainStreamingURL.Name = "tbMainStreamingURL";
            this.tbMainStreamingURL.Size = new System.Drawing.Size(634, 26);
            this.tbMainStreamingURL.TabIndex = 39;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(625, 575);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(224, 36);
            this.button3.TabIndex = 38;
            this.button3.Text = "Reset Channel Streaming";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // btnUpdatePreviewURL
            // 
            this.btnUpdatePreviewURL.Location = new System.Drawing.Point(774, 371);
            this.btnUpdatePreviewURL.Name = "btnUpdatePreviewURL";
            this.btnUpdatePreviewURL.Size = new System.Drawing.Size(75, 26);
            this.btnUpdatePreviewURL.TabIndex = 37;
            this.btnUpdatePreviewURL.Text = "Update";
            this.btnUpdatePreviewURL.UseVisualStyleBackColor = true;
            this.btnUpdatePreviewURL.Click += new System.EventHandler(this.btnUpdatePreviewURL_Click);
            // 
            // btnUpdateIngestURL
            // 
            this.btnUpdateIngestURL.Location = new System.Drawing.Point(774, 294);
            this.btnUpdateIngestURL.Name = "btnUpdateIngestURL";
            this.btnUpdateIngestURL.Size = new System.Drawing.Size(75, 26);
            this.btnUpdateIngestURL.TabIndex = 36;
            this.btnUpdateIngestURL.Text = "Update";
            this.btnUpdateIngestURL.UseVisualStyleBackColor = true;
            this.btnUpdateIngestURL.Click += new System.EventHandler(this.btnUpdateIngestURL_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(115, 333);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(129, 24);
            this.label2.TabIndex = 35;
            this.label2.Text = "Preview URL";
            // 
            // tbPreviewURL
            // 
            this.tbPreviewURL.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbPreviewURL.Location = new System.Drawing.Point(116, 371);
            this.tbPreviewURL.Name = "tbPreviewURL";
            this.tbPreviewURL.Size = new System.Drawing.Size(634, 26);
            this.tbPreviewURL.TabIndex = 34;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(115, 256);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(111, 24);
            this.label1.TabIndex = 33;
            this.label1.Text = "Ingest URL";
            // 
            // tbIngestURL
            // 
            this.tbIngestURL.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbIngestURL.Location = new System.Drawing.Point(116, 294);
            this.tbIngestURL.Name = "tbIngestURL";
            this.tbIngestURL.Size = new System.Drawing.Size(634, 26);
            this.tbIngestURL.TabIndex = 32;
            // 
            // lbProgramName
            // 
            this.lbProgramName.AutoSize = true;
            this.lbProgramName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbProgramName.Location = new System.Drawing.Point(529, 110);
            this.lbProgramName.Name = "lbProgramName";
            this.lbProgramName.Size = new System.Drawing.Size(155, 25);
            this.lbProgramName.TabIndex = 31;
            this.lbProgramName.Text = "Program Name";
            // 
            // tbProgramName
            // 
            this.tbProgramName.Location = new System.Drawing.Point(531, 146);
            this.tbProgramName.Name = "tbProgramName";
            this.tbProgramName.Size = new System.Drawing.Size(219, 22);
            this.tbProgramName.TabIndex = 30;
            this.tbProgramName.Text = "program001";
            // 
            // lbAssetlName
            // 
            this.lbAssetlName.AutoSize = true;
            this.lbAssetlName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbAssetlName.Location = new System.Drawing.Point(190, 110);
            this.lbAssetlName.Name = "lbAssetlName";
            this.lbAssetlName.Size = new System.Drawing.Size(129, 25);
            this.lbAssetlName.TabIndex = 29;
            this.lbAssetlName.Text = "Asset Name";
            // 
            // tbAssetlName
            // 
            this.tbAssetlName.Location = new System.Drawing.Point(192, 146);
            this.tbAssetlName.Name = "tbAssetlName";
            this.tbAssetlName.Size = new System.Drawing.Size(219, 22);
            this.tbAssetlName.TabIndex = 28;
            this.tbAssetlName.Text = "asset001";
            // 
            // lbChannelName
            // 
            this.lbChannelName.AutoSize = true;
            this.lbChannelName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbChannelName.Location = new System.Drawing.Point(189, 26);
            this.lbChannelName.Name = "lbChannelName";
            this.lbChannelName.Size = new System.Drawing.Size(155, 25);
            this.lbChannelName.TabIndex = 27;
            this.lbChannelName.Text = "Channel Name";
            // 
            // tbChannelName
            // 
            this.tbChannelName.Location = new System.Drawing.Point(191, 62);
            this.tbChannelName.Name = "tbChannelName";
            this.tbChannelName.Size = new System.Drawing.Size(219, 22);
            this.tbChannelName.TabIndex = 26;
            this.tbChannelName.Text = "channel001";
            // 
            // lbStreamingEndpointName
            // 
            this.lbStreamingEndpointName.AutoSize = true;
            this.lbStreamingEndpointName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbStreamingEndpointName.Location = new System.Drawing.Point(529, 26);
            this.lbStreamingEndpointName.Name = "lbStreamingEndpointName";
            this.lbStreamingEndpointName.Size = new System.Drawing.Size(263, 25);
            this.lbStreamingEndpointName.TabIndex = 25;
            this.lbStreamingEndpointName.Text = "Streaming Endpoint Name";
            // 
            // tbStreamingEndpointName
            // 
            this.tbStreamingEndpointName.Location = new System.Drawing.Point(531, 62);
            this.tbStreamingEndpointName.Name = "tbStreamingEndpointName";
            this.tbStreamingEndpointName.Size = new System.Drawing.Size(219, 22);
            this.tbStreamingEndpointName.TabIndex = 24;
            this.tbStreamingEndpointName.Text = "streamingendpoint001";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(140, 575);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(224, 36);
            this.button2.TabIndex = 23;
            this.button2.Text = "Remove Live Infrastructure";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnCreateLiveInfrastructure
            // 
            this.btnCreateLiveInfrastructure.Location = new System.Drawing.Point(140, 525);
            this.btnCreateLiveInfrastructure.Name = "btnCreateLiveInfrastructure";
            this.btnCreateLiveInfrastructure.Size = new System.Drawing.Size(224, 36);
            this.btnCreateLiveInfrastructure.TabIndex = 22;
            this.btnCreateLiveInfrastructure.Text = "Create Live Infrastructure";
            this.btnCreateLiveInfrastructure.UseVisualStyleBackColor = true;
            this.btnCreateLiveInfrastructure.Click += new System.EventHandler(this.btnCreateLiveInfrastructure_Click);
            // 
            // btnStartInfrastructure
            // 
            this.btnStartInfrastructure.Location = new System.Drawing.Point(186, 187);
            this.btnStartInfrastructure.Name = "btnStartInfrastructure";
            this.btnStartInfrastructure.Size = new System.Drawing.Size(224, 36);
            this.btnStartInfrastructure.TabIndex = 44;
            this.btnStartInfrastructure.Text = "Start Infrastructure";
            this.btnStartInfrastructure.UseVisualStyleBackColor = true;
            this.btnStartInfrastructure.Click += new System.EventHandler(this.btnStartInfrastructure_Click);
            // 
            // btnStopInfrastructure
            // 
            this.btnStopInfrastructure.Location = new System.Drawing.Point(526, 187);
            this.btnStopInfrastructure.Name = "btnStopInfrastructure";
            this.btnStopInfrastructure.Size = new System.Drawing.Size(224, 36);
            this.btnStopInfrastructure.TabIndex = 45;
            this.btnStopInfrastructure.Text = "Stop Infrastructure";
            this.btnStopInfrastructure.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(965, 618);
            this.Controls.Add(this.btnStopInfrastructure);
            this.Controls.Add(this.btnStartInfrastructure);
            this.Controls.Add(this.btnStartLiveStreaming);
            this.Controls.Add(this.btnStartChannel);
            this.Controls.Add(this.btnGetMainStreamingURL);
            this.Controls.Add(this.lbMainStreamingURL);
            this.Controls.Add(this.tbMainStreamingURL);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.btnUpdatePreviewURL);
            this.Controls.Add(this.btnUpdateIngestURL);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbPreviewURL);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbIngestURL);
            this.Controls.Add(this.lbProgramName);
            this.Controls.Add(this.tbProgramName);
            this.Controls.Add(this.lbAssetlName);
            this.Controls.Add(this.tbAssetlName);
            this.Controls.Add(this.lbChannelName);
            this.Controls.Add(this.tbChannelName);
            this.Controls.Add(this.lbStreamingEndpointName);
            this.Controls.Add(this.tbStreamingEndpointName);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.btnCreateLiveInfrastructure);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnStartLiveStreaming;
        private System.Windows.Forms.Button btnStartChannel;
        private System.Windows.Forms.Button btnGetMainStreamingURL;
        private System.Windows.Forms.Label lbMainStreamingURL;
        private System.Windows.Forms.TextBox tbMainStreamingURL;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button btnUpdatePreviewURL;
        private System.Windows.Forms.Button btnUpdateIngestURL;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbPreviewURL;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbIngestURL;
        private System.Windows.Forms.Label lbProgramName;
        private System.Windows.Forms.TextBox tbProgramName;
        private System.Windows.Forms.Label lbAssetlName;
        private System.Windows.Forms.TextBox tbAssetlName;
        private System.Windows.Forms.Label lbChannelName;
        private System.Windows.Forms.TextBox tbChannelName;
        private System.Windows.Forms.Label lbStreamingEndpointName;
        private System.Windows.Forms.TextBox tbStreamingEndpointName;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button btnCreateLiveInfrastructure;
        private System.Windows.Forms.Button btnStartInfrastructure;
        private System.Windows.Forms.Button btnStopInfrastructure;
    }
}

