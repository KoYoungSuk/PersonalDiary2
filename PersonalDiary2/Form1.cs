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
using System.IO;
using System.Diagnostics;

namespace PersonalDiary2
{
    public partial class Form1 : Form
    {
        String id;
        global g = new global();
        OracleConnection conn = null; 
        public Form1(String id, Boolean desc, OracleConnection conn)
        {
            InitializeComponent();
            this.id = id;
            this.conn = conn; 
            label7.Text = g.checkOS(); 
            countList();
            selectDiary(false);
        }

        private void countList()
        {
            try
            {
                DiaryDAO diarydao = new DiaryDAO(conn);
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
                DiaryDAO diarydao = new DiaryDAO(conn);
                label3.Text = "STATUS: Successfully Connected at [ " + DateTime.Now + "] & Current User: " + id;
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
            DetailForm df = new DetailForm(title, false, id, conn); //상세정보 읽기 모드 
            df.Show();
        }
        private void button4_Click(object sender, EventArgs e)
        {
            if(conn != null)
            {
                conn.Close(); 
                conn = null; 
            }
            Application.Exit();
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            detailform();
        }


        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                String title = textBox1.Text;
                DialogResult dr = g.informationmessage("You will delete diary " + title + ". Continue?");

                if(dr == DialogResult.OK)
                {
                    DiaryDAO diarydao = new DiaryDAO(conn);

                    int result = diarydao.DeleteDiary(title);
                    if (result == 1)
                    {
                        g.DeleteSFTP(title + ".txt");
                        g.informationmessage("Successfully deleted.");
                        selectDiary(false);
                    }
                    else
                    {
                        g.errormessage("Unknown Error Message");
                    }
                }
                else
                {
                    g.informationmessage("Delete Cancelled."); 
                }
               
            }catch(Exception ex)
            {
                g.errormessage(ex.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DetailForm df = new DetailForm(null, true, id, conn); 
            df.Show();
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
            if(conn != null)
            {
                conn.Close();
                conn = null; 
            }
            if (File.Exists("sftp.txt"))
            {
                //SFTP 로그인 정보를 삭제할껀지 물어봄 
                DialogResult dr = g.informationmessage("Do you want to delete sftp setting?");
                if (dr == DialogResult.OK) //삭제한다고 하면 삭제함 
                {
                    GC.Collect();
                    GC.WaitForPendingFinalizers();
                    File.Delete("sftp.txt");
                    g.informationmessage("Successfully deleted.");
                }
            }
            Application.Exit();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(conn != null)
            {
                conn.Close();
                conn = null;
            }
            if (File.Exists("sftp.txt"))
            {
                //SFTP 로그인 정보를 삭제할껀지 물어봄 
                DialogResult dr = g.informationmessage("Do you want to delete sftp setting?");
                if (dr == DialogResult.OK) //삭제한다고 하면 삭제함 
                {
                    GC.Collect();
                    GC.WaitForPendingFinalizers();
                    File.Delete("sftp.txt");
                    g.informationmessage("Successfully deleted.");
                }
            }
            Application.Exit();
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                detailform();
            }
        }

        #region["내림차순으로 정렬"] 
        private void descendArrangementDToolStripMenuItem_Click(object sender, EventArgs e)
        {
            selectDiary(true);
        }
        #endregion

        #region["오름차순으로 정렬"] 
        private void ascendArrangementAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            selectDiary(false);
        }
        #endregion

        #region["한번 클릭할 때는 텍스트 상자에 제목을 출력한다."]
        private void DataGridView_Click(object sender, DataGridViewCellEventArgs e)
        {
             textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
        }
        #endregion

        #region["더블클릭할때는 그 제목에 맞는 상세 내용으로 넘어간다."] 
        private void DataGridView_DoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            detailform();
        }
        #endregion

        private void panel3_Paint(object sender, PaintEventArgs e) { }

        private void sFTPServerSettingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SFTPSettingForm ssf = new SFTPSettingForm();
            ssf.Show(); 
        }

        private void personalMemoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start(new ProcessStartInfo("https://home.yspersonal.com") { UseShellExecute = true });
        }

        private void naverBlogToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start(new ProcessStartInfo("https://blog.naver.com/vheh5678") { UseShellExecute = true });
        }
    }
}
