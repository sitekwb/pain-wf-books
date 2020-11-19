using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MDIApp
{
    public partial class MainForm : Form
    {
        Document document = new Document();

        public MainForm()
        {
            InitializeComponent();
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_Closing);
            IsMdiContainer = true;
        }

        private void openBooksForm()
        {
            BooksForm booksForm = new BooksForm(document);
            booksForm.MdiParent = this;
            document.OpenFormsCount += 1;
            booksForm.Show();
        }

        private void newWindowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openBooksForm();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            openBooksForm();
        }
        
        private void statusStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void Form1_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = false;
        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
    }
}
