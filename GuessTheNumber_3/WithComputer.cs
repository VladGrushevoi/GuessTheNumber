using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;

namespace GuessTheNumber_3
{
    public class WithComputer : Magic
    {
        Panel with = new Panel();

        Label Lcomp = new Label();
        public WithComputer()
        {
            FillPanels(with, "ВСТАНОВИТЬ", "ПОЧАТОК", "ВИХІД", "ВГАДАТЬ");
            Initialization(with);
            ListBut[2].Click += Exit_Click;
            ListBut[3].Click += new EventHandler(this.butTry_Click);
            AddLabelForComp();
        }

        public Panel Panel
        {
            get
            {
                return with;
            }
        }

        private void AddLabelForComp()
        {
            Lcomp.AutoSize = true;
            Lcomp.BackColor = Color.LawnGreen;
            Lcomp.BorderStyle = BorderStyle.Fixed3D;
            Lcomp.Font = new Font("Mistral", 15F);
            Lcomp.Location = new Point(10, 350);
            Lcomp.Margin = new Padding(4, 0, 4, 0);
            Lcomp.MaximumSize = new Size(400, 100);
            Lcomp.Name = "labelInfoComp";
            Lcomp.Size = new Size(2, 32);
            Lcomp.TabIndex = 12;
            Lcomp.Text = "Hello";
            with.Controls.Add(Lcomp);
        }

        public override void ChekInputNumber()
        {
            int chek = magic.Check();
            if (chek == 1)
            {
                MessageBox.Show("Ви ввели більше число чим найбільше число проміжка. Введіть друге",
                    "Вгадай число", MessageBoxButtons.OK);
                ListBox[2].Text = "";
            }
            else if (chek == -1)
            {
                MessageBox.Show("Ви ввели менше число чим найменше число проміжка. Введіть друге",
                    "Вгадай число", MessageBoxButtons.OK);
                ListBox[2].Text = "";
            }
            else
            {
                
                ListLabel[4].Text = " ";
                ListLabel[5].Text = "ЗРОБЛЕНО СПРОБ: " + (magic.CountTry).ToString();
                if (magic.InputNumber < magic.Guess)
                {
                    ListLabel[4].Text = "ВАШЕ ЧИСЛО МЕНШЕ";
                    magic.CountTry++;
                    LogicComputer();

                }
                else if (magic.InputNumber > magic.Guess)
                {
                    ListLabel[4].Text = "ВАШЕ ЧИСЛО БІЛЬШЕ";
                    magic.CountTry++;
                    LogicComputer();
                }
                else
                {
                    MessageBox.Show("          Вітаєм!   \n" +
                                                 "Ви вгадали число за " + magic.CountTry.ToString() + " спроб"
                                                 , "Вгадай число",
                                                 MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ListBut[1].Text = "РЕСТАРТ";
                    ListBut[1].Enabled = true;
                    ListBox[2].Enabled = false;

                    magic.CountTry = 0;
                }
            }
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            Clear();
            MainMenu.CompOnMenu();
        }

        private void LogicComputer()
        {
            Random rnd = new Random();
            int inum = 0;
            int tempFrom;
            int tempTo;
            if (magic.InputNumber < magic.Guess)
            {
                tempFrom = magic.InputNumber;
                inum = rnd.Next(tempFrom, magic.To);
            }
            else if (magic.InputNumber > magic.Guess)
            {
                tempTo = magic.InputNumber;
                inum = rnd.Next(magic.From, tempTo);
            }
            CheckInum(inum);
        }

        public void CheckInum(int inum)
        {
            int chek = magic.Check();
            if (inum == magic.Guess)
            {
                MessageBox.Show("          Ви програли!   \n" +
                                                 "Комп'ютер вгадав число за " + magic.CountTry.ToString() + " спроб " + inum
                                                 , "Вгадай число",
                                                 MessageBoxButtons.OK, MessageBoxIcon.Information);
                ListLabel[3].Text = "";
                ListBox[2].Enabled = false;

                magic.CountTry = 0;
            }
            else if (inum < magic.Guess)
            {
                Lcomp.Text = "КОМП'ЮТЕР СПРОБУВАВ ЧИСЛО " + inum + " ВОНО ВИЯВИЛОСЯ МЕНШИМ";
            }
            else if (inum > magic.Guess)
            {
                Lcomp.Text = "КОМП'ЮТЕР СПРОБУВАВ ЧИСЛО " + inum + " ВОНО ВИЯВИЛОСЯ БІЛЬШИМ";

                ListBut[1].Enabled = true;
            }
        }

        public void butTry_Click(object sender, EventArgs e)
        {
            ListBut[3].Enabled = false;
            try
            {
                magic.InputNumber = Convert.ToInt32(ListBox[2].Text);
                ChekInputNumber();
            }
            catch
            {
                MessageBox.Show("Ви не ввели число");
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
            Lcomp.Text = "";
        }
    }
}
