namespace WinFormsApp1
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            loadButton = new Button();
            processButton = new Button();
            originalPictureBox = new PictureBox();
            thresholdPictureBox = new PictureBox();
            grayscalePictureBox = new PictureBox();
            negativePictureBox = new PictureBox();
            mirrorPictureBox = new PictureBox();
            openFileDialog1 = new OpenFileDialog();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            ((System.ComponentModel.ISupportInitialize)originalPictureBox).BeginInit();
            ((System.ComponentModel.ISupportInitialize)thresholdPictureBox).BeginInit();
            ((System.ComponentModel.ISupportInitialize)grayscalePictureBox).BeginInit();
            ((System.ComponentModel.ISupportInitialize)negativePictureBox).BeginInit();
            ((System.ComponentModel.ISupportInitialize)mirrorPictureBox).BeginInit();
            SuspendLayout();
            // 
            // loadButton
            // 
            loadButton.Location = new Point(333, 130);
            loadButton.Name = "loadButton";
            loadButton.Size = new Size(75, 23);
            loadButton.TabIndex = 0;
            loadButton.Text = "load";
            loadButton.UseVisualStyleBackColor = true;
            loadButton.Click += loadButton_Click;
            // 
            // processButton
            // 
            processButton.Location = new Point(333, 229);
            processButton.Name = "processButton";
            processButton.Size = new Size(75, 23);
            processButton.TabIndex = 1;
            processButton.Text = "parallel process";
            processButton.UseVisualStyleBackColor = true;
            processButton.Click += processButton_Click;
            // 
            // originalPictureBox
            // 
            originalPictureBox.Location = new Point(12, 70);
            originalPictureBox.Name = "originalPictureBox";
            originalPictureBox.Size = new Size(300, 300);
            originalPictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            originalPictureBox.TabIndex = 2;
            originalPictureBox.TabStop = false;
            // 
            // thresholdPictureBox
            // 
            thresholdPictureBox.Location = new Point(439, 40);
            thresholdPictureBox.Name = "thresholdPictureBox";
            thresholdPictureBox.Size = new Size(150, 150);
            thresholdPictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            thresholdPictureBox.TabIndex = 3;
            thresholdPictureBox.TabStop = false;
            // 
            // grayscalePictureBox
            // 
            grayscalePictureBox.Location = new Point(638, 40);
            grayscalePictureBox.Name = "grayscalePictureBox";
            grayscalePictureBox.Size = new Size(150, 150);
            grayscalePictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            grayscalePictureBox.TabIndex = 4;
            grayscalePictureBox.TabStop = false;
            // 
            // negativePictureBox
            // 
            negativePictureBox.Location = new Point(439, 264);
            negativePictureBox.Name = "negativePictureBox";
            negativePictureBox.Size = new Size(150, 150);
            negativePictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            negativePictureBox.TabIndex = 5;
            negativePictureBox.TabStop = false;
            // 
            // mirrorPictureBox
            // 
            mirrorPictureBox.Location = new Point(638, 264);
            mirrorPictureBox.Name = "mirrorPictureBox";
            mirrorPictureBox.Size = new Size(150, 150);
            mirrorPictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            mirrorPictureBox.TabIndex = 6;
            mirrorPictureBox.TabStop = false;
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog1";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(130, 52);
            label1.Name = "label1";
            label1.Size = new Size(49, 15);
            label1.TabIndex = 7;
            label1.Text = "Original";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(490, 22);
            label2.Name = "label2";
            label2.Size = new Size(59, 15);
            label2.TabIndex = 8;
            label2.Text = "Threshold";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(691, 22);
            label3.Name = "label3";
            label3.Size = new Size(57, 15);
            label3.TabIndex = 9;
            label3.Text = "Grayscale";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(490, 246);
            label4.Name = "label4";
            label4.Size = new Size(54, 15);
            label4.TabIndex = 10;
            label4.Text = "Negative";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(691, 246);
            label5.Name = "label5";
            label5.Size = new Size(40, 15);
            label5.TabIndex = 11;
            label5.Text = "Mirror";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(mirrorPictureBox);
            Controls.Add(negativePictureBox);
            Controls.Add(grayscalePictureBox);
            Controls.Add(thresholdPictureBox);
            Controls.Add(originalPictureBox);
            Controls.Add(processButton);
            Controls.Add(loadButton);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)originalPictureBox).EndInit();
            ((System.ComponentModel.ISupportInitialize)thresholdPictureBox).EndInit();
            ((System.ComponentModel.ISupportInitialize)grayscalePictureBox).EndInit();
            ((System.ComponentModel.ISupportInitialize)negativePictureBox).EndInit();
            ((System.ComponentModel.ISupportInitialize)mirrorPictureBox).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button loadButton;
        private Button processButton;
        private PictureBox originalPictureBox;
        private PictureBox thresholdPictureBox;
        private PictureBox grayscalePictureBox;
        private PictureBox negativePictureBox;
        private PictureBox mirrorPictureBox;
        private OpenFileDialog openFileDialog1;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
    }
}
