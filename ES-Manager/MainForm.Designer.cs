namespace ES_Manager
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.lbGames = new System.Windows.Forms.ListBox();
            this.tbTitle = new System.Windows.Forms.TextBox();
            this.tbDescription = new System.Windows.Forms.TextBox();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblDescription = new System.Windows.Forms.Label();
            this.cbMachine = new System.Windows.Forms.ComboBox();
            this.lblMachine = new System.Windows.Forms.Label();
            this.pbCover = new System.Windows.Forms.PictureBox();
            this.btnScrapeGamesDb = new System.Windows.Forms.Button();
            this.tbFilename = new System.Windows.Forms.TextBox();
            this.lblRomName = new System.Windows.Forms.Label();
            this.btnRemoveCover = new System.Windows.Forms.Button();
            this.rbSize1 = new System.Windows.Forms.RadioButton();
            this.rbSize2 = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnBrowseCover = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnGoogleSearch = new System.Windows.Forms.Button();
            this.lblSpecificSearch = new System.Windows.Forms.Label();
            this.tbSpecificScraperSearch = new System.Windows.Forms.TextBox();
            this.btnCopyToPi = new System.Windows.Forms.Button();
            this.btnOpenSmbShare = new System.Windows.Forms.Button();
            this.btnOpenRomFolder = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pbCover)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbGames
            // 
            this.lbGames.Dock = System.Windows.Forms.DockStyle.Left;
            this.lbGames.FormattingEnabled = true;
            this.lbGames.Location = new System.Drawing.Point(0, 0);
            this.lbGames.Name = "lbGames";
            this.lbGames.Size = new System.Drawing.Size(331, 556);
            this.lbGames.Sorted = true;
            this.lbGames.TabIndex = 0;
            this.lbGames.SelectedIndexChanged += new System.EventHandler(this.lbGames_SelectedIndexChanged);
            // 
            // tbTitle
            // 
            this.tbTitle.Location = new System.Drawing.Point(340, 112);
            this.tbTitle.Name = "tbTitle";
            this.tbTitle.Size = new System.Drawing.Size(319, 20);
            this.tbTitle.TabIndex = 1;
            this.tbTitle.TextChanged += new System.EventHandler(this.tbTitle_TextChanged);
            // 
            // tbDescription
            // 
            this.tbDescription.AcceptsReturn = true;
            this.tbDescription.Location = new System.Drawing.Point(340, 157);
            this.tbDescription.Multiline = true;
            this.tbDescription.Name = "tbDescription";
            this.tbDescription.Size = new System.Drawing.Size(319, 110);
            this.tbDescription.TabIndex = 2;
            this.tbDescription.TextChanged += new System.EventHandler(this.tbDescription_TextChanged);
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Location = new System.Drawing.Point(337, 96);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(27, 13);
            this.lblTitle.TabIndex = 3;
            this.lblTitle.Text = "Title";
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Location = new System.Drawing.Point(337, 141);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(60, 13);
            this.lblDescription.TabIndex = 4;
            this.lblDescription.Text = "Description";
            // 
            // cbMachine
            // 
            this.cbMachine.FormattingEnabled = true;
            this.cbMachine.Location = new System.Drawing.Point(340, 21);
            this.cbMachine.Name = "cbMachine";
            this.cbMachine.Size = new System.Drawing.Size(154, 21);
            this.cbMachine.TabIndex = 5;
            this.cbMachine.SelectedIndexChanged += new System.EventHandler(this.cbMachine_SelectedIndexChanged);
            // 
            // lblMachine
            // 
            this.lblMachine.AutoSize = true;
            this.lblMachine.Location = new System.Drawing.Point(337, 5);
            this.lblMachine.Name = "lblMachine";
            this.lblMachine.Size = new System.Drawing.Size(48, 13);
            this.lblMachine.TabIndex = 6;
            this.lblMachine.Text = "Machine";
            // 
            // pbCover
            // 
            this.pbCover.Location = new System.Drawing.Point(340, 273);
            this.pbCover.Name = "pbCover";
            this.pbCover.Size = new System.Drawing.Size(372, 243);
            this.pbCover.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbCover.TabIndex = 7;
            this.pbCover.TabStop = false;
            // 
            // btnScrapeGamesDb
            // 
            this.btnScrapeGamesDb.Location = new System.Drawing.Point(6, 141);
            this.btnScrapeGamesDb.Name = "btnScrapeGamesDb";
            this.btnScrapeGamesDb.Size = new System.Drawing.Size(162, 23);
            this.btnScrapeGamesDb.TabIndex = 8;
            this.btnScrapeGamesDb.Text = "Scrape with Gamesdb.net";
            this.btnScrapeGamesDb.UseVisualStyleBackColor = true;
            this.btnScrapeGamesDb.Click += new System.EventHandler(this.btnScrapeGamesDb_Click);
            // 
            // tbFilename
            // 
            this.tbFilename.Location = new System.Drawing.Point(340, 67);
            this.tbFilename.Name = "tbFilename";
            this.tbFilename.ReadOnly = true;
            this.tbFilename.Size = new System.Drawing.Size(299, 20);
            this.tbFilename.TabIndex = 9;
            // 
            // lblRomName
            // 
            this.lblRomName.AutoSize = true;
            this.lblRomName.Location = new System.Drawing.Point(337, 51);
            this.lblRomName.Name = "lblRomName";
            this.lblRomName.Size = new System.Drawing.Size(51, 13);
            this.lblRomName.TabIndex = 10;
            this.lblRomName.Text = "FileName";
            // 
            // btnRemoveCover
            // 
            this.btnRemoveCover.BackColor = System.Drawing.Color.Red;
            this.btnRemoveCover.Location = new System.Drawing.Point(6, 238);
            this.btnRemoveCover.Name = "btnRemoveCover";
            this.btnRemoveCover.Size = new System.Drawing.Size(109, 28);
            this.btnRemoveCover.TabIndex = 11;
            this.btnRemoveCover.Text = "Remove Cover";
            this.btnRemoveCover.UseVisualStyleBackColor = false;
            this.btnRemoveCover.Click += new System.EventHandler(this.btnRemoveCover_Click);
            // 
            // rbSize1
            // 
            this.rbSize1.AutoSize = true;
            this.rbSize1.Location = new System.Drawing.Point(6, 24);
            this.rbSize1.Name = "rbSize1";
            this.rbSize1.Size = new System.Drawing.Size(54, 17);
            this.rbSize1.TabIndex = 12;
            this.rbSize1.TabStop = true;
            this.rbSize1.Text = "Size 1";
            this.rbSize1.UseVisualStyleBackColor = true;
            this.rbSize1.CheckedChanged += new System.EventHandler(this.rbSize1_CheckedChanged);
            // 
            // rbSize2
            // 
            this.rbSize2.AutoSize = true;
            this.rbSize2.Location = new System.Drawing.Point(6, 47);
            this.rbSize2.Name = "rbSize2";
            this.rbSize2.Size = new System.Drawing.Size(54, 17);
            this.rbSize2.TabIndex = 13;
            this.rbSize2.TabStop = true;
            this.rbSize2.Text = "Size 2";
            this.rbSize2.UseVisualStyleBackColor = true;
            this.rbSize2.CheckedChanged += new System.EventHandler(this.rbSize2_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnBrowseCover);
            this.groupBox1.Controls.Add(this.rbSize2);
            this.groupBox1.Controls.Add(this.btnRemoveCover);
            this.groupBox1.Controls.Add(this.rbSize1);
            this.groupBox1.Location = new System.Drawing.Point(718, 273);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(121, 272);
            this.groupBox1.TabIndex = 14;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Cover settings";
            // 
            // btnBrowseCover
            // 
            this.btnBrowseCover.Location = new System.Drawing.Point(6, 209);
            this.btnBrowseCover.Name = "btnBrowseCover";
            this.btnBrowseCover.Size = new System.Drawing.Size(109, 23);
            this.btnBrowseCover.TabIndex = 14;
            this.btnBrowseCover.Text = "Browse...";
            this.btnBrowseCover.UseVisualStyleBackColor = true;
            this.btnBrowseCover.Click += new System.EventHandler(this.btnBrowseCover_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(337, 519);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(269, 20);
            this.label1.TabIndex = 15;
            this.label1.Text = "You can drag and drop cover file";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnGoogleSearch);
            this.groupBox2.Controls.Add(this.lblSpecificSearch);
            this.groupBox2.Controls.Add(this.tbSpecificScraperSearch);
            this.groupBox2.Controls.Add(this.btnScrapeGamesDb);
            this.groupBox2.Location = new System.Drawing.Point(665, 96);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(174, 171);
            this.groupBox2.TabIndex = 16;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Scraper settings";
            // 
            // btnGoogleSearch
            // 
            this.btnGoogleSearch.Location = new System.Drawing.Point(6, 112);
            this.btnGoogleSearch.Name = "btnGoogleSearch";
            this.btnGoogleSearch.Size = new System.Drawing.Size(162, 23);
            this.btnGoogleSearch.TabIndex = 11;
            this.btnGoogleSearch.Text = "Search cover on Google";
            this.btnGoogleSearch.UseVisualStyleBackColor = true;
            this.btnGoogleSearch.Click += new System.EventHandler(this.btnGoogleSearch_Click);
            // 
            // lblSpecificSearch
            // 
            this.lblSpecificSearch.AutoSize = true;
            this.lblSpecificSearch.Location = new System.Drawing.Point(6, 26);
            this.lblSpecificSearch.Name = "lblSpecificSearch";
            this.lblSpecificSearch.Size = new System.Drawing.Size(126, 13);
            this.lblSpecificSearch.TabIndex = 10;
            this.lblSpecificSearch.Text = "Specific search (optional)";
            // 
            // tbSpecificScraperSearch
            // 
            this.tbSpecificScraperSearch.Location = new System.Drawing.Point(7, 45);
            this.tbSpecificScraperSearch.Name = "tbSpecificScraperSearch";
            this.tbSpecificScraperSearch.Size = new System.Drawing.Size(161, 20);
            this.tbSpecificScraperSearch.TabIndex = 9;
            // 
            // btnCopyToPi
            // 
            this.btnCopyToPi.Location = new System.Drawing.Point(716, 46);
            this.btnCopyToPi.Name = "btnCopyToPi";
            this.btnCopyToPi.Size = new System.Drawing.Size(123, 23);
            this.btnCopyToPi.TabIndex = 17;
            this.btnCopyToPi.Text = "Copy on RaspberryPi";
            this.btnCopyToPi.UseVisualStyleBackColor = true;
            this.btnCopyToPi.Click += new System.EventHandler(this.btnCopyToPi_Click);
            // 
            // btnOpenSmbShare
            // 
            this.btnOpenSmbShare.Location = new System.Drawing.Point(592, 20);
            this.btnOpenSmbShare.Name = "btnOpenSmbShare";
            this.btnOpenSmbShare.Size = new System.Drawing.Size(122, 23);
            this.btnOpenSmbShare.TabIndex = 18;
            this.btnOpenSmbShare.Text = "Open Pi SMB Share";
            this.btnOpenSmbShare.UseVisualStyleBackColor = true;
            this.btnOpenSmbShare.Click += new System.EventHandler(this.btnOpenSmbShare_Click);
            // 
            // btnOpenRomFolder
            // 
            this.btnOpenRomFolder.Location = new System.Drawing.Point(716, 20);
            this.btnOpenRomFolder.Name = "btnOpenRomFolder";
            this.btnOpenRomFolder.Size = new System.Drawing.Size(123, 23);
            this.btnOpenRomFolder.TabIndex = 19;
            this.btnOpenRomFolder.Text = "Open Roms folder";
            this.btnOpenRomFolder.UseVisualStyleBackColor = true;
            this.btnOpenRomFolder.Click += new System.EventHandler(this.btnOpenRomFolder_Click);
            // 
            // MainForm
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(848, 556);
            this.Controls.Add(this.btnOpenRomFolder);
            this.Controls.Add(this.btnOpenSmbShare);
            this.Controls.Add(this.btnCopyToPi);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblRomName);
            this.Controls.Add(this.tbFilename);
            this.Controls.Add(this.pbCover);
            this.Controls.Add(this.lblMachine);
            this.Controls.Add(this.cbMachine);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.tbTitle);
            this.Controls.Add(this.tbDescription);
            this.Controls.Add(this.lbGames);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "ES-Manager";
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.MainForm_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.MainForm_DragEnter);
            ((System.ComponentModel.ISupportInitialize)(this.pbCover)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lbGames;
        private System.Windows.Forms.TextBox tbTitle;
        private System.Windows.Forms.TextBox tbDescription;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.ComboBox cbMachine;
        private System.Windows.Forms.Label lblMachine;
        private System.Windows.Forms.PictureBox pbCover;
        private System.Windows.Forms.Button btnScrapeGamesDb;
        private System.Windows.Forms.TextBox tbFilename;
        private System.Windows.Forms.Label lblRomName;
        private System.Windows.Forms.Button btnRemoveCover;
        private System.Windows.Forms.RadioButton rbSize1;
        private System.Windows.Forms.RadioButton rbSize2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnBrowseCover;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label lblSpecificSearch;
        private System.Windows.Forms.TextBox tbSpecificScraperSearch;
        private System.Windows.Forms.Button btnGoogleSearch;
        private System.Windows.Forms.Button btnCopyToPi;
        private System.Windows.Forms.Button btnOpenSmbShare;
        private System.Windows.Forms.Button btnOpenRomFolder;
    }
}

