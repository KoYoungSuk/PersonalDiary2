using Oracle.ManagedDataAccess.Client;
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

namespace PersonalDiary2
{
    public partial class ModifyForm : Form
    {
        String title;
        String content;
        global g = new global();
        public ModifyForm(String title, String content)
        {
            InitializeComponent();
            this.title = title;
            this.content = content;
            textBox1.Text = title;
            textBox2.Text = content;
        }


        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void saveAsDocumentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Filter = "Diary Document(*.diary)|*.diary|Text Document(*.txt)|*.txt|All Files(*.*)|*.*";
            saveFileDialog1.OverwritePrompt = true;
            saveFileDialog1.Title = "Save as Text Document...";
            saveFileDialog1.FileName = textBox1.Text;
            StreamWriter sw = null;
            try
            {
                if(saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    sw = File.CreateText(saveFileDialog1.FileName);
                    sw.Write(textBox2.Text);
                    sw.Flush();
                    sw.Close(); 
                }
            }catch(Exception ex)
            {
                g.errormessage(ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                DiaryDTO diarydto = new DiaryDTO(title, textBox2.Text, null, DateTime.Now.ToString());
                DiaryDAO diarydao = new DiaryDAO(g.address, g.port, g.sid, g.id, g.pw);
                int result = diarydao.UpdateDiary(diarydto);
                if(result == 1)
                {
                    g.informationmessage("Successfully modified.");
                    this.Hide();
                }
                else
                {
                    g.errormessage("Unknown Error Message");
                    this.Hide();
                }
            }
            catch(Exception ex)
            {
                g.errormessage(ex.Message);
            }
        }

        private void aboutPersonalDiaryAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutForm af = new AboutForm();
            af.Show();
        }

        private void exitXToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            try
            {
                openFileDialog1.Filter = "Text Document(*.txt)|*.txt|Diary Document(*.diary)|*.diary|All Files(*.*)|*.*";
                openFileDialog1.Title = "Open Text Document";
                openFileDialog1.FileName = "";
                StreamReader sr = null;
                if(openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    String[] newfilenamearr = openFileDialog1.SafeFileName.Split('.'); //filename.extension 
                    String newfilename = newfilenamearr[0]; //filename
                    sr = new StreamReader(openFileDialog1.FileName);

                    if (radioButton1.Checked)
                    {
                        sr = new StreamReader(openFileDialog1.FileName, Encoding.UTF8);
                    }
                    else
                    {
                        sr = new StreamReader(openFileDialog1.FileName, Encoding.Default);
                    }
                    textBox1.Text = newfilename; //title 
                    textBox2.Text = sr.ReadToEnd(); //content
                    sr.Close();
                }
            }
            catch(Exception ex)
            {
                g.errormessage(ex.Message);
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
