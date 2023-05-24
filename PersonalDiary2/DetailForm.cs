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
    //제목이 Null: 작성 모드
    //제목이 Null이 아님: 수정/읽기 모드(modify boolean값 파라미터로 구분) 
    public partial class DetailForm : Form
    {
        String title;
        String id;
        global g = new global();
        OracleConnection conn = null;
        
        public DetailForm(String title, Boolean modify, String id, OracleConnection conn)
        {
            InitializeComponent();
            this.conn = conn;
            if (title != null) // 제목이 존재함 -> 읽기&수정 모드 
            {
                this.title = title;
                this.id = id;
                searchDetailDiary(); //일기장 정보 불러오기 
                
            }
            else //제목이 존재하지 않음 -> 작성 모드 
            {
                textBox1.ReadOnly = false;
                textBox2.ReadOnly = false;
                button1.Text = "Write";
                button2.Enabled = false;
                radioButton1.Enabled = false;
                radioButton2.Enabled = false; 
            }

            if (modify) // 작성&수정 모드 
            {
                radioButton1.Checked = true;
                textBox1.ReadOnly = false;
                textBox2.ReadOnly = false;
                button1.Enabled = true;
                button2.Enabled = false; 
            }
            else //읽기 모드 
            {
                radioButton2.Checked = true;
                button1.Enabled = false;
                openTextDocumentOToolStripMenuItem.Enabled = false;
            }
        }

        private void searchDetailDiary()
        {
            try
            {
                textBox1.Text = title;
                DiaryDAO diarydao = new DiaryDAO(conn);
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
            this.Hide(); 
        }

        private void saveAsTextDocumentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Filter = "Text Document(*.txt)|*.txt|Diary Document(*.diary)|*.diary|All Files(*.*)|*.*";
            saveFileDialog1.Title = "Save as Text Document";
            saveFileDialog1.OverwritePrompt = true;
            saveFileDialog1.FileName = textBox1.Text;
            StreamWriter sw = null;
            if(saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    //sw = File.CreateText(saveFileDialog1.FileName);\
                    if (radioButton4.Checked) //UTF-8로 파일 저장 
                    {
                        sw = new StreamWriter(File.Open(saveFileDialog1.FileName, FileMode.Create), Encoding.UTF8);
                    }
                    else if (radioButton3.Checked) //ASCII로 파일 저장 
                    {
                        sw = new StreamWriter(File.Open(saveFileDialog1.FileName, FileMode.Create), Encoding.Default);
                    }
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
            //일기장 입력 정보 가져오기 
            String title = textBox1.Text;
            String content = textBox2.Text;

            try
            {
                DiaryDTO diarydto = null; 
                DiaryDAO diarydao = new DiaryDAO(conn);
                int result = 0; 
                if (button1.Text.Equals("Modify")) //수정 모드 
                {
                    diarydto = new DiaryDTO(title, content, null, DateTime.Now.ToString()); 
                    result = diarydao.UpdateDiary(diarydto);
                }
                else if(button1.Text.Equals("Write"))  //작성 모드 
                {
                    diarydto = new DiaryDTO(title, content, DateTime.Now.ToString(), null); 
                    result = diarydao.insertDiary(diarydto);
                }

                if (result == 0)
                {
                    g.errormessage("Unknown Error Message");
                }
                else
                {
                    String tempdir = "C:\\Temp\\PersonalDiary_Legacy_TempDoc"; //임시 파일저장경로

                    DirectoryInfo di = new DirectoryInfo(tempdir);


                    if(!di.Exists)
                    {
                        di.Create(); //경로가 존재하지 않으면 새로 생성 
                    }
                    String FileName = tempdir + "\\" + title + ".txt"; //경로명 + 파일이름  
                    String SafeFileName = title + ".txt";   //파일이름
                    if(!File.Exists(FileName))
                    {
                        //임시 파일 저장
                        StreamWriter sw = File.CreateText(FileName);
                        sw.Write(content);
                        sw.Flush();
                        sw.Close(); 
                    }

                    
                    //SFTP 서버에 기존 파일이 있다면 삭제(수정 모드에서만 사용)  
                    if(button1.Text.Equals("Modify"))
                    {
                        g.DeleteSFTP(SafeFileName);

                    }

                    //SFTP 파일 업로드 
                    g.UploadSFTP(FileName, SafeFileName);

                    GC.Collect();
                    GC.WaitForPendingFinalizers();
                    File.Delete(FileName); //임시 파일 삭제 

                    g.informationmessage("Successfully Written");

                    this.Hide();
                }
            }
            catch (Exception ex)
            {
                g.errormessage(ex.Message);
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            try
            {
                DiaryDAO diarydao = new DiaryDAO(conn);
                int result = diarydao.DeleteDiary(title);
                if (result == 0)
                {
                    g.errormessage("Unknown Error Message");
                }
                else
                {
                    g.DeleteSFTP(title + ".txt"); 
                   
                    g.informationmessage("Successfully Deleted");

                    this.Hide();
                }
            }
            catch (Exception ex)
            {
                g.errormessage(ex.Message);
            }
        }

        private void DetailForm_Load(object sender, EventArgs e)
        {

        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void openTextDocumentOToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                openFileDialog1.Filter = "Text Document(*.txt)|*.txt|Diary Document(*.diary)|*.diary|All Files(*.*)|*.*";
                openFileDialog1.Title = "Open Text Document";
                openFileDialog1.FileName = "";
                StreamReader sr = null;
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    String[] newfilenamearr = openFileDialog1.SafeFileName.Split('.');
                    String newfilename = newfilenamearr[0];
                    if (radioButton4.Checked) //UTF-8로 파일 열기 
                    {
                        sr = new StreamReader(openFileDialog1.FileName, Encoding.UTF8);
                    }
                    else if(radioButton3.Checked) //ASCII로 파일 열기 
                    {
                        sr = new StreamReader(openFileDialog1.FileName, Encoding.Default);
                    }
                    textBox1.Text = newfilename;
                    textBox2.Text = sr.ReadToEnd();
                    sr.Close();
                }
            }
            catch (Exception ex)
            {
                g.errormessage(ex.Message);
            }
        }

        #region["수정 모드로 전환"] 
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            textBox1.ReadOnly = false;
            textBox2.ReadOnly = false;
            openTextDocumentOToolStripMenuItem.Enabled = true; 
            button1.Enabled = true; 
            button2.Enabled = false; 
        }
        #endregion

        #region["읽기 모드로 전환"]  
        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            textBox1.ReadOnly = true;
            textBox2.ReadOnly = true;
            openTextDocumentOToolStripMenuItem.Enabled = false; 
            button1.Enabled = false; 
            button2.Enabled = true; 
        }
        #endregion

    }
}
