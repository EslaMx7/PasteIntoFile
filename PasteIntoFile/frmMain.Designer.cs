namespace PasteAsFile
{
    partial class frmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.lblType = new System.Windows.Forms.Label();
            this.imgContent = new System.Windows.Forms.PictureBox();
            this.txtContent = new System.Windows.Forms.TextBox();
            this.lblFileName = new System.Windows.Forms.Label();
            this.txtFilename = new System.Windows.Forms.TextBox();
            this.lblExt = new System.Windows.Forms.Label();
            this.comExt = new System.Windows.Forms.ComboBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.txtCurrentLocation = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnBrowseForFolder = new System.Windows.Forms.Button();
            this.lblMe = new System.Windows.Forms.Label();
            this.lblWebsite = new System.Windows.Forms.Label();
            this.lblHelp = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.imgContent)).BeginInit();
            this.SuspendLayout();
            // 
            // lblType
            // 
            this.lblType.AutoSize = true;
            this.lblType.Location = new System.Drawing.Point(13, 104);
            this.lblType.Name = "lblType";
            this.lblType.Size = new System.Drawing.Size(31, 13);
            this.lblType.TabIndex = 6;
            this.lblType.Text = "Type";
            // 
            // imgContent
            // 
            this.imgContent.Location = new System.Drawing.Point(206, 236);
            this.imgContent.Name = "imgContent";
            this.imgContent.Size = new System.Drawing.Size(121, 81);
            this.imgContent.TabIndex = 2;
            this.imgContent.TabStop = false;
            // 
            // txtContent
            // 
            this.txtContent.Location = new System.Drawing.Point(12, 236);
            this.txtContent.Multiline = true;
            this.txtContent.Name = "txtContent";
            this.txtContent.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtContent.Size = new System.Drawing.Size(188, 116);
            this.txtContent.TabIndex = 3;
            // 
            // lblFileName
            // 
            this.lblFileName.AutoSize = true;
            this.lblFileName.Location = new System.Drawing.Point(13, 13);
            this.lblFileName.Name = "lblFileName";
            this.lblFileName.Size = new System.Drawing.Size(55, 13);
            this.lblFileName.TabIndex = 4;
            this.lblFileName.Text = "Filename :";
            // 
            // txtFilename
            // 
            this.txtFilename.Location = new System.Drawing.Point(16, 30);
            this.txtFilename.Name = "txtFilename";
            this.txtFilename.Size = new System.Drawing.Size(184, 20);
            this.txtFilename.TabIndex = 1;
            // 
            // lblExt
            // 
            this.lblExt.AutoSize = true;
            this.lblExt.Location = new System.Drawing.Point(234, 13);
            this.lblExt.Name = "lblExt";
            this.lblExt.Size = new System.Drawing.Size(59, 13);
            this.lblExt.TabIndex = 6;
            this.lblExt.Text = "Extension :";
            // 
            // comExt
            // 
            this.comExt.FormattingEnabled = true;
            this.comExt.Items.AddRange(new object[] {
            "txt",
            "html",
            "js",
            "css",
            "csv",
            "json",
            "cs",
            "cpp",
            "java",
            "php",
            "png",
            "jpg",
            "bmp",
            "gif",
            "ico"});
            this.comExt.Location = new System.Drawing.Point(237, 30);
            this.comExt.Name = "comExt";
            this.comExt.Size = new System.Drawing.Size(73, 21);
            this.comExt.TabIndex = 2;
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.btnSave.Location = new System.Drawing.Point(108, 95);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(135, 30);
            this.btnSave.TabIndex = 5;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtCurrentLocation
            // 
            this.txtCurrentLocation.Location = new System.Drawing.Point(16, 72);
            this.txtCurrentLocation.Name = "txtCurrentLocation";
            this.txtCurrentLocation.Size = new System.Drawing.Size(255, 20);
            this.txtCurrentLocation.TabIndex = 3;
            this.txtCurrentLocation.Text = "D:\\";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Current Location :";
            // 
            // btnBrowseForFolder
            // 
            this.btnBrowseForFolder.Location = new System.Drawing.Point(277, 70);
            this.btnBrowseForFolder.Name = "btnBrowseForFolder";
            this.btnBrowseForFolder.Size = new System.Drawing.Size(33, 23);
            this.btnBrowseForFolder.TabIndex = 4;
            this.btnBrowseForFolder.Text = "...";
            this.btnBrowseForFolder.UseVisualStyleBackColor = true;
            this.btnBrowseForFolder.Click += new System.EventHandler(this.btnBrowseForFolder_Click);
            // 
            // lblMe
            // 
            this.lblMe.AutoSize = true;
            this.lblMe.ForeColor = System.Drawing.Color.Gray;
            this.lblMe.Location = new System.Drawing.Point(200, 134);
            this.lblMe.Name = "lblMe";
            this.lblMe.Size = new System.Drawing.Size(123, 13);
            this.lblMe.TabIndex = 12;
            this.lblMe.Text = "© Eslam Hamouda 2014";
            this.lblMe.Click += new System.EventHandler(this.lblMe_Click);
            // 
            // lblWebsite
            // 
            this.lblWebsite.AutoSize = true;
            this.lblWebsite.ForeColor = System.Drawing.Color.Gray;
            this.lblWebsite.Location = new System.Drawing.Point(12, 134);
            this.lblWebsite.Name = "lblWebsite";
            this.lblWebsite.Size = new System.Drawing.Size(62, 13);
            this.lblWebsite.TabIndex = 13;
            this.lblWebsite.Text = "eslamx.com";
            this.lblWebsite.Click += new System.EventHandler(this.lblWebsite_Click);
            // 
            // lblHelp
            // 
            this.lblHelp.AutoSize = true;
            this.lblHelp.Cursor = System.Windows.Forms.Cursors.Help;
            this.lblHelp.Font = new System.Drawing.Font("Tahoma", 10F);
            this.lblHelp.Location = new System.Drawing.Point(295, 102);
            this.lblHelp.Name = "lblHelp";
            this.lblHelp.Size = new System.Drawing.Size(15, 17);
            this.lblHelp.TabIndex = 8;
            this.lblHelp.Text = "?";
            this.lblHelp.Click += new System.EventHandler(this.lblHelp_Click);
            // 
            // frmMain
            // 
            this.AcceptButton = this.btnSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(334, 156);
            this.Controls.Add(this.lblHelp);
            this.Controls.Add(this.lblWebsite);
            this.Controls.Add(this.lblMe);
            this.Controls.Add(this.btnBrowseForFolder);
            this.Controls.Add(this.txtCurrentLocation);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.comExt);
            this.Controls.Add(this.lblExt);
            this.Controls.Add(this.txtFilename);
            this.Controls.Add(this.lblFileName);
            this.Controls.Add(this.txtContent);
            this.Controls.Add(this.imgContent);
            this.Controls.Add(this.lblType);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Paste Into File";
            this.Load += new System.EventHandler(this.frmMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.imgContent)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblType;
        private System.Windows.Forms.PictureBox imgContent;
        private System.Windows.Forms.TextBox txtContent;
        private System.Windows.Forms.Label lblFileName;
        private System.Windows.Forms.TextBox txtFilename;
        private System.Windows.Forms.Label lblExt;
        private System.Windows.Forms.ComboBox comExt;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox txtCurrentLocation;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnBrowseForFolder;
        private System.Windows.Forms.Label lblMe;
        private System.Windows.Forms.Label lblWebsite;
        private System.Windows.Forms.Label lblHelp;
    }
}

