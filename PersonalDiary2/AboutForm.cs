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
    public partial class AboutForm : Form
    {
        global g = new global();
        public AboutForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            g.informationmessage(g.checkOS());
        }

        private void AboutForm_Load(object sender, EventArgs e)
        {

        }
    }
}
