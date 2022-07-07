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
    public partial class DetailForm : Form
    {
        String title;
        String id;
        global g = new global();
        
        public DetailForm(String title, String id)
        {
            InitializeComponent();
            this.title = title;
            this.id = id;
            searchDetailDiary();
        }

        private void searchDetailDiary()
        {
            try
            {
                textBox1.Text = title;
                DiaryDAO diarydao = new DiaryDAO(g.address, g.port, g.sid, g.id, g.pw);
                SortedList<String, String> diarylist = diarydao.getDiaryListByTitle(title);
                textBox2.Text = diarylist["context"];
                textBox3.Text = diarylist["savedate"];
                textBox4.Text = diarylist["modifydate"];
            }catch(Exception ex)
            {
                g.errormessage(ex.Message);
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide(); 
        }

        private void exitXToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void saveAsTextDocumentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Filter = "Diary Document(*.diary)|*.diary|Text Document(*.txt)|*.txt|All Files(*.*)|*.*";
            saveFileDialog1.Title = "Save as Text Document";
            saveFileDialog1.OverwritePrompt = true;
            saveFileDialog1.FileName = textBox1.Text;
            StreamWriter sw = null;
            if(saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    sw = File.CreateText(saveFileDialog1.FileName);
                    sw.Write(textBox2.Text);
                    sw.Flush();
                    sw.Close();
                }catch(Exception ex)
                {
                    g.errormessage(ex.Message);
                }
            }
        }


        private void aboutPersonalDiaryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutForm af = new AboutForm();
            af.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ModifyForm mf = new ModifyForm(title, textBox2.Text);
            mf.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            try
            {
                DiaryDAO diarydao = new DiaryDAO(g.address, g.port, g.sid, g.id, g.pw);
                int result = diarydao.DeleteDiary(title);
                if (result == 0)
                {
                    g.errormessage("Unknown Error Message");
                }
                else
                {
                    g.informationmessage("Successfully Deleted");
                    this.Hide();
                }
            }
            catch (Exception ex)
            {
                g.errormessage(ex.Message);
            }
        }
    }
}
