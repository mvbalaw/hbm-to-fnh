namespace NHibernateHbmToFluent.WinForm
{
	partial class MainForm
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
			this.label1 = new System.Windows.Forms.Label();
			this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
			this._txtHbmDir = new System.Windows.Forms.TextBox();
			this._btnChooseHbmDirectory = new System.Windows.Forms.Button();
			this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
			this.label2 = new System.Windows.Forms.Label();
			this._txtMapDir = new System.Windows.Forms.TextBox();
			this._btnChooseMapDirectory = new System.Windows.Forms.Button();
			this._txtFilesProcessed = new System.Windows.Forms.TextBox();
			this._txtErrors = new System.Windows.Forms.TextBox();
			this._btnGo = new System.Windows.Forms.Button();
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this._menuFile = new System.Windows.Forms.ToolStripMenuItem();
			this._menuFileExit = new System.Windows.Forms.ToolStripMenuItem();
			this._menuAbout = new System.Windows.Forms.ToolStripMenuItem();
			this._lblFilesProcessed = new System.Windows.Forms.Label();
			this._lblErrors = new System.Windows.Forms.Label();
			this._txtNamespace = new System.Windows.Forms.TextBox();
			this._lblNamespace = new System.Windows.Forms.Label();
			this.menuStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(22, 36);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(93, 13);
			this.label1.TabIndex = 0;
			this.label1.Text = "HBM File directory";
			// 
			// openFileDialog1
			// 
			this.openFileDialog1.FileName = "openFileDialog1";
			// 
			// _txtHbmDir
			// 
			this._txtHbmDir.Location = new System.Drawing.Point(123, 33);
			this._txtHbmDir.Name = "_txtHbmDir";
			this._txtHbmDir.Size = new System.Drawing.Size(298, 20);
			this._txtHbmDir.TabIndex = 0;
			// 
			// _btnChooseHbmDirectory
			// 
			this._btnChooseHbmDirectory.Location = new System.Drawing.Point(427, 30);
			this._btnChooseHbmDirectory.Name = "_btnChooseHbmDirectory";
			this._btnChooseHbmDirectory.Size = new System.Drawing.Size(25, 23);
			this._btnChooseHbmDirectory.TabIndex = 1;
			this._btnChooseHbmDirectory.Text = "...";
			this._btnChooseHbmDirectory.UseVisualStyleBackColor = true;
			this._btnChooseHbmDirectory.Click += new System.EventHandler(this._btnChooseHbmDirectory_Click);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(12, 64);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(103, 13);
			this.label2.TabIndex = 3;
			this.label2.Text = "Fluent Map directory";
			// 
			// _txtMapDir
			// 
			this._txtMapDir.Location = new System.Drawing.Point(122, 60);
			this._txtMapDir.Name = "_txtMapDir";
			this._txtMapDir.Size = new System.Drawing.Size(298, 20);
			this._txtMapDir.TabIndex = 2;
			// 
			// _btnChooseMapDirectory
			// 
			this._btnChooseMapDirectory.Location = new System.Drawing.Point(427, 57);
			this._btnChooseMapDirectory.Name = "_btnChooseMapDirectory";
			this._btnChooseMapDirectory.Size = new System.Drawing.Size(25, 23);
			this._btnChooseMapDirectory.TabIndex = 3;
			this._btnChooseMapDirectory.Text = "...";
			this._btnChooseMapDirectory.UseVisualStyleBackColor = true;
			this._btnChooseMapDirectory.Click += new System.EventHandler(this._btnChooseMapDirectory_Click);
			// 
			// _txtFilesProcessed
			// 
			this._txtFilesProcessed.Location = new System.Drawing.Point(19, 146);
			this._txtFilesProcessed.Multiline = true;
			this._txtFilesProcessed.Name = "_txtFilesProcessed";
			this._txtFilesProcessed.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this._txtFilesProcessed.Size = new System.Drawing.Size(467, 121);
			this._txtFilesProcessed.TabIndex = 6;
			this._txtFilesProcessed.TabStop = false;
			// 
			// _txtErrors
			// 
			this._txtErrors.Location = new System.Drawing.Point(20, 291);
			this._txtErrors.Multiline = true;
			this._txtErrors.Name = "_txtErrors";
			this._txtErrors.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this._txtErrors.Size = new System.Drawing.Size(467, 97);
			this._txtErrors.TabIndex = 7;
			this._txtErrors.TabStop = false;
			// 
			// _btnGo
			// 
			this._btnGo.Location = new System.Drawing.Point(418, 117);
			this._btnGo.Name = "_btnGo";
			this._btnGo.Size = new System.Drawing.Size(34, 23);
			this._btnGo.TabIndex = 5;
			this._btnGo.Text = "GO!";
			this._btnGo.UseVisualStyleBackColor = true;
			this._btnGo.Click += new System.EventHandler(this._btnGo_Click);
			// 
			// menuStrip1
			// 
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._menuFile,
            this._menuAbout});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(498, 24);
			this.menuStrip1.TabIndex = 8;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// _menuFile
			// 
			this._menuFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._menuFileExit});
			this._menuFile.Name = "_menuFile";
			this._menuFile.Size = new System.Drawing.Size(37, 20);
			this._menuFile.Text = "File";
			// 
			// _menuFileExit
			// 
			this._menuFileExit.Name = "_menuFileExit";
			this._menuFileExit.Size = new System.Drawing.Size(92, 22);
			this._menuFileExit.Text = "Exit";
			this._menuFileExit.Click += new System.EventHandler(this._menuFileExit_Click);
			// 
			// _menuAbout
			// 
			this._menuAbout.Name = "_menuAbout";
			this._menuAbout.Size = new System.Drawing.Size(52, 20);
			this._menuAbout.Text = "About";
			// 
			// _lblFilesProcessed
			// 
			this._lblFilesProcessed.AutoSize = true;
			this._lblFilesProcessed.Location = new System.Drawing.Point(17, 130);
			this._lblFilesProcessed.Name = "_lblFilesProcessed";
			this._lblFilesProcessed.Size = new System.Drawing.Size(108, 13);
			this._lblFilesProcessed.TabIndex = 9;
			this._lblFilesProcessed.Text = "HBM Files Processed";
			// 
			// _lblErrors
			// 
			this._lblErrors.AutoSize = true;
			this._lblErrors.Location = new System.Drawing.Point(20, 274);
			this._lblErrors.Name = "_lblErrors";
			this._lblErrors.Size = new System.Drawing.Size(34, 13);
			this._lblErrors.TabIndex = 10;
			this._lblErrors.Text = "Errors";
			// 
			// _txtNamespace
			// 
			this._txtNamespace.Location = new System.Drawing.Point(122, 86);
			this._txtNamespace.Name = "_txtNamespace";
			this._txtNamespace.Size = new System.Drawing.Size(298, 20);
			this._txtNamespace.TabIndex = 4;
			// 
			// _lblNamespace
			// 
			this._lblNamespace.AutoSize = true;
			this._lblNamespace.Location = new System.Drawing.Point(51, 89);
			this._lblNamespace.Name = "_lblNamespace";
			this._lblNamespace.Size = new System.Drawing.Size(64, 13);
			this._lblNamespace.TabIndex = 12;
			this._lblNamespace.Text = "Namespace";
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(498, 394);
			this.Controls.Add(this._lblNamespace);
			this.Controls.Add(this._txtNamespace);
			this.Controls.Add(this._lblErrors);
			this.Controls.Add(this._lblFilesProcessed);
			this.Controls.Add(this._btnGo);
			this.Controls.Add(this._txtErrors);
			this.Controls.Add(this._txtFilesProcessed);
			this.Controls.Add(this._btnChooseMapDirectory);
			this.Controls.Add(this._txtMapDir);
			this.Controls.Add(this.label2);
			this.Controls.Add(this._btnChooseHbmDirectory);
			this.Controls.Add(this._txtHbmDir);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.menuStrip1);
			this.MainMenuStrip = this.menuStrip1;
			this.Name = "MainForm";
			this.Text = "HBM to Fluent Map converter";
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.OpenFileDialog openFileDialog1;
		private System.Windows.Forms.TextBox _txtHbmDir;
		private System.Windows.Forms.Button _btnChooseHbmDirectory;
		private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox _txtMapDir;
		private System.Windows.Forms.Button _btnChooseMapDirectory;
		private System.Windows.Forms.TextBox _txtFilesProcessed;
		private System.Windows.Forms.TextBox _txtErrors;
		private System.Windows.Forms.Button _btnGo;
		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem _menuFile;
		private System.Windows.Forms.ToolStripMenuItem _menuFileExit;
		private System.Windows.Forms.ToolStripMenuItem _menuAbout;
		private System.Windows.Forms.Label _lblFilesProcessed;
		private System.Windows.Forms.Label _lblErrors;
		private System.Windows.Forms.TextBox _txtNamespace;
		private System.Windows.Forms.Label _lblNamespace;
	}
}