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
            this.borderMaroon1 = new System.Windows.Forms.PictureBox();
            this.resetButton = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.iterationButton = new System.Windows.Forms.Button();
            this.incrementButton = new System.Windows.Forms.Button();
            this.decrementButton = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.ownerLabel = new System.Windows.Forms.Label();
            this.createButton = new System.Windows.Forms.Button();
            this.importButton = new System.Windows.Forms.Button();
            this.trainButton = new System.Windows.Forms.Button();
            this.testButton = new System.Windows.Forms.Button();
            this.exportButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.outputLabel = new System.Windows.Forms.Label();
            this.stripeWhite1 = new System.Windows.Forms.PictureBox();
            this.stripeWhite2 = new System.Windows.Forms.PictureBox();
            this.stripeMaroon1 = new System.Windows.Forms.PictureBox();
            this.stripeMaroon2 = new System.Windows.Forms.PictureBox();
            this.stripeMaroon3 = new System.Windows.Forms.PictureBox();
            this.borderMaroon2 = new System.Windows.Forms.PictureBox();
            this.titleLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.samplePictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.borderMaroon1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.stripeWhite1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.stripeWhite2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.stripeMaroon1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.stripeMaroon2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.stripeMaroon3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.borderMaroon2)).BeginInit();
            this.SuspendLayout();
            // 
            // addButton
            // 
            this.addButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.addButton.Location = new System.Drawing.Point(6, 20);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(74, 74);
            this.addButton.TabIndex = 0;
            this.addButton.Text = "Add";
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // removeButton
            // 
            this.removeButton.Enabled = false;
            this.removeButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.removeButton.Location = new System.Drawing.Point(91, 21);
            this.removeButton.Name = "removeButton";
            this.removeButton.Size = new System.Drawing.Size(74, 74);
            this.removeButton.TabIndex = 1;
            this.removeButton.Text = "Remove";
            this.removeButton.UseVisualStyleBackColor = true;
            this.removeButton.Click += new System.EventHandler(this.removeButton_Click);
            // 
            // samplePictureBox
            // 
            this.samplePictureBox.BackColor = System.Drawing.SystemColors.ControlDark;
            this.samplePictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.samplePictureBox.Cursor = System.Windows.Forms.Cursors.Default;
            this.samplePictureBox.Location = new System.Drawing.Point(22, 21);
            this.samplePictureBox.Name = "samplePictureBox";
            this.samplePictureBox.Size = new System.Drawing.Size(246, 246);
            this.samplePictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.samplePictureBox.TabIndex = 2;
            this.samplePictureBox.TabStop = false;
            // 
            // borderMaroon1
            // 
            this.borderMaroon1.BackColor = System.Drawing.Color.Maroon;
            this.borderMaroon1.Cursor = System.Windows.Forms.Cursors.Default;
            this.borderMaroon1.Location = new System.Drawing.Point(17, 16);
            this.borderMaroon1.Name = "borderMaroon1";
            this.borderMaroon1.Size = new System.Drawing.Size(256, 256);
            this.borderMaroon1.TabIndex = 2;
            this.borderMaroon1.TabStop = false;
            // 
            // resetButton
            // 
            this.resetButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.resetButton.Location = new System.Drawing.Point(176, 21);
            this.resetButton.Name = "resetButton";
            this.resetButton.Size = new System.Drawing.Size(74, 74);
            this.resetButton.TabIndex = 1;
            this.resetButton.Text = "Reset";
            this.resetButton.UseVisualStyleBackColor = true;
            this.resetButton.Click += new System.EventHandler(this.resetButton_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.resetButton);
            this.groupBox1.Controls.Add(this.removeButton);
            this.groupBox1.Controls.Add(this.addButton);
            this.groupBox1.ForeColor = System.Drawing.SystemColors.Control;
            this.groupBox1.Location = new System.Drawing.Point(17, 278);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(256, 105);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Buttons";
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.Maroon;
            this.groupBox2.Controls.Add(this.panel1);
            this.groupBox2.ForeColor = System.Drawing.SystemColors.Control;
            this.groupBox2.Location = new System.Drawing.Point(307, 16);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(400, 251);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Options";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Control;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.iterationButton);
            this.panel1.Controls.Add(this.incrementButton);
            this.panel1.Controls.Add(this.decrementButton);
            this.panel1.Controls.Add(this.groupBox3);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.outputLabel);
            this.panel1.Location = new System.Drawing.Point(6, 21);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(388, 224);
            this.panel1.TabIndex = 0;
            // 
            // iterationButton
            // 
            this.iterationButton.BackColor = System.Drawing.Color.Transparent;
            this.iterationButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.iterationButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.iterationButton.Location = new System.Drawing.Point(174, 10);
            this.iterationButton.Name = "iterationButton";
            this.iterationButton.Size = new System.Drawing.Size(169, 30);
            this.iterationButton.TabIndex = 5;
            this.iterationButton.Text = "0";
            this.iterationButton.UseVisualStyleBackColor = false;
            this.iterationButton.Click += new System.EventHandler(this.iterationButton_Click);
            // 
            // incrementButton
            // 
            this.incrementButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.incrementButton.Location = new System.Drawing.Point(351, 10);
            this.incrementButton.Name = "incrementButton";
            this.incrementButton.Size = new System.Drawing.Size(30, 30);
            this.incrementButton.TabIndex = 5;
            this.incrementButton.Text = "+";
            this.incrementButton.UseVisualStyleBackColor = true;
            this.incrementButton.Click += new System.EventHandler(this.incrementButton_Click);
            // 
            // decrementButton
            // 
            this.decrementButton.Enabled = false;
            this.decrementButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.decrementButton.Location = new System.Drawing.Point(135, 10);
            this.decrementButton.Name = "decrementButton";
            this.decrementButton.Size = new System.Drawing.Size(30, 30);
            this.decrementButton.TabIndex = 5;
            this.decrementButton.Text = "-";
            this.decrementButton.UseVisualStyleBackColor = true;
            this.decrementButton.Click += new System.EventHandler(this.decrementButton_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.SystemColors.ControlDark;
            this.groupBox3.Controls.Add(this.ownerLabel);
            this.groupBox3.Controls.Add(this.createButton);
            this.groupBox3.Controls.Add(this.importButton);
            this.groupBox3.Controls.Add(this.trainButton);
            this.groupBox3.Controls.Add(this.testButton);
            this.groupBox3.Controls.Add(this.exportButton);
            this.groupBox3.Location = new System.Drawing.Point(3, 102);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(378, 117);
            this.groupBox3.TabIndex = 4;
            this.groupBox3.TabStop = false;
            // 
            // ownerLabel
            // 
            this.ownerLabel.AutoSize = true;
            this.ownerLabel.Location = new System.Drawing.Point(251, 67);
            this.ownerLabel.Name = "ownerLabel";
            this.ownerLabel.Size = new System.Drawing.Size(107, 16);
            this.ownerLabel.TabIndex = 1;
            this.ownerLabel.Text = "By : JimBoi Tech";
            // 
            // createButton
            // 
            this.createButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.createButton.Location = new System.Drawing.Point(11, 21);
            this.createButton.Name = "createButton";
            this.createButton.Size = new System.Drawing.Size(115, 37);
            this.createButton.TabIndex = 0;
            this.createButton.Text = "Create";
            this.createButton.UseVisualStyleBackColor = true;
            this.createButton.Click += new System.EventHandler(this.createButton_Click);
            // 
            // importButton
            // 
            this.importButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.importButton.Location = new System.Drawing.Point(12, 67);
            this.importButton.Name = "importButton";
            this.importButton.Size = new System.Drawing.Size(115, 37);
            this.importButton.TabIndex = 0;
            this.importButton.Text = "Import";
            this.importButton.UseVisualStyleBackColor = true;
            this.importButton.Click += new System.EventHandler(this.importButton_Click);
            // 
            // trainButton
            // 
            this.trainButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.trainButton.Location = new System.Drawing.Point(130, 21);
            this.trainButton.Name = "trainButton";
            this.trainButton.Size = new System.Drawing.Size(115, 37);
            this.trainButton.TabIndex = 0;
            this.trainButton.Text = "Train";
            this.trainButton.UseVisualStyleBackColor = true;
            this.trainButton.Click += new System.EventHandler(this.trainButton_Click);
            // 
            // testButton
            // 
            this.testButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.testButton.Location = new System.Drawing.Point(248, 21);
            this.testButton.Name = "testButton";
            this.testButton.Size = new System.Drawing.Size(115, 37);
            this.testButton.TabIndex = 0;
            this.testButton.Text = "Test";
            this.testButton.UseVisualStyleBackColor = true;
            this.testButton.Click += new System.EventHandler(this.testButton_Click);
            // 
            // exportButton
            // 
            this.exportButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.exportButton.Location = new System.Drawing.Point(130, 67);
            this.exportButton.Name = "exportButton";
            this.exportButton.Size = new System.Drawing.Size(115, 37);
            this.exportButton.TabIndex = 0;
            this.exportButton.Text = "Export";
            this.exportButton.UseVisualStyleBackColor = true;
            this.exportButton.Click += new System.EventHandler(this.exportButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label1.Location = new System.Drawing.Point(12, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 16);
            this.label1.TabIndex = 3;
            this.label1.Text = "Max Trainings";
            // 
            // outputLabel
            // 
            this.outputLabel.AutoSize = true;
            this.outputLabel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.outputLabel.Location = new System.Drawing.Point(12, 50);
            this.outputLabel.Name = "outputLabel";
            this.outputLabel.Size = new System.Drawing.Size(54, 16);
            this.outputLabel.TabIndex = 3;
            this.outputLabel.Text = "Output : ";
            // 
            // stripeWhite1
            // 
            this.stripeWhite1.BackColor = System.Drawing.SystemColors.Control;
            this.stripeWhite1.Cursor = System.Windows.Forms.Cursors.Default;
            this.stripeWhite1.Location = new System.Drawing.Point(-8, 299);
            this.stripeWhite1.Name = "stripeWhite1";
            this.stripeWhite1.Size = new System.Drawing.Size(750, 30);
            this.stripeWhite1.TabIndex = 2;
            this.stripeWhite1.TabStop = false;
            // 
            // stripeWhite2
            // 
            this.stripeWhite2.BackColor = System.Drawing.SystemColors.Control;
            this.stripeWhite2.Cursor = System.Windows.Forms.Cursors.Default;
            this.stripeWhite2.Location = new System.Drawing.Point(-8, 335);
            this.stripeWhite2.Name = "stripeWhite2";
            this.stripeWhite2.Size = new System.Drawing.Size(750, 30);
            this.stripeWhite2.TabIndex = 2;
            this.stripeWhite2.TabStop = false;
            // 
            // stripeMaroon1
            // 
            this.stripeMaroon1.BackColor = System.Drawing.Color.Maroon;
            this.stripeMaroon1.Cursor = System.Windows.Forms.Cursors.Default;
            this.stripeMaroon1.Location = new System.Drawing.Point(-8, 109);
            this.stripeMaroon1.Name = "stripeMaroon1";
            this.stripeMaroon1.Size = new System.Drawing.Size(328, 30);
            this.stripeMaroon1.TabIndex = 2;
            this.stripeMaroon1.TabStop = false;
            // 
            // stripeMaroon2
            // 
            this.stripeMaroon2.BackColor = System.Drawing.Color.Maroon;
            this.stripeMaroon2.Cursor = System.Windows.Forms.Cursors.Default;
            this.stripeMaroon2.Location = new System.Drawing.Point(-8, 145);
            this.stripeMaroon2.Name = "stripeMaroon2";
            this.stripeMaroon2.Size = new System.Drawing.Size(330, 30);
            this.stripeMaroon2.TabIndex = 2;
            this.stripeMaroon2.TabStop = false;
            // 
            // stripeMaroon3
            // 
            this.stripeMaroon3.BackColor = System.Drawing.Color.Maroon;
            this.stripeMaroon3.Cursor = System.Windows.Forms.Cursors.Default;
            this.stripeMaroon3.Location = new System.Drawing.Point(-8, 181);
            this.stripeMaroon3.Name = "stripeMaroon3";
            this.stripeMaroon3.Size = new System.Drawing.Size(328, 30);
            this.stripeMaroon3.TabIndex = 2;
            this.stripeMaroon3.TabStop = false;
            // 
            // borderMaroon2
            // 
            this.borderMaroon2.BackColor = System.Drawing.Color.Maroon;
            this.borderMaroon2.Cursor = System.Windows.Forms.Cursors.Default;
            this.borderMaroon2.Location = new System.Drawing.Point(299, 16);
            this.borderMaroon2.Name = "borderMaroon2";
            this.borderMaroon2.Size = new System.Drawing.Size(418, 256);
            this.borderMaroon2.TabIndex = 2;
            this.borderMaroon2.TabStop = false;
            // 
            // titleLabel
            // 
            this.titleLabel.AutoSize = true;
            this.titleLabel.BackColor = System.Drawing.Color.Transparent;
            this.titleLabel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.titleLabel.Font = new System.Drawing.Font("OCR A Extended", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titleLabel.Location = new System.Drawing.Point(298, 294);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(393, 35);
            this.titleLabel.TabIndex = 5;
            this.titleLabel.Text = "Number Recognition";
            // 
            // mainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Goldenrod;
            this.ClientSize = new System.Drawing.Size(732, 403);
            this.Controls.Add(this.titleLabel);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.samplePictureBox);
            this.Controls.Add(this.borderMaroon1);
            this.Controls.Add(this.stripeWhite2);
            this.Controls.Add(this.stripeWhite1);
            this.Controls.Add(this.borderMaroon2);
            this.Controls.Add(this.stripeMaroon2);
            this.Controls.Add(this.stripeMaroon3);
            this.Controls.Add(this.stripeMaroon1);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(750, 450);
            this.MinimumSize = new System.Drawing.Size(750, 450);
            this.Name = "mainForm";
            this.Text = "Easter Egg 🥚";
            ((System.ComponentModel.ISupportInitialize)(this.samplePictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.borderMaroon1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.stripeWhite1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.stripeWhite2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.stripeMaroon1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.stripeMaroon2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.stripeMaroon3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.borderMaroon2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.Button removeButton;
        private System.Windows.Forms.PictureBox samplePictureBox;
        private System.Windows.Forms.PictureBox borderMaroon1;
        private System.Windows.Forms.Button resetButton;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button createButton;
        private System.Windows.Forms.Button importButton;
        private System.Windows.Forms.Button trainButton;
        private System.Windows.Forms.Button testButton;
        private System.Windows.Forms.Button exportButton;
        private System.Windows.Forms.Label outputLabel;
        private System.Windows.Forms.Label ownerLabel;
        private System.Windows.Forms.Button iterationButton;
        private System.Windows.Forms.Button incrementButton;
        private System.Windows.Forms.Button decrementButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox stripeWhite1;
        private System.Windows.Forms.PictureBox stripeWhite2;
        private System.Windows.Forms.PictureBox stripeMaroon1;
        private System.Windows.Forms.PictureBox stripeMaroon2;
        private System.Windows.Forms.PictureBox stripeMaroon3;
        private System.Windows.Forms.PictureBox borderMaroon2;
        private System.Windows.Forms.Label titleLabel;
    }
}

