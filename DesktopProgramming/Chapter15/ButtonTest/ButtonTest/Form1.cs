using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ButtonTest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void buttonEnglish_Click(object sender, EventArgs e)
        {
            this.Text = "Do you speak English?";
        }

        private void buttonDanish_Click(object sender, EventArgs e)
        {
            this.Text = "Taler du Dansk?";
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
