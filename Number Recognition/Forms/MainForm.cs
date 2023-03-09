using Backpropagation;
using System;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace Number_Recognition
{
    public partial class mainForm : Form
    {
        Bitmap originalBitmap;
        Bitmap sampleBitmap;

        int height = 0;
        int width = 0;

        public mainForm()
        {
            InitializeComponent();
        }

        int[,] num = new int[7, 5];

        private void addButton_Click(object sender, EventArgs e)
        {
            // Loads an image
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                // Sets properties of dialog
                openFileDialog.Title = "Add Image";
                openFileDialog.Filter = "Image Files(*.jpeg;*.bmp;*.png;*.jpg)|*.jpeg;*.bmp;*.png;*.jpg";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    originalBitmap = new Bitmap(openFileDialog.FileName);

                    // Calculates ratio, height and weight of image
                    height = originalBitmap.Height;
                    width = originalBitmap.Width;

                    double ratio = (double) samplePictureBox.Height / height;
                    int newHeight = (int)(height * ratio);
                    int newWidth = (int) (width * ratio);
                    
                    sampleBitmap = new Bitmap(newWidth, newHeight);

                    // Scales image to picture box
                    using (Graphics graphics = Graphics.FromImage(sampleBitmap))
                    {
                        // Sets properties of graphics
                        graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
                        graphics.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.Half;

                        graphics.DrawImage(originalBitmap, 0, 0, newWidth, newHeight);
                    }

                    // Sets image to picture box
                    samplePictureBox.Image = sampleBitmap;

                    removeButton.Enabled = true;

                    for (int i = 0; i < height; i++)
                    {
                        for (int j = 0; j < width; j++)
                        {
                            num[i, j] = originalBitmap.GetPixel(j, i).ToArgb() < -1 ? 1 : 0;
                        }
                    }
                }
            }
        }

        private void removeButton_Click(object sender, EventArgs e)
        {
            samplePictureBox.Image = null;
            
            removeButton.Enabled = false;
        }

        private void resetButton_Click(object sender, EventArgs e)
        {
            samplePictureBox.Image = null;

            removeButton.Enabled = false;
            decrementButton.Enabled = false;
            
            iterationButton.Text = "0";
        }

        private void iterationButton_Click(object sender, EventArgs e)
        {
            try
            {
                string input = "0";

                // Opens an input box
                using (var inputForm = new InputForm())
                {
                    var result = inputForm.ShowDialog();

                    if (result == DialogResult.OK)
                    {
                        input = inputForm.ReturnInput;
                    }
                    else
                    {
                        return;
                    }
                }

                // Error message if input is negative
                if (int.Parse(input) < 0)
                {
                    MessageBox.Show("Input must be positive!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Enables/Disables decrement button
                if(int.Parse(input) > 0)
                {
                    decrementButton.Enabled = true;
                }
                else
                {
                    decrementButton.Enabled = false;
                }

                iterationButton.Text = input;
            }
            // Error message if input is non-integer
            catch (FormatException)
            {
                MessageBox.Show("Input must be an integer!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void decrementButton_Click(object sender, EventArgs e)
        {
            // Set minimum training limit to zero
            if (int.Parse(iterationButton.Text) <= 1)
            {
                if (int.Parse(iterationButton.Text) <= 2)
                {
                    iterationButton.Text = (int.Parse(iterationButton.Text) - 1).ToString();
                    decrementButton.Enabled = false;
                }

                return;
            }
            
            iterationButton.Text = (int.Parse(iterationButton.Text) - 1).ToString();
        }

        private void incrementButton_Click(object sender, EventArgs e)
        {
            iterationButton.Text = (int.Parse(iterationButton.Text) + 1).ToString();

            if(int.Parse(iterationButton.Text) > 0)
            {
                decrementButton.Enabled = true;
            }
        }

        NeuralNet neuralNet;

        private void createButton_Click(object sender, EventArgs e)
        {
            var input = height * width;
            neuralNet =  new NeuralNet(input, 16, 10);

        }

        private void trainButton_Click(object sender, EventArgs e)
        {
            new Thread(()=>
            {
                int trainingLimit = int.Parse(iterationButton.Text);
                for(int i = 0; i < trainingLimit; i++)
                {
                    for (int j = 0; j < height; j++)
                    {
                        for (int k = 0; k < width; k++)
                        {
                            neuralNet.setInputs(j * width + k, num[j,k]);
                        }
                    }
                }

                MessageBox.Show("Finish");
            }).Start();

            neuralNet.setDesiredOutput(0, 9);
            neuralNet.learn();
        }

        private void testButton_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    neuralNet.setInputs(j, num[i, j]);
                }
            }
            neuralNet.run();
            outputLabel.Text = "Output : " + neuralNet.getOuputData(0);
        }

        private void importButton_Click(object sender, EventArgs e)
        {
            // Get base directory
            var basePath = Path.GetDirectoryName(Path.GetDirectoryName(Directory.GetCurrentDirectory()));

            string folderName = "\\Data\\";
            string fileName = "data.csv";

            neuralNet.loadWeights(basePath + folderName + fileName);
            MessageBox.Show("Data Imported");
        }

        private void exportButton_Click(object sender, EventArgs e)
        { 
            // Get base directory
            var basePath = Path.GetDirectoryName(Path.GetDirectoryName(Directory.GetCurrentDirectory()));
            
            string folderName = "\\Data\\";

            neuralNet.saveWeights(basePath + folderName);
            MessageBox.Show("Data Exported");
        }
    }
}
