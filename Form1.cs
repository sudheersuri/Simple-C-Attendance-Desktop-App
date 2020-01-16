using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Test
{
    public partial class Form1 : Form
    {
        int x;
        TextBox t1;
        int btnclicked=0;
        String[] students = { "Akhila", "Maneesh", "Vinitha", "Clinse", "Smit", "Aleena", "Sharine", "Arshdeep", "Simarjit", "Mansi Shekar", "Gurpreet", "Alekya", "Leela", "Anil",
                               "Raghavendra","Preeti","Anish","Shashidar","Urvish","Sri Harsha","Mohit","Nikhil","Dharmik","Daniel","Kamaldeep","Sudheer"};
        /*
        String[] students = {"Adam","Adrian","Alan","Alexander","Andrew","Benjamin","Blake" };
*/
        public Form1()
        {
            InitializeComponent();
            this.Text = "Attendance";
            Array.Sort(students, 0, students.Length);
           /* this.FormBorderStyle = FormBorderStyle.FixedDialog;*/
            this.StartPosition = FormStartPosition.CenterScreen;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.AutoScroll = true;
            this.MinimumSize = new Size(258, 480);
            this.MaximumSize = new Size(258, 480);
            for (int i = 0; i < students.Length; i++)
            {
                crt_btn(i,students[i]);
            }
            absent_by_default();
            add_file_textbox();
            add_save_button();
            
        }
        private void absent_by_default()
        {
            for (int i = 0; i < students.Length; i++)
            {
                students[i] = students[i] + " :A";
            }
        }

        private void add_file_textbox()
        {
            t1 = new TextBox();
            t1.Width = 220;
            t1.Location = new Point(3, 14 + x);
            this.Controls.Add(t1);
            x += 20;
            t1.Text = "Enter Lab number";
            t1.ForeColor = Color.Gray;
            t1.Click += new EventHandler(clear_txt);
            t1.Show();
        }

        private void clear_txt(object sender, EventArgs e)
        {
            t1.ForeColor = Color.Black;
            t1.Text = "";
            btnclicked = 1;
        }

        private void add_save_button()
        {
            Button b1 = new Button();
            b1.BackColor = Color.CadetBlue;
            b1.Name = "Save_btn";
            b1.Text = "Save Data";
            b1.Width =220;
            b1.Height = 50;
            b1.Font = new System.Drawing.Font("Microsoft Times Roman", 20F, System.Drawing.FontStyle.Bold);
            b1.ForeColor = Color.White;
            b1.Location = new Point(3, 14 + x);
            b1.Click += new EventHandler(btn_save);
            x += 50;
            this.Controls.Add(b1);
        }

        
        private void btn_save(object sender, EventArgs e)
        {

            /* File.WriteAllText("C:\\Users\\lenovo\\Desktop\\windows apps\\Test\\"+t1.Text.ToString()+".txt", "");
             System.IO.TextWriter txt = new StreamWriter("C:\\Users\\lenovo\\Desktop\\windows apps\\Test\\"+t1.Text.ToString()+".txt", true);*/

            File.WriteAllText( t1.Text.ToString() + ".txt", "");
            System.IO.TextWriter txt = new StreamWriter( t1.Text.ToString() + ".txt", true);


            for (int i = 0; i < students.Length; i++)
            {
                txt.WriteLine(students[i]);
            }

            txt.Close();
            if (btnclicked == 1  &&  t1.Text.ToString() != "")
            {
                string title = "Data Saved";
                string message = "Data Saved to " + t1.Text.ToString() + ".txt" + " click Ok to close app";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                DialogResult result = MessageBox.Show(message, title, buttons);
                if (result == DialogResult.OK)
                {
                    this.Close();
                }
            }

        }

        private void crt_btn(int i,string v)
        {
            Button b1 = new Button();
            b1.BackColor = Color.Red;
            b1.Text = v;
            b1.Width= 220;
            b1.Height = 50;
            b1.ForeColor = Color.White;
            b1.Font = new System.Drawing.Font("Microsoft Times Roman", 20, System.Drawing.FontStyle.Bold);
            b1.Location = new Point(3, x);
            b1.Click += delegate (object sender2, EventArgs e2)
            {
                btn_click(sender2, e2, i);
            };
            x += 50;
            this.Controls.Add(b1);

        }

        private void btn_click(object sender, EventArgs e,int i)
        {
            Control ctrl = ((Control)sender);
            switch (ctrl.BackColor.Name)
            {
                case "Red":
                    if (students[i].IndexOf(":") == -1)
                        students[i] = students[i] + ": P";
                    else
                    {
                        students[i] = students[i].Substring(0, students[i].IndexOf(":"));
                        students[i] = students[i] + ": P";
                    }
                    ctrl.BackColor = Color.Green;

                    break;
                case "Green":
                    if (students[i].IndexOf(":") == -1)
                        students[i] = students[i] + ": A";
                    else
                    { 
                    students[i] = students[i].Substring(0, students[i].IndexOf(":"));
                    students[i] = students[i] + ": A";
                    }
                    ctrl.BackColor = Color.Red;
                    break;
            }
        }

        
    }
}
