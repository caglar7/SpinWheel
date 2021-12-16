namespace SpinWheel
{
    partial class difficultyScreen
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
            this.components = new System.ComponentModel.Container();
            this.hardButton = new System.Windows.Forms.Button();
            this.mediumButton = new System.Windows.Forms.Button();
            this.easyButton = new System.Windows.Forms.Button();
            this.goBackButton = new System.Windows.Forms.Button();
            this.cloudPicture1 = new System.Windows.Forms.PictureBox();
            this.cloudPicture2 = new System.Windows.Forms.PictureBox();
            this.cloudPicture3 = new System.Windows.Forms.PictureBox();
            this.cloudPicture4 = new System.Windows.Forms.PictureBox();
            this.cloudPicture5 = new System.Windows.Forms.PictureBox();
            this.cloudPicture6 = new System.Windows.Forms.PictureBox();
            this.cloudPicture7 = new System.Windows.Forms.PictureBox();
            this.cloudPicture8 = new System.Windows.Forms.PictureBox();
            this.cloudPicture9 = new System.Windows.Forms.PictureBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.cloudPicture1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cloudPicture2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cloudPicture3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cloudPicture4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cloudPicture5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cloudPicture6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cloudPicture7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cloudPicture8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cloudPicture9)).BeginInit();
            this.SuspendLayout();
            // 
            // hardButton
            // 
            this.hardButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.hardButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.hardButton.Font = new System.Drawing.Font("Comic Sans MS", 28.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.hardButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.hardButton.Location = new System.Drawing.Point(250, 356);
            this.hardButton.Name = "hardButton";
            this.hardButton.Size = new System.Drawing.Size(700, 100);
            this.hardButton.TabIndex = 12;
            this.hardButton.Text = "HARD";
            this.hardButton.UseVisualStyleBackColor = false;
            this.hardButton.Click += new System.EventHandler(this.difficultySelection_Click);
            // 
            // mediumButton
            // 
            this.mediumButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.mediumButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.mediumButton.Font = new System.Drawing.Font("Comic Sans MS", 28.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.mediumButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.mediumButton.Location = new System.Drawing.Point(250, 250);
            this.mediumButton.Name = "mediumButton";
            this.mediumButton.Size = new System.Drawing.Size(700, 100);
            this.mediumButton.TabIndex = 11;
            this.mediumButton.Text = "MEDIUM";
            this.mediumButton.UseVisualStyleBackColor = false;
            this.mediumButton.Click += new System.EventHandler(this.difficultySelection_Click);
            // 
            // easyButton
            // 
            this.easyButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.easyButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.easyButton.Font = new System.Drawing.Font("Comic Sans MS", 28.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.easyButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.easyButton.Location = new System.Drawing.Point(250, 144);
            this.easyButton.Name = "easyButton";
            this.easyButton.Size = new System.Drawing.Size(700, 100);
            this.easyButton.TabIndex = 13;
            this.easyButton.Text = "EASY";
            this.easyButton.UseVisualStyleBackColor = false;
            this.easyButton.Click += new System.EventHandler(this.difficultySelection_Click);
            // 
            // goBackButton
            // 
            this.goBackButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.goBackButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.goBackButton.Font = new System.Drawing.Font("Comic Sans MS", 28.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.goBackButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.goBackButton.Location = new System.Drawing.Point(250, 462);
            this.goBackButton.Name = "goBackButton";
            this.goBackButton.Size = new System.Drawing.Size(700, 100);
            this.goBackButton.TabIndex = 14;
            this.goBackButton.Text = "GO BACK";
            this.goBackButton.UseVisualStyleBackColor = false;
            this.goBackButton.Click += new System.EventHandler(this.goBackButton_Click);
            // 
            // cloudPicture1
            // 
            this.cloudPicture1.Image = global::SpinWheel.Properties.Resources.Cloud1;
            this.cloudPicture1.Location = new System.Drawing.Point(24, 60);
            this.cloudPicture1.Name = "cloudPicture1";
            this.cloudPicture1.Size = new System.Drawing.Size(220, 240);
            this.cloudPicture1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.cloudPicture1.TabIndex = 15;
            this.cloudPicture1.TabStop = false;
            // 
            // cloudPicture2
            // 
            this.cloudPicture2.Image = global::SpinWheel.Properties.Resources.Cloud1;
            this.cloudPicture2.Location = new System.Drawing.Point(225, 250);
            this.cloudPicture2.Name = "cloudPicture2";
            this.cloudPicture2.Size = new System.Drawing.Size(220, 240);
            this.cloudPicture2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.cloudPicture2.TabIndex = 16;
            this.cloudPicture2.TabStop = false;
            // 
            // cloudPicture3
            // 
            this.cloudPicture3.Image = global::SpinWheel.Properties.Resources.Cloud1;
            this.cloudPicture3.Location = new System.Drawing.Point(330, -43);
            this.cloudPicture3.Name = "cloudPicture3";
            this.cloudPicture3.Size = new System.Drawing.Size(220, 240);
            this.cloudPicture3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.cloudPicture3.TabIndex = 17;
            this.cloudPicture3.TabStop = false;
            // 
            // cloudPicture4
            // 
            this.cloudPicture4.Image = global::SpinWheel.Properties.Resources.Cloud1;
            this.cloudPicture4.Location = new System.Drawing.Point(83, 501);
            this.cloudPicture4.Name = "cloudPicture4";
            this.cloudPicture4.Size = new System.Drawing.Size(220, 240);
            this.cloudPicture4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.cloudPicture4.TabIndex = 18;
            this.cloudPicture4.TabStop = false;
            // 
            // cloudPicture5
            // 
            this.cloudPicture5.Image = global::SpinWheel.Properties.Resources.Cloud1;
            this.cloudPicture5.Location = new System.Drawing.Point(495, 385);
            this.cloudPicture5.Name = "cloudPicture5";
            this.cloudPicture5.Size = new System.Drawing.Size(220, 240);
            this.cloudPicture5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.cloudPicture5.TabIndex = 19;
            this.cloudPicture5.TabStop = false;
            // 
            // cloudPicture6
            // 
            this.cloudPicture6.Image = global::SpinWheel.Properties.Resources.Cloud1;
            this.cloudPicture6.Location = new System.Drawing.Point(756, 530);
            this.cloudPicture6.Name = "cloudPicture6";
            this.cloudPicture6.Size = new System.Drawing.Size(220, 240);
            this.cloudPicture6.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.cloudPicture6.TabIndex = 20;
            this.cloudPicture6.TabStop = false;
            // 
            // cloudPicture7
            // 
            this.cloudPicture7.Image = global::SpinWheel.Properties.Resources.Cloud1;
            this.cloudPicture7.Location = new System.Drawing.Point(588, 123);
            this.cloudPicture7.Name = "cloudPicture7";
            this.cloudPicture7.Size = new System.Drawing.Size(220, 240);
            this.cloudPicture7.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.cloudPicture7.TabIndex = 21;
            this.cloudPicture7.TabStop = false;
            // 
            // cloudPicture8
            // 
            this.cloudPicture8.Image = global::SpinWheel.Properties.Resources.Cloud1;
            this.cloudPicture8.Location = new System.Drawing.Point(1016, 12);
            this.cloudPicture8.Name = "cloudPicture8";
            this.cloudPicture8.Size = new System.Drawing.Size(220, 240);
            this.cloudPicture8.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.cloudPicture8.TabIndex = 22;
            this.cloudPicture8.TabStop = false;
            // 
            // cloudPicture9
            // 
            this.cloudPicture9.Image = global::SpinWheel.Properties.Resources.Cloud1;
            this.cloudPicture9.Location = new System.Drawing.Point(922, 284);
            this.cloudPicture9.Name = "cloudPicture9";
            this.cloudPicture9.Size = new System.Drawing.Size(220, 240);
            this.cloudPicture9.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.cloudPicture9.TabIndex = 23;
            this.cloudPicture9.TabStop = false;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // difficultyScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SkyBlue;
            this.ClientSize = new System.Drawing.Size(1182, 753);
            this.Controls.Add(this.goBackButton);
            this.Controls.Add(this.hardButton);
            this.Controls.Add(this.mediumButton);
            this.Controls.Add(this.easyButton);
            this.Controls.Add(this.cloudPicture9);
            this.Controls.Add(this.cloudPicture8);
            this.Controls.Add(this.cloudPicture7);
            this.Controls.Add(this.cloudPicture6);
            this.Controls.Add(this.cloudPicture5);
            this.Controls.Add(this.cloudPicture4);
            this.Controls.Add(this.cloudPicture3);
            this.Controls.Add(this.cloudPicture2);
            this.Controls.Add(this.cloudPicture1);
            this.MaximizeBox = false;
            this.Name = "difficultyScreen";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Spin Wheel";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.difficultyScreen_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.cloudPicture1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cloudPicture2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cloudPicture3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cloudPicture4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cloudPicture5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cloudPicture6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cloudPicture7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cloudPicture8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cloudPicture9)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button hardButton;
        private System.Windows.Forms.Button mediumButton;
        private System.Windows.Forms.Button easyButton;
        private System.Windows.Forms.Button goBackButton;
        private System.Windows.Forms.PictureBox cloudPicture1;
        private System.Windows.Forms.PictureBox cloudPicture2;
        private System.Windows.Forms.PictureBox cloudPicture3;
        private System.Windows.Forms.PictureBox cloudPicture4;
        private System.Windows.Forms.PictureBox cloudPicture5;
        private System.Windows.Forms.PictureBox cloudPicture6;
        private System.Windows.Forms.PictureBox cloudPicture7;
        private System.Windows.Forms.PictureBox cloudPicture8;
        private System.Windows.Forms.PictureBox cloudPicture9;
        private System.Windows.Forms.Timer timer1;
    }
}