namespace Image_Processing_CVC
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.liveVideoFeedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.airDrawingModeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mouseControlModeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.liveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.darkModeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showGestureDictionaryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.closeTheCameraToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog1_FileOk);
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.menuStrip1.Font = new System.Drawing.Font("Gabriola", 15.25F, System.Drawing.FontStyle.Bold);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.liveToolStripMenuItem,
            this.helpToolStripMenuItem,
            this.closeTheCameraToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(15, 10, 0, 10);
            this.menuStrip1.Size = new System.Drawing.Size(517, 66);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.liveVideoFeedToolStripMenuItem,
            this.airDrawingModeToolStripMenuItem,
            this.mouseControlModeToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(55, 46);
            this.fileToolStripMenuItem.Text = "File";
            this.fileToolStripMenuItem.Click += new System.EventHandler(this.fileToolStripMenuItem_Click);
            // 
            // liveVideoFeedToolStripMenuItem
            // 
            this.liveVideoFeedToolStripMenuItem.Name = "liveVideoFeedToolStripMenuItem";
            this.liveVideoFeedToolStripMenuItem.Size = new System.Drawing.Size(345, 44);
            this.liveVideoFeedToolStripMenuItem.Text = "Live video feed for Hand detection";
            this.liveVideoFeedToolStripMenuItem.Click += new System.EventHandler(this.liveVideoFeedToolStripMenuItem_Click);
            // 
            // airDrawingModeToolStripMenuItem
            // 
            this.airDrawingModeToolStripMenuItem.Name = "airDrawingModeToolStripMenuItem";
            this.airDrawingModeToolStripMenuItem.Size = new System.Drawing.Size(345, 44);
            this.airDrawingModeToolStripMenuItem.Text = "Air drawing mode";
            this.airDrawingModeToolStripMenuItem.Click += new System.EventHandler(this.airDrawingModeToolStripMenuItem_Click);
            // 
            // mouseControlModeToolStripMenuItem
            // 
            this.mouseControlModeToolStripMenuItem.Name = "mouseControlModeToolStripMenuItem";
            this.mouseControlModeToolStripMenuItem.Size = new System.Drawing.Size(345, 44);
            this.mouseControlModeToolStripMenuItem.Text = "Mouse control mode";
            this.mouseControlModeToolStripMenuItem.Click += new System.EventHandler(this.mouseControlModeToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(345, 44);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // liveToolStripMenuItem
            // 
            this.liveToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.darkModeToolStripMenuItem});
            this.liveToolStripMenuItem.Name = "liveToolStripMenuItem";
            this.liveToolStripMenuItem.Size = new System.Drawing.Size(87, 46);
            this.liveToolStripMenuItem.Text = "Options";
            this.liveToolStripMenuItem.Click += new System.EventHandler(this.liveToolStripMenuItem_Click);
            // 
            // darkModeToolStripMenuItem
            // 
            this.darkModeToolStripMenuItem.Checked = true;
            this.darkModeToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.darkModeToolStripMenuItem.Name = "darkModeToolStripMenuItem";
            this.darkModeToolStripMenuItem.Size = new System.Drawing.Size(175, 44);
            this.darkModeToolStripMenuItem.Text = "Dark mode";
            this.darkModeToolStripMenuItem.Click += new System.EventHandler(this.darkModeToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showGestureDictionaryToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(64, 46);
            this.helpToolStripMenuItem.Text = "Help";
            this.helpToolStripMenuItem.Click += new System.EventHandler(this.helpToolStripMenuItem_Click);
            // 
            // showGestureDictionaryToolStripMenuItem
            // 
            this.showGestureDictionaryToolStripMenuItem.Name = "showGestureDictionaryToolStripMenuItem";
            this.showGestureDictionaryToolStripMenuItem.Size = new System.Drawing.Size(269, 44);
            this.showGestureDictionaryToolStripMenuItem.Text = "Show gesture dictionary";
            this.showGestureDictionaryToolStripMenuItem.Click += new System.EventHandler(this.showGestureDictionaryToolStripMenuItem_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(30, 377);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 65);
            this.label1.TabIndex = 2;
            this.label1.Text = "live";
            this.label1.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Gabriola", 10F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(9, 400);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(27, 26);
            this.label2.TabIndex = 3;
            this.label2.Text = "●";
            this.label2.Visible = false;
            // 
            // timer1
            // 
            this.timer1.Interval = 750;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // closeTheCameraToolStripMenuItem
            // 
            this.closeTheCameraToolStripMenuItem.Font = new System.Drawing.Font("Gabriola", 17F, System.Drawing.FontStyle.Bold);
            this.closeTheCameraToolStripMenuItem.ForeColor = System.Drawing.Color.Firebrick;
            this.closeTheCameraToolStripMenuItem.Name = "closeTheCameraToolStripMenuItem";
            this.closeTheCameraToolStripMenuItem.Size = new System.Drawing.Size(185, 46);
            this.closeTheCameraToolStripMenuItem.Text = "Turn the camera off";
            this.closeTheCameraToolStripMenuItem.Visible = false;
            this.closeTheCameraToolStripMenuItem.Click += new System.EventHandler(this.closeTheCameraToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(15F, 65F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ClientSize = new System.Drawing.Size(517, 441);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Gabriola", 26.25F, System.Drawing.FontStyle.Bold);
            this.ForeColor = System.Drawing.Color.White;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(8, 15, 8, 15);
            this.Name = "Form1";
            this.Text = "Hand Gesture Recognition";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.SizeChanged += new System.EventHandler(this.Form1_SizeChanged);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem liveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStripMenuItem liveVideoFeedToolStripMenuItem;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ToolStripMenuItem darkModeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showGestureDictionaryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem airDrawingModeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mouseControlModeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem closeTheCameraToolStripMenuItem;
    }
}

