using System;
using System.Windows.Forms;
using System.Drawing;

namespace GuessTheNumber_3
{
    public class PVP : Magic
    {
        Panel pvp = new Panel();
        TextBox p2 = new TextBox();
        Label l2 = new Label();
        Label MoreLessP2 = new Label();
        Button b2 = new Button();
        PictureBox pi = new PictureBox();

        public PVP()
        {
            FillPanels(pvp, "ВСТАНОВИТЬ", "ПОЧАТОК", "ВИХІД", "ВГАДАТЬ");
            Initialization(pvp);
            AddSecondPlayer();
        }

        public Panel Panel
        {
            get
            {
                return pvp;
            }
        }

        private void AddSecondPlayer()
        {
            //Button try second player
            b2.Text = "ВГАДАТЬ";
            b2.Size = new Size(120, 45);
            b2.FlatStyle = FlatStyle.Flat;
            b2.FlatAppearance.BorderColor = Color.RoyalBlue;
            b2.FlatAppearance.BorderSize = 0;
            b2.FlatAppearance.MouseDownBackColor = Color.RoyalBlue;
            b2.FlatAppearance.MouseOverBackColor = Color.RoyalBlue;
            b2.Font = new Font("Mistral", 16F);
            b2.Location = new Point(700, 230);
            b2.Click += butTry_p2_Click;
            pvp.Controls.Add(b2);

            //Label seond player
            l2.AutoSize = true;
            l2.Font = new Font("Mistral", 16F);
            l2.Location = new Point(740, 170);
            l2.Name = "label5";
            l2.Size = new Size(232, 41);
            l2.Text = "ДРУГИЙ ГРАВЕЦЬ";
            pvp.Controls.Add(l2);

            //Label MoreLess for 2 player
            MoreLessP2.AutoSize = true;
            MoreLessP2.Font = new Font("Mistral", 16F);
            MoreLessP2.Location = new Point(820, 240);
            MoreLessP2.Name = "labelMoreLess_p2";
            MoreLessP2.Size = new Size(0, 100);
            MoreLessP2.MaximumSize = new Size(500, 50);
            pvp.Controls.Add(MoreLessP2);

            //TextBox for 2 player
            p2.BackColor = Color.DarkOrange;
            p2.BorderStyle = BorderStyle.FixedSingle;
            p2.Font = new Font("Microsoft Sans Serif", 10F);
            p2.MaxLength = 9;
            p2.Size = new Size(100, 25);
            p2.Location = new Point(580, 240);
            p2.UseSystemPasswordChar = true;
            pvp.Controls.Add(p2);
            p2.KeyPress += tBoxMyNumber_p2_KeyPress;
            pvp.Controls.Add(p2);

            //Picture
            pi.BackColor = Color.OrangeRed;
            pi.Location = new Point(500, 200);
            pi.Name = "pictureBox1";
            pi.Size = new Size(13, 272);
            pi.TabStop = false;
            pvp.Controls.Add(pi);

            //Some other
            pvp.Size = new Size(1100, 600);
            ListBut[2].Click += Exit_Click;
            ListBut[3].Click += butTry_Click;
            ListLabel[5].Location = new Point(170, 170);
            ListLabel[5].Visible = true;
            ListLabel[5].Text = "ПЕРШИЙ ГРАВЕЦЬ";
            ListLabel[3].Location = new Point(600, 10);
            ListBox[2].UseSystemPasswordChar = true;

        }

        private void tBoxMyNumber_p2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && (!Char.IsControl(e.KeyChar)))
            {
                e.Handled = true;
            }
            else
            {

                b2.Enabled = true;
            }
        }

        private void butTry_p2_Click(object sender, EventArgs e)
        {
            ListBut[3].Enabled = false;
            try
            {
                magic.InputNumber = Convert.ToInt32(p2.Text);
                ChekInputNumber(magic.InputNumber, "Другий");
            }
            catch
            {
                MessageBox.Show("Ви не ввели число");
            }
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            Clear();
            MainMenu.PvpOnMenu();
        }

        public void butTry_Click(object sender, EventArgs e) // Player 1
        {
            ListBut[3].Enabled = false;
            try
            {
                magic.InputNumber = Convert.ToInt32(ListBox[2].Text);
                ChekInputNumber(magic.InputNumber,"Перший");
            }
            catch
            {
                MessageBox.Show("Ви не ввели число");
            }
        }

        public override void ChekInputNumber(int g, string name) 
        {
            if (g > magic.To)
            {
                MessageBox.Show("Ви ввели більше число чим найбільше число проміжка. Введіть друге",
                    "Вгадай число", MessageBoxButtons.OK);
                ListBox[2].Text = "";
            }
            else if (g < magic.From)
            {
                MessageBox.Show("Ви ввели менше число чим найменше число проміжка. Введіть друге",
                    "Вгадай число", MessageBoxButtons.OK);
                ListBox[2].Text = "";
            }
            else
            {
                if (g < magic.Guess)
                {
                    if (name == "Перший")
                    {
                        ListLabel[4].Text = "ВАШЕ ЧИСЛО МЕНШЕ";
                        DisEnabled_p1();
                        Enabled_p2();
                    }
                    else
                    {
                        MoreLessP2.Text = "ВАШЕ ЧИСЛО МЕНШЕ";
                        Enabled_p1();
                        DisEnabled_p2();
                    }
                }
                else if (g > magic.Guess)
                {
                    if (name == "Перший")
                    {
                        ListLabel[4].Text = "ВАШЕ ЧИСЛО БІЛЬШЕ";
                        DisEnabled_p1();
                        Enabled_p2();
                    }
                    else
                    {
                        MoreLessP2.Text = "ВАШЕ ЧИСЛО БІЛЬШЕ";
                        Enabled_p1();
                        DisEnabled_p2();
                    }
                }
                else
                {
                    MessageBox.Show("          Вітаємo!   \n" + "Виграв "+ name + " гравець, це число " + magic.InputNumber
                                                 , "Вгадай число",
                                                 MessageBoxButtons.OK, MessageBoxIcon.Information);

                    ListBut[1].Text = "РЕСТАРТ";
                    ListBut[1].Enabled = true;
                    DisEnabled_p1();
                    DisEnabled_p2();
                }
            }
        }

        public override void Clear()
        {
            ListBox[0].Clear();
            ListBox[1].Clear();
            ListBox[2].Clear();
            ListLabel[3].Text = "";
            ListLabel[4].Text = "";
            ListLabel[5].Text = "";
            MoreLessP2.Text = "";
            ListBut[1].Text = "ПОЧАТОК";
            magic.From = 0;
            magic.To = 0;
            p2.Clear();
        }

        private void Enabled_p1()
        {
            ListBox[2].Visible = true;
            ListBut[3].Visible = true;
            ListLabel[4].Visible = true;
            ListBox[2].Enabled = true;
        }

        private void DisEnabled_p1()
        {
            ListBox[2].Enabled = false;
            ListBut[3].Enabled = false;
        }

        private void Enabled_p2()
        {
            p2.Visible = true;
            b2.Visible = true;
            MoreLessP2.Visible = true;
            p2.Enabled = true;
        }

        private void DisEnabled_p2()
        {
            p2.Enabled = false;
            b2.Enabled = false;
        }
    }
}
