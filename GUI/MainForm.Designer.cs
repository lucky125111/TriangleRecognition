namespace GUI
{
    partial class Gui
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
            this.Image_PictureBox = new System.Windows.Forms.PictureBox();
            this.Start_Button = new System.Windows.Forms.Button();
            this.ColorPick_Button = new System.Windows.Forms.Button();
            this.ChoosenColor_PictureBox = new System.Windows.Forms.PictureBox();
            this.Rest_Button = new System.Windows.Forms.Button();
            this.Buttons_Panel = new System.Windows.Forms.Panel();
            this.Triangles_UpDown = new System.Windows.Forms.NumericUpDown();
            this.Triangles_Label = new System.Windows.Forms.Label();
            this.Threshold_UpDown = new System.Windows.Forms.NumericUpDown();
            this.Threshold_Label = new System.Windows.Forms.Label();
            this.OpenFile_Dialog = new System.Windows.Forms.OpenFileDialog();
            this.OpenImage_Button = new System.Windows.Forms.Button();
            this.SaveImage_Button = new System.Windows.Forms.Button();
            this.SaveFile_Dialog = new System.Windows.Forms.SaveFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.Image_PictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ChoosenColor_PictureBox)).BeginInit();
            this.Buttons_Panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Triangles_UpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Threshold_UpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // Image_PictureBox
            // 
            this.Image_PictureBox.BackgroundImage = global::GUI.Properties.Resources.test_image;
            this.Image_PictureBox.Image = global::GUI.Properties.Resources.test_image;
            this.Image_PictureBox.InitialImage = null;
            this.Image_PictureBox.Location = new System.Drawing.Point(13, 13);
            this.Image_PictureBox.Name = "Image_PictureBox";
            this.Image_PictureBox.Size = new System.Drawing.Size(500, 500);
            this.Image_PictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Image_PictureBox.TabIndex = 0;
            this.Image_PictureBox.TabStop = false;
            // 
            // Start_Button
            // 
            this.Start_Button.Location = new System.Drawing.Point(6, 215);
            this.Start_Button.Name = "Start_Button";
            this.Start_Button.Size = new System.Drawing.Size(199, 49);
            this.Start_Button.TabIndex = 1;
            this.Start_Button.Text = "Start";
            this.Start_Button.UseVisualStyleBackColor = true;
            this.Start_Button.Click += new System.EventHandler(this.Start_Button_Click);
            // 
            // ColorPick_Button
            // 
            this.ColorPick_Button.Location = new System.Drawing.Point(6, 62);
            this.ColorPick_Button.Name = "ColorPick_Button";
            this.ColorPick_Button.Size = new System.Drawing.Size(102, 42);
            this.ColorPick_Button.TabIndex = 3;
            this.ColorPick_Button.Text = "Pick Color";
            this.ColorPick_Button.UseVisualStyleBackColor = true;
            this.ColorPick_Button.Click += new System.EventHandler(this.ColorPick_Button_Click);
            // 
            // ChoosenColor_PictureBox
            // 
            this.ChoosenColor_PictureBox.BackColor = System.Drawing.Color.Lime;
            this.ChoosenColor_PictureBox.Location = new System.Drawing.Point(114, 62);
            this.ChoosenColor_PictureBox.Name = "ChoosenColor_PictureBox";
            this.ChoosenColor_PictureBox.Size = new System.Drawing.Size(91, 42);
            this.ChoosenColor_PictureBox.TabIndex = 4;
            this.ChoosenColor_PictureBox.TabStop = false;
            // 
            // Rest_Button
            // 
            this.Rest_Button.Location = new System.Drawing.Point(6, 168);
            this.Rest_Button.Name = "Rest_Button";
            this.Rest_Button.Size = new System.Drawing.Size(199, 41);
            this.Rest_Button.TabIndex = 5;
            this.Rest_Button.Text = "Rest Image";
            this.Rest_Button.UseVisualStyleBackColor = true;
            this.Rest_Button.Click += new System.EventHandler(this.Rest_Button_Click);
            // 
            // Buttons_Panel
            // 
            this.Buttons_Panel.Controls.Add(this.SaveImage_Button);
            this.Buttons_Panel.Controls.Add(this.OpenImage_Button);
            this.Buttons_Panel.Controls.Add(this.Triangles_UpDown);
            this.Buttons_Panel.Controls.Add(this.Triangles_Label);
            this.Buttons_Panel.Controls.Add(this.Threshold_UpDown);
            this.Buttons_Panel.Controls.Add(this.Threshold_Label);
            this.Buttons_Panel.Controls.Add(this.ColorPick_Button);
            this.Buttons_Panel.Controls.Add(this.Start_Button);
            this.Buttons_Panel.Controls.Add(this.Rest_Button);
            this.Buttons_Panel.Controls.Add(this.ChoosenColor_PictureBox);
            this.Buttons_Panel.Location = new System.Drawing.Point(520, 13);
            this.Buttons_Panel.Name = "Buttons_Panel";
            this.Buttons_Panel.Size = new System.Drawing.Size(214, 267);
            this.Buttons_Panel.TabIndex = 6;
            // 
            // Triangles_UpDown
            // 
            this.Triangles_UpDown.Location = new System.Drawing.Point(114, 141);
            this.Triangles_UpDown.Name = "Triangles_UpDown";
            this.Triangles_UpDown.Size = new System.Drawing.Size(91, 20);
            this.Triangles_UpDown.TabIndex = 10;
            this.Triangles_UpDown.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.Triangles_UpDown.ValueChanged += new System.EventHandler(this.Triangles_UpDown_ValueChanged);
            // 
            // Triangles_Label
            // 
            this.Triangles_Label.AutoSize = true;
            this.Triangles_Label.Location = new System.Drawing.Point(10, 143);
            this.Triangles_Label.Name = "Triangles_Label";
            this.Triangles_Label.Size = new System.Drawing.Size(98, 13);
            this.Triangles_Label.TabIndex = 9;
            this.Triangles_Label.Text = "Number of triangles";
            // 
            // Threshold_UpDown
            // 
            this.Threshold_UpDown.Location = new System.Drawing.Point(114, 115);
            this.Threshold_UpDown.Name = "Threshold_UpDown";
            this.Threshold_UpDown.Size = new System.Drawing.Size(91, 20);
            this.Threshold_UpDown.TabIndex = 8;
            this.Threshold_UpDown.ValueChanged += new System.EventHandler(this.Threshold_UpDown_ValueChanged);
            // 
            // Threshold_Label
            // 
            this.Threshold_Label.AutoSize = true;
            this.Threshold_Label.Location = new System.Drawing.Point(21, 118);
            this.Threshold_Label.Name = "Threshold_Label";
            this.Threshold_Label.Size = new System.Drawing.Size(54, 13);
            this.Threshold_Label.TabIndex = 7;
            this.Threshold_Label.Text = "Threshold";
            // 
            // OpenFile_Dialog
            // 
            this.OpenFile_Dialog.FileName = "OpenFile_Dialog";
            // 
            // OpenImage_Button
            // 
            this.OpenImage_Button.Location = new System.Drawing.Point(6, 3);
            this.OpenImage_Button.Name = "OpenImage_Button";
            this.OpenImage_Button.Size = new System.Drawing.Size(102, 23);
            this.OpenImage_Button.TabIndex = 11;
            this.OpenImage_Button.Text = "Change Image";
            this.OpenImage_Button.UseVisualStyleBackColor = true;
            this.OpenImage_Button.Click += new System.EventHandler(this.OpenImage_Button_Click);
            // 
            // SaveImage_Button
            // 
            this.SaveImage_Button.Location = new System.Drawing.Point(6, 33);
            this.SaveImage_Button.Name = "SaveImage_Button";
            this.SaveImage_Button.Size = new System.Drawing.Size(102, 23);
            this.SaveImage_Button.TabIndex = 12;
            this.SaveImage_Button.Text = "Save Image";
            this.SaveImage_Button.UseVisualStyleBackColor = true;
            this.SaveImage_Button.Click += new System.EventHandler(this.SaveImage_Button_Click);
            // 
            // Gui
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(737, 526);
            this.Controls.Add(this.Buttons_Panel);
            this.Controls.Add(this.Image_PictureBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "Gui";
            this.Text = "TriangleFinder";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Image_PictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ChoosenColor_PictureBox)).EndInit();
            this.Buttons_Panel.ResumeLayout(false);
            this.Buttons_Panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Triangles_UpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Threshold_UpDown)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox Image_PictureBox;
        private System.Windows.Forms.Button Start_Button;
        private System.Windows.Forms.Button ColorPick_Button;
        private System.Windows.Forms.PictureBox ChoosenColor_PictureBox;
        private System.Windows.Forms.Button Rest_Button;
        private System.Windows.Forms.Panel Buttons_Panel;
        private System.Windows.Forms.Label Threshold_Label;
        private System.Windows.Forms.NumericUpDown Threshold_UpDown;
        private System.Windows.Forms.NumericUpDown Triangles_UpDown;
        private System.Windows.Forms.Label Triangles_Label;
        private System.Windows.Forms.Button OpenImage_Button;
        private System.Windows.Forms.OpenFileDialog OpenFile_Dialog;
        private System.Windows.Forms.Button SaveImage_Button;
        private System.Windows.Forms.SaveFileDialog SaveFile_Dialog;
    }
}

