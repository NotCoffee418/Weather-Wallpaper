namespace WeatherWallpaper
{
    partial class SettingsForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsForm));
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.currentWeatherLabel = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.findLocationButton = new System.Windows.Forms.Button();
            this.locationComboBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.statusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.loadingStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.loadingStatusBar = new System.Windows.Forms.ToolStripProgressBar();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.changeButton_Sunny = new System.Windows.Forms.Button();
            this.pictureBox_Sunny = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox9 = new System.Windows.Forms.GroupBox();
            this.groupBox10 = new System.Windows.Forms.GroupBox();
            this.pictureBox_Static = new System.Windows.Forms.PictureBox();
            this.screenListBox = new System.Windows.Forms.CheckedListBox();
            this.changeButton_Static = new System.Windows.Forms.Button();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.changeButton_Clear = new System.Windows.Forms.Button();
            this.pictureBox_Clear = new System.Windows.Forms.PictureBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.changeButton_PartlyCloudy = new System.Windows.Forms.Button();
            this.pictureBox_PartlyCloudy = new System.Windows.Forms.PictureBox();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.changeButton_Snow = new System.Windows.Forms.Button();
            this.pictureBox_Snow = new System.Windows.Forms.PictureBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.changeButton_Cloudy = new System.Windows.Forms.Button();
            this.pictureBox_Cloudy = new System.Windows.Forms.PictureBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.changeButton_Thunderstorm = new System.Windows.Forms.Button();
            this.pictureBox_Thunderstorm = new System.Windows.Forms.PictureBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.changeButton_Rain = new System.Windows.Forms.Button();
            this.pictureBox_Rain = new System.Windows.Forms.PictureBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.updatesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Sunny)).BeginInit();
            this.panel1.SuspendLayout();
            this.groupBox9.SuspendLayout();
            this.groupBox10.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Static)).BeginInit();
            this.groupBox8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Clear)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_PartlyCloudy)).BeginInit();
            this.groupBox7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Snow)).BeginInit();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Cloudy)).BeginInit();
            this.groupBox6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Thunderstorm)).BeginInit();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Rain)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // notifyIcon
            // 
            this.notifyIcon.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.notifyIcon.BalloonTipText = "Weather Wallpaper will remain active in your System Tray.";
            this.notifyIcon.BalloonTipTitle = "Weather Wallpaper";
            this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
            this.notifyIcon.Text = "Weather Wallpaper";
            this.notifyIcon.Visible = true;
            this.notifyIcon.DoubleClick += new System.EventHandler(this.IconMenuOpen);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.currentWeatherLabel);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.findLocationButton);
            this.groupBox1.Controls.Add(this.locationComboBox);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 24);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(647, 66);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Weather";
            // 
            // currentWeatherLabel
            // 
            this.currentWeatherLabel.AutoSize = true;
            this.currentWeatherLabel.Location = new System.Drawing.Point(78, 41);
            this.currentWeatherLabel.Name = "currentWeatherLabel";
            this.currentWeatherLabel.Size = new System.Drawing.Size(54, 13);
            this.currentWeatherLabel.TabIndex = 4;
            this.currentWeatherLabel.Text = "Loading...";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Weather";
            // 
            // findLocationButton
            // 
            this.findLocationButton.Location = new System.Drawing.Point(263, 11);
            this.findLocationButton.Name = "findLocationButton";
            this.findLocationButton.Size = new System.Drawing.Size(82, 23);
            this.findLocationButton.TabIndex = 2;
            this.findLocationButton.Text = "Find Location";
            this.findLocationButton.UseVisualStyleBackColor = true;
            this.findLocationButton.Click += new System.EventHandler(this.findLocationButton_Click);
            // 
            // locationComboBox
            // 
            this.locationComboBox.FormattingEnabled = true;
            this.locationComboBox.Location = new System.Drawing.Point(78, 13);
            this.locationComboBox.Name = "locationComboBox";
            this.locationComboBox.Size = new System.Drawing.Size(179, 21);
            this.locationComboBox.TabIndex = 1;
            this.locationComboBox.SelectedIndexChanged += new System.EventHandler(this.locationComboBox_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Location";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Enabled = false;
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusLabel,
            this.loadingStatusBar,
            this.loadingStatusLabel,
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 484);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(647, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // statusLabel
            // 
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(0, 17);
            // 
            // loadingStatusLabel
            // 
            this.loadingStatusLabel.Name = "loadingStatusLabel";
            this.loadingStatusLabel.Size = new System.Drawing.Size(59, 17);
            this.loadingStatusLabel.Text = "Loading...";
            // 
            // loadingStatusBar
            // 
            this.loadingStatusBar.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.loadingStatusBar.Name = "loadingStatusBar";
            this.loadingStatusBar.Size = new System.Drawing.Size(100, 16);
            this.loadingStatusBar.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.loadingStatusBar.Value = 100;
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(381, 17);
            this.toolStripStatusLabel1.Spring = true;
            this.toolStripStatusLabel1.Text = "© Stijn Raeymaekers 2015";
            this.toolStripStatusLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.changeButton_Sunny);
            this.groupBox2.Controls.Add(this.pictureBox_Sunny);
            this.groupBox2.Location = new System.Drawing.Point(16, 19);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(150, 180);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Sunny";
            // 
            // changeButton_Sunny
            // 
            this.changeButton_Sunny.Location = new System.Drawing.Point(6, 150);
            this.changeButton_Sunny.Name = "changeButton_Sunny";
            this.changeButton_Sunny.Size = new System.Drawing.Size(138, 23);
            this.changeButton_Sunny.TabIndex = 1;
            this.changeButton_Sunny.Text = "Change";
            this.changeButton_Sunny.UseVisualStyleBackColor = true;
            this.changeButton_Sunny.Click += new System.EventHandler(this.changeButton_Sunny_Click);
            // 
            // pictureBox_Sunny
            // 
            this.pictureBox_Sunny.InitialImage = null;
            this.pictureBox_Sunny.Location = new System.Drawing.Point(6, 19);
            this.pictureBox_Sunny.Name = "pictureBox_Sunny";
            this.pictureBox_Sunny.Size = new System.Drawing.Size(138, 125);
            this.pictureBox_Sunny.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox_Sunny.TabIndex = 0;
            this.pictureBox_Sunny.TabStop = false;
            this.pictureBox_Sunny.Click += new System.EventHandler(this.pictureBox_Sunny_Click);
            this.pictureBox_Sunny.DragDrop += new System.Windows.Forms.DragEventHandler(this.pictureBox_Sunny_DragDrop);
            this.pictureBox_Sunny.DragEnter += new System.Windows.Forms.DragEventHandler(this.pictureBox_Sunny_DragEnter);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.groupBox9);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.menuStrip1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(647, 484);
            this.panel1.TabIndex = 3;
            // 
            // groupBox9
            // 
            this.groupBox9.Controls.Add(this.groupBox10);
            this.groupBox9.Controls.Add(this.groupBox2);
            this.groupBox9.Controls.Add(this.groupBox8);
            this.groupBox9.Controls.Add(this.groupBox3);
            this.groupBox9.Controls.Add(this.groupBox7);
            this.groupBox9.Controls.Add(this.groupBox4);
            this.groupBox9.Controls.Add(this.groupBox6);
            this.groupBox9.Controls.Add(this.groupBox5);
            this.groupBox9.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox9.Location = new System.Drawing.Point(0, 90);
            this.groupBox9.Name = "groupBox9";
            this.groupBox9.Size = new System.Drawing.Size(647, 423);
            this.groupBox9.TabIndex = 9;
            this.groupBox9.TabStop = false;
            this.groupBox9.Text = "Wallpaper";
            // 
            // groupBox10
            // 
            this.groupBox10.Controls.Add(this.pictureBox_Static);
            this.groupBox10.Controls.Add(this.screenListBox);
            this.groupBox10.Controls.Add(this.changeButton_Static);
            this.groupBox10.Location = new System.Drawing.Point(484, 205);
            this.groupBox10.Name = "groupBox10";
            this.groupBox10.Size = new System.Drawing.Size(150, 180);
            this.groupBox10.TabIndex = 9;
            this.groupBox10.TabStop = false;
            this.groupBox10.Text = "Multiscreen Wallpaper";
            // 
            // pictureBox_Static
            // 
            this.pictureBox_Static.InitialImage = null;
            this.pictureBox_Static.Location = new System.Drawing.Point(6, 59);
            this.pictureBox_Static.Name = "pictureBox_Static";
            this.pictureBox_Static.Size = new System.Drawing.Size(138, 85);
            this.pictureBox_Static.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox_Static.TabIndex = 2;
            this.pictureBox_Static.TabStop = false;
            this.pictureBox_Static.Click += new System.EventHandler(this.pictureBox_Static_Click);
            this.pictureBox_Static.DragDrop += new System.Windows.Forms.DragEventHandler(this.pictureBox_Static_DragDrop);
            this.pictureBox_Static.DragEnter += new System.Windows.Forms.DragEventHandler(this.pictureBox_Static_DragEnter);
            // 
            // screenListBox
            // 
            this.screenListBox.Location = new System.Drawing.Point(6, 19);
            this.screenListBox.Name = "screenListBox";
            this.screenListBox.Size = new System.Drawing.Size(137, 34);
            this.screenListBox.TabIndex = 1;
            this.screenListBox.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.screenListBox_ItemCheck);
            this.screenListBox.SelectedIndexChanged += new System.EventHandler(this.screenListBox_SelectedIndexChanged);
            // 
            // changeButton_Static
            // 
            this.changeButton_Static.Location = new System.Drawing.Point(6, 150);
            this.changeButton_Static.Name = "changeButton_Static";
            this.changeButton_Static.Size = new System.Drawing.Size(137, 23);
            this.changeButton_Static.TabIndex = 0;
            this.changeButton_Static.Text = "Change Static Wallpaper";
            this.changeButton_Static.UseVisualStyleBackColor = true;
            this.changeButton_Static.Click += new System.EventHandler(this.changeButton_Static_Click);
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.changeButton_Clear);
            this.groupBox8.Controls.Add(this.pictureBox_Clear);
            this.groupBox8.Location = new System.Drawing.Point(484, 19);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(150, 180);
            this.groupBox8.TabIndex = 8;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "Clear Night";
            // 
            // changeButton_Clear
            // 
            this.changeButton_Clear.Location = new System.Drawing.Point(6, 150);
            this.changeButton_Clear.Name = "changeButton_Clear";
            this.changeButton_Clear.Size = new System.Drawing.Size(138, 23);
            this.changeButton_Clear.TabIndex = 1;
            this.changeButton_Clear.Text = "Change";
            this.changeButton_Clear.UseVisualStyleBackColor = true;
            this.changeButton_Clear.Click += new System.EventHandler(this.changeButton_Clear_Click);
            // 
            // pictureBox_Clear
            // 
            this.pictureBox_Clear.InitialImage = null;
            this.pictureBox_Clear.Location = new System.Drawing.Point(6, 19);
            this.pictureBox_Clear.Name = "pictureBox_Clear";
            this.pictureBox_Clear.Size = new System.Drawing.Size(138, 125);
            this.pictureBox_Clear.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox_Clear.TabIndex = 0;
            this.pictureBox_Clear.TabStop = false;
            this.pictureBox_Clear.Click += new System.EventHandler(this.pictureBox_Clear_Click);
            this.pictureBox_Clear.DragDrop += new System.Windows.Forms.DragEventHandler(this.pictureBox_Clear_DragDrop);
            this.pictureBox_Clear.DragEnter += new System.Windows.Forms.DragEventHandler(this.pictureBox_Clear_DragEnter);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.changeButton_PartlyCloudy);
            this.groupBox3.Controls.Add(this.pictureBox_PartlyCloudy);
            this.groupBox3.Location = new System.Drawing.Point(172, 19);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(150, 180);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Partly Cloudy";
            // 
            // changeButton_PartlyCloudy
            // 
            this.changeButton_PartlyCloudy.Location = new System.Drawing.Point(6, 150);
            this.changeButton_PartlyCloudy.Name = "changeButton_PartlyCloudy";
            this.changeButton_PartlyCloudy.Size = new System.Drawing.Size(138, 23);
            this.changeButton_PartlyCloudy.TabIndex = 1;
            this.changeButton_PartlyCloudy.Text = "Change";
            this.changeButton_PartlyCloudy.UseVisualStyleBackColor = true;
            this.changeButton_PartlyCloudy.Click += new System.EventHandler(this.changeButton_PartlyCloudy_Click);
            // 
            // pictureBox_PartlyCloudy
            // 
            this.pictureBox_PartlyCloudy.InitialImage = null;
            this.pictureBox_PartlyCloudy.Location = new System.Drawing.Point(6, 19);
            this.pictureBox_PartlyCloudy.Name = "pictureBox_PartlyCloudy";
            this.pictureBox_PartlyCloudy.Size = new System.Drawing.Size(138, 125);
            this.pictureBox_PartlyCloudy.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox_PartlyCloudy.TabIndex = 0;
            this.pictureBox_PartlyCloudy.TabStop = false;
            this.pictureBox_PartlyCloudy.Click += new System.EventHandler(this.pictureBox_PartlyCloudy_Click);
            this.pictureBox_PartlyCloudy.DragDrop += new System.Windows.Forms.DragEventHandler(this.pictureBox_PartlyCloudy_DragDrop);
            this.pictureBox_PartlyCloudy.DragEnter += new System.Windows.Forms.DragEventHandler(this.pictureBox_PartlyCloudy_DragEnter);
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.changeButton_Snow);
            this.groupBox7.Controls.Add(this.pictureBox_Snow);
            this.groupBox7.Location = new System.Drawing.Point(328, 205);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(150, 180);
            this.groupBox7.TabIndex = 7;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Snow";
            // 
            // changeButton_Snow
            // 
            this.changeButton_Snow.Location = new System.Drawing.Point(6, 150);
            this.changeButton_Snow.Name = "changeButton_Snow";
            this.changeButton_Snow.Size = new System.Drawing.Size(138, 23);
            this.changeButton_Snow.TabIndex = 1;
            this.changeButton_Snow.Text = "Change";
            this.changeButton_Snow.UseVisualStyleBackColor = true;
            this.changeButton_Snow.Click += new System.EventHandler(this.changeButton_Snow_Click);
            // 
            // pictureBox_Snow
            // 
            this.pictureBox_Snow.InitialImage = null;
            this.pictureBox_Snow.Location = new System.Drawing.Point(6, 19);
            this.pictureBox_Snow.Name = "pictureBox_Snow";
            this.pictureBox_Snow.Size = new System.Drawing.Size(138, 125);
            this.pictureBox_Snow.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox_Snow.TabIndex = 0;
            this.pictureBox_Snow.TabStop = false;
            this.pictureBox_Snow.Click += new System.EventHandler(this.pictureBox_Snow_Click);
            this.pictureBox_Snow.DragDrop += new System.Windows.Forms.DragEventHandler(this.pictureBox_Snow_DragDrop);
            this.pictureBox_Snow.DragEnter += new System.Windows.Forms.DragEventHandler(this.pictureBox_Snow_DragEnter);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.changeButton_Cloudy);
            this.groupBox4.Controls.Add(this.pictureBox_Cloudy);
            this.groupBox4.Location = new System.Drawing.Point(328, 19);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(150, 180);
            this.groupBox4.TabIndex = 4;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Cloudy";
            // 
            // changeButton_Cloudy
            // 
            this.changeButton_Cloudy.Location = new System.Drawing.Point(6, 150);
            this.changeButton_Cloudy.Name = "changeButton_Cloudy";
            this.changeButton_Cloudy.Size = new System.Drawing.Size(138, 23);
            this.changeButton_Cloudy.TabIndex = 1;
            this.changeButton_Cloudy.Text = "Change";
            this.changeButton_Cloudy.UseVisualStyleBackColor = true;
            this.changeButton_Cloudy.Click += new System.EventHandler(this.changeButton_Cloudy_Click);
            // 
            // pictureBox_Cloudy
            // 
            this.pictureBox_Cloudy.InitialImage = null;
            this.pictureBox_Cloudy.Location = new System.Drawing.Point(6, 19);
            this.pictureBox_Cloudy.Name = "pictureBox_Cloudy";
            this.pictureBox_Cloudy.Size = new System.Drawing.Size(138, 125);
            this.pictureBox_Cloudy.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox_Cloudy.TabIndex = 0;
            this.pictureBox_Cloudy.TabStop = false;
            this.pictureBox_Cloudy.Click += new System.EventHandler(this.pictureBox_Cloudy_Click);
            this.pictureBox_Cloudy.DragDrop += new System.Windows.Forms.DragEventHandler(this.pictureBox_Cloudy_DragDrop);
            this.pictureBox_Cloudy.DragEnter += new System.Windows.Forms.DragEventHandler(this.pictureBox_Cloudy_DragEnter);
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.changeButton_Thunderstorm);
            this.groupBox6.Controls.Add(this.pictureBox_Thunderstorm);
            this.groupBox6.Location = new System.Drawing.Point(172, 205);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(150, 180);
            this.groupBox6.TabIndex = 6;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Thunderstorm";
            // 
            // changeButton_Thunderstorm
            // 
            this.changeButton_Thunderstorm.Location = new System.Drawing.Point(6, 150);
            this.changeButton_Thunderstorm.Name = "changeButton_Thunderstorm";
            this.changeButton_Thunderstorm.Size = new System.Drawing.Size(138, 23);
            this.changeButton_Thunderstorm.TabIndex = 1;
            this.changeButton_Thunderstorm.Text = "Change";
            this.changeButton_Thunderstorm.UseVisualStyleBackColor = true;
            this.changeButton_Thunderstorm.Click += new System.EventHandler(this.changeButton_Thunderstorm_Click);
            // 
            // pictureBox_Thunderstorm
            // 
            this.pictureBox_Thunderstorm.InitialImage = null;
            this.pictureBox_Thunderstorm.Location = new System.Drawing.Point(6, 19);
            this.pictureBox_Thunderstorm.Name = "pictureBox_Thunderstorm";
            this.pictureBox_Thunderstorm.Size = new System.Drawing.Size(138, 125);
            this.pictureBox_Thunderstorm.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox_Thunderstorm.TabIndex = 0;
            this.pictureBox_Thunderstorm.TabStop = false;
            this.pictureBox_Thunderstorm.Click += new System.EventHandler(this.pictureBox_Thunderstorm_Click);
            this.pictureBox_Thunderstorm.DragDrop += new System.Windows.Forms.DragEventHandler(this.pictureBox_Thunderstorm_DragDrop);
            this.pictureBox_Thunderstorm.DragEnter += new System.Windows.Forms.DragEventHandler(this.pictureBox_Thunderstorm_DragEnter);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.changeButton_Rain);
            this.groupBox5.Controls.Add(this.pictureBox_Rain);
            this.groupBox5.Location = new System.Drawing.Point(16, 205);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(150, 180);
            this.groupBox5.TabIndex = 5;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Rain";
            // 
            // changeButton_Rain
            // 
            this.changeButton_Rain.Location = new System.Drawing.Point(6, 150);
            this.changeButton_Rain.Name = "changeButton_Rain";
            this.changeButton_Rain.Size = new System.Drawing.Size(138, 23);
            this.changeButton_Rain.TabIndex = 1;
            this.changeButton_Rain.Text = "Change";
            this.changeButton_Rain.UseVisualStyleBackColor = true;
            this.changeButton_Rain.Click += new System.EventHandler(this.changeButton_Rain_Click);
            // 
            // pictureBox_Rain
            // 
            this.pictureBox_Rain.InitialImage = null;
            this.pictureBox_Rain.Location = new System.Drawing.Point(6, 19);
            this.pictureBox_Rain.Name = "pictureBox_Rain";
            this.pictureBox_Rain.Size = new System.Drawing.Size(138, 125);
            this.pictureBox_Rain.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox_Rain.TabIndex = 0;
            this.pictureBox_Rain.TabStop = false;
            this.pictureBox_Rain.Click += new System.EventHandler(this.pictureBox_Rain_Click);
            this.pictureBox_Rain.DragDrop += new System.Windows.Forms.DragEventHandler(this.pictureBox_Rain_DragDrop);
            this.pictureBox_Rain.DragEnter += new System.Windows.Forms.DragEventHandler(this.pictureBox_Rain_DragEnter);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.updatesToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(647, 24);
            this.menuStrip1.TabIndex = 10;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // updatesToolStripMenuItem
            // 
            this.updatesToolStripMenuItem.Name = "updatesToolStripMenuItem";
            this.updatesToolStripMenuItem.Size = new System.Drawing.Size(62, 20);
            this.updatesToolStripMenuItem.Text = "Updates";
            this.updatesToolStripMenuItem.Click += new System.EventHandler(this.updatesToolStripMenuItem_Click);
            // 
            // SettingsForm
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(647, 506);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.statusStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "SettingsForm";
            this.Text = "Weather Wallpaper";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Shown += new System.EventHandler(this.Form1_Shown);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Sunny)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox9.ResumeLayout(false);
            this.groupBox10.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Static)).EndInit();
            this.groupBox8.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Clear)).EndInit();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_PartlyCloudy)).EndInit();
            this.groupBox7.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Snow)).EndInit();
            this.groupBox4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Cloudy)).EndInit();
            this.groupBox6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Thunderstorm)).EndInit();
            this.groupBox5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Rain)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NotifyIcon notifyIcon;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox locationComboBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button findLocationButton;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel statusLabel;
        private System.Windows.Forms.Label label2;
        internal System.Windows.Forms.Label currentWeatherLabel;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button changeButton_Sunny;
        private System.Windows.Forms.PictureBox pictureBox_Sunny;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox8;
        private System.Windows.Forms.Button changeButton_Clear;
        private System.Windows.Forms.PictureBox pictureBox_Clear;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.Button changeButton_Snow;
        private System.Windows.Forms.PictureBox pictureBox_Snow;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Button changeButton_Thunderstorm;
        private System.Windows.Forms.PictureBox pictureBox_Thunderstorm;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Button changeButton_Rain;
        private System.Windows.Forms.PictureBox pictureBox_Rain;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button changeButton_Cloudy;
        private System.Windows.Forms.PictureBox pictureBox_Cloudy;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button changeButton_PartlyCloudy;
        private System.Windows.Forms.PictureBox pictureBox_PartlyCloudy;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.GroupBox groupBox9;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem updatesToolStripMenuItem;
        private System.Windows.Forms.GroupBox groupBox10;
        private System.Windows.Forms.PictureBox pictureBox_Static;
        private System.Windows.Forms.CheckedListBox screenListBox;
        private System.Windows.Forms.Button changeButton_Static;
        public System.Windows.Forms.ToolStripStatusLabel loadingStatusLabel;
        public System.Windows.Forms.ToolStripProgressBar loadingStatusBar;
    }
}

