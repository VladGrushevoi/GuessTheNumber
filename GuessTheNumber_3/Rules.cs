using System;
using System.Windows.Forms;
using System.Drawing;

namespace GuessTheNumber_3
{
    public class Rules
    {
        private Panel rul;
        private Label tile;
        private Button ButBack;
        private Label rule;

        public Panel Panel
        {
            get
            {
                return rul;
            }
        }

        public Rules()
        {
            rul = new Panel();
            tile = new Label();
            ButBack = new Button();
            rule = new Label();
            Initilization();
        }

        private void Initilization()
        {
            //Панель
            rul.AutoSize = true;
            rul.BackColor = Color.DodgerBlue;
            rul.ClientSize = new Size(1100, 530);
            rul.Location = new Point(0, 0);
            rul.Controls.Add(tile);
            rul.Controls.Add(ButBack);
            rul.Controls.Add(rule);
            rul.Paint += new PaintEventHandler(Rules_Paint);
            rul.Margin = new Padding(0);
            rul.Name = "SingleForm";
            rul.Text = "Гра Вгадай число";
            rul.ResumeLayout(false);
            rul.PerformLayout();

            //кнопка назад
            ButBack.AutoSize = true;
            ButBack.Cursor = Cursors.Hand;
            ButBack.FlatAppearance.BorderColor = Color.RoyalBlue;
            ButBack.FlatAppearance.BorderSize = 0;
            ButBack.FlatAppearance.MouseDownBackColor = Color.RoyalBlue;
            ButBack.FlatAppearance.MouseOverBackColor = Color.RoyalBlue;
            ButBack.FlatStyle = FlatStyle.Flat;
            ButBack.Font = new Font("Mistral", 14F);
            ButBack.Location = new Point(25, 25);
            ButBack.Margin = new Padding(4);
            ButBack.Name = "butSingleP";
            ButBack.Size = new Size(100, 30);
            ButBack.TabIndex = 1;
            ButBack.Text = "НАЗАД";
            ButBack.UseVisualStyleBackColor = true;
            ButBack.Click += new EventHandler(ButBack_Click);

            //Ініціалізація заголовка
            tile.Location = new Point(150, 50);
            tile.AutoSize = true;
            tile.Font = new System.Drawing.Font("Mistral", 20F);
            tile.Size = new Size(100, 50);
            tile.Text = "ПРАВИЛА ГРИ";

            //Ініціалізація текста правил
            string rrule;
            rrule = "   ГРА ПОЛЯГАЄ В ТОМУ, ЩОБ ВГАДАТИ ЧИСЛО ЯКЕ ЗАГАДАВ КОМП'ЮТЕР." +
                        "ПРОМІЖОК ДЛЯ ВІДГАДУВАННЯ ВКАЗУЄ ГРАВЕЦЬ, У ВІДПОВІДНИХ ПОЛЯХ." +
                        "   ЗА ДОПОМОГОЮ КНОПКИ ПОЧАТОК, ГРАВЕЦЬ ПОЧИНАЄ ГРУ. ГРА" +
                        "ПРОДОВЖУЄТЬСЯ ДО ТИХ ПІР, ДОКИ АБО ГРАВЕЦЬ, АБО КОМП'ЮТЕР(В" +
                        "РЕЖИМІ ГРА З КОМП'ЮТЕРОМ), АБО ГРАВЦІ(В РЕЖИМІ ОДИН ПРОТИ ОДНОГО)," +
                        "ВГАДАЮТЬ ЧИСЛО." +
                        "   ЧИСЛО ГЕНЕРУЄТЬСЯ ВИПАДКОВИМ ЧИНОМ, В ПРОМІЖКУ ЯКИЙ ВВІВ ГРАВЕЦЬ." +
                        "ЗА ДОПОМОГОЮ КНОПКИ РЕСТАРТ, МОЖНА ПОЧАТИ ГРУ СПОЧАТКУ. В ГРІ Є ТРИ РЕЖИМИ:" +
                        ", ЦЕ: ОДИНОЧНА ГРА, ГРА З КОМП'ЮТЕРОМ ТА ПРОТИ ОДНОГО.";

            rule.Location = new Point(25, 100);
            rule.AutoSize = true;
            rule.Font = new System.Drawing.Font("Mistral", 14F);
            rule.MaximumSize = new Size(500, 500);
            rule.Text = rrule;
        }

        private void ButBack_Click(object sender, EventArgs e)
        {
            MainMenu.RulesOnMenu();
        }

        private void Rules_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
