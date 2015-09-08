using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Fiver_Bridge
{
    public partial class Game : Form
    {
        public string txtA, txtB, txtC, txtz;

        public Game()
        {
            InitializeComponent();
            this.Width = 520; this.Height = 393;
            btnPlay.Enabled = false;
            btnPlay.BackColor = Color.LightGray; btnPlay.ForeColor = Color.Black;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
        }

        private void Game_Load(object sender, EventArgs e)
        {
            lblOpt.Enabled = false; lblOpt.Visible = false;
            btn1.Enabled = true;
        }

        private void btn1_Click(object sender, EventArgs e)
        {
            Help f1 = new Help(); f1.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        { this.Close(); }


        private void RadioButton1_CheckedChanged(object sender, EventArgs e)
        {
            textBox6.Text = "1";
            RadioButton1.BackColor = Color.Navy; RadioButton1.ForeColor = Color.White;
            RadioButton2.BackColor = Color.Gainsboro; RadioButton2.ForeColor = Color.Black;
            RadioButton3.BackColor = Color.Gainsboro; RadioButton3.ForeColor = Color.Black;
            ShowPlayers();
        }

        private void RadioButton2_CheckedChanged(object sender, EventArgs e)
        {
            textBox6.Text = "2";
            RadioButton2.BackColor = Color.Navy; RadioButton2.ForeColor = Color.White;
            RadioButton3.BackColor = Color.Gainsboro; RadioButton3.ForeColor = Color.Black;
            RadioButton1.BackColor = Color.Gainsboro; RadioButton1.ForeColor = Color.Black;
            ShowPlayers();
        }

        private void RadioButton3_CheckedChanged(object sender, EventArgs e)
        {
            textBox6.Text = "3";
            RadioButton3.BackColor = Color.Navy; RadioButton3.ForeColor = Color.White;
            RadioButton1.BackColor = Color.Gainsboro; RadioButton1.ForeColor = Color.Black;
            RadioButton2.BackColor = Color.Gainsboro; RadioButton2.ForeColor = Color.Black;
            ShowPlayers();
        }

        private void ShowPlayers()
        {
            this.Width = 765; this.Height = 393;
            txtz = textBox6.Text;
            lblOpt.Enabled = true; lblOpt.Visible = true;
            textBox1.Select();

            int i = 1;
            for (i = 1; i <= 5; i++)
            {
                foreach (Control contrl in this.Controls)
                {
                    if (contrl.Name == ("textBox" + i.ToString()))
                    {
                        string var1 = contrl.Text;
                        if (var1 != "")
                        {
                            btnPlay.BackColor = Color.DimGray; btnPlay.ForeColor = Color.White;
                            btnPlay.Enabled = true; btnPlay.Focus();
                            return;
                        }
                        else
                        {
                            textBox1.Focus();
                        }
                    }
                }
            }
        }

        private bool NullOrEmpty(string var1)
        {
            throw new NotImplementedException();
        }

        private void textBox5_TextChanged_1(object sender, EventArgs e)
        {
            btnPlay.Enabled = true;
            btnPlay.BackColor = Color.DimGray; btnPlay.ForeColor = Color.White;
        }

        private void btnPlay_Click(object sender, EventArgs e)
        {
            int i = 1;
            for (i = 1; i <= 5; i++)
            {
                foreach (Control contrl in this.Controls)
                {
                    if (contrl.Name == ("textBox" + i.ToString()))
                    {
                        string var1 = contrl.Text;
                        if (string.IsNullOrEmpty(var1))
                        {
                            errorProvider2.SetError(contrl, "ENTER NAME OF PLAYER");
                            return;
                        }
                        else
                        {
                            btnPlay.BackColor = Color.DimGray; btnPlay.ForeColor = Color.White;
                            btnPlay.Enabled = true; btnPlay.Visible = true;
                            var1 =
                            System.Threading.Thread.CurrentThread.CurrentCulture.TextInfo.
                            ToTitleCase(var1.ToLower());
                            contrl.Text = var1;
                        }
                    }
                }
            }
            Scores f = new Scores((textBox1.Text), (textBox2.Text), (textBox3.Text), (textBox4.Text), (textBox5.Text), txtz);
            f.Show(); this.Hide();
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
    }
}
