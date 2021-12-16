using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SpinWheel
{
    public partial class startScreen : Form
    {
        int finalCloudLocation = 0;
        public startScreen()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            moveClouds(1);
            finalCloudLocation++;
        }

        void moveClouds(int cloudSpeed)
        {
            cloudPicture1.Location = new Point(cloudPicture1.Location.X - cloudSpeed, cloudPicture1.Location.Y);
            cloudPicture2.Location = new Point(cloudPicture2.Location.X - cloudSpeed, cloudPicture2.Location.Y);
            cloudPicture3.Location = new Point(cloudPicture3.Location.X - cloudSpeed, cloudPicture3.Location.Y);
            cloudPicture4.Location = new Point(cloudPicture4.Location.X - cloudSpeed, cloudPicture4.Location.Y);
            cloudPicture5.Location = new Point(cloudPicture5.Location.X - cloudSpeed, cloudPicture5.Location.Y);
            cloudPicture6.Location = new Point(cloudPicture6.Location.X - cloudSpeed, cloudPicture6.Location.Y);
            cloudPicture7.Location = new Point(cloudPicture7.Location.X - cloudSpeed, cloudPicture7.Location.Y);
            cloudPicture8.Location = new Point(cloudPicture8.Location.X - cloudSpeed, cloudPicture8.Location.Y);
            cloudPicture9.Location = new Point(cloudPicture9.Location.X - cloudSpeed, cloudPicture9.Location.Y);

            if (cloudPicture1.Location.X == -168)
            {
                cloudPicture1.Location = new Point(cloudPicture1.Location.X + 1036, cloudPicture1.Location.Y);
            }
            if (cloudPicture2.Location.X == -168)
            {
                cloudPicture2.Location = new Point(cloudPicture2.Location.X + 1036, cloudPicture2.Location.Y);
            }
            if (cloudPicture3.Location.X == -168)
            {
                cloudPicture3.Location = new Point(cloudPicture3.Location.X + 1036, cloudPicture3.Location.Y);
            }
            if (cloudPicture4.Location.X == -168)
            {
                cloudPicture4.Location = new Point(cloudPicture4.Location.X + 1036, cloudPicture4.Location.Y);
            }
            if (cloudPicture5.Location.X == -168)
            {
                cloudPicture5.Location = new Point(cloudPicture5.Location.X + 1036, cloudPicture5.Location.Y);
            }
            if (cloudPicture6.Location.X == -168)
            {
                cloudPicture6.Location = new Point(cloudPicture6.Location.X + 1036, cloudPicture6.Location.Y);
            }
            if (cloudPicture7.Location.X == -168)
            {
                cloudPicture7.Location = new Point(cloudPicture7.Location.X + 1036, cloudPicture7.Location.Y);
            }
            if (cloudPicture8.Location.X == -168)
            {
                cloudPicture8.Location = new Point(cloudPicture8.Location.X + 1036, cloudPicture8.Location.Y);
            }
            if (cloudPicture9.Location.X == -168)
            {
                cloudPicture9.Location = new Point(cloudPicture9.Location.X + 1036, cloudPicture9.Location.Y);
            }

        }

        private void playButton_Click(object sender, EventArgs e)
        {
            finalCloudLocation %= 1200;
            difficultyScreen fDiff = new difficultyScreen(finalCloudLocation);
            fDiff.Show();
            this.Hide();
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        public void goBackToStartScreen()
        {
            this.Show();
        }

        private void startScreen_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(e.CloseReason == CloseReason.UserClosing)
            {
                Application.Exit();
            }
        }
    }
}
