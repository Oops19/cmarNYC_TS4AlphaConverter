namespace TS4AlphaConverter
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
            this.PackageSelect_button = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.label2 = new System.Windows.Forms.Label();
            this.FolderSelect_button = new System.Windows.Forms.Button();
            this.OutputSelect_button = new System.Windows.Forms.Button();
            this.FolderName = new System.Windows.Forms.TextBox();
            this.OutputName = new System.Windows.Forms.TextBox();
            this.FolderGo_button = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.ConvertLRLE_radioButton = new System.Windows.Forms.RadioButton();
            this.UpdateLRLE_radioButton = new System.Windows.Forms.RadioButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.ConvertAll_radioButton = new System.Windows.Forms.RadioButton();
            this.LinkedOnly_radioButton = new System.Windows.Forms.RadioButton();
            this.NoCopy_checkBox = new System.Windows.Forms.CheckBox();
            this.NoRename_checkBox = new System.Windows.Forms.CheckBox();
            this.LinkedOptions_panel = new System.Windows.Forms.Panel();
            this.DoAll_checkBox = new System.Windows.Forms.CheckBox();
            this.DoMakeup_checkBox = new System.Windows.Forms.CheckBox();
            this.DoSkinDetails_checkBox = new System.Windows.Forms.CheckBox();
            this.DoHair_checkBox = new System.Windows.Forms.CheckBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.Subfolders_checkBox = new System.Windows.Forms.CheckBox();
            this.ConvertRLE2_radioButton = new System.Windows.Forms.RadioButton();
            this.statusStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.LinkedOptions_panel.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // PackageSelect_button
            // 
            this.PackageSelect_button.Location = new System.Drawing.Point(22, 21);
            this.PackageSelect_button.Name = "PackageSelect_button";
            this.PackageSelect_button.Size = new System.Drawing.Size(658, 64);
            this.PackageSelect_button.TabIndex = 2;
            this.PackageSelect_button.Text = "Select Package - LRLE textures will be converted to RLE2";
            this.PackageSelect_button.UseVisualStyleBackColor = true;
            this.PackageSelect_button.Click += new System.EventHandler(this.PackageSelect_button_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.toolStripStatusLabel2,
            this.toolStripStatusLabel3});
            this.statusStrip1.Location = new System.Drawing.Point(0, 515);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(703, 22);
            this.statusStrip1.TabIndex = 3;
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(118, 17);
            this.toolStripStatusLabel1.Text = "toolStripStatusLabel1";
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(118, 17);
            this.toolStripStatusLabel2.Text = "toolStripStatusLabel2";
            // 
            // toolStripStatusLabel3
            // 
            this.toolStripStatusLabel3.Name = "toolStripStatusLabel3";
            this.toolStripStatusLabel3.Size = new System.Drawing.Size(118, 17);
            this.toolStripStatusLabel3.Text = "toolStripStatusLabel3";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(339, 102);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(25, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "OR";
            // 
            // FolderSelect_button
            // 
            this.FolderSelect_button.Location = new System.Drawing.Point(0, 19);
            this.FolderSelect_button.Name = "FolderSelect_button";
            this.FolderSelect_button.Size = new System.Drawing.Size(165, 31);
            this.FolderSelect_button.TabIndex = 7;
            this.FolderSelect_button.Text = "Select Input Folder";
            this.FolderSelect_button.UseVisualStyleBackColor = true;
            this.FolderSelect_button.Click += new System.EventHandler(this.FolderSelect_button_Click);
            // 
            // OutputSelect_button
            // 
            this.OutputSelect_button.Location = new System.Drawing.Point(0, 56);
            this.OutputSelect_button.Name = "OutputSelect_button";
            this.OutputSelect_button.Size = new System.Drawing.Size(165, 31);
            this.OutputSelect_button.TabIndex = 22;
            this.OutputSelect_button.Text = "Select Output Folder";
            this.OutputSelect_button.UseVisualStyleBackColor = true;
            this.OutputSelect_button.Click += new System.EventHandler(this.OutputSelect_button_Click);
            // 
            // FolderName
            // 
            this.FolderName.Location = new System.Drawing.Point(171, 25);
            this.FolderName.Name = "FolderName";
            this.FolderName.Size = new System.Drawing.Size(424, 20);
            this.FolderName.TabIndex = 23;
            // 
            // OutputName
            // 
            this.OutputName.Location = new System.Drawing.Point(171, 62);
            this.OutputName.Name = "OutputName";
            this.OutputName.Size = new System.Drawing.Size(424, 20);
            this.OutputName.TabIndex = 24;
            // 
            // FolderGo_button
            // 
            this.FolderGo_button.Location = new System.Drawing.Point(601, 25);
            this.FolderGo_button.Name = "FolderGo_button";
            this.FolderGo_button.Size = new System.Drawing.Size(57, 57);
            this.FolderGo_button.TabIndex = 26;
            this.FolderGo_button.Text = "Go";
            this.FolderGo_button.UseVisualStyleBackColor = true;
            this.FolderGo_button.Click += new System.EventHandler(this.FolderGo_button_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.panel2);
            this.groupBox1.Controls.Add(this.panel1);
            this.groupBox1.Controls.Add(this.NoCopy_checkBox);
            this.groupBox1.Controls.Add(this.NoRename_checkBox);
            this.groupBox1.Controls.Add(this.LinkedOptions_panel);
            this.groupBox1.Location = new System.Drawing.Point(22, 273);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(658, 239);
            this.groupBox1.TabIndex = 27;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Conversion options:";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.ConvertRLE2_radioButton);
            this.panel2.Controls.Add(this.ConvertLRLE_radioButton);
            this.panel2.Controls.Add(this.UpdateLRLE_radioButton);
            this.panel2.Location = new System.Drawing.Point(6, 42);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(649, 76);
            this.panel2.TabIndex = 32;
            // 
            // ConvertLRLE_radioButton
            // 
            this.ConvertLRLE_radioButton.AutoSize = true;
            this.ConvertLRLE_radioButton.Location = new System.Drawing.Point(4, 50);
            this.ConvertLRLE_radioButton.Name = "ConvertLRLE_radioButton";
            this.ConvertLRLE_radioButton.Size = new System.Drawing.Size(253, 17);
            this.ConvertLRLE_radioButton.TabIndex = 1;
            this.ConvertLRLE_radioButton.Text = "Convert LRLE to RLE2 (fix appearance in game)";
            this.ConvertLRLE_radioButton.UseVisualStyleBackColor = true;
            // 
            // UpdateLRLE_radioButton
            // 
            this.UpdateLRLE_radioButton.AutoSize = true;
            this.UpdateLRLE_radioButton.Checked = true;
            this.UpdateLRLE_radioButton.Location = new System.Drawing.Point(4, 4);
            this.UpdateLRLE_radioButton.Name = "UpdateLRLE_radioButton";
            this.UpdateLRLE_radioButton.Size = new System.Drawing.Size(387, 17);
            this.UpdateLRLE_radioButton.TabIndex = 0;
            this.UpdateLRLE_radioButton.TabStop = true;
            this.UpdateLRLE_radioButton.Text = "Update LRLE compression (fix appearance in game, color slider compatibility)";
            this.UpdateLRLE_radioButton.UseVisualStyleBackColor = true;
            this.UpdateLRLE_radioButton.CheckedChanged += new System.EventHandler(this.UpdateLRLE_radioButton_CheckedChanged);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.ConvertAll_radioButton);
            this.panel1.Controls.Add(this.LinkedOnly_radioButton);
            this.panel1.Location = new System.Drawing.Point(6, 124);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(227, 73);
            this.panel1.TabIndex = 31;
            // 
            // ConvertAll_radioButton
            // 
            this.ConvertAll_radioButton.AutoSize = true;
            this.ConvertAll_radioButton.Checked = true;
            this.ConvertAll_radioButton.Location = new System.Drawing.Point(3, 9);
            this.ConvertAll_radioButton.Name = "ConvertAll_radioButton";
            this.ConvertAll_radioButton.Size = new System.Drawing.Size(171, 17);
            this.ConvertAll_radioButton.TabIndex = 1;
            this.ConvertAll_radioButton.TabStop = true;
            this.ConvertAll_radioButton.Text = "Convert all textures in package";
            this.ConvertAll_radioButton.UseVisualStyleBackColor = true;
            this.ConvertAll_radioButton.CheckedChanged += new System.EventHandler(this.ConvertAll_radioButton_CheckedChanged);
            // 
            // LinkedOnly_radioButton
            // 
            this.LinkedOnly_radioButton.AutoSize = true;
            this.LinkedOnly_radioButton.Location = new System.Drawing.Point(3, 32);
            this.LinkedOnly_radioButton.Name = "LinkedOnly_radioButton";
            this.LinkedOnly_radioButton.Size = new System.Drawing.Size(217, 17);
            this.LinkedOnly_radioButton.TabIndex = 0;
            this.LinkedOnly_radioButton.Text = "Convert only textures linked from CASPs:";
            this.LinkedOnly_radioButton.UseVisualStyleBackColor = true;
            // 
            // NoCopy_checkBox
            // 
            this.NoCopy_checkBox.AutoSize = true;
            this.NoCopy_checkBox.Checked = true;
            this.NoCopy_checkBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.NoCopy_checkBox.Location = new System.Drawing.Point(245, 19);
            this.NoCopy_checkBox.Name = "NoCopy_checkBox";
            this.NoCopy_checkBox.Size = new System.Drawing.Size(184, 17);
            this.NoCopy_checkBox.TabIndex = 29;
            this.NoCopy_checkBox.Text = "Don\'t copy unchanged packages";
            this.NoCopy_checkBox.UseVisualStyleBackColor = true;
            // 
            // NoRename_checkBox
            // 
            this.NoRename_checkBox.AutoSize = true;
            this.NoRename_checkBox.Location = new System.Drawing.Point(10, 19);
            this.NoRename_checkBox.Name = "NoRename_checkBox";
            this.NoRename_checkBox.Size = new System.Drawing.Size(169, 17);
            this.NoRename_checkBox.TabIndex = 28;
            this.NoRename_checkBox.Text = "Don\'t change package names";
            this.NoRename_checkBox.UseVisualStyleBackColor = true;
            // 
            // LinkedOptions_panel
            // 
            this.LinkedOptions_panel.Controls.Add(this.DoAll_checkBox);
            this.LinkedOptions_panel.Controls.Add(this.DoMakeup_checkBox);
            this.LinkedOptions_panel.Controls.Add(this.DoSkinDetails_checkBox);
            this.LinkedOptions_panel.Controls.Add(this.DoHair_checkBox);
            this.LinkedOptions_panel.Enabled = false;
            this.LinkedOptions_panel.Location = new System.Drawing.Point(245, 124);
            this.LinkedOptions_panel.Name = "LinkedOptions_panel";
            this.LinkedOptions_panel.Size = new System.Drawing.Size(410, 103);
            this.LinkedOptions_panel.TabIndex = 2;
            // 
            // DoAll_checkBox
            // 
            this.DoAll_checkBox.AutoSize = true;
            this.DoAll_checkBox.Checked = true;
            this.DoAll_checkBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.DoAll_checkBox.Location = new System.Drawing.Point(3, 10);
            this.DoAll_checkBox.Name = "DoAll_checkBox";
            this.DoAll_checkBox.Size = new System.Drawing.Size(244, 17);
            this.DoAll_checkBox.TabIndex = 3;
            this.DoAll_checkBox.Text = "Convert all diffuse textures linked from a CASP";
            this.DoAll_checkBox.UseVisualStyleBackColor = true;
            this.DoAll_checkBox.CheckedChanged += new System.EventHandler(this.DoOnlyHairSkin_checkBox_CheckedChanged);
            // 
            // DoMakeup_checkBox
            // 
            this.DoMakeup_checkBox.AutoSize = true;
            this.DoMakeup_checkBox.Location = new System.Drawing.Point(3, 79);
            this.DoMakeup_checkBox.Name = "DoMakeup_checkBox";
            this.DoMakeup_checkBox.Size = new System.Drawing.Size(104, 17);
            this.DoMakeup_checkBox.TabIndex = 2;
            this.DoMakeup_checkBox.Text = "Convert makeup";
            this.DoMakeup_checkBox.UseVisualStyleBackColor = true;
            this.DoMakeup_checkBox.CheckedChanged += new System.EventHandler(this.DoExceptMakeup_checkBox_CheckedChanged);
            // 
            // DoSkinDetails_checkBox
            // 
            this.DoSkinDetails_checkBox.AutoSize = true;
            this.DoSkinDetails_checkBox.Location = new System.Drawing.Point(3, 56);
            this.DoSkinDetails_checkBox.Name = "DoSkinDetails_checkBox";
            this.DoSkinDetails_checkBox.Size = new System.Drawing.Size(181, 17);
            this.DoSkinDetails_checkBox.TabIndex = 1;
            this.DoSkinDetails_checkBox.Text = "Convert skin details and overlays";
            this.DoSkinDetails_checkBox.UseVisualStyleBackColor = true;
            this.DoSkinDetails_checkBox.CheckedChanged += new System.EventHandler(this.DoOnlySkinDetails_checkBox_CheckedChanged);
            // 
            // DoHair_checkBox
            // 
            this.DoHair_checkBox.AutoSize = true;
            this.DoHair_checkBox.Location = new System.Drawing.Point(3, 33);
            this.DoHair_checkBox.Name = "DoHair_checkBox";
            this.DoHair_checkBox.Size = new System.Drawing.Size(83, 17);
            this.DoHair_checkBox.TabIndex = 0;
            this.DoHair_checkBox.Text = "Convert hair";
            this.DoHair_checkBox.UseVisualStyleBackColor = true;
            this.DoHair_checkBox.CheckedChanged += new System.EventHandler(this.DoOnlyHair_checkBox_CheckedChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.Subfolders_checkBox);
            this.groupBox2.Controls.Add(this.FolderSelect_button);
            this.groupBox2.Controls.Add(this.OutputSelect_button);
            this.groupBox2.Controls.Add(this.FolderGo_button);
            this.groupBox2.Controls.Add(this.FolderName);
            this.groupBox2.Controls.Add(this.OutputName);
            this.groupBox2.Location = new System.Drawing.Point(22, 133);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(658, 121);
            this.groupBox2.TabIndex = 28;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "All packages in input folder will be processed and saved in output folder";
            // 
            // Subfolders_checkBox
            // 
            this.Subfolders_checkBox.AutoSize = true;
            this.Subfolders_checkBox.Checked = true;
            this.Subfolders_checkBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.Subfolders_checkBox.Location = new System.Drawing.Point(0, 93);
            this.Subfolders_checkBox.Name = "Subfolders_checkBox";
            this.Subfolders_checkBox.Size = new System.Drawing.Size(115, 17);
            this.Subfolders_checkBox.TabIndex = 27;
            this.Subfolders_checkBox.Text = "Include sub-folders";
            this.Subfolders_checkBox.UseVisualStyleBackColor = true;
            // 
            // ConvertRLE2_radioButton
            // 
            this.ConvertRLE2_radioButton.AutoSize = true;
            this.ConvertRLE2_radioButton.Location = new System.Drawing.Point(4, 27);
            this.ConvertRLE2_radioButton.Name = "ConvertRLE2_radioButton";
            this.ConvertRLE2_radioButton.Size = new System.Drawing.Size(531, 17);
            this.ConvertRLE2_radioButton.TabIndex = 2;
            this.ConvertRLE2_radioButton.TabStop = true;
            this.ConvertRLE2_radioButton.Text = "Convert RLE2 to LRLE (color slider compatibility. Convert only textures linked fr" +
    "om CASPs is recommended.)";
            this.ConvertRLE2_radioButton.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(703, 537);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.PackageSelect_button);
            this.Name = "Form1";
            this.Text = "TS4 Alpha Converter v2.2 64-bit";
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.LinkedOptions_panel.ResumeLayout(false);
            this.LinkedOptions_panel.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button PackageSelect_button;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button FolderSelect_button;
        private System.Windows.Forms.Button OutputSelect_button;
        private System.Windows.Forms.TextBox FolderName;
        private System.Windows.Forms.TextBox OutputName;
        private System.Windows.Forms.Button FolderGo_button;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel3;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox Subfolders_checkBox;
        private System.Windows.Forms.RadioButton ConvertAll_radioButton;
        private System.Windows.Forms.RadioButton LinkedOnly_radioButton;
        private System.Windows.Forms.Panel LinkedOptions_panel;
        private System.Windows.Forms.CheckBox DoMakeup_checkBox;
        private System.Windows.Forms.CheckBox DoSkinDetails_checkBox;
        private System.Windows.Forms.CheckBox DoHair_checkBox;
        private System.Windows.Forms.CheckBox NoRename_checkBox;
        private System.Windows.Forms.CheckBox DoAll_checkBox;
        private System.Windows.Forms.CheckBox NoCopy_checkBox;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.RadioButton ConvertLRLE_radioButton;
        private System.Windows.Forms.RadioButton UpdateLRLE_radioButton;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton ConvertRLE2_radioButton;
    }
}

