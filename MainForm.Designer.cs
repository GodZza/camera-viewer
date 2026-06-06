namespace CameraInfo
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.topPanel = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.devicesCombo = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.resolutionsCombo = new System.Windows.Forms.ComboBox();
            this.connectButton = new System.Windows.Forms.Button();
            this.disconnectButton = new System.Windows.Forms.Button();
            this.switchResolutionButton = new System.Windows.Forms.Button();
            this.propertyPageButton = new System.Windows.Forms.Button();
            this.fpsLabel = new System.Windows.Forms.Label();
            this.statusLabel = new System.Windows.Forms.Label();
            this.mainSplit = new System.Windows.Forms.SplitContainer();
            this.leftSplit = new System.Windows.Forms.SplitContainer();
            this.capabilitiesListView = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader5 = new System.Windows.Forms.ColumnHeader();
            this.infoTextBox = new System.Windows.Forms.TextBox();
            this.previewPanel = new System.Windows.Forms.Panel();
            this.videoSourcePlayer = new AForge.Controls.VideoSourcePlayer();
            this.fpsTimer = new System.Windows.Forms.Timer(this.components);
            this.refreshButton = new System.Windows.Forms.Button();
            this.showGridCheckBox = new System.Windows.Forms.CheckBox();
            this.topPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mainSplit)).BeginInit();
            this.mainSplit.Panel1.SuspendLayout();
            this.mainSplit.Panel2.SuspendLayout();
            this.mainSplit.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.leftSplit)).BeginInit();
            this.leftSplit.Panel1.SuspendLayout();
            this.leftSplit.Panel2.SuspendLayout();
            this.leftSplit.SuspendLayout();
            this.previewPanel.SuspendLayout();
            this.SuspendLayout();
            //
            // topPanel
            //
            this.topPanel.Controls.Add(this.showGridCheckBox);
            this.topPanel.Controls.Add(this.refreshButton);
            this.topPanel.Controls.Add(this.statusLabel);
            this.topPanel.Controls.Add(this.fpsLabel);
            this.topPanel.Controls.Add(this.propertyPageButton);
            this.topPanel.Controls.Add(this.switchResolutionButton);
            this.topPanel.Controls.Add(this.disconnectButton);
            this.topPanel.Controls.Add(this.connectButton);
            this.topPanel.Controls.Add(this.resolutionsCombo);
            this.topPanel.Controls.Add(this.label2);
            this.topPanel.Controls.Add(this.devicesCombo);
            this.topPanel.Controls.Add(this.label1);
            this.topPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.topPanel.Location = new System.Drawing.Point(0, 0);
            this.topPanel.Name = "topPanel";
            this.topPanel.Size = new System.Drawing.Size(984, 75);
            this.topPanel.TabIndex = 0;
            //
            // label1
            //
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "Device:";
            //
            // devicesCombo
            //
            this.devicesCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.devicesCombo.FormattingEnabled = true;
            this.devicesCombo.Location = new System.Drawing.Point(83, 10);
            this.devicesCombo.Name = "devicesCombo";
            this.devicesCombo.Size = new System.Drawing.Size(280, 20);
            this.devicesCombo.TabIndex = 1;
            this.devicesCombo.SelectedIndexChanged += new System.EventHandler(this.devicesCombo_SelectedIndexChanged);
            //
            // label2
            //
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "Resolution:";
            //
            // resolutionsCombo
            //
            this.resolutionsCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.resolutionsCombo.FormattingEnabled = true;
            this.resolutionsCombo.Location = new System.Drawing.Point(83, 40);
            this.resolutionsCombo.Name = "resolutionsCombo";
            this.resolutionsCombo.Size = new System.Drawing.Size(280, 20);
            this.resolutionsCombo.TabIndex = 3;
            //
            // connectButton
            //
            this.connectButton.Location = new System.Drawing.Point(380, 8);
            this.connectButton.Name = "connectButton";
            this.connectButton.Size = new System.Drawing.Size(75, 25);
            this.connectButton.TabIndex = 4;
            this.connectButton.Text = "Connect";
            this.connectButton.UseVisualStyleBackColor = true;
            this.connectButton.Click += new System.EventHandler(this.connectButton_Click);
            //
            // disconnectButton
            //
            this.disconnectButton.Location = new System.Drawing.Point(460, 8);
            this.disconnectButton.Name = "disconnectButton";
            this.disconnectButton.Size = new System.Drawing.Size(75, 25);
            this.disconnectButton.TabIndex = 5;
            this.disconnectButton.Text = "Disconnect";
            this.disconnectButton.UseVisualStyleBackColor = true;
            this.disconnectButton.Click += new System.EventHandler(this.disconnectButton_Click);
            //
            // switchResolutionButton
            //
            this.switchResolutionButton.Location = new System.Drawing.Point(380, 38);
            this.switchResolutionButton.Name = "switchResolutionButton";
            this.switchResolutionButton.Size = new System.Drawing.Size(120, 25);
            this.switchResolutionButton.TabIndex = 6;
            this.switchResolutionButton.Text = "Switch Resolution";
            this.switchResolutionButton.UseVisualStyleBackColor = true;
            this.switchResolutionButton.Click += new System.EventHandler(this.switchResolutionButton_Click);
            //
            // propertyPageButton
            //
            this.propertyPageButton.Location = new System.Drawing.Point(505, 38);
            this.propertyPageButton.Name = "propertyPageButton";
            this.propertyPageButton.Size = new System.Drawing.Size(75, 25);
            this.propertyPageButton.TabIndex = 7;
            this.propertyPageButton.Text = "Properties";
            this.propertyPageButton.UseVisualStyleBackColor = true;
            this.propertyPageButton.Click += new System.EventHandler(this.propertyPageButton_Click);
            //
            // fpsLabel
            //
            this.fpsLabel.AutoSize = true;
            this.fpsLabel.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Bold);
            this.fpsLabel.ForeColor = System.Drawing.Color.Green;
            this.fpsLabel.Location = new System.Drawing.Point(600, 14);
            this.fpsLabel.Name = "fpsLabel";
            this.fpsLabel.Size = new System.Drawing.Size(0, 15);
            this.fpsLabel.TabIndex = 8;
            //
            // statusLabel
            //
            this.statusLabel.AutoSize = true;
            this.statusLabel.Location = new System.Drawing.Point(600, 44);
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(0, 12);
            this.statusLabel.TabIndex = 9;
            //
            // mainSplit
            //
            this.mainSplit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainSplit.Location = new System.Drawing.Point(0, 75);
            this.mainSplit.Name = "mainSplit";
            //
            // mainSplit.Panel1
            //
            this.mainSplit.Panel1.Controls.Add(this.leftSplit);
            this.mainSplit.Panel1MinSize = 300;
            //
            // mainSplit.Panel2
            //
            this.mainSplit.Panel2.Controls.Add(this.previewPanel);
            this.mainSplit.Panel2MinSize = 200;
            this.mainSplit.Size = new System.Drawing.Size(984, 486);
            this.mainSplit.SplitterDistance = 500;
            this.mainSplit.TabIndex = 1;
            //
            // leftSplit
            //
            this.leftSplit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.leftSplit.Location = new System.Drawing.Point(0, 0);
            this.leftSplit.Name = "leftSplit";
            this.leftSplit.Orientation = System.Windows.Forms.Orientation.Horizontal;
            //
            // leftSplit.Panel1
            //
            this.leftSplit.Panel1.Controls.Add(this.capabilitiesListView);
            this.leftSplit.Panel1MinSize = 100;
            //
            // leftSplit.Panel2
            //
            this.leftSplit.Panel2.Controls.Add(this.infoTextBox);
            this.leftSplit.Panel2MinSize = 100;
            this.leftSplit.Size = new System.Drawing.Size(500, 486);
            this.leftSplit.SplitterDistance = 250;
            this.leftSplit.TabIndex = 0;
            //
            // capabilitiesListView
            //
            this.capabilitiesListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5});
            this.capabilitiesListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.capabilitiesListView.FullRowSelect = true;
            this.capabilitiesListView.GridLines = true;
            this.capabilitiesListView.HideSelection = false;
            this.capabilitiesListView.Location = new System.Drawing.Point(0, 0);
            this.capabilitiesListView.MultiSelect = false;
            this.capabilitiesListView.Name = "capabilitiesListView";
            this.capabilitiesListView.Size = new System.Drawing.Size(500, 250);
            this.capabilitiesListView.TabIndex = 0;
            this.capabilitiesListView.UseCompatibleStateImageBehavior = false;
            this.capabilitiesListView.View = System.Windows.Forms.View.Details;
            this.capabilitiesListView.SelectedIndexChanged += new System.EventHandler(this.capabilitiesListView_SelectedIndexChanged);
            //
            // columnHeader1
            //
            this.columnHeader1.Text = "Width";
            this.columnHeader1.Width = 60;
            //
            // columnHeader2
            //
            this.columnHeader2.Text = "Height";
            this.columnHeader2.Width = 60;
            //
            // columnHeader3
            //
            this.columnHeader3.Text = "BitCount";
            this.columnHeader3.Width = 60;
            //
            // columnHeader4
            //
            this.columnHeader4.Text = "AvgFPS";
            this.columnHeader4.Width = 60;
            //
            // columnHeader5
            //
            this.columnHeader5.Text = "MaxFPS";
            this.columnHeader5.Width = 60;
            //
            // infoTextBox
            //
            this.infoTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.infoTextBox.Font = new System.Drawing.Font("Consolas", 9F);
            this.infoTextBox.Location = new System.Drawing.Point(0, 0);
            this.infoTextBox.Multiline = true;
            this.infoTextBox.Name = "infoTextBox";
            this.infoTextBox.ReadOnly = true;
            this.infoTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.infoTextBox.Size = new System.Drawing.Size(500, 232);
            this.infoTextBox.TabIndex = 0;
            this.infoTextBox.WordWrap = false;
            //
            // previewPanel
            //
            this.previewPanel.AutoScroll = true;
            this.previewPanel.BackColor = System.Drawing.SystemColors.ControlDark;
            this.previewPanel.Controls.Add(this.videoSourcePlayer);
            this.previewPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.previewPanel.Location = new System.Drawing.Point(0, 0);
            this.previewPanel.Name = "previewPanel";
            this.previewPanel.Size = new System.Drawing.Size(478, 486);
            this.previewPanel.TabIndex = 0;
            this.previewPanel.Resize += new System.EventHandler(this.previewPanel_Resize);
            //
            // videoSourcePlayer
            //
            this.videoSourcePlayer.AutoSizeControl = true;
            this.videoSourcePlayer.BackColor = System.Drawing.SystemColors.ControlDark;
            this.videoSourcePlayer.ForeColor = System.Drawing.Color.DarkRed;
            this.videoSourcePlayer.Location = new System.Drawing.Point(0, 0);
            this.videoSourcePlayer.Name = "videoSourcePlayer";
            this.videoSourcePlayer.Size = new System.Drawing.Size(320, 240);
            this.videoSourcePlayer.TabIndex = 0;
            this.videoSourcePlayer.VideoSource = null;
            //
            // refreshButton
            //
            this.refreshButton.Location = new System.Drawing.Point(540, 8);
            this.refreshButton.Name = "refreshButton";
            this.refreshButton.Size = new System.Drawing.Size(75, 25);
            this.refreshButton.TabIndex = 10;
            this.refreshButton.Text = "Refresh";
            this.refreshButton.UseVisualStyleBackColor = true;
            this.refreshButton.Click += new System.EventHandler(this.refreshButton_Click);
            //
            // showGridCheckBox
            //
            this.showGridCheckBox.AutoSize = true;
            this.showGridCheckBox.Location = new System.Drawing.Point(600, 44);
            this.showGridCheckBox.Name = "showGridCheckBox";
            this.showGridCheckBox.Size = new System.Drawing.Size(72, 16);
            this.showGridCheckBox.TabIndex = 11;
            this.showGridCheckBox.Text = "显示网格";
            this.showGridCheckBox.UseVisualStyleBackColor = true;
            //
            // fpsTimer
            //
            this.fpsTimer.Interval = 1000;
            this.fpsTimer.Tick += new System.EventHandler(this.fpsTimer_Tick);
            //
            // MainForm
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 561);
            this.Controls.Add(this.mainSplit);
            this.Controls.Add(this.topPanel);
            this.MinimumSize = new System.Drawing.Size(800, 400);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Camera Info - Device Capabilities Viewer";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.topPanel.ResumeLayout(false);
            this.topPanel.PerformLayout();
            this.mainSplit.Panel1.ResumeLayout(false);
            this.mainSplit.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.mainSplit)).EndInit();
            this.mainSplit.ResumeLayout(false);
            this.leftSplit.Panel1.ResumeLayout(false);
            this.leftSplit.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.leftSplit)).EndInit();
            this.leftSplit.ResumeLayout(false);
            this.previewPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel topPanel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox devicesCombo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox resolutionsCombo;
        private System.Windows.Forms.Button connectButton;
        private System.Windows.Forms.Button disconnectButton;
        private System.Windows.Forms.Button switchResolutionButton;
        private System.Windows.Forms.Button propertyPageButton;
        private System.Windows.Forms.Label fpsLabel;
        private System.Windows.Forms.Label statusLabel;
        private System.Windows.Forms.SplitContainer mainSplit;
        private System.Windows.Forms.SplitContainer leftSplit;
        private System.Windows.Forms.ListView capabilitiesListView;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.TextBox infoTextBox;
        private System.Windows.Forms.Panel previewPanel;
        private AForge.Controls.VideoSourcePlayer videoSourcePlayer;
        private System.Windows.Forms.Timer fpsTimer;
        private System.Windows.Forms.Button refreshButton;
        private System.Windows.Forms.CheckBox showGridCheckBox;
    }
}
