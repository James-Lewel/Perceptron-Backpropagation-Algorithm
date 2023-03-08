using System;
using System.Drawing;
using System.Windows.Forms;

namespace Number_Recognition
{
    public partial class mainForm : Form
    {
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
                openFileDialog.Title = "Open Image";
                openFileDialog.Filter = "Image Files(*.jpeg;*.bmp;*.png;*.jpg)|*.jpeg;*.bmp;*.png;*.jpg";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                    samplePictureBox.Image = new Bitmap(openFileDialog.FileName);
            }
        }

        private void removeButton_Click(object sender, EventArgs e)
        {
            samplePictureBox.Image = null;
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

                // Checks if input is negative
                if (int.Parse(input) < 0)
                {
                    MessageBox.Show("Input must be positive!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Enables/Disables decrement button
                if(int.Parse(input) > 0)
                    decrementButton.Enabled = true;
                else
                    decrementButton.Enabled = false;

                iterationButton.Text = input;
            }
            catch(FormatException)
            {
                MessageBox.Show("Input mush be an integer!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void decrementButton_Click(object sender, EventArgs e)
        {
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
                decrementButton.Enabled = true;
        }
    }
}
