using Oracle.ManagedDataAccess.Client;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PersonalDiary2
{
    public partial class Form1 : Form
    {
        String id;
        global g = new global();
        public Form1(String id, Boolean desc)
        {
            InitializeComponent();
            this.id = id;
            label7.Text = g.checkOS();
            countList();
            selectDiary(false);
        }

        private void countList()
        {
            try
            {
                DiaryDAO diarydao = new DiaryDAO(g.address, g.port, g.sid, g.id, g.pw);
                int diarynumber = diarydao.getDiaryCount();
                label2.Text = "DIARY NUMBER: " + diarynumber;
            }catch(Exception ex)
            {
                g.errormessage(ex.Message); 
            }
        }
        private void selectDiary(Boolean desc)
        {
            //listBox1.Items.Clear();
            dataGridView1.DataSource = null; 
            countList();
            try
            {
                DiaryDAO diarydao = new DiaryDAO(g.address, g.port, g.sid, g.id, g.pw);
                label3.Text = "STATUS: Successfully Connected at [ " + DateTime.Now + "] & Current User: " + id;
                //List<DiaryDTO> diarylist = diarydao.getDiaryList(desc);
                DataTable diarylist = diarydao.getDiaryList2(desc);

                diarylist.Columns.RemoveAt(1);
                dataGridView1.DataSource = diarylist;
                
            }
            catch (Exception ex)
            {
                label3.Text = "ERROR: " + ex.Message + " at [ " + DateTime.Now + "] ";
            }
        }

        private void detailform()
        {
            String title = textBox1.Text;
            DetailForm df = new DetailForm(title, id); 
            df.Show();
        }
        private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            detailform();
        }

        /*
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                textBox1.Text = listBox1.SelectedItem.ToString();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        */

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                DiaryDAO diarydao = new DiaryDAO(g.address, g.port, g.sid, g.id, g.pw);
                String title = textBox1.Text;
                int result = diarydao.DeleteDiary(title);
                if(result == 1)
                {
                    g.informationmessage("Successfully deleted.");
                    selectDiary(false);
                }
                else
                {
                    g.errormessage("Unknown Error Message");
                }
            }catch(Exception ex)
            {
                g.errormessage(ex.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            WriteForm wf = new WriteForm(id);
            wf.Show();
        }

        private void Form1_Load(object sender, EventArgs e) { }

        private void button5_Click(object sender, EventArgs e)
        {
            selectDiary(false);
        }

        private void aboutAToolStripMenuItem_Click(object sender, EventArgs e){  }

        private void aboutPersonalDiaryAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutForm af = new AboutForm();
            af.Show();
        }

        private void exitXToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                detailform();
            }
        }

        private void descendArrangementDToolStripMenuItem_Click(object sender, EventArgs e)
        {
            selectDiary(true);
        }

        private void ascendArrangementAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            selectDiary(false);
        }

        private void DataGridView_Click(object sender, DataGridViewCellEventArgs e)
        {
             textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
        }

        private void DataGridView_DoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            detailform();
        }
    }
}
