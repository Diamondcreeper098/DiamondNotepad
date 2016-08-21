using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;//Normal Using
using io = System.IO;// Alias Using Type

namespace DiamondNotepad
{
    public partial class Form1 : Form
    {
        public string ffl = ""; // Filename
        public string mmd = "";
        public bool chng = false;
        public Form1(string fnl)
        {
            ffl = fnl;
            InitializeComponent();//Environment.CurrentDirectory);
            if (fnl == string.Empty || fnl == "")
            {
                this.Text = "DiamondNotepad";
            }
            else
            {
                this.Text = "DiamondNotepad - " + fnl;
                string mmd = opens(textBox1, ffl);
                if (mmd == "Error")
                {
                    Application.Exit();
                }
            }
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("A Notepad With Color Save and Read" + "\n" + "By Diamondcreeper098" + "\n" + "Time is: " + DateTime.Now.ToString() ,"About");
        }

        private void toolStripLabel1_Click(object sender, EventArgs e)
        {
            this.Text = "DiamondNotepad";
            textBox1.Clear();
            textBox1.BackColor = Color.White;
            this.Text = "DiamondNotepad";
        }

        private void toolStripLabel1_MouseEnter(object sender, EventArgs e)
        {
            
        }

        private void dd(object sender, EventArgs e)
        {
            ToolStripLabel tsl = (ToolStripLabel)sender;
            tsl.ForeColor = Color.Blue;
        }

        private void ddw(object sender, EventArgs e)
        {
            ToolStripLabel tsl = (ToolStripLabel)sender;
            tsl.ForeColor = Color.Blue;
        }

        private void ddf(object sender, EventArgs e)
        {
            ToolStripLabel tsl = (ToolStripLabel)sender;
            tsl.ForeColor = Color.Black;
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Text = "DiamondNotepad";
            textBox1.Clear();
            textBox1.BackColor = Color.White;
        }
        public void openf(TextBox texb, string filen) 
        {
            texb.Clear();
            chng = false;
            string[] temp = filen.Split('.');
            if (temp[temp.Length - 1] == "clrd")
            {
                try
                {
                    string[] ff = io.File.ReadAllLines(filen)[0].Split(':');
                    if (ff[0] != "Color")
                    {
                        MessageBox.Show("File is Corrupted");
                        return;
                    }
                    texb.BackColor = Color.FromName(ff[1]);
                    for (int i = 1; i < io.File.ReadAllLines(filen).Length; i++)
                    {
                        texb.Text += io.File.ReadAllLines(filen)[i];
                        texb.Text +=Environment.NewLine;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("File is Corrupted" + "\n" + "Error is: " + ex.Message,"Error", MessageBoxButtons.OK,MessageBoxIcon.Error);
                }
            }
            else
            {
                texb.Lines = io.File.ReadAllLines(filen) ;
            }
            chng = false;
        }
        public string opens(TextBox texb, string filen)
        {
            string msg = "";
            texb.Clear();
            chng = false;
            string[] temp = filen.Split('.');
            if (temp[temp.Length - 1] == "clrd")
            {
                try
                {
                    string[] ff = io.File.ReadAllLines(filen)[0].Split(':');
                    if (ff[0] != "Color")
                    {
                        MessageBox.Show("File is Corrupted");
                        Application.Exit();
                    }
                    texb.BackColor = Color.FromName(ff[1]);
                    for (int i = 1; i < io.File.ReadAllLines(filen).Length; i++)
                    {
                        texb.Text += io.File.ReadAllLines(filen)[i];
                        texb.Text += Environment.NewLine;
                    }
                    msg = "ok";
                }
                catch (Exception ex)
                {
                    MessageBox.Show("File is Corrupted" + "\n" + "Error is: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Application.Exit();
                    msg = "Error";
                    return msg;
                }
            }
            else
            {
                texb.Lines = io.File.ReadAllLines(filen);
            }
            chng = false;
            return msg;
        }
        public void savef(TextBox texb, string color)
        {
            if (ffl != "")
            {
                string[] temp = ffl.Split('.');
                if (temp[temp.Length - 1] == "clrd")
                {
                    io.File.WriteAllText(ffl, "Color:" + color + "\n" + texb.Text);
                }
                else
                {
                    io.File.WriteAllText(ffl, texb.Text);
                }
                this.Text = "DiamondNotepad - " + ffl;
            }
        }
        public void saveasf(TextBox texb, string fl,string color)
        {
            string[] temp = fl.Split('.');
            if (temp[temp.Length - 1]=="clrd")
            {
                io.File.WriteAllText(fl, "Color:"+color+"\n"+texb.Text);
            }
            else
            {
                io.File.WriteAllText(fl, texb.Text);
            }
            
        }

        private void fontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (fontDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    textBox1.Font = fontDialog1.Font;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void toolStripLabel3_Click(object sender, EventArgs e)
        {
            savef(textBox1,textBox1.BackColor.Name);
        }

        private void toolStripLabel4_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                ffl = saveFileDialog1.FileName;
                this.Text = "DiamondNotepad - " + ffl;
               if (!io.File.Exists(ffl))
                {
                    saveasf(textBox1,ffl,textBox1.BackColor.Name);
                }
                else
                {
                    if (MessageBox.Show("Your file Exists Overwrite it?","Question",MessageBoxButtons.YesNo,MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                    {
                        savef(textBox1,textBox1.BackColor.Name);
                    }
                }
            }
        }

        private void saveFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void toolStripLabel7_Click(object sender, EventArgs e)
        {
            if (chng == true)
            {
                var sd = MessageBox.Show("Save Your file Before Open?", "Question", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                if (sd == System.Windows.Forms.DialogResult.Yes)
                {
                    toolStripLabel4_Click(null, null);
                    if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        ffl = openFileDialog1.FileName;

                        openf(textBox1, ffl);
                        this.Text = "DiamondNotepad - " + ffl;
                    }
                }
                else if (sd == System.Windows.Forms.DialogResult.No)
                {
                    if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        ffl = openFileDialog1.FileName;

                        openf(textBox1, ffl);
                        this.Text = "DiamondNotepad - " + ffl;
                    }
                }
                else
                {
                    return;
                }
            }
            else
            {
                if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    ffl = openFileDialog1.FileName;

                    openf(textBox1, ffl);
                    this.Text = "DiamondNotepad - " + ffl;
                }
            }
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (chng == true)           
            {
                var sd = MessageBox.Show("Save Your file Before Open?", "Question", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                if (sd == System.Windows.Forms.DialogResult.Yes)
                {
                    toolStripLabel4_Click(null, null);
                    if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        ffl = openFileDialog1.FileName;

                        openf(textBox1, ffl);
                        this.Text = "DiamondNotepad - " + ffl;
                    }
                }
                else if(sd == System.Windows.Forms.DialogResult.No)
                {
                    if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        ffl = openFileDialog1.FileName;

                        openf(textBox1, ffl);
                        this.Text = "DiamondNotepad - " + ffl;
                    }
                }
                else
                {
                    return;
                }
            }
            else
            {
                if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    ffl = openFileDialog1.FileName;

                    openf(textBox1, ffl);
                    this.Text = "DiamondNotepad - " + ffl;
                }
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (ffl != "")
            {
                this.Text = "* DiamondNotepad - " + ffl + " *";
                chng = true;
            }
            else
            {
                chng = true;
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (chng == true)
            {
                var sd = MessageBox.Show("Save Your file Before Exit?", "Question", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                if (sd == System.Windows.Forms.DialogResult.Yes)
                {
                    toolStripLabel4_Click(null, null);
                    MessageBox.Show("Your file saved successfully");
                }
                else if (sd == System.Windows.Forms.DialogResult.No)
                {
                    return;
                }
                else
                {
                    e.Cancel = true;
                    return;
                }
            }
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toolStripLabel4_Click(null, null);
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toolStripLabel3_Click(null, null);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void toolStripLabel5_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                textBox1.BackColor = colorDialog1.Color;
            }
        }

        private void colorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toolStripLabel5_Click(null, null);
        }

        private void Form1_Activated(object sender, EventArgs e)
        {
            if (mmd == "Error")
            {
               Application.Exit(); 
            }
        }
    }
}
