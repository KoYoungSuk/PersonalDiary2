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
    public partial class WriteForm : Form
    {
        String id;
        global g = new global();
        public WriteForm(String id)
        {
            InitializeComponent();
            this.id = id;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void openTextDocumentOToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                openFileDialog1.Filter = "Diary Document(*.diary)|*.diary|Text Document(*.txt)|*.txt|All Files(*.*)|*.*";
                openFileDialog1.Title = "Open Text Document";
                openFileDialog1.FileName = "";
                StreamReader sr = null;
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    String[] newfilenamearr = openFileDialog1.SafeFileName.Split('.');
                    String newfilename = newfilenamearr[0];
                    if (radioButton1.Checked)
                    {
                        sr = new StreamReader(openFileDialog1.FileName, Encoding.UTF8);
                    }
                    else
                    {
                        sr = new StreamReader(openFileDialog1.FileName, Encoding.Default);
                    }
                    textBox1.Text = newfilename;
                    textBox2.Text = sr.ReadToEnd();
                    sr.Close();
                }
            }
            catch(Exception ex)
            {
                g.errormessage(ex.Message);
            }
        }

        private void exitXToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        
        private void button1_Click(object sender, EventArgs e)
        {
            String title = textBox1.Text;
            String content = textBox2.Text;
            try
            {
                DiaryDTO diarydto = new DiaryDTO(title, content, DateTime.Now.ToString(), null);
                DiaryDAO diarydao = new DiaryDAO(g.address, g.port, g.sid, g.id, g.pw);
                int result = diarydao.insertDiary(diarydto);
                if(result == 0)
                {
                    g.errormessage("Unknown Error Message");
                }
                else
                {
                    g.informationmessage("Successfully Written");
                    this.Hide();
                }
            }
            catch (Exception ex)
            {
                g.errormessage(ex.Message);
            }
        }

        private void saveAsTextDocumentSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                saveFileDialog1.Filter = "Diary Document(*.diary)|*.diary|Text Document(*.txt)|*.txt|All Files(*.*)|*.*";
                saveFileDialog1.Title = "Save as Text Document...";
                saveFileDialog1.OverwritePrompt = true;
                saveFileDialog1.FileName = textBox1.Text;
                StreamWriter sw = null;
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

        private void aboutPersonalDiaryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutForm af = new AboutForm();
            af.Show();
        }

        private void WriteForm_Load(object sender, EventArgs e){ }
    }
}
