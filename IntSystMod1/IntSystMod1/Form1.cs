using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IntSystMod1
{
    public partial class Form1 : Form
    {
        public double[] M;
        public int a = 0;
        public double x = 0;
        public Form1()
        {
            InitializeComponent();
            numericUpDown2.Visible = false;
            numericUpDown3.Visible = false;
            label2.Visible = false;
            label3.Visible = false;
            button1.Visible = false;
            checkBox1.Checked = true;
            label4.Visible = false;
            label5.Visible = false;
            label7.Visible = false;
            label6.Visible = false;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                label3.Visible = false;
                label4.Visible = false;
                label5.Visible = false;
                label6.Visible = false;
                numericUpDown2.Visible = false;
                numericUpDown2.Text = "";
                button1.Visible = false;

                for (int i = 0; i < a; i++)
                {
                    TextBox textb = Controls["textb" + i.ToString()] as TextBox;
                    TrackBar TB = Controls["trackBar" + i.ToString()] as TrackBar;
                    if(textb!=null&&TB!=null)
                        try
                        {
                            Controls.Remove(textb);
                            textb.Dispose();
                            Controls.Remove(TB);
                            TB.Dispose();
                        }
                        catch { }
                    
                }

            }
            else
            {
                label3.Visible = true;
                numericUpDown2.Visible = true;
                button1.Visible = true;
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked == false)
            {
                label7.Visible = false;
                numericUpDown3.Visible = false;

            }
            else
            {
                label7.Visible = true;
                numericUpDown3.Visible = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            label3.Visible = true;
            label4.Visible = true;
            label5.Visible = true;
            label6.Visible = true;
            a = int.Parse(numericUpDown2.Text);
            M = new double[a];
            for (int i = 0; i < a; i++)
            {
                TrackBar trackBars = new TrackBar();
                TextBox textboxes = new TextBox();
                trackBars.Name = i.ToString();
                trackBars.Size = new Size(308, 70);
                textboxes.Name = "textb" + i.ToString();
                trackBars.Location = new Point(label4.Left, label4.Bottom + 5 + 80 * i);
                trackBars.Minimum = 0;
                trackBars.Maximum = 200;
                textboxes.Location = new Point(trackBars.Right + 10, label4.Bottom + 5 + 80 * i);
                textboxes.Text = "";
                
                Controls.Add(trackBars);
                Controls.Add(textboxes);
                trackBars.Scroll += new EventHandler(trackBars_Scroll);
            }
        }
        private void trackBars_Scroll(object sender, EventArgs e)
        {
            TrackBar trackBars = (TrackBar)sender;
            int strName = int.Parse(trackBars.Name);
            M[strName] = trackBars.Value/200.00;
        }

        private void numericUpDown3_TextChanged(object sender, EventArgs e)
        {
            if (numericUpDown3.Text != "")
                x = int.Parse(numericUpDown3.Text);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked == false)
                for (int i = 0; i < a; i++)
                {
                    TextBox textb = Controls["textb" + i.ToString()] as TextBox;
                    TrackBar TB = Controls["trackBar" + i.ToString()] as TrackBar;
                    if (textb != null && TB != null)
                        try
                        {
                            Controls.Remove(textb);
                            textb.Dispose();
                            Controls.Remove(TB);
                            TB.Dispose();
                        }
                        catch { }
                }
            numericUpDown1.Text = "";
            numericUpDown2.Text = "";
            numericUpDown3.Text = "";
            label3.Visible = false;
            numericUpDown2.Visible = false;
            label2.Visible = false;
            numericUpDown3.Visible = false;
            button1.Visible = false;
            checkBox1.Checked = true;
            label4.Visible = false;
            label5.Visible = false;
            label6.Visible = false;
            label7.Visible = false;
            label8.Text = "";
            label8.Visible = false;

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
            Answer[3] = "Вы не заполнили поля для ввода или заполнили их неверно.'\n' Нажмите Очистить, после чего введите данные заново.";

            double l = 0;
            if ((numericUpDown1.Text == "") || (numericUpDown2.Visible && !double.TryParse(numericUpDown2.Text, out l)) || (numericUpDown3.Visible && !double.TryParse(numericUpDown3.Text, out l)))
            {
                label8.Text = Answer[3];
                label8.Visible = true;
            }
            else
            {
                l = 0;
                string k = "", z = "", key;
                double n = 0, checkcounter=0;
                if (checkBox1.Checked)
                    checkcounter += 1;
                if (checkBox2.Checked)
                    checkcounter += 2;
                double y = double.Parse(numericUpDown1.Text);
                Dictionary<string, double> chasItog = new Dictionary<string, double>
                {
                    { "Простой1-2", 99 },
                    { "Простой3", 49.5 },
                    { "Простой4", 27.5 },
                    { "Простой5", 5.5 },
                    { "Сложный1-2", 104.5 },
                    { "Сложный3", 60.5 },
                    { "Сложный4", 33 },
                    { "Сложный5", 11 },
                    { "Очень сложный1-2", 110 },
                    { "Очень сложный3", 71.5 },
                    { "Очень сложный4", 66 },
                    { "Очень сложный5", 22 }
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
                    if (radioButtons[i].Checked)
                    {
                        z = radioButtons[i].Text;
                        l += 1;
                    }
                }

                for (int i = 4; i < 7; i++)
                {
                    if (radioButtons[i].Checked)
                    {
                        k = radioButtons[i].Text;
                        l += 1;
                    }
                }
                for (int i = 7; i < 10; i++)
                {
                    if (radioButtons[i].Checked)
                    {
                        l += 1;
                        checkcounter += 10 * (i + 1);
                    }

                }
                if (l != 3)
                {
                    label8.Text = Answer[3];
                    label8.Visible = true;
                    return;
                }
                key = k + z;

                for (int i = 0; i < a; i++)
                {
                    n += chasItog[key] * M[i];
                }
                double value1 = y * 7.09 - n,
                    value2 = y * (6.09 - 17* x / (7 * 69) - (y / 7) * x) - n;

                if (y > 1)
                {
                    if (checkcounter==90)
                        if (chasItog[key] < value1)
                            label8.Text = Answer[0] + (Math.Round(chasItog[key] / y, 1)).ToString() + " час (-а, -ов).";
                        else
                            label8.Text = Answer[1] + (Math.Round(chasItog[key] / y, 1)).ToString() + "часу (-ам, -ов).";
                    if (checkcounter == 100)
                        if (0.5 * chasItog[key] < value1)
                            label8.Text = Answer[0] + (Math.Round(0.5 * chasItog[key] / y, 1)).ToString() + " час(-а, -ов).";
                        else
                            label8.Text = Answer[1] + (Math.Round(0.5 * chasItog[key] / y, 1)).ToString() + "часу (-ам, -ов).";
                    if (checkcounter == 80)
                        if (1.5 * chasItog[key] < value1)
                            label8.Text = Answer[0] + (Math.Round(1.5 * chasItog[key] / y, 1)).ToString() + " час(-а, -ов).";
                        else
                            label8.Text = Answer[1] + (Math.Round(1.5 * chasItog[key] / y, 1)).ToString() + "часу (-ам, -ов).";
                    if (checkcounter == 92)
                        if (chasItog[key] < value2)
                            label8.Text = Answer[0] + (Math.Round(chasItog[key] / y, 1)).ToString() + " час (-а, -ов).";
                        else
                            label8.Text = Answer[1] + (Math.Round(chasItog[key] / y, 1)).ToString() + "часу (-ам, -ов).";
                    if (checkcounter == 102)
                        if (0.5 * chasItog[key] < value2)
                            label8.Text = Answer[0] + (Math.Round(0.5 * chasItog[key] / y, 1)).ToString() + " час(-а, -ов).";
                        else
                            label8.Text = Answer[1] + (Math.Round(0.5 * chasItog[key] / y, 1)).ToString() + "часу (-ам, -ов).";
                    if (checkcounter == 82)
                        if (1.5 * chasItog[key] < value2)
                            label8.Text = Answer[0] + (Math.Round(1.5 * chasItog[key] / y, 1)).ToString() + " час(-а, -ов).";
                        else
                            label8.Text = Answer[1] + (Math.Round(1.5 * chasItog[key] / y, 1)).ToString() + "часу (-ам, -ов).";
                    if (checkcounter == 91)
                        if (chasItog[key] < value1)
                            label8.Text = Answer[0] + (Math.Round(chasItog[key] / y, 1)).ToString() + " час (-а, -ов).";
                        else
                            label8.Text = Answer[1] + (Math.Round(chasItog[key] / y, 1)).ToString() + "часу (-ам, -ов).";
                    if (checkcounter==101)
                        if (0.5 * chasItog[key] < value1)
                            label8.Text = Answer[0] + (Math.Round(0.5 * chasItog[key] / y, 1)).ToString() + " час(-а, -ов).";
                        else
                            label8.Text = Answer[1] + (Math.Round(0.5 * chasItog[key] / y, 1)).ToString() + "часу (-ам, -ов).";
                    if (checkcounter == 81)
                        if (1.5 * chasItog[key] < value1)
                            label8.Text = Answer[0] + (Math.Round(1.5 * chasItog[key] / y, 1)).ToString() + " час(-а, -ов).";
                        else
                            label8.Text = Answer[1] + (Math.Round(1.5 * chasItog[key] / y, 1)).ToString() + "часу (-ам, -ов).";
                    if (checkcounter == 93)
                        if (chasItog[key] < value2)
                            label8.Text = Answer[0] + (Math.Round(chasItog[key] / y, 1)).ToString() + " час (-а, -ов).";
                        else
                            label8.Text = Answer[1] + (Math.Round(chasItog[key] / y, 1)).ToString() + "часу (-ам, -ов).";
                    if (checkcounter == 103)
                        if (0.5 * chasItog[key] < value2)
                            label8.Text = Answer[0] + (Math.Round(0.5 * chasItog[key] / y, 1)).ToString() + " час(-а, -ов).";
                        else
                            label8.Text = Answer[1] + (Math.Round(0.5 * chasItog[key] / y, 1)).ToString() + "часу (-ам, -ов).";
                    if (checkcounter == 83)
                        if (1.5 * chasItog[key] < value2)
                            label8.Text = Answer[0] + (Math.Round(1.5 * chasItog[key] / y, 1)).ToString() + " час(-а, -ов).";
                        else
                            label8.Text = Answer[1] + (Math.Round(1.5 * chasItog[key] / y, 1)).ToString() + "часу (-ам, -ов).";
                    
                }
                else
                {
                    label8.Text = Answer[2];
                }
                label8.Visible = true;

                x = 0;
            }
        }

    }
}
