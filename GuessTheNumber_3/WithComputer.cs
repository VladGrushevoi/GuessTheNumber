using System;
using System.Windows.Forms;
using System.Drawing;

namespace GuessTheNumber_3
{
    public class WithComputer : Magic, IClear
    {
        Panel with = new Panel();
        Label Lcomp = new Label();

        private int tempFrom = 0;
        private int tempTo = 0;
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

        public override void butPlayRestart_Click(object sender, EventArgs e)
        {
            if (ListBut[1].Text == "ПОЧАТОК")
            {
                magic.CountTry = 0;
                #region//Деякі дії над компонентами після натиску кнопки Початок
                ListBut[1].Text = "РЕСТАРТ";
                ListLabel[3].Visible = true;
                ListLabel[3].Text = "ЧИСЛО В МЕЖАХ ВІД: " + magic.From.ToString() + " ДО " + magic.To.ToString() + "! ";
                ListBox[2].Visible = true;
                ListBox[2].Enabled = true;
                ListBut[3].Visible = true;
                ListLabel[4].Visible = true;
                ListLabel[5].Visible = true;
                #endregion


            }
            else
            {
                magic.CountTry = 0;
                #region //Деякі дії над компонентами після натиску кнопки рестарт
                ListBox[1].Enabled = true;
                ListBox[0].Enabled = true;
                ListBut[1].Text = "ПОЧАТОК";
                ListBut[1].Enabled = false;
                ListBox[1].Text = "";
                ListBox[0].Text = "";
                ListBox[2].Text = "";
                ListLabel[3].Text = "";
                ListLabel[4].Text = "";
                ListLabel[5].Text = "";
                ListLabel[5].Enabled = true;
                ListBox[2].Enabled = false;
                #endregion
            }
        }

        public override void ChekInputNumber(int g,string name)
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
            else if(chek == 0)
            {
                    if (g < magic.Guess)
                    {
                    if (name == "Гравець") {
                        magic.CountTry++;
                        ListLabel[5].Text = "ЗРОБЛЕНО СПРОБ: " + (magic.CountTry).ToString();
                        ListLabel[4].Text = "ВАШЕ ЧИСЛО МЕНШЕ";
                        LogicComputer();
                    }
                    else
                    {
                        Lcomp.Text = "КОМП'ЮТЕР СПРОБУВАВ ЧИСЛО " + g + ", ВОНО ВИЯВИЛОСЯ МЕШНИМ";
                    }
                    }
                    else if (g > magic.Guess)
                    {
                        if(name == "Гравець")
                         {
                            magic.CountTry++;
                            ListLabel[5].Text = "ЗРОБЛЕНО СПРОБ: " + (magic.CountTry).ToString();
                            ListLabel[4].Text = "ВАШЕ ЧИСЛО БІЛЬШЕ";
                            LogicComputer();
                        }
                        else
                        {
                             Lcomp.Text = "КОМП'ЮТЕР СПРОБУВАВ ЧИСЛО " + g + ", ВОНО ВИЯВИЛОСЯ БІЛЬШИМ";
                        }
                    }
                    else
                    {
                    
                        MessageBox.Show("          Вітаємo!   \n" +
                                                                        name + " виграв!!! "
                                                                            , "Вгадай число",
                                                       MessageBoxButtons.OK, MessageBoxIcon.Information);
                    
                        ListBut[1].Text = "РЕСТАРТ";
                        ListBut[1].Enabled = true;
                        ListBox[2].Enabled = false;
                        tempFrom = 0;
                        tempTo = 0;
                        magic.CountTry = 0;

                    Lcomp.Text = "КОМП'ЮТЕР СПРОБУВАВ ЧИСЛО " + g + ", ВОНО ВИЯВИЛОСЯ ПРАВИЛЬНИМ";
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
            if (tempFrom == 0)
            {
                tempFrom = magic.From;
            }
            if (tempTo == 0)
            {
                tempTo = magic.To;
            }
            if (magic.InputNumber <= magic.Guess && magic.InputNumber >= tempFrom)
            {
                tempFrom = magic.InputNumber;
            }
            else if (magic.InputNumber >= magic.Guess && magic.InputNumber <= tempTo)
            {
                tempTo = magic.InputNumber;
            }
            inum = rnd.Next(tempFrom, tempTo);
            ChekInputNumber(inum, "Комп'ютер");
        }
        public void butTry_Click(object sender, EventArgs e)
        {
            try
            {
                magic.InputNumber = Convert.ToInt32(ListBox[2].Text);
                ChekInputNumber(magic.InputNumber, "Гравець");
                ListBut[3].Enabled = false;
            }
            catch
            {
                MessageBox.Show("Ви не ввели число");
            }
        }

        public void Clear()
        {
            ListBox[0].Clear();
            ListBox[1].Clear();
            ListBox[2].Clear();
            ListLabel[3].Text = "";
            ListLabel[4].Text = "";
            ListLabel[5].Text = "";
            ListBut[1].Text = "ПОЧАТОК";
            Lcomp.Text = "HELLO";
            magic.From = 0;
            magic.To = 0;
        }
    }
}
