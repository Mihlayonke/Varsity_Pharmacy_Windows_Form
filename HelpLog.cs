using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Varsity_Phamarcy
{
    public partial class HelpLog : Form
    {
        public HelpLog()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LOGIN log = new LOGIN();
            this.Hide();
            log.Show();
        }
    }
}
