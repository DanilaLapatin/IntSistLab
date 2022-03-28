using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WFTree
{
    public partial class Form1 : Form
    {
        public double[] M;
        public int a = 0, x = 0;
        public Form1()
        {
            InitializeComponent();
            label3.Visible = false;
            textBox2.Visible = false;
            label2.Visible = false;
            textBox3.Visible = false;
            button1.Visible = false;
            checkBox1.Checked = true;
            label4.Visible = false;
            label5.Visible = false;
            label7.Visible = false;
            label6.Visible = false;
            label9.Visible = false;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true) 
            {
                label3.Visible = false;
                textBox2.Visible = false;
            }
            else
            {
                label3.Visible = true;
                textBox2.Visible = true;
                button1.Visible = true;
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked == false)
            {
                label2.Visible = false;
                textBox3.Visible = false;
            }
            else
            {
                label2.Visible = true;
                textBox3.Visible = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            label9.Visible = true;
            label4.Visible = true;
            label5.Visible = true;
            label6.Visible = true;
            label7.Visible = true;
            a = int.Parse(textBox2.Text);
            M = new double[a];
            int startX = 631, startY = 150;
            for (int i = 0; i < a; i++)
            {
                TrackBar trackBars = new TrackBar();
                TextBox textboxes = new TextBox();
                trackBars.Name = "trackBar" + i.ToString();
                trackBars.Size = new Size(308, 70);
                textboxes.Name = "textb" + i.ToString();
                textboxes.Location = new Point(945, startY + 80 * i);
                textboxes.Text = "";
                textboxes.AccessibleName = i.ToString();
                trackBars.Location = new Point(startX, startY + 80 * i);
                trackBars.Minimum = 0;
                trackBars.Maximum = 200;
                trackBars.AccessibleName= i.ToString();
                Controls.Add(trackBars);
                Controls.Add(textboxes);
                trackBars.Scroll += new EventHandler(trackBars_Scroll);
            }
        }
        private void trackBars_Scroll(object sender, EventArgs e)
        {
            TrackBar trackBars = (TrackBar)sender;
            string strName = trackBars.AccessibleName;
            M[int.Parse(strName)]= trackBars.Value;
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            if(textBox3.Text != "")
                x = int.Parse(textBox3.Text);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if(checkBox1.Checked==false)
                for (int i = 0; i < a; i++)
                {
                    TextBox  textb= Controls["textb" + i.ToString()]as TextBox;
                    TrackBar TB = Controls["trackBar" + i.ToString()] as TrackBar;
                    Controls.Remove(textb);
                    textb.Dispose();
                    Controls.Remove(TB);
                    TB.Dispose();
                }
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            label3.Visible = false;
            textBox2.Visible = false;
            label2.Visible = false;
            textBox3.Visible = false;
            button1.Visible = false;
            checkBox1.Checked = true;
            label4.Visible = false;
            label5.Visible = false;
            label7.Visible = false;
            label6.Text = "";
            label6.Visible = false;
            label9.Visible = false;
            checkBox2.Checked = false;
            a = 0;
            x = 0;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string[] Answer = new string[4];
            Answer[0] = "В день на подготовку будет достаточно уделять по ";
            Answer[1] = "Возможно, у Вас будет меньше времени на обычные дела, не рекомендуем работать больше положенного.'\n'Тем не менее, Вы можете попытаться готовиться каждый день по ";
            Answer[2] = "Мы не рекомендуем сейчас начинать готовиться. Уже поздно, и лучше расслабиться и хорошо выспаться.";
            Answer[3] = "Вы не заполнили поля для ввода или заполнили их неверно. Нажмите Очистить, после чего введите данные заново.";

            int l =0;
            if ((textBox1.Text == "") ||(textBox2.Visible== true&& Int32.TryParse(textBox2.Text,out l)==false) || (textBox3.Visible == true && Int32.TryParse(textBox2.Text, out l)))
            {
                label6.Text = Answer[3];
                label6.Visible = true;
            }
            else
            {
                l = 0;
                string k = "", z = "", key;
                double n = 0;
                int y = int.Parse(textBox1.Text);
                Dictionary<string, double> chasItog = new Dictionary<string, double>
                {
                    { "простой1-2", 99 },
                    { "простой3", 49.5 },
                    { "простой4", 27.5 },
                    { "простой5", 5.5 },
                    { "средний1-2", 104.5 },
                    { "средний3", 60.5 },
                    { "средний4", 33 },
                    { "средний5", 11 },
                    { "сложный1-2", 110 },
                    { "сложный3", 71.5 },
                    { "сложный4", 66 },
                    { "сложный5", 22 }
                };
                RadioButton[] radioButtons = new RadioButton[10]
                {
                radioButton1,
                radioButton2,
                radioButton3,
                radioButton4,
                radioButton5,
                radioButton6,
                radioButton7,
                radioButton8,
                radioButton9,
                radioButton10
                };

                for (int i = 0; i < 4; i++)
                {
                    if (radioButtons[i].Checked == true)
                    {
                        z = radioButtons[i].Text;
                        l += 1;
                    }
                }

                for (int i = 4; i < 7; i++)
                {
                    if (radioButtons[i].Checked == true)
                    {
                        k = radioButtons[i].Text;
                        l += 1;
                    }
                }
                for (int i = 7; i < 10; i++)
                {
                    if (radioButtons[i].Checked == true)
                        l += 1;    
                }
                if (l != 3)
                {
                    label6.Text = Answer[3];
                    label6.Visible = true;
                    return ;
                }
                key = k + z;

                for (int i = 0; i < a; i++)
                {
                    n += chasItog[key] * M[i];
                }
                if ((checkBox1.Checked == false) && (checkBox2.Checked == false) && (radioButton9.Checked == true) && (y > 1))
                    if (chasItog[key] < (y * 7.09 - n))
                        label6.Text = Answer[0] + (Math.Round(chasItog[key] / y, 1)).ToString() + " час (-а, -ов).";
                    else
                        label6.Text = Answer[1] + (Math.Round(chasItog[key] / y, 1)).ToString() + "часу (-ам, -ов).";
                if ((checkBox1.Checked == false) && (checkBox2.Checked == false) && (radioButton10.Checked == true) && (y > 1))
                    if (0.5 * chasItog[key] < (y * 7.09 - n))
                        label6.Text = Answer[0] + (Math.Round(0.5 * chasItog[key] / y, 1)).ToString() + " час(-а, -ов).";
                    else
                        label6.Text = Answer[1] + (Math.Round(0.5 * chasItog[key] / y, 1)).ToString() + "часу (-ам, -ов).";

                if ((checkBox1.Checked == false) && (checkBox2.Checked == false) && (radioButton8.Checked == true) && (y > 1))
                    if (1.5 * chasItog[key] < (y * 7.09 - n))
                        label6.Text = Answer[0] + (Math.Round(1.5 * chasItog[key] / y, 1)).ToString() + " час(-а, -ов).";
                    else
                        label6.Text = Answer[1] + (Math.Round(1.5 * chasItog[key] / y, 1)).ToString() + "часу (-ам, -ов).";
                if ((checkBox1.Checked == false) && (checkBox2.Checked == true) && (radioButton9.Checked == true) && (y > 1))
                    if (chasItog[key] < (y * (6.09 - 17 * x / (7 * 69) - (y / 7) * x - n)))
                        label6.Text = Answer[0] + (Math.Round(chasItog[key] / y, 1)).ToString() + " час (-а, -ов).";
                    else
                        label6.Text = Answer[1] + (Math.Round(chasItog[key] / y, 1)).ToString() + "часу (-ам, -ов).";
                if ((checkBox1.Checked == false) && (checkBox2.Checked == true) && (radioButton10.Checked == true) && (y > 1))
                    if (0.5 * chasItog[key] < (y * (6.09 - 17 * x / (7 * 69) - (y / 7) * x - n)))
                        label6.Text = Answer[0] + (Math.Round(0.5 * chasItog[key] / y, 1)).ToString() + " час(-а, -ов).";
                    else
                        label6.Text = Answer[1] + (Math.Round(0.5 * chasItog[key] / y, 1)).ToString() + "часу (-ам, -ов).";
                if ((checkBox1.Checked == false) && (checkBox2.Checked == true) && (radioButton8.Checked == true) && (y > 1))
                    if (1.5 * chasItog[key] < (y * (6.09 - 17 * x / (7 * 69) - (y / 7) * x - n)))
                        label6.Text = Answer[0] + (Math.Round(1.5 * chasItog[key] / y, 1)).ToString() + " час(-а, -ов).";
                    else
                        label6.Text = Answer[1] + (Math.Round(1.5 * chasItog[key] / y, 1)).ToString() + "часу (-ам, -ов).";
                if ((checkBox1.Checked == true) && (checkBox2.Checked == false) && (radioButton9.Checked == true) && (y > 1))
                    if (chasItog[key] < (y * 7.09 - n))
                        label6.Text = Answer[0] + (Math.Round(chasItog[key] / y, 1)).ToString() + " час (-а, -ов).";
                    else
                        label6.Text = Answer[1] + (Math.Round(chasItog[key] / y, 1)).ToString() + "часу (-ам, -ов).";
                if ((checkBox1.Checked == true) && (checkBox2.Checked == false) && (radioButton10.Checked == true) && (y > 1))
                    if (0.5 * chasItog[key] < (y * 7.09 - n))
                        label6.Text = Answer[0] + (Math.Round(0.5 * chasItog[key] / y, 1)).ToString() + " час(-а, -ов).";
                    else
                        label6.Text = Answer[1] + (Math.Round(0.5 * chasItog[key] / y, 1)).ToString() + "часу (-ам, -ов).";
                if ((checkBox1.Checked == true) && (checkBox2.Checked == false) && (radioButton8.Checked == true) && (y > 1))
                    if (1.5 * chasItog[key] < (y * 7.09 - n))
                        label6.Text = Answer[0] + (Math.Round(1.5 * chasItog[key] / y, 1)).ToString() + " час(-а, -ов).";
                    else
                        label6.Text = Answer[1] + (Math.Round(1.5 * chasItog[key] / y, 1)).ToString() + "часу (-ам, -ов).";
                if ((checkBox1.Checked == true) && (checkBox2.Checked == true) && (radioButton9.Checked == true) && (y > 1))
                    if (chasItog[key] < (y * (6.09 - 17 * x / (7 * 69) - (y / 7) * x - n)))
                        label6.Text = Answer[0] + (Math.Round(chasItog[key] / y, 1)).ToString() + " час (-а, -ов).";
                    else
                        label6.Text = Answer[1] + (Math.Round(chasItog[key] / y, 1)).ToString() + "часу (-ам, -ов).";
                if ((checkBox1.Checked == true) && (checkBox2.Checked == true) && (radioButton10.Checked == true) && (y > 1))
                    if (0.5 * chasItog[key] < (y * (6.09 - 17 * x / (7 * 69) - (y / 7) * x - n)))
                        label6.Text = Answer[0] + (Math.Round(0.5 * chasItog[key] / y, 1)).ToString() + " час(-а, -ов).";
                    else
                        label6.Text = Answer[1] + (Math.Round(0.5 * chasItog[key] / y, 1)).ToString() + "часу (-ам, -ов).";
                if ((checkBox1.Checked == true) && (checkBox2.Checked == true) && (radioButton8.Checked == true) && (y > 1))
                    if (1.5 * chasItog[key] < (y * (6.09 - 17 * x / (7 * 69) - (y / 7) * x - n)))
                        label6.Text = Answer[0] + (Math.Round(1.5 * chasItog[key] / y, 1)).ToString() + " час(-а, -ов).";
                    else
                        label6.Text = Answer[1] + (Math.Round(1.5 * chasItog[key] / y, 1)).ToString() + "часу (-ам, -ов).";
                if ((y <= 1))
                {
                    label6.Text = Answer[2];
                }
                label6.Visible = true;

                x = 0;
            }
        }

    }
}
