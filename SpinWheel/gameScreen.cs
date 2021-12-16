using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Reflection;

namespace SpinWheel
{
    public partial class gameScreen : Form
    {   
        // messagelabel initial location = (259, 0)
        // message label center location = (259, 230)
        // proverb , animal, object, profession,    
        string inputString;
        string outputString;
        string guessString; 
        string pointIndicated = "";                 // my chances
        string letterChosen = "";
        string puzzleType;
        List<int> lettersFound = new List<int>();

        bool messageShown = false;           
        bool puzzleNumberShown = false;
        bool puzzleTypeShown = false;
        bool firstStart = false;
        bool secondStart = false;
        bool thirdStart = false;
        bool puzzleFirstDisplayed = false;   // puzzle first shown check
        bool puzzleAssigned = false;
        bool itemsMoved = false;
        bool wheelMoved = false;
        bool wheelTurned = false;
        bool spinActionConfirmed = false;
        bool stopActionConfirmed = false;
        bool goBackConfirmed = false;
        bool letterSelected = false;        // to use timergeneral to show letters one by one
        bool spinButtonClicked = false;     // to check if it happens before letters open
        bool blankLettersOpened = false;
        bool buyVowelConfirmed = false;

        int puzzleCount = 0;
        int spinStopCounter = 0;
        int spinStopLimit = 0;
        int thirdStartIndex = 0;                // third starting animation index
        int showTheMessageLabelCount = 0;       // counting index showing message #seconds
        int showTheMessageLabelSeconds;         // time message label will be shown       
        int startIndex = 0;                     // moving through the columns
        int angleValue = 0;                  
        int angleSpeed = 9;                     // ANGLE SPEED   should take value 90%value == 0
        int randomAngleOutput=0;
        int letterDisplayedIndex = 0;           
        int lettersFoundIndex = 0;
        int answerDisplayIndex = 0;
        int totalScore = 0;
        int tempScore = 0;
        int turnNumber = 15;
        int guessTime = 30;

        string[] easyPuzzles =
        {
            "BESLE KARGAYI OYSUN GÖZÜNÜ", "CAN ÇIKMAYINCA HUY ÇIKMAZ", "GELEN GİDENİ ARATIR", "DEMİR TAVINDA DÖVÜLÜR",
            "LAF İLE PEYNİR GEMİSİ YÜRÜMEZ", "NE EKERSEN ONU BİÇERSİN", "ÖFKEYLE KALKAN ZARARLA OTURUR", "GÜNEŞ GİRMEYEN EVE DOKTOR GİRER",        
            "ÜZÜM ÜZÜME BAKA BAKA KARARIR", "ÜZÜMÜNÜ YE BAĞINI SORMA", "ASLAN", "KAPLAN", "KEDİ", "KÖPEK", "LEYLEK", "PENGUEN",
            "MAYMUN", "GEYİK", "FARE", "İNEK", "KALEM", "KİTAP", "TELEFON", "ÇANTA", "MASA", "KUTU", "KAPI", "PENCERE", "SAAT",
            "BİLGİSAYAR", "DOKTOR", "ÖĞRETMEN", "MARANGOZ", "DİŞ HEKİMİ", "ECZACI", "YAZAR", "AVUKAT", "BASKETBOLCU", "ANTRENÖR", "BİLGİSAYAR MÜHENDİSİ"
        };
        string[] mediumPuzzles =
        {
            "ÇÜRÜK TAHTA ÇİVİ TUTMAZ", "DAVULUN SESİ UZAKTAN HOŞ GELİR", "YALANCININ EVİ YANMIŞ KİMSE İNANMAMIŞ",
            "HER HOROZ KENDİ ÇÖPLÜĞÜNDE ÖTER", "YALANCININ MUMU YATSIYA KADAR YANAR", "DOĞRU SÖYLEYENİ DOKUZ KÖYDEN KOVARLAR",
            "BAŞ BAŞA VERMEYİNCE TAŞ YERİNDEN KALKMAZ", "BÜLBÜLÜ ALTIN KAFESE KOYMUŞLAR AH VATANIM DEMİŞ",
            "İNSAN YEDİSİNDE NE İSE YETMİŞİNDE DE ODUR", "KEDİ UZANAMADIĞI CİĞERE MURDAR DER",
            "AHTAPOT", "ATMACA", "KARTAL", "KUZGUN", "DEVEKUŞU", "GERGEDAN", "HOROZ", "KANGURU", "LEOPAR", "NEON BALIĞI",
            "KERPETEN", "LAPTOP", "MANTO", "OYUNCAK", "RADYO", "SALINCAK", "VANTİLATÖR", "ZIMPARA", "YELPAZE", "ADAPTÖR",
            "BİYOLOG", "CANKURTARAN", "EKONOMİST", "FOTOĞRAFÇI", "HAKİM", "İÇ MİMAR", "MADEN MÜHENDİSİ", "PSİKOLOG", "ÇİLİNGİR", "PARKE DÖŞEMECİSİ"
        };
        string[] hardPuzzles =
        {
            "AKARA KOKARA BAKMA ÇUVALA GİRENE BAK", "BİR DÖNÜM GÜZLÜK ON DÖNÜM YAZLIĞA BEDELDİR", 
            "GÖLGESİNDE OTURULACAK AĞACIN DALI KESİLMEZ", "DAĞ BAŞINDAN DUMAN EKSİK OLMAZ", 
            "KARTALA BİR OK DEĞMİŞ YİNE KENDİ YELEĞİNDEN", "OLSA İLE BULSAYI EKMİŞLER YEL İLE YUF BİTMİŞ",
            "PALAMUT ÇOK BİTERSE KIŞ ERKEN OLUR", "HER ZAMAN GEMİCİNİN İSTEDİĞİ RÜZGAR ESMEZ",
            "TARLADA İZİ OLMAYANIN HARMANINDA YÜZÜ OLMAZ", "YARIM HEKİM CANDAN EDER YARIM HOCA DİNDEN EDER",
            "ALAYCI KUŞ", "MAVİ BALİNA", "KARINCAYİYEN", "KAPLAN KELEBEĞİ","DENİZ KESTANESİ", "GÖKKUŞAĞI İSPİNOZU", 
            "HAYALET YARASA", "KALKAN BALIĞI", "MİSK GEYİĞİ", "REN GEYİĞİ", "KONTEYNIR", "LİMON SIKACAĞI", "MANDOLİN", 
            "OKLAVA", "RONDELA", "SÖRF TAHTASI", "VESTİYER", "ZEMBEREK", "YAĞDANLIK", "BAROMETRE",
            "ACİL TIP TEKNİSYENİ", "AHŞAP BOYACISI", "BİYOKİMYAGER", "ETNOLOG", "FINDIK EKSPERİ", "HUKUK SEKRETERİ",
            "İSTATİSTİKÇİ", "KABİN MEMURU", "NÜKLEER ENERJİ MÜHENDİSİ", "SOSYAL ANTROPOLOG"
        };

        int[] columnTArrayStart =
        {   0, 6, 10, 12, 14,
            16, 18, 20, 22, 24,
            26, 28, 30, 32, 34,
            38
        };   // For starting animation
        int[] columnTArrayEnd =
        {
            5, 9, 11, 13, 15,
            17, 19, 21, 23, 25,
            27, 29, 31, 33, 37,
            43
        };     // For starting animation
        int[] vowelIndexArray =
        {
            0, 5, 10, 11, 17, 18, 24, 25
        };
        string[] alphaCharArray = new string[29];
        string difficultySelected;
        Button[] buttonArray;
        Button[] letterButtonArray;
        TextBox[] textBoxArray;
        PictureBox[] wheelPictureArray;
        string[] comparedWords;

        public gameScreen(string diff)
        {
            InitializeComponent();
            difficultySelected = diff;
            
        }
        private void gameScreen_Load(object sender, EventArgs e)
        {
            indicatorPicture.Visible = false;
            indicatorPicture.Image.RotateFlip(RotateFlipType.Rotate180FlipNone);
            indicatorPicture.BringToFront();
            buyVowelButton.Visible = false;
            guessTextBox.Visible = false;
            labelGuessTime.Visible = false;
            letterButton.Visible = false;
            goBackButton.Visible = false;
            guessButton.Visible = false;
            spinButton.Visible = false;
            stopButton.Visible = false;
            spinActionButton.Visible = false;
            messageLabel.Visible = false;
 
            buttonArray = new Button[]
            {
                button1, button2, button3, button4, button5, button6,
                button7, button8, button9, button10, button11, button12,
                button13, button14, button15, button16, button17, button18,
                button19, button20, button21, button22, button23, button24,
                button25, button26, button27, button28, button29, button30,
                button31, button32, button33, button34, button35, button36,
                button37, button38, button39, button40, button41, button42,
                button43, button44, button45, button46, button47, button48,
                button49, button50, button51, button52
            };

            letterButtonArray = new Button[]
            {
                letterButton0, letterButton1, letterButton2, letterButton3,
                letterButton4, letterButton5, letterButton6, letterButton7,
                letterButton8, letterButton9, letterButton10, letterButton11,
                letterButton12, letterButton13, letterButton14, letterButton15,
                letterButton16, letterButton17, letterButton18, letterButton19,
                letterButton20, letterButton21, letterButton22, letterButton23,
                letterButton24, letterButton25, letterButton26, letterButton27,
                letterButton28
            };

            textBoxArray = new TextBox[]
            {
                textBox1, textBox2, textBox3, textBox4, textBox5, textBox6,
                textBox7, textBox8, textBox9, textBox10, textBox11, textBox12,
                textBox13, textBox14, textBox15, textBox16, textBox17, textBox18,
                textBox19, textBox20, textBox21, textBox22, textBox23, textBox24,
                textBox25, textBox26, textBox27, textBox28, textBox29, textBox30,
                textBox31, textBox32, textBox33, textBox34, textBox35, textBox36,
                textBox37, textBox38, textBox39, textBox40, textBox41, textBox42,
                textBox43, textBox44
            };

            wheelPictureArray = new PictureBox[]
            {
                pictureBox0, pictureBox1, pictureBox2, pictureBox3, pictureBox4,
                pictureBox5, pictureBox6, pictureBox7, pictureBox8, pictureBox9,
                pictureBox10, pictureBox11, pictureBox12, pictureBox13, pictureBox14,
                pictureBox15, pictureBox16, pictureBox17, pictureBox18, pictureBox19,
                pictureBox20, pictureBox21, pictureBox22, pictureBox23, pictureBox24,
                pictureBox25, pictureBox26, pictureBox27, pictureBox28, pictureBox29,
                pictureBox30, pictureBox31, pictureBox32, pictureBox33, pictureBox34,
                pictureBox35, pictureBox36, pictureBox37, pictureBox38, pictureBox39,
                pictureBox40, pictureBox41, pictureBox42, pictureBox43, pictureBox44,
                pictureBox45, pictureBox46, pictureBox47, pictureBox48, pictureBox49,
                pictureBox50, pictureBox51, pictureBox52, pictureBox53, pictureBox54,
                pictureBox55, pictureBox56, pictureBox57, pictureBox58, pictureBox59,
                pictureBox60, pictureBox61, pictureBox62, pictureBox63, pictureBox64,
                pictureBox65, pictureBox66, pictureBox67, pictureBox68, pictureBox69,
                pictureBox70, pictureBox71, pictureBox72, pictureBox73, pictureBox74,
                pictureBox75, pictureBox76, pictureBox77, pictureBox78, pictureBox79,
                pictureBox80, pictureBox81, pictureBox82, pictureBox83, pictureBox84,
                pictureBox85, pictureBox86, pictureBox87, pictureBox88, pictureBox89
            };

            for (int i = 0; i < 52; i++)
            {
                buttonArray[i].TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                buttonArray[i].BackColor = Color.SlateGray;
                buttonArray[i].Text = "";
                if (i < 44)
                {
                    textBoxArray[i].BackColor = Color.SlateGray;
                    textBoxArray[i].ReadOnly = true;
                    textBoxArray[i].Enabled = false;
                } 
                if(i < 29)
                {
                    letterButtonArray[i].Visible = false;
                    alphaCharArray[i] = letterButtonArray[i].Text;
                }
            } 
        }


        private void startButton_Click(object sender, EventArgs e)
        {
            startButton.Visible = false;
         
            messageLabel.Text = "Starting Animation";
            showTheMessageLabelSeconds = 2;
            timerMessage.Enabled = true;
            messageShown = true;

            timerStart.Enabled = true;
            assignRandomInputString(puzzleCount);

        }    // message label for  #seconds

        private void spinButton_Click(object sender, EventArgs e)
        {
            buyVowelConfirmed = false;
            labelGuessTime.Visible = false;
            guessTime = 30;
            labelGuessTime.Text = (guessTime).ToString();
            guessButton.Visible = false;
            spinButton.Visible = false;
            turnsLabel.Visible = false;
            turnsBoard.Visible = false;
            BackColor = Color.Black;
            
            foreach(int buttonIndex in lettersFound)
            {
                buttonArray[buttonIndex].Text = letterChosen;
            }
            lettersFound.Clear();
            letterChosen = "";
            lettersFoundIndex = 0;

            goBackConfirmed = false;
            timerGeneral.Enabled = false;
            timerWheelScreen.Enabled = true;
            timerGuessLimit.Enabled = false;
        }

        private void spinActionButton_Click(object sender, EventArgs e)
        {
            spinActionConfirmed = true;             // for timerwheelscreen thread to call spin the wheel condition
            spinActionButton.Visible = false;
            timerWheelScreen.Interval = 1;

            timerSpinStop.Enabled = true;
            spinStopLimit = 1;
        }

        private void stopButton_Click(object sender, EventArgs e)
        {
            spinActionConfirmed = false;
            stopActionConfirmed = true;
            timerWheelScreen.Enabled = false;
            wheelTurned = true;
            
            wheelMoved = false;
            
            stopButton.Visible = false;
            timerSpinStop.Enabled = true;    // that's for goback button to appear 2 seconds later
            spinStopLimit = 2;

            messageShown = false;           // we need centerMessageLabel
            showTheMessageLabelSeconds = 4;
            timerMessage.Enabled = true;
            centerMessageLabel.BackColor = Color.RoyalBlue;
            centerMessageLabel.Location = new Point(centerMessageLabel.Location.X, centerMessageLabel.Location.Y + 80);
            pointAssigning(randomAngleOutput);
            if(pointIndicated[0] == 'x')
            {
                string subString = pointIndicated.Substring(1);
                tempScore = Convert.ToInt32(subString);
            }
            centerMessageLabel.Text = pointIndicated; 
        }

        private void goBackButton_Click(object sender, EventArgs e)
        {
            timerWheelScreen.Enabled = true;
            goBackButton.Visible = false;
            goBackConfirmed = true;
        }

        private void letterButton_Click(object sender, EventArgs e)
        {
            letterButton.Visible = false;
            buyVowelButton.Visible = true;
            for(int i = 0; i<29; i++)
            {
                for(int j = 0; j < 8; j++)
                {
                    if(i == vowelIndexArray[j])
                    {
                        letterButtonArray[i].Text = "";
                        letterButtonArray[i].Enabled = false;
                        break;
                    }
                    else if (j == 7)
                    {
                        letterButtonArray[i].Enabled = true;
                        letterButtonArray[i].Text = alphaCharArray[i];
                    }
                }
                letterButtonArray[i].Visible = true;
            }        
        }

        private void assignLetterButton_Click(object sender, EventArgs e)
        {
            if(letterSelected == false)
            {
                Button chosenLetter = (Button)sender;
                chosenLetter.BackColor = Color.RoyalBlue;
                letterChosen = chosenLetter.Text;
                timerGeneral.Enabled = true;
                letterSelected = true;
                buyVowelConfirmed = true;
            }
            for(int i=0; i<29; i++)
            {
                letterButtonArray[i].Enabled = false;
            }
        }

        private void guessButton_Click(object sender, EventArgs e)
        {
            guessTextBox.Clear();
            guessTextBox.Text = "Type and Enter Please";
            guessTextBox.Visible = true;
            guessTextBox.BringToFront();
            guessButton.Visible = false;
            spinButton.Visible = false;
            timerGuessLimit.Enabled = true;
            labelGuessTime.Visible = true;
        }

        private void guessTextBox_MouseDown(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Left)
            {
                guessTextBox.Text = "";
            }
        }

        private void guessTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                guessTextBox.Visible = false;
                guessButton.Visible = true;
                spinButton.Visible = true;
                guessString = guessTextBox.Text.ToUpper();
                if(guessString == inputString)
                {
                    timerGuessLimit.Enabled = false;
                    labelGuessTime.Visible = false;
                    spinButton.Visible = false;
                    guessButton.Visible = false;
                    messageLabel.Text = "CORRECT GUESS! (+5000)";
                    messageLabel.Visible = true;
                    showTheMessageLabelSeconds = 4;
                    timerMessage.Enabled = true;
                    messageShown = true;
                    timerShow.Enabled = true;
                    timerShow.Interval = 50;
                    totalScore += 5000;
                    scoreLabel.Text = (totalScore).ToString();
                }
                else
                {
                    messageLabel.Text = "WRONG GUESS!";
                    messageLabel.Visible = true;
                    showTheMessageLabelSeconds = 2;
                    timerMessage.Enabled = true;
                    messageShown = true;
                }
            }
        }

        private void buyVowelButton_Click(object sender, EventArgs e)
        {
            if(totalScore >= 1000)
            {
                if (buyVowelConfirmed == false)
                {
                    buyVowelConfirmed = true;
                    totalScore -= 1000;
                    scoreLabel.Text = (totalScore).ToString();
                    for (int i = 0; i < 29; i++)
                    {
                        for (int j = 0; j < 8; j++)
                        {
                            if (i == vowelIndexArray[j])
                            {
                                letterButtonArray[i].Enabled = true;
                                letterButtonArray[i].Text = alphaCharArray[i];
                                break;
                            }
                            else if (j == 7)
                            {
                                letterButtonArray[i].Text = "";
                                letterButtonArray[i].Enabled = false;
                            }
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("YOU MUST HAVE AT LEAST 1000$");
            }
        }

        
        private void timerMessage_Tick(object sender, EventArgs e)
        {
            if (messageShown == true)
            {
                messageLabel.Visible = true;
                messageLabel.BringToFront();
                showTheMessageLabel(showTheMessageLabelSeconds);
            }
            else
            {
                centerMessageLabel.BringToFront();
                centerMessageLabel.Visible = true;
                showTheCenterMessageLabel(showTheMessageLabelSeconds);
            }
        }      // visibility will be changed when the text first assigned

        private void timerStart_Tick(object sender, EventArgs e)
        {
            if(secondStart == true)
            {
                startTheGameThird();
            }
            else if (firstStart == true)
            {
                startTheGameSecond();
            }
            else
            {
                startTheGameFirst();
            }                      
        }       // game starting animation  

        private void timerWheelScreen_Tick(object sender, EventArgs e)
        {
            if(itemsMoved == false)
            {
                moveTheItems();
            }
            else if(wheelMoved == false)
            {
                timerWheelScreen.Interval = 1;
                moveTheWheel();
            }
            else if (wheelTurned == false && spinActionConfirmed == true)
            {
                spinTheWheel(angleSpeed); 
            }
        }

        private void timerGeneral_Tick(object sender, EventArgs e)
        {   
            if(thirdStart == true)  
            {
                if (puzzleNumberShown == false && timerMessage.Enabled == false)
                {
                    messageShown = false;           
                    centerMessageLabel.Text = (puzzleCount + 1).ToString() + ". PUZZLE";   
                    showTheMessageLabelSeconds = 2;
                    timerMessage.Enabled = true;
                    puzzleNumberShown = true;         
                }

                else if (puzzleTypeShown == false && timerMessage.Enabled == false)
                {
                    messageShown = false;
                    centerMessageLabel.Text = puzzleType;        
                    showTheMessageLabelSeconds = 2;
                    timerMessage.Enabled = true;
                    puzzleTypeShown = true;
                }

                else if(puzzleTypeShown==true && timerMessage.Enabled == false)
                {
                    if (letterSelected == true || blankLettersOpened == true)               
                    {
                        timerGeneral.Interval = 500;
                    }
                    else
                    {                                                      
                        timerGeneral.Interval = 50;
                    }
                    displayThePuzzle(puzzleCount);
                }
            }
        }

        private void timerSpinStop_Tick(object sender, EventArgs e)
        {
            spinStopCounter++;
            if(spinStopCounter >= spinStopLimit)
            {
                if(spinActionConfirmed == true)
                {
                    stopButton.Visible = true;
                    stopButton.BringToFront();
                    spinStopCounter = 0;
                    timerSpinStop.Enabled = false;
                }
                else if(stopActionConfirmed == true)
                {
                    goBackButton.Visible = true;
                    goBackButton.BringToFront();
                    spinStopCounter = 0;
                    timerSpinStop.Enabled = false;
                }
            }  
        }

        private void timerShow_Tick(object sender, EventArgs e)
        {
            displayTheAnswer();
        }

        private void timerGuessLimit_Tick(object sender, EventArgs e)
        {
            guessTime--;
            labelGuessTime.Text = (guessTime).ToString();
            if(guessTime == 0 && turnNumber == 0)
            {
                labelGuessTime.Visible = false;
                guessTime = 30;
                guessButton.Visible = false;
                spinButton.Visible = false;
                guessTextBox.Visible = false;
                goToNextPuzzle();
                timerGuessLimit.Enabled = false;
            }
            else if(guessTime == 0)
            {
                labelGuessTime.Visible = false;
                guessTime = 30;
                guessButton.Visible = false;
                guessTextBox.Visible = false;
                spinButton.Visible = true;
                timerGuessLimit.Enabled = false;
            }
        }


        public void assignRandomInputString(int puzzleNumber)
        {
            Random rndStringIndex = new Random();
            int index = rndStringIndex.Next(0+(10*puzzleNumber), 0+(10 * puzzleNumber)+10);

            switch (difficultySelected)
            {
                case "EASY":
                    inputString = easyPuzzles[index];
                    break;
                case "MEDIUM":
                    inputString = mediumPuzzles[index];
                    break;
                case "HARD":
                    inputString = hardPuzzles[index];
                    break;
            }
            if(index < 10)
            {
                puzzleType = "PROVERB";
            }
            else if(index < 20)
            {
                puzzleType = "ANIMAL";
            }
            else if(index < 30)
            {
                puzzleType = "OBJECT";
            }
            else
            {
                puzzleType = "PROFESSION";
            }
        }           // random inputstring assigning

        public void showTheMessageLabel(int visibleTime)
        {
            if(showTheMessageLabelCount == visibleTime)
            {
                showTheMessageLabelCount = 0;
                messageLabel.Visible = false;
                timerMessage.Enabled = false;
                messageLabel.BackColor = Color.SlateGray;
                if(messageLabel.Text == "Starting Animation")
                {
                    messageLabel.Visible = false;
                }
            }
            showTheMessageLabelCount++;        
        } 

        public void showTheCenterMessageLabel(int visibleTime)
        {
            // initial location 259; 230
            if (showTheMessageLabelCount == visibleTime)
            {
                if(stopActionConfirmed == true)
                {
                    centerMessageLabel.Location = new Point(centerMessageLabel.Location.X, centerMessageLabel.Location.Y - 80);
                    stopActionConfirmed = false;
                }
                showTheMessageLabelCount = 0;
                centerMessageLabel.Visible = false;
                timerMessage.Enabled = false;
                messageShown = false;  // set it to center here
                centerMessageLabel.BackColor = Color.SlateGray;
                if(centerMessageLabel.Text == "Game Over")
                {
                    Application.Exit();
                }
            }
            showTheMessageLabelCount++;
        }

        public void startTheGameFirst()
        {
            if(startIndex >= columnTArrayStart.Length)
            {
                startIndex--;
            }
            for (int i = columnTArrayStart[startIndex]; i <= columnTArrayEnd[startIndex]; i++)
            {
                textBoxArray[i].BackColor = Color.RoyalBlue;
            }
            for(int i = 0; i<52; i++)
            {
                if( textBoxArray[columnTArrayStart[startIndex]].Location.X == buttonArray[i].Location.X)
                {
                    buttonArray[i].BackColor = Color.RoyalBlue;
                    buttonArray[i].Text = "";
                }
            }
            startIndex++;
            if (startIndex == 16)
            {
                startIndex = 0;
                firstStart = true;
            }
        }               // first starting animation

        public void startTheGameSecond()
        {
            if (startIndex >= columnTArrayStart.Length)
            {
                startIndex--;
            }
            for (int i = columnTArrayStart[startIndex]; i <= columnTArrayEnd[startIndex]; i++)
            {
                textBoxArray[i].BackColor = Color.SlateGray;
            }
            for (int i = 0; i < 52; i++)
            {
                if (textBoxArray[columnTArrayStart[startIndex]].Location.X == buttonArray[i].Location.X)
                {
                    buttonArray[i].BackColor = Color.RoyalBlue;
                }
            }
            startIndex++;
            if(startIndex == 16)
            {
                startIndex = 0;
                secondStart = true;
            }

        }               // second starting animation

        public void startTheGameThird()
        {
            if (startIndex >= columnTArrayStart.Length)
            {
                startIndex--;
            }
            for (int i = columnTArrayStart[startIndex]; i <= columnTArrayEnd[startIndex]; i++)
            {
                textBoxArray[i].BackColor = Color.SlateGray;
            }
            for (int i = 0; i < 52; i++)
            {
                if (textBoxArray[columnTArrayStart[startIndex]].Location.X == buttonArray[i].Location.X)
                {
                    buttonArray[i].BackColor = Color.SlateGray;
                    buttonArray[i].Text = "";
                }
            }
            startIndex++;
            if(startIndex == 16 && puzzleCount > 3)
            {
                messageShown = false;
                centerMessageLabel.Text = "Game Over";
                showTheMessageLabelSeconds = 2;
                timerMessage.Enabled = true;
            }
            else if (startIndex == 16)
            {
                thirdStartIndex++;
                timerStart.Interval = 150;
                if(button20.BackColor == Color.SlateGray)
                {
                    for (int i = 0; i < 52; i++)
                    {
                        buttonArray[i].BackColor = Color.RoyalBlue;
                    }    
                }
                else if(button20.BackColor == Color.RoyalBlue)
                {
                    for (int i = 0; i < 52; i++)
                    {
                        buttonArray[i].BackColor = Color.SlateGray;
                    }
                }
                if(thirdStartIndex == 6)
                {
                    thirdStartIndex = 0;
                    startIndex = 0;
                    thirdStart = true;
                    timerStart.Enabled = false;
                    timerStart.Interval = 50;
                    timerGeneral.Enabled = true;
                }
            }
        }                       // third starting animation

        public void moveTheItems()
        {
            if (startIndex >= columnTArrayStart.Length)
            {
                startIndex--;
            }
            for (int i = columnTArrayStart[startIndex]; i <= columnTArrayEnd[startIndex]; i++)
            {
                if(goBackConfirmed == false)
                {
                    textBoxArray[i].Visible = false;
                }
                else
                {
                    textBoxArray[i].Visible = true;
                }
            }
            for (int i = 0; i < 52; i++)
            {
                if (textBoxArray[columnTArrayStart[startIndex]].Location.X == buttonArray[i].Location.X)
                {
                    if (goBackConfirmed == false)
                    {
                        buttonArray[i].Visible = false;
                    }
                    else
                    {
                        buttonArray[i].Visible = true;
                    }
                }
            }
            startIndex++;
            if (startIndex == 16)
            {
                startIndex = 0;
                itemsMoved = true;
                if(goBackConfirmed == true)
                {
                    turnNumber -= 1;
                    turnsLabel.Text = (turnNumber).ToString();
                    turnsLabel.Visible = true;
                    turnsBoard.Visible = true;
                    BackColor = Color.ForestGreen;
                    timerWheelScreen.Enabled = false;
                    itemsMoved = false;
                    wheelMoved = false;
                    wheelTurned = false;
                    spinActionConfirmed = false;
                    if(pointIndicated == "BANKRUPT!")
                    {
                        guessButton.Visible = true;
                        spinButton.Visible = true;
                        totalScore = 0;
                        scoreLabel.Text = (totalScore).ToString();
                    }
                    else if(pointIndicated == "lose a TURN!")
                    {
                        guessButton.Visible = true;
                        spinButton.Visible = true;
                        turnsLabel.Text = (turnNumber).ToString();
                    }
                    else
                    {
                        letterButton.Visible = true;
                    }

                    if(turnNumber == 0)
                    {
                        spinButton.Visible = false;
                    }
                }
            }
        }
        
        public void moveTheWheel()
        {
            if (goBackConfirmed == false)
            {
                wheelPictureArray[0].Visible = true;
                if (wheelPictureArray[0].Location.X <= 150)
                {
                    for (int i = 1; i <= 89; i++)
                    {
                        wheelPictureArray[i].Visible = false;
                        wheelPictureArray[i].Location = new Point(wheelPictureArray[0].Location.X, wheelPictureArray[0].Location.Y);
                    }
                    indicatorPicture.Location = new Point(wheelPictureArray[0].Location.X + 251, 193);
                    wheelMoved = true;
                    indicatorPicture.Visible = true;
                    spinActionButton.Visible = true;
                    spinActionButton.BringToFront();
                    timerWheelScreen.Interval = 50;

                }
                else
                {
                    wheelPictureArray[0].Location = new Point(wheelPictureArray[0].Location.X - 15, wheelPictureArray[0].Location.Y);
                }
            }
            else
            {
                int a = randomAngleOutput % 90;
                indicatorPicture.Visible = false;
                if (wheelPictureArray[a].Location.X >= 900)
                {
                    for(int i=0; i<=89; i++)
                    {
                        wheelPictureArray[i].Location = new Point(wheelPictureArray[a].Location.X, wheelPictureArray[a].Location.Y);
                    }
                    wheelMoved = true;
                    itemsMoved = false;
                    timerWheelScreen.Interval = 50;
                    
                }
                else
                {
                    wheelPictureArray[a].Location = new Point(wheelPictureArray[a].Location.X + 15, wheelPictureArray[a].Location.Y);
                }
            }
        }

        public void spinTheWheel(int speed)
        {           
            angleValue += speed;
            angleValue %= 90;
            wheelPictureArray[angleValue].Visible = true;
            if(angleValue >= speed)
            {
                wheelPictureArray[angleValue-speed].Visible = false;
                wheelPictureArray[angleValue - speed].Image.RotateFlip(RotateFlipType.Rotate90FlipNone);
            }
            else
            {
                wheelPictureArray[90-(speed-angleValue)].Visible = false;
                wheelPictureArray[90-(speed-angleValue)].Image.RotateFlip(RotateFlipType.Rotate90FlipNone);
            }
            randomAngleOutput += speed;
            randomAngleOutput %= 360;
        }

        public void displayThePuzzle(int puzzleCount)
        {
            if(puzzleAssigned == false)
            {
                string firstLine = "";
                string secondLine = "";
                string thirdLine = "";
                string fourthLine = "";
                string tempOutputString1 = "";
                string tempOutputString2 = ""; 
                outputString = "";

                int firstLineSize = 12;
                int secondLineSize = 14;
                int thirdLineSize = 14;
                int fourthLineSize = 12;

                int secondLineIndex = 0;
                int thirdLineIndex = 0;
                int fourthLineIndex = 0;
                int totalLineNumber;
                int tempInt;

                int wordNumberIndex = 0;         // to find how many words in the input string
                int wordTempSizeIndex = 0;       // to find sizes of each word
                int[] wordSizes = new int[10];   // word sizes here in an int array
                string[] words = new string[10];   // words here in an string array

                for (int i = 0; i < inputString.Length; i++)          // WORD NUMBERS AND SIZES ARE ASSIGNED
                {
                    wordTempSizeIndex++;
                    if (inputString[i] == ' ')
                    {
                        wordTempSizeIndex--;
                        wordSizes[wordNumberIndex] = wordTempSizeIndex;
                        wordTempSizeIndex = 0;
                        wordNumberIndex++;
                    }
                    else if (i == (inputString.Length - 1))
                    {
                        wordSizes[wordNumberIndex] = wordTempSizeIndex;
                        words[wordNumberIndex] += inputString[i];
                        wordNumberIndex++;
                    }
                    else
                    {
                        words[wordNumberIndex] += inputString[i];
                    }
                }
                for (int i = 0; i < wordNumberIndex; i++)                  // putting words into the lines
                {
                    if (firstLineSize >= (wordSizes[i] + 1))                   // FIRST LINE FITTING
                    {
                        if (i == 0)
                        {
                            firstLineSize -= wordSizes[i];
                            firstLine += words[i];
                        }
                        else
                        {
                            firstLineSize -= (wordSizes[i] + 1);
                            firstLine += " ";
                            firstLine += words[i];
                        }

                        if (firstLineSize < (wordSizes[i + 1] + 1))
                        {
                            firstLineSize = 0;
                            secondLineIndex = i + 1;
                        }
                    }
                    else if (secondLineSize >= (wordSizes[i] + 1))                 // SECOND LINE FITTING
                    {
                        if (i == secondLineIndex)
                        {
                            secondLineSize -= wordSizes[i];
                            secondLine += words[i];
                        }
                        else
                        {
                            secondLineSize -= (wordSizes[i] + 1);
                            secondLine += " ";
                            secondLine += words[i];
                        }

                        if (secondLineSize < (wordSizes[i + 1] + 1))
                        {
                            secondLineSize = 0;
                            thirdLineIndex = i + 1;
                        }
                    }
                    else if (thirdLineSize >= (wordSizes[i] + 1))              // THIRD LINE FITTING
                    {
                        if (i == thirdLineIndex)
                        {
                            thirdLineSize -= wordSizes[i];
                            thirdLine += words[i];
                        }
                        else
                        {
                            thirdLineSize -= (wordSizes[i] + 1);
                            thirdLine += " ";
                            thirdLine += words[i];
                        }

                        if (thirdLineSize < (wordSizes[i + 1] + 1))
                        {
                            thirdLineSize = 0;
                            fourthLineIndex = i + 1;
                        }
                    }
                    else                                                 // LAST LINE FITTING
                    {
                        if (i == fourthLineIndex)
                        {
                            fourthLineSize -= wordSizes[i];
                            fourthLine += words[i];
                        }
                        else
                        {
                            fourthLineSize -= (wordSizes[i] + 1);
                            fourthLine += " ";
                            fourthLine += words[i];
                        }
                    }
                }

                if(secondLineSize == 14)
                {
                    totalLineNumber = 1;
                }
                else if(thirdLineSize == 14)
                {
                    totalLineNumber = 2;
                }
                else if(fourthLineSize == 12)
                {
                    totalLineNumber = 3;
                }
                else
                {
                    totalLineNumber = 4;
                }

                tempOutputString1 += firstLine;
                for (int i = 0; i < (12 - firstLine.Length); i++)
                {
                    tempOutputString1 += " ";
                }

                tempOutputString1 += secondLine;
                for (int i = 0; i < (14 - secondLine.Length); i++)
                {
                    tempOutputString1 += " ";
                }

                tempOutputString1 += thirdLine;
                for (int i = 0; i < (14 - thirdLine.Length); i++)
                {
                    tempOutputString1 += " ";
                }
                tempOutputString1 += fourthLine;
                for (int i = 0; i < (12 - fourthLine.Length); i++)
                {
                    tempOutputString1 += " ";
                }

                switch (totalLineNumber)
                {
                    case 1:
                        for(int i = 0; i < 13; i++)
                        {
                            outputString += " ";
                        }
                        tempInt = 12 - firstLine.Length;
                        tempInt = tempInt / 2;
                        for (int i = 0; i < tempInt; i++)
                        {
                            outputString += " ";
                        }
                        outputString += firstLine;
                        for(int i = outputString.Length; i <= tempOutputString1.Length; i++)
                        {
                            outputString += " ";
                        }
                        break;
                    case 2:
                        if(secondLine.Length < 14)
                        {
                            outputString = tempOutputString1.Replace(secondLine + " ", " " + secondLine);
                        }
                        else
                        {
                            outputString = tempOutputString1;
                        }
                        break;
                    case 3:
                        if (secondLine.Length < 14 && thirdLine.Length < 14)
                        {
                            tempOutputString2 = tempOutputString1.Replace(secondLine + " ", " " + secondLine);
                            outputString = tempOutputString2.Replace(thirdLine + " ", " " + thirdLine);
                        }
                        else
                        {
                            outputString = tempOutputString1;
                        }
                        break;
                    case 4:
                        outputString = tempOutputString1; 
                        break;
                }

                puzzleAssigned = true;
                comparedWords = words;
            }

            else if(puzzleFirstDisplayed == false)
            {
                if (startIndex >= columnTArrayStart.Length)
                {
                    startIndex--;
                }
                for (int i = columnTArrayStart[startIndex]; i <= columnTArrayEnd[startIndex]; i++)
                {
                    textBoxArray[i].BackColor = Color.MidnightBlue;
                }
                for (int i = 0; i < 52; i++)
                {
                    if (textBoxArray[columnTArrayStart[startIndex]].Location.X == buttonArray[i].Location.X)
                    {
                        if (char.IsLetter(outputString[i]))
                        {
                            buttonArray[i].BackColor = Color.MediumVioletRed;
                        }
                        else
                        {
                            buttonArray[i].BackColor = Color.RoyalBlue;
                            buttonArray[i].Text = "";
                        }
                    }
                }
                startIndex++;
                if (startIndex == 16)
                {
                    guessButton.Visible = true;
                    spinButton.Visible = true;
                    startIndex = 0;
                    puzzleFirstDisplayed = true;
                    timerGeneral.Enabled = false;
                }
            }

            else if(blankLettersOpened == false)
            {
                for(int i = letterDisplayedIndex; i < outputString.Length; i++)
                {
                    if (outputString[i].ToString() == letterChosen)
                    {
                        totalScore += tempScore;
                        scoreLabel.Text = (totalScore).ToString();
                        lettersFound.Add(i);
                        buttonArray[i].BackColor = Color.AliceBlue;
                        if(i != (outputString.Length - 1))
                        {
                            letterDisplayedIndex = i + 1;
                        }
                        else
                        {
                            letterSelected = false;
                            letterDisplayedIndex = 0;
                            blankLettersOpened = true;
                        }
                        break;
                    }
                    else if(i == (outputString.Length-1))
                    {
                        letterSelected = false;
                        letterDisplayedIndex = 0;
                        blankLettersOpened = true;
                    }
                }
                if (!lettersFound.Any())
                {
                    messageShown = true;
                    messageLabel.Text = "LETTER NOT FOUND";
                    messageLabel.BackColor = Color.RoyalBlue;
                    showTheMessageLabelSeconds = 3;
                    timerMessage.Enabled = true;
                }
            }
            
            else
            {
                if(spinButtonClicked == false)
                {
                    if (lettersFound.Any())
                    {
                        foreach(int index in lettersFound)
                        {
                            buttonArray[index].Text = letterChosen;
                            lettersFound.Remove(index);
                            break;
                        }
                        if (!lettersFound.Any())
                        {
                            for (int j = 0; j < 29; j++)
                            {
                                letterButtonArray[j].Enabled = true;
                                letterButtonArray[j].Visible = false;
                            }
                            guessButton.Visible = true;
                            buyVowelButton.Visible = false;
                            if (turnNumber == 0)
                            {
                                spinButton.Visible = false;
                            }
                            else
                            {
                                spinButton.Visible = true;
                            }
                            blankLettersOpened = false;
                            timerGeneral.Enabled = false;
                        }
                        
                    }
                    else
                    {
                        for (int j = 0; j < 29; j++)
                        {
                            letterButtonArray[j].Enabled = true;
                            letterButtonArray[j].Visible = false;
                        }
                        guessButton.Visible = true;
                        buyVowelButton.Visible = false;
                        if (turnNumber == 0)
                        {
                            spinButton.Visible = false;
                        }
                        else
                        {
                            spinButton.Visible = true;
                        }
                        blankLettersOpened = false;
                        timerGeneral.Enabled = false;
                    }
                }
            }
        }

        public void pointAssigning(int angle)
        {
            angle++;
            int pieceIndex = angle / 15;
            if(angle%15 == 0)
            {
                pieceIndex--;
            }
            switch (pieceIndex)
            {
                case 0:
                    pointIndicated = "x350";
                    break;
                case 1:
                    pointIndicated = "x250";
                    break;
                case 2:
                    pointIndicated = "x400";
                    break;
                case 3:
                    pointIndicated = "x500";
                    break;
                case 4:
                    pointIndicated = "BANKRUPT!";
                    break;
                case 5:
                    pointIndicated = "x1500";
                    break;
                case 6:
                    pointIndicated = "x350";
                    break;
                case 7:
                    pointIndicated = "x900";
                    break;
                case 8:
                    pointIndicated = "x400";
                    break;
                case 9:
                    pointIndicated = "x550";
                    break;
                case 10:
                    pointIndicated = "x200";
                    break;
                case 11:
                    pointIndicated = "x500";
                    break;
                case 12:
                    pointIndicated = "BANKRUPT!";
                    break;
                case 13:
                    pointIndicated = "x600";
                    break;
                case 14:
                    pointIndicated = "x200";
                    break;
                case 15:
                    pointIndicated = "x1250";
                    break;
                case 16:
                    pointIndicated = "x400";
                    break;
                case 17:
                    pointIndicated = "x650";
                    break;
                case 18:
                    pointIndicated = "x200";
                    break;
                case 19:
                    pointIndicated = "x300";
                    break;
                case 20:
                    pointIndicated = "lose a TURN!";
                    break;
                case 21:
                    pointIndicated = "x2500";
                    break;
                case 22:
                    pointIndicated = "x450";
                    break;
                case 23:
                    pointIndicated = "x800";
                    break;
            }
        }

        public void displayTheAnswer()
        {
            if (char.IsLetter(outputString[answerDisplayIndex]))
            {
                buttonArray[answerDisplayIndex].BackColor = Color.AliceBlue;
                buttonArray[answerDisplayIndex].Text = outputString[answerDisplayIndex].ToString();
            }
            
            if(answerDisplayIndex == 51)
            {
                for(int i = 0; i<52; i++)
                {
                    if (!char.IsLetter(outputString[i]))
                    {
                        buttonArray[i].BackColor = Color.RoyalBlue;
                    }
                }               
                goToNextPuzzle();     
            }
            else
            { 
                answerDisplayIndex++;
            }
        }

        public void goToNextPuzzle()
        {
            guessTime = 30;
            labelGuessTime.Text = (guessTime).ToString();
            firstStart = true;
            secondStart = true;
            thirdStart = false;
            puzzleNumberShown = false;
            puzzleTypeShown = false;
            puzzleAssigned = false;
            puzzleFirstDisplayed = false;
            blankLettersOpened = false;
            letterButton.Visible = false;
            guessButton.Visible = false;
            spinButton.Visible = false;
            turnNumber = 15;
            turnsLabel.Text = (turnNumber).ToString();
            puzzleCount++;
            if(puzzleCount <= 3)
            {
                assignRandomInputString(puzzleCount);
            }
            else
            {
                assignRandomInputString(3);
            }
            timerStart.Enabled = true;
            timerShow.Enabled = false;
            answerDisplayIndex = 0;
            for(int i=0; i<29; i++)
            {
                letterButtonArray[i].UseVisualStyleBackColor = true;
            }
        }

        private void gameScreen_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                Application.Exit();
            }
        }

    }
}

