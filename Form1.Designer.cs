namespace file_manager
{
    partial class Formwindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Formwindow));
            this.discsCombo = new System.Windows.Forms.ComboBox();
            this.pathBox = new System.Windows.Forms.TextBox();
            this.dirListView = new System.Windows.Forms.ListView();
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.discsCombo2 = new System.Windows.Forms.ComboBox();
            this.pathBox2 = new System.Windows.Forms.TextBox();
            this.dirListView2 = new System.Windows.Forms.ListView();
            this.spaceLabel = new System.Windows.Forms.Label();
            this.spaceLabel2 = new System.Windows.Forms.Label();
            this.moveButton = new System.Windows.Forms.Button();
            this.addFolderButton = new System.Windows.Forms.Button();
            this.focusCheckbox = new System.Windows.Forms.CheckBox();
            this.copyButton = new System.Windows.Forms.Button();
            this.backButton = new System.Windows.Forms.Button();
            this.renameButton = new System.Windows.Forms.Button();
            this.deleteFolderButton = new System.Windows.Forms.Button();
            this.infoButton = new System.Windows.Forms.Button();
            this.previewButton = new System.Windows.Forms.Button();
            this.searchBox = new System.Windows.Forms.TextBox();
            this.searchButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // discsCombo
            // 
            this.discsCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.discsCombo.Location = new System.Drawing.Point(1, 3);
            this.discsCombo.Name = "discsCombo";
            this.discsCombo.Size = new System.Drawing.Size(85, 21);
            this.discsCombo.TabIndex = 3;
            this.discsCombo.SelectedIndexChanged += new System.EventHandler(this.discsCombo_SelectedIndexChanged);
            // 
            // pathBox
            // 
            this.pathBox.Location = new System.Drawing.Point(1, 72);
            this.pathBox.Name = "pathBox";
            this.pathBox.Size = new System.Drawing.Size(440, 20);
            this.pathBox.TabIndex = 4;
            // 
            // dirListView
            // 
            this.dirListView.HideSelection = false;
            this.dirListView.LargeImageList = this.imageList;
            this.dirListView.Location = new System.Drawing.Point(1, 98);
            this.dirListView.Name = "dirListView";
            this.dirListView.Size = new System.Drawing.Size(440, 440);
            this.dirListView.SmallImageList = this.imageList;
            this.dirListView.TabIndex = 5;
            this.dirListView.UseCompatibleStateImageBehavior = false;
            this.dirListView.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.dirListView_ItemSelectionChanged);
            this.dirListView.DoubleClick += new System.EventHandler(this.dirListView_DoubleClick);
            // 
            // imageList
            // 
            this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
            this.imageList.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList.Images.SetKeyName(0, "folder.png");
            // 
            // discsCombo2
            // 
            this.discsCombo2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.discsCombo2.FormattingEnabled = true;
            this.discsCombo2.Location = new System.Drawing.Point(447, 3);
            this.discsCombo2.Name = "discsCombo2";
            this.discsCombo2.Size = new System.Drawing.Size(85, 21);
            this.discsCombo2.TabIndex = 6;
            this.discsCombo2.SelectedIndexChanged += new System.EventHandler(this.discsCombo2_SelectedIndexChanged);
            // 
            // pathBox2
            // 
            this.pathBox2.Location = new System.Drawing.Point(447, 72);
            this.pathBox2.Name = "pathBox2";
            this.pathBox2.Size = new System.Drawing.Size(440, 20);
            this.pathBox2.TabIndex = 7;
            // 
            // dirListView2
            // 
            this.dirListView2.HideSelection = false;
            this.dirListView2.LargeImageList = this.imageList;
            this.dirListView2.Location = new System.Drawing.Point(447, 98);
            this.dirListView2.Name = "dirListView2";
            this.dirListView2.Size = new System.Drawing.Size(440, 440);
            this.dirListView2.SmallImageList = this.imageList;
            this.dirListView2.TabIndex = 8;
            this.dirListView2.UseCompatibleStateImageBehavior = false;
            this.dirListView2.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.dirListView2_ItemSelectionChanged);
            this.dirListView2.DoubleClick += new System.EventHandler(this.dirListView2_DoubleClick);
            // 
            // spaceLabel
            // 
            this.spaceLabel.AutoSize = true;
            this.spaceLabel.Location = new System.Drawing.Point(92, 6);
            this.spaceLabel.Name = "spaceLabel";
            this.spaceLabel.Size = new System.Drawing.Size(87, 13);
            this.spaceLabel.TabIndex = 9;
            this.spaceLabel.Text = "Space Available:";
            // 
            // spaceLabel2
            // 
            this.spaceLabel2.AutoSize = true;
            this.spaceLabel2.Location = new System.Drawing.Point(538, 6);
            this.spaceLabel2.Name = "spaceLabel2";
            this.spaceLabel2.Size = new System.Drawing.Size(87, 13);
            this.spaceLabel2.TabIndex = 10;
            this.spaceLabel2.Text = "Space Available:";
            // 
            // moveButton
            // 
            this.moveButton.Location = new System.Drawing.Point(410, 43);
            this.moveButton.Name = "moveButton";
            this.moveButton.Size = new System.Drawing.Size(75, 23);
            this.moveButton.TabIndex = 11;
            this.moveButton.Text = "<- Move ->";
            this.moveButton.UseVisualStyleBackColor = true;
            this.moveButton.Click += new System.EventHandler(this.moveButton_Click);
            // 
            // addFolderButton
            // 
            this.addFolderButton.Location = new System.Drawing.Point(1, 43);
            this.addFolderButton.Name = "addFolderButton";
            this.addFolderButton.Size = new System.Drawing.Size(85, 23);
            this.addFolderButton.TabIndex = 12;
            this.addFolderButton.Text = "Add Folder (L)";
            this.addFolderButton.UseVisualStyleBackColor = true;
            this.addFolderButton.Click += new System.EventHandler(this.addFolderButton_Click);
            // 
            // focusCheckbox
            // 
            this.focusCheckbox.AutoSize = true;
            this.focusCheckbox.Location = new System.Drawing.Point(329, 47);
            this.focusCheckbox.Name = "focusCheckbox";
            this.focusCheckbox.Size = new System.Drawing.Size(75, 17);
            this.focusCheckbox.TabIndex = 13;
            this.focusCheckbox.Text = "LCtrl (L/R)";
            this.focusCheckbox.UseVisualStyleBackColor = true;
            this.focusCheckbox.CheckedChanged += new System.EventHandler(this.focusCheckbox_CheckedChanged);
            // 
            // copyButton
            // 
            this.copyButton.Location = new System.Drawing.Point(95, 43);
            this.copyButton.Name = "copyButton";
            this.copyButton.Size = new System.Drawing.Size(66, 23);
            this.copyButton.TabIndex = 14;
            this.copyButton.Text = "Copy (L)";
            this.copyButton.UseVisualStyleBackColor = true;
            this.copyButton.Click += new System.EventHandler(this.copyButton_Click);
            // 
            // backButton
            // 
            this.backButton.Location = new System.Drawing.Point(167, 43);
            this.backButton.Name = "backButton";
            this.backButton.Size = new System.Drawing.Size(75, 23);
            this.backButton.TabIndex = 15;
            this.backButton.Text = "Back (L)";
            this.backButton.UseVisualStyleBackColor = true;
            this.backButton.Click += new System.EventHandler(this.backButton_Click);
            // 
            // renameButton
            // 
            this.renameButton.Location = new System.Drawing.Point(248, 43);
            this.renameButton.Name = "renameButton";
            this.renameButton.Size = new System.Drawing.Size(75, 23);
            this.renameButton.TabIndex = 16;
            this.renameButton.Text = "Rename (L)";
            this.renameButton.UseVisualStyleBackColor = true;
            this.renameButton.Click += new System.EventHandler(this.renameButton_Click);
            // 
            // deleteFolderButton
            // 
            this.deleteFolderButton.Location = new System.Drawing.Point(492, 43);
            this.deleteFolderButton.Name = "deleteFolderButton";
            this.deleteFolderButton.Size = new System.Drawing.Size(104, 23);
            this.deleteFolderButton.TabIndex = 17;
            this.deleteFolderButton.Text = "Delete Folder (L)";
            this.deleteFolderButton.UseVisualStyleBackColor = true;
            this.deleteFolderButton.Click += new System.EventHandler(this.deleteFolderButton_Click);
            // 
            // infoButton
            // 
            this.infoButton.Location = new System.Drawing.Point(602, 43);
            this.infoButton.Name = "infoButton";
            this.infoButton.Size = new System.Drawing.Size(65, 23);
            this.infoButton.TabIndex = 18;
            this.infoButton.Text = "Info (L)";
            this.infoButton.UseVisualStyleBackColor = true;
            this.infoButton.Click += new System.EventHandler(this.infoButton_Click);
            // 
            // previewButton
            // 
            this.previewButton.Location = new System.Drawing.Point(673, 43);
            this.previewButton.Name = "previewButton";
            this.previewButton.Size = new System.Drawing.Size(75, 23);
            this.previewButton.TabIndex = 19;
            this.previewButton.Text = "Preview (L)";
            this.previewButton.UseVisualStyleBackColor = true;
            this.previewButton.Click += new System.EventHandler(this.previewButton_Click);
            // 
            // searchBox
            // 
            this.searchBox.Location = new System.Drawing.Point(754, 45);
            this.searchBox.Name = "searchBox";
            this.searchBox.Size = new System.Drawing.Size(97, 20);
            this.searchBox.TabIndex = 20;
            // 
            // searchButton
            // 
            this.searchButton.Location = new System.Drawing.Point(857, 43);
            this.searchButton.Name = "searchButton";
            this.searchButton.Size = new System.Drawing.Size(29, 23);
            this.searchButton.TabIndex = 21;
            this.searchButton.Text = "(L)";
            this.searchButton.UseVisualStyleBackColor = true;
            this.searchButton.Click += new System.EventHandler(this.searchButton_Click);
            // 
            // Formwindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(889, 541);
            this.Controls.Add(this.searchButton);
            this.Controls.Add(this.searchBox);
            this.Controls.Add(this.previewButton);
            this.Controls.Add(this.infoButton);
            this.Controls.Add(this.deleteFolderButton);
            this.Controls.Add(this.renameButton);
            this.Controls.Add(this.backButton);
            this.Controls.Add(this.copyButton);
            this.Controls.Add(this.focusCheckbox);
            this.Controls.Add(this.addFolderButton);
            this.Controls.Add(this.moveButton);
            this.Controls.Add(this.spaceLabel2);
            this.Controls.Add(this.spaceLabel);
            this.Controls.Add(this.dirListView2);
            this.Controls.Add(this.pathBox2);
            this.Controls.Add(this.discsCombo2);
            this.Controls.Add(this.dirListView);
            this.Controls.Add(this.pathBox);
            this.Controls.Add(this.discsCombo);
            this.KeyPreview = true;
            this.MaximumSize = new System.Drawing.Size(905, 580);
            this.MinimumSize = new System.Drawing.Size(905, 580);
            this.Name = "Formwindow";
            this.Text = "File Manager";
            this.Load += new System.EventHandler(this.Formwindow_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Formwindow_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox discsCombo;
        private System.Windows.Forms.TextBox pathBox;
        private System.Windows.Forms.ListView dirListView;
        private System.Windows.Forms.ComboBox discsCombo2;
        private System.Windows.Forms.TextBox pathBox2;
        private System.Windows.Forms.ListView dirListView2;
        public System.Windows.Forms.ImageList imageList;
        private System.Windows.Forms.Label spaceLabel;
        private System.Windows.Forms.Label spaceLabel2;
        private System.Windows.Forms.Button moveButton;
        private System.Windows.Forms.Button addFolderButton;
        private System.Windows.Forms.CheckBox focusCheckbox;
        private System.Windows.Forms.Button copyButton;
        private System.Windows.Forms.Button backButton;
        private System.Windows.Forms.Button renameButton;
        private System.Windows.Forms.Button deleteFolderButton;
        private System.Windows.Forms.Button infoButton;
        private System.Windows.Forms.Button previewButton;
        private System.Windows.Forms.TextBox searchBox;
        private System.Windows.Forms.Button searchButton;
    }
}

