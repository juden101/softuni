using News.Data;
using News.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Infrastructure;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace News.GUIApplication
{
    public partial class EditNews : Form
    {
        private NewsContext newsContext;
        private News.Models.News firstNews;

        public EditNews()
        {
            InitializeComponent();

            this.newsContext = new NewsContext();
            this.firstNews = this.newsContext.News.OrderBy(n => n.Id).First();

            richTextBox1.Text = this.firstNews.Content;
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (var dbContextTransaction = this.newsContext.Database.BeginTransaction())
            {
                try
                {
                    var input = richTextBox1.Text;

                    this.firstNews.Content = input;
                    this.newsContext.SaveChanges();
                    dbContextTransaction.Commit();

                    this.Hide();
                    Success successScreen = new Success();
                    successScreen.Show();
                }
                catch (DbUpdateConcurrencyException ex)
                {
                    this.Hide();
                    Error errorScreen = new Error();
                    errorScreen.Show();
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            EditNews mainScreen = new EditNews();
            mainScreen.Show();
        }
    }
}