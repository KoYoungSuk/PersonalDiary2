using Oracle.ManagedDataAccess.Client;
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
    public partial class LoginForm : Form
    {
        global g = new global();
        OracleConnection conn = null; 
        public LoginForm()
        {
            InitializeComponent();
        }

        private void goDiary()
        {
            //데이터베이스 연결 정보 가져오기 
            String fulladdress = textBox3.Text;
            String address = fulladdress.Split(':')[0];
            String sidandport = fulladdress.Split(':')[1];
            String port = sidandport.Split('/')[0];
            String sid = sidandport.Split('/')[1];
            String id = textBox1.Text;
            String password = textBox2.Text;
            Boolean check = false;

            try
            {
                //연결 정보 스트링에 집어넣기 
                String connstr = g.connectionString(address, port, sid, id, password);
                conn = new OracleConnection(connstr);
                conn.Open();
                DiaryDAO diarydao = new DiaryDAO(conn);
                Boolean existstatus = diarydao.Tableexists();

                if (!existstatus) //테이블 존재 유무 검사: 존재하지 않으면 테이블 새로 생성, 
                {
                    DialogResult dr = MessageBox.Show("Table not existed, Do you want to create it?", "PersonalDiary", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                    if (dr == DialogResult.OK)
                    {
                        int result = diarydao.createTable();
                        if (result == 1)
                        {
                            check = true;
                        }
                        else
                        {
                            g.errormessage("Unknown Error");
                        }
                    }
                    else
                    {
                        g.errormessage("You must need create to Table");
                    }
                }
                else 
                {
                    check = true; 
                }
            }
            catch (Exception ex)
            {
                g.errormessage(ex.Message);
            }

            if (check) //테이블이 이미 존재하거나 새로 생성했으면 일기장 화면으로 이동함. 
            {
                Form1 frm = new Form1(id, false, conn);
                this.Hide();
                frm.Show();
            }
            else
            {
                g.errormessage("Login Error, Password is not Confirmed and This is Administrator Only.");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            goDiary();
        }

        private void LoginForm_Load(object sender, EventArgs e) {}

        private void text_KeyDown(object sender, KeyEventArgs e)
        {
            //비밀번호 텍스트 상자에서 엔터키를 누르면 일기장 화면으로 이동 
            if(e.KeyCode == Keys.Enter)
            {
                goDiary();
            }
        }

        private void LoginForm_FormClisoing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
