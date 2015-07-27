using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace News.GUIApplication
{
    public partial class Error : Form
    {
        public Error()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            EditNews editNewsScreen = new EditNews();
            editNewsScreen.Show();
        }
    }
}
