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
        Boolean check = false;
        public LoginForm()
        {
            InitializeComponent();
        }

        private void goDiary()
        {
            String id = textBox1.Text;
            String password = textBox2.Text;
            Boolean check = false;
            try
            {
                DiaryDAO diarydao = new DiaryDAO(g.address, g.port, g.sid, g.id, g.pw);
                check = diarydao.Login(password);
                System.Diagnostics.Debug.WriteLine(password);
                System.Diagnostics.Debug.WriteLine(check);
                /*
                List<MemberDTO> memberlist = diarydao.getMemberList();
                if(memberlist != null)
                {
                    foreach (MemberDTO member in memberlist)
                    {
                        if (id.Equals("admin"))
                        {
                            if (BCrypt.Net.BCrypt.Verify(password, member.Password))
                            {
                                check = true;
                                break;
                            }
                        }
                    }
                }
                */
            }
            catch (Exception ex)
            {
                g.errormessage(ex.Message);
            }

            if (check)
            {
                Form1 frm = new Form1(id, false);
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
