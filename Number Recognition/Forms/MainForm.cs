using System;
using System.Drawing;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace Number_Recognition
{
    public partial class mainForm : Form
    {
        Bitmap originalBitmap;
        Bitmap sampleBitmap;

        public mainForm()
        {
            InitializeComponent();
        }

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
                    double ratio = (double) samplePictureBox.Height / originalBitmap.Height;
                    int newWidth = (int) (originalBitmap.Width * ratio);
                    int newHeight = (int) (originalBitmap.Height * ratio);
                    
                    sampleBitmap = new Bitmap(newWidth, newHeight);

                    // Scales image to picture box
                    using (Graphics graphics = Graphics.FromImage(sampleBitmap))
                    {
                        // Sets properties of graphics
                        graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
                        graphics.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.Half;

                        // Draws new image
                        graphics.DrawImage(originalBitmap, 0, 0, newWidth, newHeight);
                    }

                    samplePictureBox.Image = sampleBitmap;

                    // Enables remove button
                    removeButton.Enabled = true;
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
            catch(FormatException)
            {
                // Error message if input is non-integer
                MessageBox.Show("Input must be an integer!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void decrementButton_Click(object sender, EventArgs e)
        {
            // Set minimum limit to zero
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
    }
}
