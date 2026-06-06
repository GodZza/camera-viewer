using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

using AForge.Video;
using AForge.Video.DirectShow;

namespace CameraInfo
{
    public partial class MainForm : Form
    {
        private const int WM_DEVICECHANGE = 0x0219;
        private const int DBT_DEVICEARRIVAL = 0x8000;
        private const int DBT_DEVICEREMOVECOMPLETE = 0x8004;

        private FilterInfoCollection videoDevices;
        private VideoCaptureDevice videoDevice;
        private VideoCapabilities[] videoCapabilities;
        private VideoCapabilities[] snapshotCapabilities;
        private Stopwatch stopWatch = null;
        private bool isRefreshingDevices = false;

        public MainForm()
        {
            Console.WriteLine("[MainForm] InitializeComponent start...");
            InitializeComponent();
            Console.WriteLine("[MainForm] InitializeComponent done.");
        }

        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);

            if (m.Msg == WM_DEVICECHANGE)
            {
                int eventType = m.WParam.ToInt32();
                if (eventType == DBT_DEVICEARRIVAL || eventType == DBT_DEVICEREMOVECOMPLETE)
                {
                    Console.WriteLine("[WndProc] Device change detected: {0}",
                        eventType == DBT_DEVICEARRIVAL ? "ARRIVAL" : "REMOVE");

                    BeginInvoke(new Action(() =>
                    {
                        RefreshDeviceList();
                    }));
                }
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            RefreshDeviceList();
            UpdateConnectionControls(true);
            Console.WriteLine("[MainForm_Load] Done.");
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Disconnect();
        }

        private void refreshButton_Click(object sender, EventArgs e)
        {
            RefreshDeviceList();
        }

        private void RefreshDeviceList()
        {
            if (isRefreshingDevices)
                return;

            isRefreshingDevices = true;
            string previouslySelected = (devicesCombo.SelectedItem != null) ? devicesCombo.SelectedItem.ToString() : null;

            try
            {
                videoDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);
                Console.WriteLine("[RefreshDevices] Found {0} device(s).", videoDevices.Count);

                devicesCombo.Items.Clear();

                if (videoDevices.Count != 0)
                {
                    foreach (FilterInfo device in videoDevices)
                    {
                        Console.WriteLine("[RefreshDevices]   Device: {0}", device.Name);
                        devicesCombo.Items.Add(device.Name);
                    }

                    int selectIndex = 0;
                    if (previouslySelected != null)
                    {
                        for (int i = 0; i < devicesCombo.Items.Count; i++)
                        {
                            if (devicesCombo.Items[i].ToString() == previouslySelected)
                            {
                                selectIndex = i;
                                break;
                            }
                        }
                    }
                    devicesCombo.SelectedIndex = selectIndex;

                    isRefreshingDevices = false;

                    videoDevice = new VideoCaptureDevice(videoDevices[devicesCombo.SelectedIndex].MonikerString);
                    EnumerateSupportedFrameSizes(videoDevice);
                }
                else
                {
                    devicesCombo.Items.Add("No DirectShow devices found");
                    devicesCombo.SelectedIndex = 0;

                    videoDevice = null;
                    videoCapabilities = new VideoCapabilities[0];
                    snapshotCapabilities = new VideoCapabilities[0];
                    resolutionsCombo.Items.Clear();
                    capabilitiesListView.Items.Clear();
                    infoTextBox.Clear();
                }

                statusLabel.Text = string.Format("Devices: {0}", videoDevices.Count);
            }
            catch (Exception ex)
            {
                Console.WriteLine("[RefreshDevices] ERROR: {0}", ex);
            }
            finally
            {
                isRefreshingDevices = false;
            }
        }

        private void devicesCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (isRefreshingDevices)
                return;

            if (videoDevices == null || videoDevices.Count == 0)
                return;

            try
            {
                Console.WriteLine("[DeviceChanged] Selected index: {0}", devicesCombo.SelectedIndex);
                videoDevice = new VideoCaptureDevice(videoDevices[devicesCombo.SelectedIndex].MonikerString);
                EnumerateSupportedFrameSizes(videoDevice);
            }
            catch (Exception ex)
            {
                Console.WriteLine("[DeviceChanged] ERROR: {0}", ex);
                MessageBox.Show("Failed to enumerate device capabilities:\n" + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void EnumerateSupportedFrameSizes(VideoCaptureDevice device)
        {
            Cursor = Cursors.WaitCursor;
            Console.WriteLine("[Enumerate] Getting capabilities...");

            resolutionsCombo.Items.Clear();
            capabilitiesListView.Items.Clear();

            try
            {
                videoCapabilities = device.VideoCapabilities;
                snapshotCapabilities = device.SnapshotCapabilities;
                Console.WriteLine("[Enumerate] Video caps: {0}, Snapshot caps: {1}",
                    videoCapabilities.Length, snapshotCapabilities.Length);

                foreach (VideoCapabilities cap in videoCapabilities)
                {
                    string item = string.Format("{0} x {1}  [{2}bpp]  AvgFPS:{3}  MaxFPS:{4}",
                        cap.FrameSize.Width, cap.FrameSize.Height,
                        cap.BitCount, cap.AverageFrameRate, cap.MaximumFrameRate);

                    Console.WriteLine("[Enumerate]   {0}", item);
                    resolutionsCombo.Items.Add(item);

                    ListViewItem lvi = new ListViewItem(cap.FrameSize.Width.ToString());
                    lvi.SubItems.Add(cap.FrameSize.Height.ToString());
                    lvi.SubItems.Add(cap.BitCount.ToString());
                    lvi.SubItems.Add(cap.AverageFrameRate.ToString());
                    lvi.SubItems.Add(cap.MaximumFrameRate.ToString());
                    lvi.Tag = cap;
                    capabilitiesListView.Items.Add(lvi);
                }

                if (videoCapabilities.Length == 0)
                {
                    resolutionsCombo.Items.Add("Not supported");
                }

                if (resolutionsCombo.Items.Count > 0)
                {
                    resolutionsCombo.SelectedIndex = 0;
                }

                UpdateDeviceInfo();
            }
            catch (Exception ex)
            {
                Console.WriteLine("[Enumerate] ERROR: {0}", ex);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private void UpdateDeviceInfo()
        {
            infoTextBox.Clear();

            if (videoDevice == null || videoDevices == null || videoDevices.Count == 0)
                return;

            try
            {
                infoTextBox.AppendText(string.Format("Device: {0}\r\n", devicesCombo.SelectedItem));
                infoTextBox.AppendText(string.Format("Moniker: {0}\r\n\r\n", videoDevice.Source));

                infoTextBox.AppendText(string.Format("Video Capabilities: {0}\r\n", videoCapabilities.Length));
                int idx = 1;
                foreach (VideoCapabilities cap in videoCapabilities)
                {
                    infoTextBox.AppendText(string.Format("  [{0}] {1} x {2}, {3}bpp, AvgFPS={4}, MaxFPS={5}\r\n",
                        idx, cap.FrameSize.Width, cap.FrameSize.Height,
                        cap.BitCount, cap.AverageFrameRate, cap.MaximumFrameRate));
                    idx++;
                }

                infoTextBox.AppendText(string.Format("\r\nSnapshot Capabilities: {0}\r\n", snapshotCapabilities.Length));
                idx = 1;
                foreach (VideoCapabilities cap in snapshotCapabilities)
                {
                    infoTextBox.AppendText(string.Format("  [{0}] {1} x {2}, {3}bpp, AvgFPS={4}, MaxFPS={5}\r\n",
                        idx, cap.FrameSize.Width, cap.FrameSize.Height,
                        cap.BitCount, cap.AverageFrameRate, cap.MaximumFrameRate));
                    idx++;
                }

                VideoInput[] inputs = videoDevice.AvailableCrossbarVideoInputs;
                infoTextBox.AppendText(string.Format("\r\nCrossbar Video Inputs: {0}\r\n", inputs.Length));
                foreach (VideoInput input in inputs)
                {
                    infoTextBox.AppendText(string.Format("  Index={0}, Type={1}\r\n", input.Index, input.Type));
                }

                bool crossbarAvailable = videoDevice.CheckIfCrossbarAvailable();
                infoTextBox.AppendText(string.Format("\r\nCrossbar Available: {0}\r\n", crossbarAvailable));
            }
            catch (Exception ex)
            {
                Console.WriteLine("[DeviceInfo] ERROR: {0}", ex);
                infoTextBox.AppendText("\r\nError getting device info: " + ex.Message);
            }
        }

        private void connectButton_Click(object sender, EventArgs e)
        {
            Connect();
        }

        private void disconnectButton_Click(object sender, EventArgs e)
        {
            Disconnect();
        }

        private void Connect()
        {
            if (videoDevice == null)
                return;

            try
            {
                Console.WriteLine("[Connect] Setting resolution index: {0}", resolutionsCombo.SelectedIndex);

                if (videoCapabilities != null && videoCapabilities.Length != 0 && resolutionsCombo.SelectedIndex >= 0)
                {
                    videoDevice.VideoResolution = videoCapabilities[resolutionsCombo.SelectedIndex];
                    Console.WriteLine("[Connect] Resolution set: {0} x {1}",
                        videoCapabilities[resolutionsCombo.SelectedIndex].FrameSize.Width,
                        videoCapabilities[resolutionsCombo.SelectedIndex].FrameSize.Height);
                }

                videoDevice.NewFrame += new NewFrameEventHandler(videoDevice_NewFrame);

                UpdateConnectionControls(false);

                videoSourcePlayer.VideoSource = videoDevice;
                videoSourcePlayer.Start();

                firstFrameCentered = false;
                stopWatch = null;
                fpsTimer.Start();

                Console.WriteLine("[Connect] Started.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("[Connect] ERROR: {0}", ex);
                MessageBox.Show("Failed to connect:\n" + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                UpdateConnectionControls(true);
            }
        }

        private void Disconnect()
        {
            Console.WriteLine("[Disconnect] Stopping...");
            fpsTimer.Stop();
            fpsLabel.Text = string.Empty;

            if (videoSourcePlayer.VideoSource != null)
            {
                videoSourcePlayer.SignalToStop();
                videoSourcePlayer.WaitForStop();
                videoSourcePlayer.VideoSource = null;

                if (videoDevice != null)
                {
                    videoDevice.NewFrame -= new NewFrameEventHandler(videoDevice_NewFrame);
                }

                UpdateConnectionControls(true);
            }

            Console.WriteLine("[Disconnect] Done.");
        }

        private bool firstFrameCentered = false;

        private void videoDevice_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            if (!firstFrameCentered)
            {
                firstFrameCentered = true;
                BeginInvoke(new Action(() => { CenterVideoPlayer(); }));
            }

            // 在帧上绘制十字线
            if (showGridCheckBox.Checked)
            {
                Bitmap image = eventArgs.Frame;
                int w = image.Width;
                int h = image.Height;

                using (Graphics g = Graphics.FromImage(image))
                {
                    // 红色线 - 中心 (1/2)
                    using (Pen redPen = new Pen(Color.Red, 1))
                    {
                        g.DrawLine(redPen, w / 2, 0, w / 2, h);       // 垂直线
                        g.DrawLine(redPen, 0, h / 2, w, h / 2);       // 水平线
                    }

                    // 绿色线 - 1/4 和 3/4
                    using (Pen greenPen = new Pen(Color.Green, 1))
                    {
                        g.DrawLine(greenPen, w / 4, 0, w / 4, h);     // 垂直线 1/4
                        g.DrawLine(greenPen, w * 3 / 4, 0, w * 3 / 4, h); // 垂直线 3/4
                        g.DrawLine(greenPen, 0, h / 4, w, h / 4);     // 水平线 1/4
                        g.DrawLine(greenPen, 0, h * 3 / 4, w, h * 3 / 4); // 水平线 3/4
                    }
                }
            }
        }

        private void previewPanel_Resize(object sender, EventArgs e)
        {
            CenterVideoPlayer();
        }

        private void CenterVideoPlayer()
        {
            if (previewPanel == null || videoSourcePlayer == null)
                return;

            int pw = previewPanel.ClientSize.Width;
            int ph = previewPanel.ClientSize.Height;
            int vw = videoSourcePlayer.Width;
            int vh = videoSourcePlayer.Height;

            int x = (pw - vw) / 2;
            int y = (ph - vh) / 2;

            if (x < 0) x = 0;
            if (y < 0) y = 0;

            videoSourcePlayer.Location = new System.Drawing.Point(x, y);
        }

        private void switchResolutionButton_Click(object sender, EventArgs e)
        {
            if (videoSourcePlayer.VideoSource == null || videoDevice == null)
                return;

            if (videoCapabilities == null || videoCapabilities.Length == 0 || resolutionsCombo.SelectedIndex < 0)
                return;

            try
            {
                Console.WriteLine("[SwitchRes] Switching to index: {0}", resolutionsCombo.SelectedIndex);

                videoSourcePlayer.SignalToStop();
                videoSourcePlayer.WaitForStop();
                videoSourcePlayer.VideoSource = null;
                videoDevice.NewFrame -= new NewFrameEventHandler(videoDevice_NewFrame);

                videoDevice = new VideoCaptureDevice(videoDevices[devicesCombo.SelectedIndex].MonikerString);
                videoCapabilities = videoDevice.VideoCapabilities;
                snapshotCapabilities = videoDevice.SnapshotCapabilities;

                videoDevice.VideoResolution = videoCapabilities[resolutionsCombo.SelectedIndex];

                videoDevice.NewFrame += new NewFrameEventHandler(videoDevice_NewFrame);

                videoSourcePlayer.VideoSource = videoDevice;
                videoSourcePlayer.Start();

                firstFrameCentered = false;
                stopWatch = null;
                fpsTimer.Start();

                statusLabel.Text = string.Format("Switched to: {0} x {1}",
                    videoCapabilities[resolutionsCombo.SelectedIndex].FrameSize.Width,
                    videoCapabilities[resolutionsCombo.SelectedIndex].FrameSize.Height);

                Console.WriteLine("[SwitchRes] Done: {0} x {1}",
                    videoCapabilities[resolutionsCombo.SelectedIndex].FrameSize.Width,
                    videoCapabilities[resolutionsCombo.SelectedIndex].FrameSize.Height);
            }
            catch (Exception ex)
            {
                Console.WriteLine("[SwitchRes] ERROR: {0}", ex);
                MessageBox.Show("Failed to switch resolution:\n" + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void fpsTimer_Tick(object sender, EventArgs e)
        {
            IVideoSource videoSource = videoSourcePlayer.VideoSource;

            if (videoSource != null)
            {
                int framesReceived = videoSource.FramesReceived;

                if (stopWatch == null)
                {
                    stopWatch = new Stopwatch();
                    stopWatch.Start();
                }
                else
                {
                    stopWatch.Stop();
                    if (stopWatch.ElapsedMilliseconds > 0)
                    {
                        float fps = 1000.0f * framesReceived / stopWatch.ElapsedMilliseconds;
                        fpsLabel.Text = string.Format("FPS: {0:F1}", fps);
                    }
                    stopWatch.Reset();
                    stopWatch.Start();
                }
            }
        }

        private void capabilitiesListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (capabilitiesListView.SelectedIndices.Count > 0)
            {
                int selectedIndex = capabilitiesListView.SelectedIndices[0];
                if (selectedIndex < resolutionsCombo.Items.Count)
                {
                    resolutionsCombo.SelectedIndex = selectedIndex;
                }
            }
        }

        private void propertyPageButton_Click(object sender, EventArgs e)
        {
            if (videoDevice != null)
            {
                try
                {
                    videoDevice.DisplayPropertyPage(this.Handle);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("[PropertyPage] ERROR: {0}", ex);
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void UpdateConnectionControls(bool connected)
        {
            devicesCombo.Enabled = connected;
            resolutionsCombo.Enabled = connected;
            refreshButton.Enabled = connected;
            connectButton.Enabled = connected;
            disconnectButton.Enabled = !connected;
            switchResolutionButton.Enabled = !connected;
            propertyPageButton.Enabled = !connected;
        }
    }
}
