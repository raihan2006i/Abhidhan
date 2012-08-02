namespace Abhidhan
{
    partial class Abhidhan
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Abhidhan));
            this.notifyIconTray = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStripTray = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.TrayMenuSimilarWord = new System.Windows.Forms.ToolStripMenuItem();
            this.TrayMenuBanglaWordSearch = new System.Windows.Forms.ToolStripMenuItem();
            this.TrayMenuEnglishWordSearch = new System.Windows.Forms.ToolStripMenuItem();
            this.TrayMenuShowPopUp = new System.Windows.Forms.ToolStripMenuItem();
            this.Restore = new System.Windows.Forms.ToolStripMenuItem();
            this.CloseApp = new System.Windows.Forms.ToolStripMenuItem();
            this.textBoxSearchKeyWord = new System.Windows.Forms.TextBox();
            this.labelSearchKeyWord = new System.Windows.Forms.Label();
            this.textBoxResult = new System.Windows.Forms.TextBox();
            this.groupBoxSimilarWord = new System.Windows.Forms.GroupBox();
            this.dataGridViewSimilarWord = new System.Windows.Forms.DataGridView();
            this.groupBoxSearchResult = new System.Windows.Forms.GroupBox();
            this.groupBoxSearchKeyWord = new System.Windows.Forms.GroupBox();
            this.buttonSearch = new System.Windows.Forms.Button();
            this.menuStripTopMenu = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.TopMenuSimilarWord = new System.Windows.Forms.ToolStripMenuItem();
            this.TopMenuBanglaWordSearch = new System.Windows.Forms.ToolStripMenuItem();
            this.TopMenuEnglishWordSearch = new System.Windows.Forms.ToolStripMenuItem();
            this.TopMenuShowPopUp = new System.Windows.Forms.ToolStripMenuItem();
            this.minimizeToTrayToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.languageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.TopMenuBanglaLanguage = new System.Windows.Forms.ToolStripMenuItem();
            this.TopMenuEnglishLanguage = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStripTray.SuspendLayout();
            this.groupBoxSimilarWord.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSimilarWord)).BeginInit();
            this.groupBoxSearchResult.SuspendLayout();
            this.groupBoxSearchKeyWord.SuspendLayout();
            this.menuStripTopMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // notifyIconTray
            // 
            this.notifyIconTray.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.notifyIconTray.ContextMenuStrip = this.contextMenuStripTray;
            this.notifyIconTray.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIconTray.Icon")));
            this.notifyIconTray.Text = "Abhidhan";
            this.notifyIconTray.Visible = true;
            this.notifyIconTray.DoubleClick += new System.EventHandler(this.notifyIconTray_DoubleClick);
            this.notifyIconTray.MouseClick += new System.Windows.Forms.MouseEventHandler(this.notifyIconTray_MouseClick);
            // 
            // contextMenuStripTray
            // 
            this.contextMenuStripTray.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.contextMenuStripTray.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TrayMenuSimilarWord,
            this.TrayMenuBanglaWordSearch,
            this.TrayMenuEnglishWordSearch,
            this.TrayMenuShowPopUp,
            this.Restore,
            this.CloseApp});
            this.contextMenuStripTray.Name = "contextMenuStripTray";
            this.contextMenuStripTray.Size = new System.Drawing.Size(300, 148);
            // 
            // TrayMenuSimilarWord
            // 
            this.TrayMenuSimilarWord.Checked = true;
            this.TrayMenuSimilarWord.CheckState = System.Windows.Forms.CheckState.Checked;
            this.TrayMenuSimilarWord.Image = global::Abhidhan.Properties.Resources.s_13;
            this.TrayMenuSimilarWord.Name = "TrayMenuSimilarWord";
            this.TrayMenuSimilarWord.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.D0)));
            this.TrayMenuSimilarWord.Size = new System.Drawing.Size(299, 24);
            this.TrayMenuSimilarWord.Text = "কাছাকছি শব্দ দেখাও";
            this.TrayMenuSimilarWord.ToolTipText = "Click here to show Similar word";
            this.TrayMenuSimilarWord.Click += new System.EventHandler(this.TrayMenuSimilarWord_Click);
            // 
            // TrayMenuBanglaWordSearch
            // 
            this.TrayMenuBanglaWordSearch.Checked = true;
            this.TrayMenuBanglaWordSearch.CheckState = System.Windows.Forms.CheckState.Checked;
            this.TrayMenuBanglaWordSearch.Name = "TrayMenuBanglaWordSearch";
            this.TrayMenuBanglaWordSearch.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.D1)));
            this.TrayMenuBanglaWordSearch.Size = new System.Drawing.Size(299, 24);
            this.TrayMenuBanglaWordSearch.Text = "বাংলা শব্দ অনুসন্ধান";
            this.TrayMenuBanglaWordSearch.ToolTipText = "Click here to enable Bangla word search";
            this.TrayMenuBanglaWordSearch.Click += new System.EventHandler(this.TrayMenuBanglaWordSearch_Click);
            // 
            // TrayMenuEnglishWordSearch
            // 
            this.TrayMenuEnglishWordSearch.Name = "TrayMenuEnglishWordSearch";
            this.TrayMenuEnglishWordSearch.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.D2)));
            this.TrayMenuEnglishWordSearch.Size = new System.Drawing.Size(299, 24);
            this.TrayMenuEnglishWordSearch.Text = "ইংরেজি শব্দ অনুসন্ধান";
            this.TrayMenuEnglishWordSearch.ToolTipText = "Click here to enable English word search";
            this.TrayMenuEnglishWordSearch.Click += new System.EventHandler(this.TrayMenuEnglishWordSearch_Click);
            // 
            // TrayMenuShowPopUp
            // 
            this.TrayMenuShowPopUp.Image = global::Abhidhan.Properties.Resources.s_48;
            this.TrayMenuShowPopUp.Name = "TrayMenuShowPopUp";
            this.TrayMenuShowPopUp.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.D3)));
            this.TrayMenuShowPopUp.Size = new System.Drawing.Size(299, 24);
            this.TrayMenuShowPopUp.Text = "Ctrl+C এর জন্য Popup দেখাও";
            this.TrayMenuShowPopUp.TextDirection = System.Windows.Forms.ToolStripTextDirection.Horizontal;
            this.TrayMenuShowPopUp.ToolTipText = "Click here to enable pop up search";
            this.TrayMenuShowPopUp.Click += new System.EventHandler(this.TrayMenuShowPopUp_Click);
            // 
            // Restore
            // 
            this.Restore.Image = global::Abhidhan.Properties.Resources.s_35;
            this.Restore.Name = "Restore";
            this.Restore.Size = new System.Drawing.Size(299, 24);
            this.Restore.Text = "System tray -থেকে পুনরুদ্ধার";
            this.Restore.ToolTipText = "Click here to restore Abhidhan from system tray";
            this.Restore.Click += new System.EventHandler(this.Restore_Click);
            // 
            // CloseApp
            // 
            this.CloseApp.Image = global::Abhidhan.Properties.Resources.s_33;
            this.CloseApp.Name = "CloseApp";
            this.CloseApp.Size = new System.Drawing.Size(299, 24);
            this.CloseApp.Text = "Exit";
            this.CloseApp.ToolTipText = "Click here to close Abhidhan";
            this.CloseApp.Click += new System.EventHandler(this.Close_Click);
            // 
            // textBoxSearchKeyWord
            // 
            this.textBoxSearchKeyWord.Font = new System.Drawing.Font("Siyam Rupali", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxSearchKeyWord.Location = new System.Drawing.Point(84, 17);
            this.textBoxSearchKeyWord.Name = "textBoxSearchKeyWord";
            this.textBoxSearchKeyWord.Size = new System.Drawing.Size(221, 39);
            this.textBoxSearchKeyWord.TabIndex = 1;
            // 
            // labelSearchKeyWord
            // 
            this.labelSearchKeyWord.AutoSize = true;
            this.labelSearchKeyWord.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSearchKeyWord.Location = new System.Drawing.Point(7, 24);
            this.labelSearchKeyWord.Name = "labelSearchKeyWord";
            this.labelSearchKeyWord.Size = new System.Drawing.Size(37, 24);
            this.labelSearchKeyWord.TabIndex = 2;
            this.labelSearchKeyWord.Text = "শব্দঃ";
            // 
            // textBoxResult
            // 
            this.textBoxResult.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxResult.Location = new System.Drawing.Point(6, 19);
            this.textBoxResult.Multiline = true;
            this.textBoxResult.Name = "textBoxResult";
            this.textBoxResult.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBoxResult.Size = new System.Drawing.Size(247, 279);
            this.textBoxResult.TabIndex = 0;
            // 
            // groupBoxSimilarWord
            // 
            this.groupBoxSimilarWord.Controls.Add(this.dataGridViewSimilarWord);
            this.groupBoxSimilarWord.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxSimilarWord.Location = new System.Drawing.Point(12, 106);
            this.groupBoxSimilarWord.Name = "groupBoxSimilarWord";
            this.groupBoxSimilarWord.Size = new System.Drawing.Size(422, 229);
            this.groupBoxSimilarWord.TabIndex = 5;
            this.groupBoxSimilarWord.TabStop = false;
            this.groupBoxSimilarWord.Text = "কাছাকছি শব্দ";
            // 
            // dataGridViewSimilarWord
            // 
            this.dataGridViewSimilarWord.AllowUserToAddRows = false;
            this.dataGridViewSimilarWord.AllowUserToDeleteRows = false;
            this.dataGridViewSimilarWord.AllowUserToResizeColumns = false;
            this.dataGridViewSimilarWord.AllowUserToResizeRows = false;
            this.dataGridViewSimilarWord.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewSimilarWord.ColumnHeadersHeight = 30;
            this.dataGridViewSimilarWord.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridViewSimilarWord.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGridViewSimilarWord.Location = new System.Drawing.Point(6, 19);
            this.dataGridViewSimilarWord.MinimumSize = new System.Drawing.Size(354, 150);
            this.dataGridViewSimilarWord.MultiSelect = false;
            this.dataGridViewSimilarWord.Name = "dataGridViewSimilarWord";
            this.dataGridViewSimilarWord.ReadOnly = true;
            this.dataGridViewSimilarWord.RowHeadersWidth = 30;
            this.dataGridViewSimilarWord.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dataGridViewSimilarWord.RowTemplate.ReadOnly = true;
            this.dataGridViewSimilarWord.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewSimilarWord.Size = new System.Drawing.Size(410, 204);
            this.dataGridViewSimilarWord.TabIndex = 8;
            this.dataGridViewSimilarWord.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewSimilarWord_RowEnter);
            // 
            // groupBoxSearchResult
            // 
            this.groupBoxSearchResult.Controls.Add(this.textBoxResult);
            this.groupBoxSearchResult.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxSearchResult.Location = new System.Drawing.Point(440, 31);
            this.groupBoxSearchResult.Name = "groupBoxSearchResult";
            this.groupBoxSearchResult.Size = new System.Drawing.Size(259, 304);
            this.groupBoxSearchResult.TabIndex = 6;
            this.groupBoxSearchResult.TabStop = false;
            this.groupBoxSearchResult.Text = "ফলাফল";
            // 
            // groupBoxSearchKeyWord
            // 
            this.groupBoxSearchKeyWord.Controls.Add(this.labelSearchKeyWord);
            this.groupBoxSearchKeyWord.Controls.Add(this.textBoxSearchKeyWord);
            this.groupBoxSearchKeyWord.Controls.Add(this.buttonSearch);
            this.groupBoxSearchKeyWord.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxSearchKeyWord.Location = new System.Drawing.Point(12, 31);
            this.groupBoxSearchKeyWord.Name = "groupBoxSearchKeyWord";
            this.groupBoxSearchKeyWord.Size = new System.Drawing.Size(422, 69);
            this.groupBoxSearchKeyWord.TabIndex = 0;
            this.groupBoxSearchKeyWord.TabStop = false;
            this.groupBoxSearchKeyWord.Text = "অনুসন্ধান";
            // 
            // buttonSearch
            // 
            this.buttonSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSearch.Image = global::Abhidhan.Properties.Resources.s_65;
            this.buttonSearch.Location = new System.Drawing.Point(311, 17);
            this.buttonSearch.Name = "buttonSearch";
            this.buttonSearch.Size = new System.Drawing.Size(105, 39);
            this.buttonSearch.TabIndex = 4;
            this.buttonSearch.Text = "অনুসন্ধান";
            this.buttonSearch.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonSearch.UseVisualStyleBackColor = true;
            this.buttonSearch.Click += new System.EventHandler(this.buttonSearch_Click);
            // 
            // menuStripTopMenu
            // 
            this.menuStripTopMenu.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStripTopMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem1,
            this.fileToolStripMenuItem,
            this.helpToolStripMenuItem,
            this.languageToolStripMenuItem});
            this.menuStripTopMenu.Location = new System.Drawing.Point(0, 0);
            this.menuStripTopMenu.Name = "menuStripTopMenu";
            this.menuStripTopMenu.Size = new System.Drawing.Size(711, 28);
            this.menuStripTopMenu.TabIndex = 7;
            this.menuStripTopMenu.Text = "Top Menu";
            // 
            // fileToolStripMenuItem1
            // 
            this.fileToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem1.Image = global::Abhidhan.Properties.Resources.s_62;
            this.fileToolStripMenuItem1.Name = "fileToolStripMenuItem1";
            this.fileToolStripMenuItem1.Size = new System.Drawing.Size(67, 24);
            this.fileToolStripMenuItem1.Text = "ফাইল";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Image = global::Abhidhan.Properties.Resources.s_33;
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(127, 24);
            this.exitToolStripMenuItem.Text = "প্রস্থান কর";
            this.exitToolStripMenuItem.ToolTipText = "Click here to close Abhidhan";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TopMenuSimilarWord,
            this.TopMenuBanglaWordSearch,
            this.TopMenuEnglishWordSearch,
            this.TopMenuShowPopUp,
            this.minimizeToTrayToolStripMenuItem});
            this.fileToolStripMenuItem.Image = global::Abhidhan.Properties.Resources.s_73;
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(74, 24);
            this.fileToolStripMenuItem.Text = "অপশন";
            // 
            // TopMenuSimilarWord
            // 
            this.TopMenuSimilarWord.Checked = true;
            this.TopMenuSimilarWord.CheckState = System.Windows.Forms.CheckState.Checked;
            this.TopMenuSimilarWord.Image = global::Abhidhan.Properties.Resources.s_13;
            this.TopMenuSimilarWord.Name = "TopMenuSimilarWord";
            this.TopMenuSimilarWord.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.D0)));
            this.TopMenuSimilarWord.Size = new System.Drawing.Size(299, 24);
            this.TopMenuSimilarWord.Text = "কাছাকছি শব্দ দেখাও";
            this.TopMenuSimilarWord.ToolTipText = "Click here to show Similar word";
            this.TopMenuSimilarWord.CheckedChanged += new System.EventHandler(this.TopMenuSimilarWord_CheckedChanged);
            this.TopMenuSimilarWord.Click += new System.EventHandler(this.TopMenuSimilarWord_Click);
            // 
            // TopMenuBanglaWordSearch
            // 
            this.TopMenuBanglaWordSearch.Checked = true;
            this.TopMenuBanglaWordSearch.CheckState = System.Windows.Forms.CheckState.Checked;
            this.TopMenuBanglaWordSearch.Name = "TopMenuBanglaWordSearch";
            this.TopMenuBanglaWordSearch.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.D1)));
            this.TopMenuBanglaWordSearch.Size = new System.Drawing.Size(299, 24);
            this.TopMenuBanglaWordSearch.Text = "বাংলা শব্দ অনুসন্ধান";
            this.TopMenuBanglaWordSearch.ToolTipText = "Click here to enable Bangla word search";
            this.TopMenuBanglaWordSearch.CheckedChanged += new System.EventHandler(this.TopMenuBanglaWordSearch_CheckedChanged);
            this.TopMenuBanglaWordSearch.Click += new System.EventHandler(this.TopMenuBanglaWordSearch_Click);
            // 
            // TopMenuEnglishWordSearch
            // 
            this.TopMenuEnglishWordSearch.Name = "TopMenuEnglishWordSearch";
            this.TopMenuEnglishWordSearch.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.D2)));
            this.TopMenuEnglishWordSearch.Size = new System.Drawing.Size(299, 24);
            this.TopMenuEnglishWordSearch.Text = "ইংরেজি শব্দ অনুসন্ধান";
            this.TopMenuEnglishWordSearch.ToolTipText = "Click here to enable English word search";
            this.TopMenuEnglishWordSearch.Click += new System.EventHandler(this.TopMenuEnglishWordSearch_Click);
            // 
            // TopMenuShowPopUp
            // 
            this.TopMenuShowPopUp.Image = global::Abhidhan.Properties.Resources.s_48;
            this.TopMenuShowPopUp.Name = "TopMenuShowPopUp";
            this.TopMenuShowPopUp.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.D3)));
            this.TopMenuShowPopUp.Size = new System.Drawing.Size(299, 24);
            this.TopMenuShowPopUp.Text = "Ctrl+C এর জন্য Popup দেখাও";
            this.TopMenuShowPopUp.ToolTipText = "Click here to enable pop up search";
            this.TopMenuShowPopUp.CheckedChanged += new System.EventHandler(this.TopMenuShowPopUp_CheckedChanged);
            this.TopMenuShowPopUp.Click += new System.EventHandler(this.TopMenuShowPopUp_Click);
            // 
            // minimizeToTrayToolStripMenuItem
            // 
            this.minimizeToTrayToolStripMenuItem.Image = global::Abhidhan.Properties.Resources.s_37;
            this.minimizeToTrayToolStripMenuItem.Name = "minimizeToTrayToolStripMenuItem";
            this.minimizeToTrayToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.D4)));
            this.minimizeToTrayToolStripMenuItem.Size = new System.Drawing.Size(299, 24);
            this.minimizeToTrayToolStripMenuItem.Text = "System tray -তে আড়াল কর";
            this.minimizeToTrayToolStripMenuItem.ToolTipText = "Click here to send Abhidhan to system tray";
            this.minimizeToTrayToolStripMenuItem.Click += new System.EventHandler(this.minimizeToTrayToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Image = global::Abhidhan.Properties.Resources.s_81;
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(56, 24);
            this.helpToolStripMenuItem.Text = "হেল্প";
            this.helpToolStripMenuItem.ToolTipText = "About Abhidhan";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Image = global::Abhidhan.Properties.Resources.s_4;
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(119, 24);
            this.aboutToolStripMenuItem.Text = "পরিচিতি";
            this.aboutToolStripMenuItem.ToolTipText = "About Abhidhan";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // languageToolStripMenuItem
            // 
            this.languageToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TopMenuBanglaLanguage,
            this.TopMenuEnglishLanguage});
            this.languageToolStripMenuItem.Name = "languageToolStripMenuItem";
            this.languageToolStripMenuItem.Size = new System.Drawing.Size(45, 24);
            this.languageToolStripMenuItem.Text = "ভাষা";
            this.languageToolStripMenuItem.ToolTipText = "Click here to change Language";
            // 
            // TopMenuBanglaLanguage
            // 
            this.TopMenuBanglaLanguage.Checked = true;
            this.TopMenuBanglaLanguage.CheckState = System.Windows.Forms.CheckState.Checked;
            this.TopMenuBanglaLanguage.Name = "TopMenuBanglaLanguage";
            this.TopMenuBanglaLanguage.Size = new System.Drawing.Size(116, 24);
            this.TopMenuBanglaLanguage.Text = "বাংলা";
            this.TopMenuBanglaLanguage.CheckedChanged += new System.EventHandler(this.TopMenuBanglaLanguage_CheckedChanged);
            this.TopMenuBanglaLanguage.Click += new System.EventHandler(this.TopMenuBanglaLanguage_Click);
            // 
            // TopMenuEnglishLanguage
            // 
            this.TopMenuEnglishLanguage.Name = "TopMenuEnglishLanguage";
            this.TopMenuEnglishLanguage.Size = new System.Drawing.Size(116, 24);
            this.TopMenuEnglishLanguage.Text = "ইংরেজি";
            this.TopMenuEnglishLanguage.CheckedChanged += new System.EventHandler(this.TopMenuEnglishLanguage_CheckedChanged);
            this.TopMenuEnglishLanguage.Click += new System.EventHandler(this.TopMenuEnglishLanguage_Click);
            // 
            // Abhidhan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(711, 347);
            this.Controls.Add(this.menuStripTopMenu);
            this.Controls.Add(this.groupBoxSimilarWord);
            this.Controls.Add(this.groupBoxSearchResult);
            this.Controls.Add(this.groupBoxSearchKeyWord);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStripTopMenu;
            this.MaximizeBox = false;
            this.Name = "Abhidhan";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Anubad  Abhidhan  | অনুবাদ অভিধান";
            this.Load += new System.EventHandler(this.Abhidhan_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Abhidhan_FormClosing);
            this.Resize += new System.EventHandler(this.Abhidhan_Resize);
            this.contextMenuStripTray.ResumeLayout(false);
            this.groupBoxSimilarWord.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSimilarWord)).EndInit();
            this.groupBoxSearchResult.ResumeLayout(false);
            this.groupBoxSearchResult.PerformLayout();
            this.groupBoxSearchKeyWord.ResumeLayout(false);
            this.groupBoxSearchKeyWord.PerformLayout();
            this.menuStripTopMenu.ResumeLayout(false);
            this.menuStripTopMenu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NotifyIcon notifyIconTray;
        private System.Windows.Forms.TextBox textBoxSearchKeyWord;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripTray;
        private System.Windows.Forms.ToolStripMenuItem CloseApp;
        private System.Windows.Forms.ToolStripMenuItem Restore;
        private System.Windows.Forms.ToolStripMenuItem TrayMenuShowPopUp;
        private System.Windows.Forms.Label labelSearchKeyWord;
        private System.Windows.Forms.Button buttonSearch;
        private System.Windows.Forms.TextBox textBoxResult;
        private System.Windows.Forms.GroupBox groupBoxSimilarWord;
        private System.Windows.Forms.GroupBox groupBoxSearchResult;
        private System.Windows.Forms.GroupBox groupBoxSearchKeyWord;
        private System.Windows.Forms.MenuStrip menuStripTopMenu;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem minimizeToTrayToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem TopMenuShowPopUp;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem TopMenuBanglaWordSearch;
        private System.Windows.Forms.ToolStripMenuItem TopMenuEnglishWordSearch;
        private System.Windows.Forms.ToolStripMenuItem TrayMenuBanglaWordSearch;
        private System.Windows.Forms.ToolStripMenuItem TrayMenuEnglishWordSearch;
        private System.Windows.Forms.ToolStripMenuItem TopMenuSimilarWord;
        private System.Windows.Forms.ToolStripMenuItem TrayMenuSimilarWord;
        private System.Windows.Forms.DataGridView dataGridViewSimilarWord;
        private System.Windows.Forms.ToolStripMenuItem languageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem TopMenuBanglaLanguage;
        private System.Windows.Forms.ToolStripMenuItem TopMenuEnglishLanguage;
    }
}

