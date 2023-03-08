namespace Number_Recognition
{
    partial class mainForm
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
            this.addButton = new System.Windows.Forms.Button();
            this.removeButton = new System.Windows.Forms.Button();
            this.samplePictureBox = new System.Windows.Forms.PictureBox();
            this.borderSamplePictureBox = new System.Windows.Forms.PictureBox();
            this.resetButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.samplePictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.borderSamplePictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // addButton
            // 
            this.addButton.Location = new System.Drawing.Point(17, 278);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(74, 74);
            this.addButton.TabIndex = 0;
            this.addButton.Text = "Add";
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // removeButton
            // 
            this.removeButton.Location = new System.Drawing.Point(108, 278);
            this.removeButton.Name = "removeButton";
            this.removeButton.Size = new System.Drawing.Size(74, 74);
            this.removeButton.TabIndex = 1;
            this.removeButton.Text = "Remove";
            this.removeButton.UseVisualStyleBackColor = true;
            this.removeButton.Click += new System.EventHandler(this.removeButton_Click);
            // 
            // samplePictureBox
            // 
            this.samplePictureBox.BackColor = System.Drawing.SystemColors.Control;
            this.samplePictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.samplePictureBox.Cursor = System.Windows.Forms.Cursors.Default;
            this.samplePictureBox.Location = new System.Drawing.Point(22, 22);
            this.samplePictureBox.Name = "samplePictureBox";
            this.samplePictureBox.Size = new System.Drawing.Size(246, 246);
            this.samplePictureBox.TabIndex = 2;
            this.samplePictureBox.TabStop = false;
            // 
            // borderSamplePictureBox
            // 
            this.borderSamplePictureBox.BackColor = System.Drawing.SystemColors.Control;
            this.borderSamplePictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.borderSamplePictureBox.Cursor = System.Windows.Forms.Cursors.Default;
            this.borderSamplePictureBox.Location = new System.Drawing.Point(17, 16);
            this.borderSamplePictureBox.Name = "borderSamplePictureBox";
            this.borderSamplePictureBox.Size = new System.Drawing.Size(256, 256);
            this.borderSamplePictureBox.TabIndex = 2;
            this.borderSamplePictureBox.TabStop = false;
            // 
            // resetButton
            // 
            this.resetButton.Location = new System.Drawing.Point(199, 278);
            this.resetButton.Name = "resetButton";
            this.resetButton.Size = new System.Drawing.Size(74, 74);
            this.resetButton.TabIndex = 1;
            this.resetButton.Text = "Reset";
            this.resetButton.UseVisualStyleBackColor = true;
            this.resetButton.Click += new System.EventHandler(this.removeButton_Click);
            // 
            // mainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Goldenrod;
            this.ClientSize = new System.Drawing.Size(802, 453);
            this.Controls.Add(this.samplePictureBox);
            this.Controls.Add(this.resetButton);
            this.Controls.Add(this.removeButton);
            this.Controls.Add(this.addButton);
            this.Controls.Add(this.borderSamplePictureBox);
            this.Name = "mainForm";
            this.Text = "Number Recognition";
            ((System.ComponentModel.ISupportInitialize)(this.samplePictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.borderSamplePictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.Button removeButton;
        private System.Windows.Forms.PictureBox samplePictureBox;
        private System.Windows.Forms.PictureBox borderSamplePictureBox;
        private System.Windows.Forms.Button resetButton;
    }
}

