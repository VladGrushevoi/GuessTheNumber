using System;
using System.Drawing;
using System.Windows.Forms;

namespace GuessTheNumber_3
{
    public partial class MainMenu : Form
    {
        public MainMenu()
        {
            InitializeComponent();
            single = new SinglePlayer();
            with = new WithComputer();
            pvp = new PVP();
            rule = new Rules();
            menu.Panel.BringToFront();
        }

        static Menu menu = new Menu();
        static SinglePlayer single;
        static WithComputer with;
        static PVP pvp;
        static Rules rule;

        private void MainMenu_Load(object sender, EventArgs e)
        {
            this.Controls.Add(menu.Panel);
            this.Controls.Add(single.Panel);
            this.Controls.Add(with.Panel);
            this.Controls.Add(pvp.Panel);
            this.Controls.Add(rule.Panel);
        }

        public static void MenuOnSingl()
        {
            menu.Panel.SendToBack();
            single.Panel.BringToFront();
        }

        public static void SinglOnMenu()
        {
            single.Panel.SendToBack();
            menu.Panel.BringToFront();
        }

        public static void MenuOnComp()
        {
            menu.Panel.SendToBack();
            with.Panel.BringToFront();
        }

        public static void CompOnMenu()
        {

            menu.Panel.BringToFront();
            with.Panel.SendToBack();
        }

        public static void MenuOnPvp()
        {
            MainMenu.ActiveForm.Size = new Size(1100, 500);
            menu.Panel.SendToBack();
            pvp.Panel.BringToFront();
        }

        public static void PvpOnMenu()
        {
            MainMenu.ActiveForm.Size = new Size(590, 540);
            menu.Panel.BringToFront();
            pvp.Panel.SendToBack();
        }

        public static void MenuOnRules()
        {
            menu.Panel.SendToBack();
            rule.Panel.BringToFront();
        }

        public static void RulesOnMenu()
        {
            rule.Panel.SendToBack();
            menu.Panel.BringToFront();
        }
    }
}
