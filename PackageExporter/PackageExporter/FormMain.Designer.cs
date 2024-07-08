
namespace ReportExporter
{
    partial class FormMain
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this._menu = new System.Windows.Forms.MenuStrip();
            this.itemConnectServer = new System.Windows.Forms.ToolStripMenuItem();
            this.itemConnect = new System.Windows.Forms.ToolStripMenuItem();
            this.menuExport = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tvwReports = new System.Windows.Forms.TreeView();
            this.imlIcons = new System.Windows.Forms.ImageList(this.components);
            this.fbdExport = new System.Windows.Forms.FolderBrowserDialog();
            this._menu.SuspendLayout();
            this.SuspendLayout();
            // 
            // _menu
            // 
            this._menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.itemConnectServer});
            this._menu.Location = new System.Drawing.Point(0, 0);
            this._menu.Name = "_menu";
            this._menu.Padding = new System.Windows.Forms.Padding(5, 2, 0, 2);
            this._menu.Size = new System.Drawing.Size(731, 24);
            this._menu.TabIndex = 0;
            this._menu.Text = "Server";
            // 
            // itemConnectServer
            // 
            this.itemConnectServer.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.itemConnect,
            this.menuExport,
            this.toolStripSeparator1,
            this.exitToolStripMenuItem});
            this.itemConnectServer.Name = "itemConnectServer";
            this.itemConnectServer.ShortcutKeys = System.Windows.Forms.Keys.F10;
            this.itemConnectServer.Size = new System.Drawing.Size(51, 20);
            this.itemConnectServer.Text = "Server";
            // 
            // itemConnect
            // 
            this.itemConnect.Name = "itemConnect";
            this.itemConnect.ShortcutKeys = System.Windows.Forms.Keys.F2;
            this.itemConnect.Size = new System.Drawing.Size(180, 22);
            this.itemConnect.Text = "Connect to...";
            this.itemConnect.Click += new System.EventHandler(this.itemConnect_Click);
            // 
            // menuExport
            // 
            this.menuExport.Name = "menuExport";
            this.menuExport.ShortcutKeys = System.Windows.Forms.Keys.F3;
            this.menuExport.Size = new System.Drawing.Size(180, 22);
            this.menuExport.Text = "Export selected";
            this.menuExport.Click += new System.EventHandler(this.menuExport_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(177, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F10;
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 438);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 12, 0);
            this.statusStrip1.Size = new System.Drawing.Size(731, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tvwReports
            // 
            this.tvwReports.BackColor = System.Drawing.SystemColors.Window;
            this.tvwReports.CheckBoxes = true;
            this.tvwReports.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvwReports.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tvwReports.ImageIndex = 0;
            this.tvwReports.ImageList = this.imlIcons;
            this.tvwReports.Location = new System.Drawing.Point(0, 24);
            this.tvwReports.Name = "tvwReports";
            this.tvwReports.SelectedImageIndex = 0;
            this.tvwReports.Size = new System.Drawing.Size(731, 414);
            this.tvwReports.TabIndex = 2;
            this.tvwReports.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.tvwReports_AfterCheck);
            // 
            // imlIcons
            // 
            this.imlIcons.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imlIcons.ImageStream")));
            this.imlIcons.TransparentColor = System.Drawing.Color.Transparent;
            this.imlIcons.Images.SetKeyName(0, "Icon-F.png");
            this.imlIcons.Images.SetKeyName(1, "Icon-R.png");
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(731, 460);
            this.Controls.Add(this.tvwReports);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this._menu);
            this.MainMenuStrip = this._menu;
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SSRS Exporter RDL";
            this._menu.ResumeLayout(false);
            this._menu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip _menu;
        private System.Windows.Forms.ToolStripMenuItem itemConnectServer;
        private System.Windows.Forms.ToolStripMenuItem itemConnect;
        private System.Windows.Forms.ToolStripMenuItem menuExport;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.TreeView tvwReports;
        private System.Windows.Forms.ImageList imlIcons;
        private System.Windows.Forms.FolderBrowserDialog fbdExport;
    }
}
