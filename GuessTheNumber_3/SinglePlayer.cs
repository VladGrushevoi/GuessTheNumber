using System;
using System.Windows.Forms;

namespace GuessTheNumber_3
{
    public class SinglePlayer : Magic
    {
        private Panel SinglePl = new Panel();

        public SinglePlayer()
        {
            FillPanels(SinglePl, "ВСТАНОВИТЬ", "ПОЧАТОК", "ВИХІД", "ВГАДАТЬ");
            Initialization(SinglePl);
            ListBut[2].Click += Exit_Click;
            ListBut[3].Click += new EventHandler(this.butTry_Click);
        }

        public Panel Panel
        {
            get
            {
                return SinglePl;
            }
        }

        public void butTry_Click(object sender, EventArgs e)
        {
            ListBut[3].Enabled = false;
            try
            {
                magic.InputNumber = Convert.ToInt32(ListBox[2].Text);
                ListLabel[5].Text = "ЗАЛИШИЛОСЯ СПРОБ: " + (magic.CountTry).ToString();
                ChekInputNumber(magic.InputNumber,"Ви вгадали число за " + magic.CountTry.ToString() + " спроб");
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
            ListBut[1].Text = "ПОЧАТОК";
            magic.CountTry = 0;
            magic.From = 0;
            magic.To = 0;
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            Clear();
            MainMenu.SinglOnMenu();
        }
    }
}
