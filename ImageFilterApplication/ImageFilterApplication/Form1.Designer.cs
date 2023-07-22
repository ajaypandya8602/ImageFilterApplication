namespace ImageFilterApplication
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
            this.label1 = new System.Windows.Forms.Label();
            this.pnlImage = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.trk_brightness = new System.Windows.Forms.TrackBar();
            this.trk_contrast = new System.Windows.Forms.TrackBar();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbDefaultFilter = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnBrowseImage = new System.Windows.Forms.Button();
            this.trk_smooth = new System.Windows.Forms.TrackBar();
            this.label6 = new System.Windows.Forms.Label();
            this.btnSaveImage = new System.Windows.Forms.Button();
            this.btnSaveBrightness = new System.Windows.Forms.Button();
            this.btnSaveContrast = new System.Windows.Forms.Button();
            this.btnSaveSmooth = new System.Windows.Forms.Button();
            this.btnResetImage = new System.Windows.Forms.Button();
            this.pnlAddText = new System.Windows.Forms.Panel();
            this.btnChooseColor = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.btnSetText = new System.Windows.Forms.Button();
            this.cmbFontSize = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtAddText = new System.Windows.Forms.TextBox();
            this.btnApplytext = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.trk_brightness)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trk_contrast)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trk_smooth)).BeginInit();
            this.pnlAddText.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(306, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(316, 31);
            this.label1.TabIndex = 0;
            this.label1.Text = "Image Editing Software";
            // 
            // pnlImage
            // 
            this.pnlImage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pnlImage.Location = new System.Drawing.Point(26, 71);
            this.pnlImage.Name = "pnlImage";
            this.pnlImage.Size = new System.Drawing.Size(468, 420);
            this.pnlImage.TabIndex = 1;
            this.pnlImage.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.pnlImage_MouseDoubleClick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(558, 165);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Brightness";
            // 
            // trk_brightness
            // 
            this.trk_brightness.LargeChange = 20;
            this.trk_brightness.Location = new System.Drawing.Point(627, 156);
            this.trk_brightness.Maximum = 100;
            this.trk_brightness.Minimum = -100;
            this.trk_brightness.Name = "trk_brightness";
            this.trk_brightness.Size = new System.Drawing.Size(186, 45);
            this.trk_brightness.SmallChange = 10;
            this.trk_brightness.TabIndex = 3;
            this.trk_brightness.Scroll += new System.EventHandler(this.trk_brightness_Scroll);
            // 
            // trk_contrast
            // 
            this.trk_contrast.LargeChange = 1;
            this.trk_contrast.Location = new System.Drawing.Point(627, 207);
            this.trk_contrast.Maximum = 4;
            this.trk_contrast.Minimum = -4;
            this.trk_contrast.Name = "trk_contrast";
            this.trk_contrast.Size = new System.Drawing.Size(186, 45);
            this.trk_contrast.TabIndex = 5;
            this.trk_contrast.Scroll += new System.EventHandler(this.trk_contrast_Scroll);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(558, 216);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Contrast";
            // 
            // cmbDefaultFilter
            // 
            this.cmbDefaultFilter.FormattingEnabled = true;
            this.cmbDefaultFilter.Items.AddRange(new object[] {
            "BlackAndWhite",
            "EdgeImage"});
            this.cmbDefaultFilter.Location = new System.Drawing.Point(640, 302);
            this.cmbDefaultFilter.Name = "cmbDefaultFilter";
            this.cmbDefaultFilter.Size = new System.Drawing.Size(173, 21);
            this.cmbDefaultFilter.TabIndex = 6;
            this.cmbDefaultFilter.SelectedIndexChanged += new System.EventHandler(this.cmbDefaultFilter_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(558, 305);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Defaut Filter";
            // 
            // btnBrowseImage
            // 
            this.btnBrowseImage.Location = new System.Drawing.Point(561, 82);
            this.btnBrowseImage.Name = "btnBrowseImage";
            this.btnBrowseImage.Size = new System.Drawing.Size(174, 52);
            this.btnBrowseImage.TabIndex = 9;
            this.btnBrowseImage.Text = "Browse Image";
            this.btnBrowseImage.UseVisualStyleBackColor = true;
            this.btnBrowseImage.Click += new System.EventHandler(this.btnBrowseImage_Click);
            // 
            // trk_smooth
            // 
            this.trk_smooth.LargeChange = 2;
            this.trk_smooth.Location = new System.Drawing.Point(628, 248);
            this.trk_smooth.Maximum = 20;
            this.trk_smooth.Minimum = 1;
            this.trk_smooth.Name = "trk_smooth";
            this.trk_smooth.Size = new System.Drawing.Size(186, 45);
            this.trk_smooth.TabIndex = 11;
            this.trk_smooth.Value = 1;
            this.trk_smooth.Scroll += new System.EventHandler(this.trk_smooth_Scroll);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(559, 257);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(43, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "Smooth";
            // 
            // btnSaveImage
            // 
            this.btnSaveImage.Location = new System.Drawing.Point(561, 381);
            this.btnSaveImage.Name = "btnSaveImage";
            this.btnSaveImage.Size = new System.Drawing.Size(130, 38);
            this.btnSaveImage.TabIndex = 12;
            this.btnSaveImage.Text = "Save Image";
            this.btnSaveImage.UseVisualStyleBackColor = true;
            this.btnSaveImage.Click += new System.EventHandler(this.btnSaveImage_Click);
            // 
            // btnSaveBrightness
            // 
            this.btnSaveBrightness.Location = new System.Drawing.Point(819, 160);
            this.btnSaveBrightness.Name = "btnSaveBrightness";
            this.btnSaveBrightness.Size = new System.Drawing.Size(37, 28);
            this.btnSaveBrightness.TabIndex = 0;
            this.btnSaveBrightness.Text = "OK";
            this.btnSaveBrightness.UseVisualStyleBackColor = true;
            this.btnSaveBrightness.Click += new System.EventHandler(this.btnSaveBrightness_Click);
            // 
            // btnSaveContrast
            // 
            this.btnSaveContrast.Location = new System.Drawing.Point(819, 207);
            this.btnSaveContrast.Name = "btnSaveContrast";
            this.btnSaveContrast.Size = new System.Drawing.Size(37, 28);
            this.btnSaveContrast.TabIndex = 13;
            this.btnSaveContrast.Text = "OK";
            this.btnSaveContrast.UseVisualStyleBackColor = true;
            this.btnSaveContrast.Click += new System.EventHandler(this.btnSaveContrast_Click);
            // 
            // btnSaveSmooth
            // 
            this.btnSaveSmooth.Location = new System.Drawing.Point(819, 249);
            this.btnSaveSmooth.Name = "btnSaveSmooth";
            this.btnSaveSmooth.Size = new System.Drawing.Size(37, 28);
            this.btnSaveSmooth.TabIndex = 14;
            this.btnSaveSmooth.Text = "OK";
            this.btnSaveSmooth.UseVisualStyleBackColor = true;
            this.btnSaveSmooth.Click += new System.EventHandler(this.btnSaveSmooth_Click);
            // 
            // btnResetImage
            // 
            this.btnResetImage.Location = new System.Drawing.Point(715, 381);
            this.btnResetImage.Name = "btnResetImage";
            this.btnResetImage.Size = new System.Drawing.Size(130, 38);
            this.btnResetImage.TabIndex = 15;
            this.btnResetImage.Text = "Reset Image";
            this.btnResetImage.UseVisualStyleBackColor = true;
            this.btnResetImage.Click += new System.EventHandler(this.btnResetImage_Click);
            // 
            // pnlAddText
            // 
            this.pnlAddText.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlAddText.Controls.Add(this.btnChooseColor);
            this.pnlAddText.Controls.Add(this.label8);
            this.pnlAddText.Controls.Add(this.btnSetText);
            this.pnlAddText.Controls.Add(this.cmbFontSize);
            this.pnlAddText.Controls.Add(this.label7);
            this.pnlAddText.Controls.Add(this.label5);
            this.pnlAddText.Controls.Add(this.txtAddText);
            this.pnlAddText.Location = new System.Drawing.Point(384, 143);
            this.pnlAddText.Name = "pnlAddText";
            this.pnlAddText.Size = new System.Drawing.Size(250, 159);
            this.pnlAddText.TabIndex = 16;
            this.pnlAddText.Visible = false;
            // 
            // btnChooseColor
            // 
            this.btnChooseColor.Location = new System.Drawing.Point(126, 79);
            this.btnChooseColor.Name = "btnChooseColor";
            this.btnChooseColor.Size = new System.Drawing.Size(87, 25);
            this.btnChooseColor.TabIndex = 6;
            this.btnChooseColor.Text = "Color";
            this.btnChooseColor.UseVisualStyleBackColor = true;
            this.btnChooseColor.Click += new System.EventHandler(this.btnChooseColor_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(50, 85);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(70, 13);
            this.label8.TabIndex = 5;
            this.label8.Text = "Choose Color";
            // 
            // btnSetText
            // 
            this.btnSetText.Location = new System.Drawing.Point(87, 114);
            this.btnSetText.Name = "btnSetText";
            this.btnSetText.Size = new System.Drawing.Size(72, 28);
            this.btnSetText.TabIndex = 4;
            this.btnSetText.Text = "SetText";
            this.btnSetText.UseVisualStyleBackColor = true;
            this.btnSetText.Click += new System.EventHandler(this.btnSetText_Click);
            // 
            // cmbFontSize
            // 
            this.cmbFontSize.FormattingEnabled = true;
            this.cmbFontSize.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10"});
            this.cmbFontSize.Location = new System.Drawing.Point(112, 49);
            this.cmbFontSize.Name = "cmbFontSize";
            this.cmbFontSize.Size = new System.Drawing.Size(108, 21);
            this.cmbFontSize.TabIndex = 3;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(50, 53);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(48, 13);
            this.label7.TabIndex = 2;
            this.label7.Text = "FontSize";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(50, 25);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(28, 13);
            this.label5.TabIndex = 1;
            this.label5.Text = "Text";
            // 
            // txtAddText
            // 
            this.txtAddText.Location = new System.Drawing.Point(112, 21);
            this.txtAddText.Name = "txtAddText";
            this.txtAddText.Size = new System.Drawing.Size(108, 20);
            this.txtAddText.TabIndex = 0;
            // 
            // btnApplytext
            // 
            this.btnApplytext.Location = new System.Drawing.Point(562, 339);
            this.btnApplytext.Name = "btnApplytext";
            this.btnApplytext.Size = new System.Drawing.Size(283, 28);
            this.btnApplytext.TabIndex = 17;
            this.btnApplytext.Text = "Apply text";
            this.btnApplytext.UseVisualStyleBackColor = true;
            this.btnApplytext.Click += new System.EventHandler(this.btnApplytext_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(819, 302);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(37, 28);
            this.button1.TabIndex = 18;
            this.button1.Text = "OK";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(885, 522);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnApplytext);
            this.Controls.Add(this.pnlAddText);
            this.Controls.Add(this.btnResetImage);
            this.Controls.Add(this.btnSaveSmooth);
            this.Controls.Add(this.btnSaveContrast);
            this.Controls.Add(this.btnSaveBrightness);
            this.Controls.Add(this.btnSaveImage);
            this.Controls.Add(this.trk_smooth);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btnBrowseImage);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cmbDefaultFilter);
            this.Controls.Add(this.trk_contrast);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.trk_brightness);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pnlImage);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.trk_brightness)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trk_contrast)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trk_smooth)).EndInit();
            this.pnlAddText.ResumeLayout(false);
            this.pnlAddText.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel pnlImage;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TrackBar trk_brightness;
        private System.Windows.Forms.TrackBar trk_contrast;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbDefaultFilter;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnBrowseImage;
        private System.Windows.Forms.TrackBar trk_smooth;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnSaveImage;
        private System.Windows.Forms.Button btnSaveBrightness;
        private System.Windows.Forms.Button btnSaveContrast;
        private System.Windows.Forms.Button btnSaveSmooth;
        private System.Windows.Forms.Button btnResetImage;
        private System.Windows.Forms.Panel pnlAddText;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtAddText;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cmbFontSize;
        private System.Windows.Forms.Button btnSetText;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnChooseColor;
        private System.Windows.Forms.Button btnApplytext;
        private System.Windows.Forms.Button button1;
    }
}

