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
        private const string OpenFileFilter = @"images |*.bmp; *.jpeg; *.png";
        private const string SaveFileFilter = @"All (*.*)|*.*";

        public Gui()
        {
            InitializeComponent();
            Triangles_UpDown.Minimum = 1;
        }

        private ICalculator Calculator { get; set; }
        private PointScaler PointScaler { get; set; }
        private Bitmap SourceImage { get; set; }

        /// <summary>
        ///     Metoda do ustawiania niepewnosci wartosci kolorow
        /// </summary>
        private void Set_Threshold_UpDown()
        {
            Threshold_UpDown.Maximum = 100;
            Threshold_UpDown.Minimum = 0;
            Threshold_UpDown.Enabled = false;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            SourceImage = Resources.test_image;
            PointScaler = new PointScaler(Image_PictureBox.Image.Size, Image_PictureBox.Size);
            OpenFile_Dialog.Filter = OpenFileFilter;
            SaveFile_Dialog.Filter = SaveFileFilter;
            Set_Threshold_UpDown();
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
            Enabled = false;
            using (var img = new Image<Rgb, byte>((Bitmap)Image_PictureBox.Image))
            {
                Image_PictureBox.Image = DrawCircles(img);
            }

            Enabled = true;
        }

        private Bitmap DrawCircles(Image<Rgb, byte> img)
        {
            var settings = new CalculatorSettings()
            {
                Color = ChoosenColor_PictureBox.BackColor,
                Threshold = Convert.ToInt32(Threshold_UpDown.Value),
                NumberOfTriangles = Convert.ToInt32(Triangles_UpDown.Value)
            };

            Calculator = new CircumscribedCirclesFinder(img, settings);

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
                    ForeColor = ChoosenColor_PictureBox.BackColor.InvertColor(),
                    BackColor = Color.Transparent
                };

                Image_PictureBox.Controls.Add(label);
            }
            return img.ToBitmap();
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
                        var label = (Label)el;
                        g.DrawString(label.Text, DefaultFont, new SolidBrush(label.ForeColor),
                            PointScaler.ScaleToSource(Image_PictureBox.Size, label.Location));
                    }
                }

                Image_PictureBox.Image.Save(SaveFile_Dialog.FileName);
            }
        }
    }
}