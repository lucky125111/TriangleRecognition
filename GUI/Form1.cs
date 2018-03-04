using System;
using System.Drawing;
using System.Windows.Forms;
using Emgu.CV;
using Emgu.CV.Structure;
using GUI.Properties;
using ImageProcessing;

namespace GUI
{
    public partial class Gui : Form
    {
        public Gui()
        {
            InitializeComponent();
            Threshold_UpDown.Maximum = 765;
            Threshold_UpDown.Minimum = 0;
            Triangles_UpDown.Minimum = 1;
        }

        private ICalculator Calculator { get; set; }
        private PointScaler PointScaler { get; set; }
        private Bitmap SourceImage { get; set; }

        private void Form1_Load(object sender, EventArgs e)
        {
            SourceImage = Resources.test_image;
            PointScaler = new PointScaler(Image_PictureBox.Image.Size, Image_PictureBox.Size);
            OpenFile_Dialog.Filter = @"images |*.bmp; *.jpeg; *.png";
            SaveFile_Dialog.Filter = @"All (*.*)|*.*";
            Threshold_UpDown.Enabled = false;
        }

        private void ColorPick_Button_Click(object sender, EventArgs e)
        {
            var c = new ColorDialog();
            if (c.ShowDialog() == DialogResult.OK)
                ChoosenColor_PictureBox.BackColor = c.Color;
        }

        private void Rest_Button_Click(object sender, EventArgs e)
        {
            Image_PictureBox.Image = SourceImage;
            Image_PictureBox.Controls.Clear();
        }

        private void Start_Button_Click(object sender, EventArgs e)
        {
            this.Enabled = false;
            var img = new Image<Rgb, byte>((Bitmap)Image_PictureBox.Image);

            DrawCircles(img);
            this.Enabled = true;
        }
        
        private void DrawCircles(Image<Rgb, byte> img)
        {
            
            Calculator = new Calculator(ChoosenColor_PictureBox.BackColor, img, Convert.ToInt32(Threshold_UpDown.Value),
                Convert.ToInt32(Triangles_UpDown.Value));

            var l = Calculator.FindTriangleContour();

            foreach (var el in l)
            {
                img.Draw(el.Circle, new Rgb(0, 0, 255), 2);

                var label = new Label
                {
                    Location = PointScaler.ScaleToPictureBox(el.LabelPosition),
                    Text = el.Index.ToString(),
                    AutoSize = true,
                    Visible = true,
                    ForeColor = Color.FromArgb(255 - ChoosenColor_PictureBox.BackColor.R, 255 - ChoosenColor_PictureBox.BackColor.G, 255 - ChoosenColor_PictureBox.BackColor.B),
                    BackColor = Color.Transparent
                };

                Image_PictureBox.Controls.Add(label);
            }
            Image_PictureBox.Image = img.ToBitmap();
        }

        private void Threshold_UpDown_ValueChanged(object sender, EventArgs e)
        {
            Threshold_UpDown.Value = Convert.ToInt32(Threshold_UpDown.Value);
        }

        private void Triangles_UpDown_ValueChanged(object sender, EventArgs e)
        {
            Triangles_UpDown.Value = Convert.ToInt32(Triangles_UpDown.Value);
        }

        private void OpenImage_Button_Click(object sender, EventArgs e)
        {
            OpenFile_Dialog.FileName = "";
            if (OpenFile_Dialog.ShowDialog() == DialogResult.OK)
            {
                SourceImage = new Bitmap(OpenFile_Dialog.FileName);
                Image_PictureBox.Image = SourceImage;
                Image_PictureBox.Controls.Clear();
                PointScaler = new PointScaler(Image_PictureBox.Image.Size, Image_PictureBox.Size);
            }
        }

        private void SaveImage_Button_Click(object sender, EventArgs e)
        {
            if (SaveFile_Dialog.ShowDialog() == DialogResult.OK)
            {
                using (var g = Graphics.FromImage(Image_PictureBox.Image))
                {
                    foreach (var el in Image_PictureBox.Controls)
                    {
                        var label = ((Label)el);
                        g.DrawString(label.Text, DefaultFont, new SolidBrush(label.ForeColor), PointScaler.ScaleToSource(Image_PictureBox.Size, label.Location));
                    }
                }

                Image_PictureBox.Image.Save(SaveFile_Dialog.FileName);
            }
        }
    }
}