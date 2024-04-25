using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private Bitmap? originalImage;
        private Bitmap thresholdImage;
        private Bitmap grayscaleImage;
        private Bitmap negativeImage;
        private Bitmap mirrorImage;

        private void loadButton_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            var file = openFileDialog1.FileName;
            if (file != null)
            {
                try
                {
                    originalImage = new Bitmap(file);
                } catch (Exception ex)
                {
                    MessageBox.Show("Error loading image: " + ex.Message);
                }
                originalPictureBox.Image = originalImage;
            }
        }

        private void processButton_Click(object sender, EventArgs e)
        {
            if (originalImage == null)
                return;

            Bitmap thresholdCopy = new Bitmap(originalImage);
            Bitmap grayscaleCopy = new Bitmap(originalImage);
            Bitmap negativeCopy = new Bitmap(originalImage);
            Bitmap mirrorCopy = new Bitmap(originalImage);

            Thread thresholdThread = new Thread(() =>
            {
                thresholdImage = ApplyThreshold(thresholdCopy);
                originalPictureBox.Invoke((MethodInvoker)delegate
                {
                    thresholdPictureBox.Image = thresholdImage;
                });
            });
            thresholdThread.Start();

            Thread grayscaleThread = new Thread(() =>
            {
                grayscaleImage = ApplyGrayscale(grayscaleCopy);
                originalPictureBox.Invoke((MethodInvoker)delegate
                {
                    grayscalePictureBox.Image = grayscaleImage;
                });
            });
            grayscaleThread.Start();

            Thread negativeThread = new Thread(() =>
            {
                negativeImage = ApplyNegative(negativeCopy);
                originalPictureBox.Invoke((MethodInvoker)delegate
                {
                    negativePictureBox.Image = negativeImage;
                });
            });
            negativeThread.Start();

            Thread mirrorThread = new Thread(() =>
            {
                mirrorImage = ApplyMirror(mirrorCopy);
                originalPictureBox.Invoke((MethodInvoker)delegate
                {
                    mirrorPictureBox.Image = mirrorImage;
                });
            });
            mirrorThread.Start();
        }

        private Bitmap ApplyThreshold(Bitmap original)
        {
            Bitmap result = new Bitmap(original.Width, original.Height);
            for (int y = 0; y < original.Height; y++)
            {
                for (int x = 0; x < original.Width; x++)
                {
                    Color pixelColor = original.GetPixel(x, y);
                    int average = (pixelColor.R + pixelColor.G + pixelColor.B) / 3;
                    Color newColor = average > 128 ? Color.White : Color.Black;
                    result.SetPixel(x, y, newColor);
                }
            }
            return result;
        }

        private Bitmap ApplyGrayscale(Bitmap original)
        {
            Bitmap result = new Bitmap(original.Width, original.Height);
            for (int y = 0; y < original.Height; y++)
            {
                for (int x = 0; x < original.Width; x++)
                {
                    Color pixelColor = original.GetPixel(x, y);
                    int average = (pixelColor.R + pixelColor.G + pixelColor.B) / 3;
                    result.SetPixel(x, y, Color.FromArgb(average, average, average));
                }
            }
            return result;
        }

        private Bitmap ApplyNegative(Bitmap original)
        {
            Bitmap result = new Bitmap(original.Width, original.Height);
            for (int y = 0; y < original.Height; y++)
            {
                for (int x = 0; x < original.Width; x++)
                {
                    Color pixelColor = original.GetPixel(x, y);
                    Color newColor = Color.FromArgb(255 - pixelColor.R, 255 - pixelColor.G, 255 - pixelColor.B);
                    result.SetPixel(x, y, newColor);
                }
            }
            return result;
        }

        private Bitmap ApplyMirror(Bitmap original)
        {
            Bitmap result = new Bitmap(original.Width, original.Height);
            for (int y = 0; y < original.Height; y++)
            {
                for (int x = 0; x < original.Width; x++)
                {
                    Color pixelColor = original.GetPixel(x, y);
                    result.SetPixel(original.Width - x - 1, y, pixelColor);
                }
            }
            return result;
        }

    }
}
