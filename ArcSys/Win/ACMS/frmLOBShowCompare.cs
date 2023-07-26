using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CS2010.ArcSys.Win
{
    public partial class frmLOBShowCompare : Form
    {
        public frmLOBShowCompare()
        {
            InitializeComponent();
        }

        public void ShowOpen(string acms, string load_list)
        {
            txtAcms.Text = acms;
            txtLoadList.Text = load_list;
            this.ShowDialog();
        }

        private void bntOK_Click(object sender, EventArgs e)
        {
            this.Close();
        }


    }
}
