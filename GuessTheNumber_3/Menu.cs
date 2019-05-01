using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace GuessTheNumber_3
{
    public class Menu
    {
        List<Button> ListBut = new List<Button>();
        private static Button button;

        private Panel menu;


        public Panel Panel
        {
            get
            {
                return menu;
            }
        }


        public Menu()
        {
            Initilization();
            SetButtons("SINGLE PLAYER", "1 VS COMPUTER", "ONE VS TWO", "RULES", "EXIT");
            SetEvent();
        }

        private void SetButtons(params string[] text)
        {
            Point p = new Point(170, 50);
            foreach (string t in text)
            {
                button = new Button();
                button.Text = t;
                button.Location = p;
                p = new Point(p.X, p.Y + 60);
                button.Size = new Size(175, 60);
                button.FlatStyle = FlatStyle.Flat;
                button.FlatAppearance.BorderColor = Color.RoyalBlue;
                button.FlatAppearance.BorderSize = 0;
                button.FlatAppearance.MouseDownBackColor = Color.RoyalBlue;
                button.FlatAppearance.MouseOverBackColor = Color.RoyalBlue;
                button.Font = new Font("Mistral", 16F);
                Panel.Controls.Add(button);
                ListBut.Add(button);
            }
        }

        private void SetEvent()
        {
            ListBut[0].Click += SingleP_Click;
            ListBut[1].Click += butOneVScomp_Click;
            ListBut[2].Click += butOneVSTwo_Click;
            ListBut[3].Click += butHelp_Click;
            ListBut[4].Click += butExitBtn_Click;
        }

        private void Initilization()
        {
            menu = new Panel();
            menu.AutoSize = true;
            menu.BackColor = Color.DodgerBlue;
            menu.ClientSize = new Size(600, 500);
            menu.Paint += new PaintEventHandler(this.Menu_Paint);
            menu.BringToFront();
            menu.Location = new Point(0, 0);
            menu.Margin = new Padding(4);
            menu.Name = "Menu";
            menu.Text = "Гра Вгадай число";
            menu.ResumeLayout(false);
            menu.PerformLayout();
        }

        private void Menu_Paint(object sender, EventArgs e)
        {

        }

        private void SingleP_Click(object sender, EventArgs e)
        {
            MainMenu.MenuOnSingl();
        }

        private void butOneVSTwo_Click(object sender, EventArgs e)
        {
            MainMenu.MenuOnPvp();
        }

        private void butOneVScomp_Click(object sender, EventArgs e)
        {
            MainMenu.MenuOnComp();
        }

        private void butHelp_Click(object sender, EventArgs e)
        {
            MainMenu.MenuOnRules();
        }

        private void butExitBtn_Click(object sender, EventArgs e)
        {
            Form.ActiveForm.Close();
        }
    }
}
