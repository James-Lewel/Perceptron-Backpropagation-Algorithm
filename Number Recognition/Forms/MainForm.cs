using Backpropagation;
using Number_Recognition.Helpers;
using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Number_Recognition
{
    public partial class mainForm : Form
    {
        Bitmap originalBitmap;
        Bitmap sampleBitmap;

        int height = 28;
        int width = 28;

        public mainForm()
        {
            InitializeComponent();
        }

        int[,] num = new int[28, 28];

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
            // Get base directory
            var basePath = Path.GetDirectoryName(Path.GetDirectoryName(Directory.GetCurrentDirectory()));

            string folderName = "\\Data\\";

            var trainingData = MnistReader.ReadTrainingData(basePath + folderName);
            int trainingLimit = int.Parse(iterationButton.Text);

            progressBar.Style = ProgressBarStyle.Marquee;
            progressBar.MarqueeAnimationSpeed = 100;

            var thread = new Thread(() =>
            {
                foreach (var image in trainingData)
                {
                    for (int i = 0; i < trainingLimit; i++)
                    {
                        for (int j = 0; j < height; j++)
                        {
                            for (int k = 0; k < width; k++)
                            {
                                int color = image.Data[j, k] == 0 ? 0 : 1;
                                neuralNet.setInputs(j * width + k, color);
                            }
                        }
                        neuralNet.setDesiredOutput(0, image.Label);
                        neuralNet.learn();
                    }
                }

                MessageBox.Show("Training Finish");
            });

            thread.Start();

            Task.Run(() =>
            {
                thread.Join();
                progressBar.Invoke((MethodInvoker)(() =>
                {
                    progressBar.Style = ProgressBarStyle.Blocks;
                    progressBar.MarqueeAnimationSpeed = 0;
                }));
            });

            /*new Thread(()=>
            {
                int trainingLimit = int.Parse(iterationButton.Text);
                for(int i = 0; i < trainingLimit; i++)
                {
                    for (int j = 0; j < height; j++)
                    {
                        for (int k = 0; k < width; k++)
                        {
                            neuralNet.setInputs(k, num[j,k]);
                        }
                    }
                }

                MessageBox.Show("Finish");
            }).Start();*/

            #region temporary
            /*
                if (isZero(num))
                {
                    neuralNet.setDesiredOutput(0, 5);
                }
                else if (isOne(num))
                {
                    neuralNet.setDesiredOutput(1, 5);
                }
                else if (isTwo(num))
                {
                    neuralNet.setDesiredOutput(2, 5);
                }
                else if (isThree(num))
                {
                    neuralNet.setDesiredOutput(3, 5);
                }
                else if (isFour(num))
                {
                    neuralNet.setDesiredOutput(4, 5);
                }
                else if (isFive(num))
                {
                    neuralNet.setDesiredOutput(5, 5);
                }
                else if (isSix(num))
                {
                    neuralNet.setDesiredOutput(6, 5);
                }
                else if (isSeven(num))
                {
                    neuralNet.setDesiredOutput(7, 5);
                }
                else if (isEight(num))
                {
                    neuralNet.setDesiredOutput(8, 5);
                }
                else
                {
                    neuralNet.setDesiredOutput(9, 5);
                }
                
            */
            #endregion
        }

        private void testButton_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    neuralNet.setInputs(i * width + j, num[i, j]);
                }
            }
            neuralNet.run();

            /*double max = 0;
            int index = 0;

            for(int i = 0; i < 10; i++)
            {
                if (max < neuralNet.getOuputData(i))
                {
                    max = neuralNet.getOuputData(i);
                    index = i;
                }
            }*/

            double predict = 1;

            for (int i = 0; i < 10; i++)
            {
                predict *= neuralNet.getOuputData(i);
            }


            outputLabel.Text = "Output : " + (predict);

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

        #region temporary
        public bool isZero(int[,] input)
        {
            int counter = 0;
            int[,] zero = new int[,]
                {{ 0, 1, 1, 1, 0},
                { 1, 0, 0, 0, 1},
                { 1, 0, 0, 0, 1},
                { 1, 0, 0, 0, 1},
                { 1, 0, 0, 0, 1},
                { 1, 0, 0, 0, 1},
                { 0, 1, 1, 1, 0}};
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    if (input[i, j] == zero[i, j])
                    {
                        counter++;
                    }
                    else
                    {
                        return false;
                    }
                }

            }
            return true;
        }
        public bool isOne(int[,] input)
        {
            int counter = 0;
            int[,] one = new int[,]
                {{ 0, 1, 1, 0, 0},
                { 0, 0, 1, 0, 0},
                { 0, 0, 1, 0, 0},
                { 0, 0, 1, 0, 0},
                { 0, 0, 1, 0, 0},
                { 0, 0, 1, 0, 0},
                { 0, 1, 1, 1, 0}};
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    if (input[i, j] == one[i, j])
                    {
                        counter++;
                    }
                    else
                    {
                        return false;
                    }
                }

            }
            return true;
        }
        public bool isTwo(int[,] input)
        {
            int counter = 0;
            int[,] two = new int[,]
                {{ 0, 1, 1, 1, 0},
                { 1, 0, 0, 0, 1},
                { 1, 0, 0, 0, 1},
                { 0, 0, 0, 0, 1},
                { 0, 1, 1, 1, 0},
                { 1, 0, 0, 0, 0},
                { 0, 1, 1, 1, 1}};
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    if (input[i, j] == two[i, j])
                    {
                        counter++;
                    }
                    else
                    {
                        return false;
                    }
                }

            }
            return true;
        }
        public bool isThree(int[,] input)
        {
            int counter = 0;
            int[,] three = new int[,]
                {{ 0, 1, 1, 1, 0},
                { 1, 0, 0, 0, 1},
                { 0, 0, 0, 0, 1},
                { 0, 0, 1, 1, 0},
                { 0, 0, 0, 0, 1},
                { 1, 0, 0, 0, 1},
                { 0, 1, 1, 1, 0}};
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    if (input[i, j] == three[i, j])
                    {
                        counter++;
                    }
                    else
                    {
                        return false;
                    }
                }

            }
            return true;
        }
        public bool isFour(int[,] input)
        {
            int counter = 0;
            int[,] four = new int[,]
                {{ 0, 0, 0, 1, 0},
                { 0, 0, 1, 1, 0},
                { 0, 1, 0, 1, 0},
                { 1, 0, 0, 1, 0},
                { 1, 1, 1, 1, 1},
                { 0, 0, 0, 1, 0},
                { 0, 0, 0, 1, 0}};
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    if (input[i, j] == four[i, j])
                    {
                        counter++;
                    }
                    else
                    {
                        return false;
                    }
                }

            }
            return true;
        }
        public bool isFive(int[,] input)
        {
            int counter = 0;
            int[,] five = new int[,]
                {{ 1, 1, 1, 1, 1},
                { 1, 0, 0, 0, 0},
                { 1, 1, 1, 1, 0},
                { 0, 0, 0, 0, 1},
                { 1, 0, 0, 0, 1},
                { 1, 0, 0, 0, 1},
                { 0, 1, 1, 1, 0}};
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    if (input[i, j] == five[i, j])
                    {
                        counter++;
                    }
                    else
                    {
                        return false;
                    }
                }

            }
            return true;
        }
        public bool isSix(int[,] input)
        {
            int counter = 0;
            int[,] six = new int[,]
                {{ 0, 1, 1, 1, 0},
                { 1, 0, 0, 0, 1},
                { 1, 0, 0, 0, 0},
                { 1, 1, 1, 1, 0},
                { 1, 0, 0, 0, 1},
                { 1, 0, 0, 0, 1},
                { 0, 1, 1, 1, 0}};
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    if (input[i, j] == six[i, j])
                    {
                        counter++;
                    }
                    else
                    {
                        return false;
                    }
                }

            }
            return true;
        }
        public bool isSeven(int[,] input)
        {
            int counter = 0;
            int[,] seven = new int[,]
                 {{ 1, 1, 1, 1, 1},
                 { 1, 0, 0, 0, 1},
                 { 1, 0, 0, 1, 0},
                 { 0, 0, 0, 1, 0},
                 { 0, 0, 1, 0, 0},
                 { 0, 0, 1, 0, 0},
                 { 0, 0, 1, 0, 0}};
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    if (input[i, j] == seven[i, j])
                    {
                        counter++;
                    }
                    else
                    {
                        return false;
                    }
                }

            }
            return true;
        }
        public bool isEight(int[,] input)
        {
            int counter = 0;
            int[,] eight = new int[,]
                 {{ 0, 1, 1, 1, 0},
                 { 1, 0, 0, 0, 1},
                 { 1, 0, 0, 0, 1},
                 { 0, 1, 1, 1, 0},
                 { 1, 0, 0, 0, 1},
                 { 1, 0, 0, 0, 1},
                 { 0, 1, 1, 1, 0}};
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    if (input[i, j] == eight[i, j])
                    {
                        counter++;
                    }
                    else
                    {
                        return false;
                    }
                }

            }
            return true;
        }
        public bool isNine(int[,] input)
        {
            int counter = 0;
            int[,] nine = new int[,]
                {{ 0, 1, 1, 1, 0},
                { 1, 0, 0, 0, 1},
                { 1, 0, 0, 0, 1},
                { 0, 1, 1, 1, 1},
                { 0, 0, 0, 0, 1},
                { 1, 0, 0, 0, 1},
                { 0, 1, 1, 1, 0}};
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    if (input[i, j] == nine[i, j])
                    {
                        counter++;
                    }
                    else
                    {
                        return false;
                    }
                }

            }
            return true;
        }

        #endregion
    }
}
