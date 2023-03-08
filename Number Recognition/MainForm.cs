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
                {
                    samplePictureBox.Image = new Bitmap(openFileDialog.FileName);
                }
            }
        }

        private void removeButton_Click(object sender, EventArgs e)
        {
            samplePictureBox.Image = null;
        }
    }
}
