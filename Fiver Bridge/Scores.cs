using System;
using System.ComponentModel;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Fiver_Bridge
{
    public partial class Scores : Form
    {
        public string tr;
        public int gameNum, cardNum, bNum, tNum, tbid, tgot, val1, val2, val3, val4, val5, valb, valx, valy, vals, ja, jb, ka, kb;
// public int n1, n2, n3, n4, n5;
        public Scores(string txt1, string txt2, string txt3, string txt4, string txt5, string txtz)
        {
            InitializeComponent(); this.FormBorderStyle = FormBorderStyle.FixedDialog;
            textBox1.Text = " " + txt1; textBox2.Text = " " + txt2; textBox3.Text = " " + txt3;
            textBox4.Text = " " + txt4; textBox5.Text = " " + txt5; textBox16.Text = txtz;

            textBox11.Text = "0"; textBox12.Text = "0"; textBox13.Text = "0";
            textBox14.Text = "0"; textBox15.Text = "0";

            comboBox1.SelectedIndex = 5; comboBox1.Enabled = false;
        }

        public void Scores_Load(object sender, EventArgs e)
        {
            btnScore.Enabled = false; btnScore.BackColor = Color.LightGray; btnScore.ForeColor = Color.Black;
            btnEnd.Enabled = false; btnEnd.BackColor = Color.LightGray; btnEnd.ForeColor = Color.Black;
            gameNum = 1; cardNum = 10;
            label2.Text = " Game # ( " + gameNum + " )       Cards ( " + cardNum + " )          Dealer: " + textBox5.Text +
            "                      Bidder: " + textBox1.Text;
        }

        //public void NextDeal(object sender, EventArgs e)
        //{
        //    tb6.Select();
        //    tb6.Focus();
        //}

        private void tb6_Validating(object sender, CancelEventArgs e)
        {
            int i;
            if (!int.TryParse(tb6.Text, out i))
            {
                label1.ForeColor = Color.Red;
                label1.Text = "PLEASE ENTER A VALID NUMBER !"; tb6.SelectAll(); tb6.Focus();
            }
            else if (int.Parse(tb6.Text) > cardNum)
            { label1.Text = "BID MUST BE LESS THAN : " + cardNum; tb6.SelectAll(); tb6.Focus(); }
            else
            {
                label1.BackColor = Color.Gainsboro; label1.ForeColor = Color.DarkBlue;
                tbid = int.Parse(tb6.Text);
                (label1.Text) = "TOTAL BID SO FAR : " + tbid; tb7.SelectAll(); tb7.Focus();
            }
        }

        private void tb7_Validating(object sender, CancelEventArgs e)
        {
            int i;
            if (!int.TryParse(tb7.Text, out i))
            {
                label1.ForeColor = Color.Red;
                label1.Text = "PLEASE ENTER A VALID NUMBER !"; tb7.SelectAll(); tb7.Focus();
            }
            else if (int.Parse(tb7.Text) > cardNum)
            {
                label1.Text = "BID MUST BE LESS THAN : " + cardNum;
                tb7.SelectAll(); }//tb7.Focus(); }
            else
            {
                label1.ForeColor = Color.DarkBlue;
                tbid = int.Parse(tb6.Text) + int.Parse(tb7.Text);
                (label1.Text) = "TOTAL BID SO FAR : " + tbid; tb8.SelectAll(); //tb8.Focus();
            }
        }

        private void tb8_Validating(object sender, CancelEventArgs e)
        {
            int i;
            if (!int.TryParse(tb8.Text, out i))
            {
                label1.ForeColor = Color.Red;
                label1.Text = "PLEASE ENTER A VALID NUMBER !"; tb8.SelectAll(); tb8.Focus();
            }
            else if (int.Parse(tb8.Text) > cardNum)
            {
                label1.Text = "BID MUST BE LESS THAN : " + cardNum;
                tb8.SelectAll(); }//tb8.Focus(); }
            else
            {
                label1.ForeColor = Color.DarkBlue;
                tbid = int.Parse(tb6.Text) + int.Parse(tb7.Text) + int.Parse(tb8.Text);
                (label1.Text) = "TOTAL BID SO FAR : " + tbid; tb9.SelectAll(); //tb9.Focus();
            }
        }

        private void tb9_Validating(object sender, CancelEventArgs e)
        {
            int i;
            if (!int.TryParse(tb9.Text, out i))
            {
                label1.ForeColor = Color.Red;
                label1.Text = "PLEASE ENTER A VALID NUMBER !"; tb9.SelectAll(); tb9.Focus();
            }
            else if (int.Parse(tb9.Text) > cardNum) { label1.Text = "BID MUST BE LESS THAN : " + cardNum;
                tb9.SelectAll(); } //tb9.Focus(); }
            else
            {
                label1.ForeColor = Color.DarkBlue;
                tbid = int.Parse(tb6.Text) + int.Parse(tb7.Text) + int.Parse(tb8.Text) + int.Parse(tb9.Text);
                (label1.Text) = "TOTAL BID SO FAR : " + tbid; tb10.SelectAll(); //tb10.Focus();
            }
        }

        private void tb10_Validating(object sender, CancelEventArgs e)
        {
            int i;
            if (!int.TryParse(tb10.Text, out i))
            {
                label1.ForeColor = Color.Red;
                label1.Text = "PLEASE ENTER A VALID NUMBER !"; tb10.SelectAll(); tb10.Focus();
            }
            else if (int.Parse(tb10.Text) > cardNum) { label1.Text = "BID MUST BE LESS THAN : " + cardNum;
                tb10.SelectAll(); } //tb10.Focus(); }
            else {
                label1.ForeColor = Color.DarkBlue;
                tbid = int.Parse(tb6.Text) + int.Parse(tb7.Text) + int.Parse(tb8.Text) + int.Parse(tb9.Text) + int.Parse(tb10.Text);
                (label1.Text) = "TOTAL BID FOR THIS ROUND : " + tbid; VerifyBids(); }
        }

        private void VerifyBids()
        {
            tbid = (int.Parse(tb6.Text) + int.Parse(tb7.Text) + int.Parse(tb8.Text) + int.Parse(tb9.Text) + int.Parse(tb10.Text));
            valb = Math.Abs(tbid - cardNum); label1.Text = "";
            if (cardNum < tbid)
            {
                label1.BackColor = Color.DarkCyan; label1.ForeColor = Color.White;
                label1.Text = "Overbid by : " + valb; }
            else if (cardNum > tbid)
            {
                label1.BackColor = Color.DarkRed; label1.ForeColor = Color.White;
                label1.Text = "Underbid by : " + valb; }
                comboBox1.Enabled = true; comboBox1.DroppedDown = true; //comboBox1.Focus();
        }

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        { tb11.SelectAll(); tb11.Focus(); }

        private void tb11_Validating(object sender, CancelEventArgs e)
        {
            int n1;
            if (int.TryParse(tb11.Text, out n1) == false)
            {
                errorProvider1.SetError(tb11, "Enter Number Only!");
                label1.Text = ("Enter A Number < or = " + cardNum);
                tb11.SelectAll(); tb11.Clear(); tb11.Focus();
            }
            else
            {
                n1 = int.Parse(tb11.Text);
                if (n1 > cardNum)
                {
                    errorProvider1.SetError(tb11, ("Enter A Number < or = " + cardNum));
                    label1.Text = ("Enter A Number < or = " + cardNum);
                    tb11.Clear(); tb11.Focus();
                }
                else
                {
                    errorProvider1.Clear();
                    label1.ForeColor = Color.White;
                    tgot = int.Parse(tb11.Text);
                    (label1.Text) = "TOTAL GOT SO FAR : " + tgot;
                }
            }
        }

        private void tb12_Validating(object sender, CancelEventArgs e)
        {
                int n1;
                if (int.TryParse(tb12.Text, out n1) == false)
                {
                    errorProvider1.SetError(tb12, "Enter Number Only!");
                    label1.Text = ("Enter A Number < or = " + cardNum);
                    tb12.SelectAll(); tb12.Clear(); tb12.Focus();
                }
                else
                {
                    n1 = int.Parse(tb12.Text);
                    if (n1 > cardNum)
                    {
                        errorProvider1.SetError(tb12, ("Enter A Number < or = " + cardNum));
                        label1.Text = ("Enter A Number < or = " + cardNum);
                        tb12.Clear(); tb12.Focus();
                    }
                    else
                    {
                        errorProvider1.Clear();
                        label1.ForeColor = Color.White;
                        tgot = int.Parse(tb11.Text) + int.Parse(tb12.Text);
                        (label1.Text) = "TOTAL GOT SO FAR : " + tgot;
                    }
                }
            }

        private void tb13_Validating(object sender, CancelEventArgs e)
        {
            int n1;
            if (int.TryParse(tb13.Text, out n1) == false)
            {
                errorProvider1.SetError(tb12, "Enter Number Only!");
                label1.Text = ("Enter A Number < or = " + cardNum);
                tb13.SelectAll(); tb13.Clear(); tb13.Focus();
            }
            else
            {
                n1 = int.Parse(tb13.Text);
                if (n1 > cardNum)
                {
                    errorProvider1.SetError(tb13, ("Enter A Number < or = " + cardNum));
                    label1.Text = ("Enter A Number < or = " + cardNum);
                    tb13.Clear(); tb13.Focus();
                }
                else
                {
                    errorProvider1.Clear();
                    label1.ForeColor = Color.White;
                    tgot = int.Parse(tb11.Text) + int.Parse(tb12.Text) + int.Parse(tb13.Text);
                    (label1.Text) = "TOTAL GOT SO FAR : " + tgot;
                }
            }
        }

        private void tb14_Validating(object sender, CancelEventArgs e)
        {
            int n1;
            if (int.TryParse(tb14.Text, out n1) == false)
            {
                errorProvider1.SetError(tb14, "Enter Number Only!");
                label1.Text = ("Enter A Number < or = " + cardNum);
                tb14.SelectAll(); tb14.Clear(); tb14.Focus();
            }
            else
            {
                n1 = int.Parse(tb14.Text);
                if (n1 > cardNum)
                {
                    errorProvider1.SetError(tb14, ("Enter A Number < or = " + cardNum));
                    label1.Text = ("Enter A Number < or = " + cardNum);
                    tb14.Clear(); tb14.Focus();
                }
                else
                {
                    errorProvider1.Clear();
                    label1.ForeColor = Color.White;
                    tgot = int.Parse(tb11.Text) + int.Parse(tb12.Text) + int.Parse(tb13.Text) + int.Parse(tb14.Text);
                    (label1.Text) = "TOTAL GOT SO FAR : " + tgot;
                }
            }
        }

        private void tb15_Validating(object sender, CancelEventArgs e)
        {
            int n1;
            if (int.TryParse(tb15.Text, out n1) == false)
            {
                errorProvider1.SetError(tb15, "Enter Number Only!");
                label1.Text = ("Enter A Number < or = " + cardNum);
                tb15.SelectAll(); tb15.Clear(); tb15.Focus();
            }
            else
            {
                n1 = int.Parse(tb15.Text);
                if (n1 > cardNum)
                {
                    errorProvider1.SetError(tb15, ("Enter A Number < or = " + cardNum));
                    label1.Text = ("Enter A Number < or = " + cardNum);
                    tb15.Clear(); tb15.Focus();
                }
                else
                {
                    errorProvider1.Clear();
                    label1.ForeColor = Color.White;
                    tgot = int.Parse(tb11.Text) + int.Parse(tb12.Text) + int.Parse(tb13.Text) + int.Parse(tb14.Text) + int.Parse(tb15.Text);
                    (label1.Text) = "TOTAL GOT SO FAR : " + tgot;
                    verifyTricks();
                }
            }
        }

        private void verifyTricks()
        {
            valy = (int.Parse(tb11.Text) + int.Parse(tb12.Text) + int.Parse(tb13.Text) + int.Parse(tb14.Text)) + int.Parse(tb15.Text);
            if (valy != cardNum)
            {
                errorProvider1.SetError(tb11, "TOTAL GOT MUST BE = " + cardNum);
                label1.BackColor = Color.Crimson; label1.ForeColor = Color.White;
                label1.Text = "TOTAL GOT MUST BE = " + cardNum;
                btnScore.Enabled = false; btnScore.BackColor = Color.LightGray; btnScore.ForeColor = Color.Black;
//tb15.SelectAll(); //tb11.Focus();
            }
            else
            {
                errorProvider1.Clear();
                btnScore.Enabled = true; btnScore.BackColor = Color.DarkBlue; btnScore.ForeColor = Color.White;
                btnScore.Focus();
                //label1.ForeColor = Color.Gainsboro; label1.BackColor = Color.DarkBlue;
                //label1.Text = "Good .. Press Compute"; btnScore.Focus(); tb6.Focus();
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        { Help f1 = new Help(); f1.Show(); }

// COMPUTE BUTTON 
        private void btnScore_Click_1(object sender, EventArgs e)
        {
            label1.BackColor = Color.Gainsboro; label1.ForeColor = Color.Black; label1.Text = "";
            if (comboBox1.Text == "Select Trump") { tr = "<**>"; }
            if (comboBox1.Text == " Spade") { tr = "<S>"; }
            if (comboBox1.Text == " Diamond") { tr = "<D>"; }
            if (comboBox1.Text == " Hearts") { tr = "<H>"; }
            if (comboBox1.Text == " Clubs") { tr = "<C>"; }
            if (comboBox1.Text == " No Trump") { tr = "<NT>"; }

            vals = int.Parse(textBox16.Text);
            calcPoints();
            btnScore.Enabled = false; btnScore.BackColor = Color.LightGray; btnScore.ForeColor = Color.Black;
            tbTrmp.Text = (tbTrmp.Text) + gameNum + ". " + tr + " ";
            NextGame(); tb6.Focus();
        }

// Calculate Score for Player # 1

        public void calcPoints()
        {
            if (tb6.Text != null) { val1 = int.Parse(tb6.Text); } else { val1 = 0; }
            if (tb11.Text != null) { val2 = int.Parse(tb11.Text); } else { val2 = 0; }
            if (textBox11.Text != null) { val4 = int.Parse(textBox11.Text); } else { val4 = 0; }
            switch (vals)
            {
                case 1:
                    if (val1 == val2 && val1 == 0) { val3 = 0; }
                    else if (val1 == val2 && val1 != 0) { val3 = val1 * 10; }
                    else if (val1 != val2) { val3 = Math.Abs(val1 - val2) * -5; }
                    break;
                case 2:
                    if (val1 == val2 && val1 == 0) { val3 = 5; }
                    else if (val1 == val2 && val1 != 0) { val3 = val1 * 10; }
                    else if (val1 != val2) { val3 = Math.Abs(val1 - val2) * -5; }
                    break;
                case 3:
                    if (val1 == val2 && val1 == 0) { val3 = 10; }
                    else if (val1 == val2 && val1 != 0) { val3 = val1 * 10; }
                    else if (val1 != val2) { val3 = Math.Abs(val1 - val2) * -10; }
                    break;
            }
            tb16.Text = val3.ToString();
            val5 = (val3 + val4); (textBox11.Text) = val5.ToString();
            tb26.Text = tb26.Text + (tb6.Text) + "/" + (tb11.Text) + "/" + (tb16.Text) + "; ";

// Calculate Score for Player # 2

            if (tb7.Text != null) { val1 = int.Parse(tb7.Text); } else { val1 = 0; }
            if (tb12.Text != null) { val2 = int.Parse(tb12.Text); } else { val2 = 0; }
            if (textBox12.Text != null) { val4 = int.Parse(textBox12.Text); } else { val4 = 0; }
            switch (vals)
            {
                case 1:
                    if (val1 == val2 && val1 == 0) { val3 = 0; }
                    else if (val1 == val2 && val1 != 0) { val3 = val1 * 10; }
                    else if (val1 != val2) { val3 = Math.Abs(val1 - val2) * -5; }
                    break;
                case 2:
                    if (val1 == val2 && val1 == 0) { val3 = 5; }
                    else if (val1 == val2 && val1 != 0) { val3 = val1 * 10; }
                    else if (val1 != val2) { val3 = Math.Abs(val1 - val2) * -5; }
                    break;
                case 3:
                    if (val1 == val2 && val1 == 0) { val3 = 10; }
                    else if (val1 == val2 && val1 != 0) { val3 = val1 * 10; }
                    else if (val1 != val2) { val3 = Math.Abs(val1 - val2) * -10; }
                    break;
            }
            tb17.Text = val3.ToString();
            val5 = (val3 + val4); (textBox12.Text) = val5.ToString();
            tb27.Text = tb27.Text + (tb7.Text) + "/" + (tb12.Text) + "/" + (tb17.Text) + "; ";

// Calculate Score for Player # 3

            if (tb8.Text != null) { val1 = int.Parse(tb8.Text); } else { val1 = 0; }
            if (tb13.Text != null) { val2 = int.Parse(tb13.Text); } else { val2 = 0; }
            if (textBox13.Text != null) { val4 = int.Parse(textBox13.Text); } else { val4 = 0; }
            switch (vals)
            {
                case 1:
                    if (val1 == val2 && val1 == 0) { val3 = 0; }
                    else if (val1 == val2 && val1 != 0) { val3 = val1 * 10; }
                    else if (val1 != val2) { val3 = Math.Abs(val1 - val2) * -5; }
                    break;
                case 2:
                    if (val1 == val2 && val1 == 0) { val3 = 5; }
                    else if (val1 == val2 && val1 != 0) { val3 = val1 * 10; }
                    else if (val1 != val2) { val3 = Math.Abs(val1 - val2) * -5; }
                    break;
                case 3:
                    if (val1 == val2 && val1 == 0) { val3 = 10; }
                    else if (val1 == val2 && val1 != 0) { val3 = val1 * 10; }
                    else if (val1 != val2) { val3 = Math.Abs(val1 - val2) * -10; }
                    break;
            }
            tb18.Text = val3.ToString();
            tb18.Text = val3.ToString();
            val5 = (val3 + val4); (textBox13.Text) = val5.ToString();
            tb28.Text = tb28.Text + (tb8.Text) + "/" + (tb13.Text) + "/" + (tb18.Text) + "; ";

// Calculate Score for Player # 4

            if (tb9.Text != null) { val1 = int.Parse(tb9.Text); } else { val1 = 0; }
            if (tb14.Text != null) { val2 = int.Parse(tb14.Text); } else { val2 = 0; }
            if (textBox14.Text != null) { val4 = int.Parse(textBox14.Text); } else { val4 = 0; }
            switch (vals)
            {
                case 1:
                    if (val1 == val2 && val1 == 0) { val3 = 0; }
                    else if (val1 == val2 && val1 != 0) { val3 = val1 * 10; }
                    else if (val1 != val2) { val3 = Math.Abs(val1 - val2) * -5; }
                    break;
                case 2:
                    if (val1 == val2 && val1 == 0) { val3 = 5; }
                    else if (val1 == val2 && val1 != 0) { val3 = val1 * 10; }
                    else if (val1 != val2) { val3 = Math.Abs(val1 - val2) * -5; }
                    break;
                case 3:
                    if (val1 == val2 && val1 == 0) { val3 = 10; }
                    else if (val1 == val2 && val1 != 0) { val3 = val1 * 10; }
                    else if (val1 != val2) { val3 = Math.Abs(val1 - val2) * -10; }
                    break;
            }
            tb19.Text = val3.ToString();
            val5 = (val3 + val4); (textBox14.Text) = val5.ToString();
            tb29.Text = tb29.Text + (tb9.Text) + "/" + (tb14.Text) + "/" + (tb19.Text) + "; ";

// Calculate Score for Player # 5

            if (tb10.Text != null) { val1 = int.Parse(tb10.Text); } else { val1 = 0; }
            if (tb15.Text != null) { val2 = int.Parse(tb15.Text); } else { val2 = 0; }
            if (textBox15.Text != null) { val4 = int.Parse(textBox15.Text); } else { val4 = 0; }
            switch (vals)
            {
                case 1:
                    if (val1 == val2 && val1 == 0) { val3 = 0; }
                    else if (val1 == val2 && val1 != 0) { val3 = val1 * 10; }
                    else if (val1 != val2) { val3 = Math.Abs(val1 - val2) * -5; }
                    break;
                case 2:
                    if (val1 == val2 && val1 == 0) { val3 = 5; }
                    else if (val1 == val2 && val1 != 0) { val3 = val1 * 10; }
                    else if (val1 != val2) { val3 = Math.Abs(val1 - val2) * -5; }
                    break;
                case 3:
                    if (val1 == val2 && val1 == 0) { val3 = 10; }
                    else if (val1 == val2 && val1 != 0) { val3 = val1 * 10; }
                    else if (val1 != val2) { val3 = Math.Abs(val1 - val2) * -10; }
                    break;
            }
            tb20.Text = val3.ToString();
            val5 = (val3 + val4); (textBox15.Text) = val5.ToString();
            tb30.Text = tb30.Text + (tb10.Text) + "/" + (tb15.Text) + "/" + (tb20.Text) + "; ";
        }

// NEXT-GAME Event

        private void NextGame()
        {
            if (gameNum != 10)
            {
                CardChange();
                MovePlayers_And_Scores();
                label2.Text = " Game # ( " + gameNum + " )       Cards ( " + cardNum + " )          Dealer: " + textBox5.Text +
                "                     Bidder: " + textBox1.Text;
                tbid = 0; tgot = 0; 
                comboBox1.Enabled = false; comboBox1.SelectedIndex = 5;
                ClearBIdGot(); //ErrorHide();

            }
            else
            {
                int i = 1;
                for (i = 1; i <= 5; i++)
                    foreach (Control contrl in this.Controls)
                    {
                        if (contrl.Name == ("textBox" + i.ToString()))
                        {
                            contrl.Text = "";
                        }
                    }
                btnEnd.Visible = true; btnEnd.ForeColor = Color.DimGray; btnEnd.BackColor = Color.White;
                label2.BackColor = Color.MediumSeaGreen; label2.ForeColor = Color.Maroon;
                label2.Text = ("GAME  OVER . . . TO  CLOSE  WINDOW,  PRESS  'EXIT APP'  BUTTON");
            }
        }

        public void CardChange()
        {
            switch (gameNum)
            {
                case 1:
                    gameNum = gameNum + 1; cardNum = cardNum - 1;
                    label2.BackColor = Color.Gainsboro; label2.ForeColor = Color.Maroon;
                    break;
                case 2:
                    gameNum = 3; cardNum = 8;
                    label2.BackColor = Color.Chocolate; label2.ForeColor = Color.White;
                    break;
                case 3:
                    gameNum = 4; cardNum = 7;
                    label2.BackColor = Color.Teal; label2.ForeColor = Color.White;
                    break;
                case 4:
                    gameNum = 5; cardNum = 6;
                    label2.BackColor = Color.Chocolate; label2.ForeColor = Color.White;
                    break;
                case 5:
                    gameNum = 6; cardNum = 6;
                    label2.BackColor = Color.MidnightBlue; label2.ForeColor = Color.White;
                    break;
                case 6:
                    gameNum = 7; cardNum = 7;
                    label2.BackColor = Color.DarkSlateGray; label2.ForeColor = Color.White;
                    break;
                case 7: //case 8: case 9:
                    gameNum = 8; cardNum = 8;
                    label2.BackColor = Color.SaddleBrown; label2.ForeColor = Color.White;
                    break;
                case 8:
                    gameNum = 9; cardNum = 9;
                    label2.BackColor = Color.DarkRed; label2.ForeColor = Color.White;
                    break;
                case 9:
                    gameNum = 10; cardNum = 10;
                    label2.BackColor = Color.Chocolate; label2.ForeColor = Color.White;
                    break;
            }
        }

        //**** Rotate Player & Scores
        public void MovePlayers_And_Scores()
        {
// Rotate Player Names
            string tbTxt = textBox1.Text; textBox1.Text = textBox2.Text; textBox2.Text = textBox3.Text;
            textBox3.Text = textBox4.Text; textBox4.Text = textBox5.Text; textBox5.Text = tbTxt;
// Rotate Game Scores
            tbTxt = tb16.Text; tb16.Text = tb17.Text; tb17.Text = tb18.Text;
            tb18.Text = tb19.Text; tb19.Text = tb20.Text; tb20.Text = tbTxt;
            // Rotate Total Scores
            tbTxt = textBox11.Text; textBox11.Text = textBox12.Text; textBox12.Text = textBox13.Text;
            textBox13.Text = textBox14.Text; textBox14.Text = textBox15.Text; textBox15.Text = tbTxt;
// Rotate Individual Game Scores
            tbTxt = tb26.Text; tb26.Text = tb27.Text; tb27.Text = tb28.Text;
            tb28.Text = tb29.Text; tb29.Text = tb30.Text; tb30.Text = tbTxt;
        }
// Clear Values in Bids & Got for the Next Game Entry
        public void ClearBIdGot()
        {
            int i;
            for (i = 6; i <= 15; i++)
            {
                foreach (Control contrl in this.Controls)
                {
                    if (contrl.Name == ("tb" + i.ToString()))
                    {
                        contrl.Text = "";
                    }
                }
            }
        }
        public void ErrorHide()
        {
            int i;
            for (i = 6; i <= 15; i++)
            {
                foreach (Control contrl in this.Controls)
                {
                    Console.WriteLine("Control: " + contrl.Name);
                    if (contrl.Name == ("tb" + i.ToString()))
                    {
                        errorProvider1.Clear();
                    }
                }
            }

            NextDeal();       

         }

        private void NextDeal()
        {
            tb6.Select();
            tb6.Focus();
        }

        private void btnEnd_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            if (e.CloseReason == CloseReason.WindowsShutDown) return;
            // Confirm user wants to close
            switch (MessageBox.Show(this, "Are you sure you want to close?", "Closing", MessageBoxButtons.YesNo))
            {
                case DialogResult.No:
                    e.Cancel = true;
                    break;
                default:
                    break;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        { Help f1 = new Help(); f1.Show(); }
    }
}





