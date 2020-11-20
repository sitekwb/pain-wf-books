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
    public partial class BooksForm : Form
    {
        private Document Document { get; set; }

        public BooksForm( Document document )
        {
            InitializeComponent();
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_Closing);
            Document = document;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            UpdateItems();
            Document.AddBookEvent += Document_AddBookEvent;
            Document.UpdateBookEvent += Document_UpdateBookEvent;
            Document.DeleteBookEvent += Document_DeleteBookEvent;
            menuStrip1.Visible = false;
            ResizeColumns();
        }

        private void ResizeColumns()
        {
            ColumnHeaderAutoResizeStyle style = ColumnHeaderAutoResizeStyle.ColumnContent;
            if (booksListView.Items.Count == 0)
            {
                style = ColumnHeaderAutoResizeStyle.HeaderSize;
            }
            booksListView.AutoResizeColumns(style);
        }

        private void Form1_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if(Document.OpenFormsCount <= 1)
            {
                e.Cancel = true;
            }
            else
            {
                Document.OpenFormsCount -= 1;
            }
        }

        private void Document_AddBookEvent(Book book)
        {
            ListViewItem item = new ListViewItem();
            item.Tag = book;
            AddItem(item);
            booksListView.Items.Add(item);
            UpdateStatusStripValue();
        }

        private void Document_UpdateBookEvent(Book book)
        {
            foreach( ListViewItem item in booksListView.Items)
            {
                if(ReferenceEquals(((Book)item.Tag), book))
                {
                    UpdateItem(item);
                    break;
                }
            }
            // status update not needed - number of elements is the same
        }

        private void Document_DeleteBookEvent(Book book)
        {
            foreach (ListViewItem item in booksListView.Items)
            {
                if (ReferenceEquals(((Book)item.Tag), book))
                {
                    booksListView.Items.Remove(item);
                    break;
                }
            }
            UpdateStatusStripValue();
        }

        private void addBook_Click()
        {
            BookForm bookForm = new BookForm(null, Document.books);
            if (bookForm.ShowDialog() == DialogResult.OK)
            {
                Book newBook = new Book(bookForm.BookTitle, bookForm.BookAuthor, bookForm.BookPubDate, bookForm.BookCategory);

                Document.AddBook(newBook);
            }
        }

        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            addBook_Click();
        }

        private void editBook_Click()
        {
            if (booksListView.SelectedItems.Count == 1)
            {
                Book book = (Book)booksListView.SelectedItems[0].Tag;
                BookForm bookForm = new BookForm(book, Document.books);
                if (bookForm.ShowDialog() == DialogResult.OK)
                {
                    book.Title = bookForm.BookTitle;
                    book.Author = bookForm.BookAuthor;
                    book.PubDate = bookForm.BookPubDate;
                    book.Category = bookForm.BookCategory;

                    Document.UpdateBook(book);
                }
            }
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            editBook_Click();
        }

        private void deleteBook_Click()
        {
            if (booksListView.SelectedItems.Count == 1)
            {
                Book book = (Book)booksListView.SelectedItems[0].Tag;
                Document.DeleteBook(book);
            }
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            deleteBook_Click();
        }

        private bool filterIncludesInForm(DateTime date)
        {
            int newValue = filterComboBox.SelectedIndex;
            switch (newValue)
            {
                case 0: // < 2000
                    return date.Year < 2000;
                case 1: // >= 2000
                    return date.Year >= 2000;
                case 2: // ALL
                default:
                    return true;
            }

        }

        private void AddItem( ListViewItem item)
        {
            Book book = (Book)item.Tag;
            if (!filterIncludesInForm(book.PubDate))
            {
                return;
            }
            while (item.SubItems.Count < 4)
                item.SubItems.Add(new ListViewItem.ListViewSubItem());
            item.SubItems[0].Text = book.Title.ToString();
            item.SubItems[1].Text = book.Author.ToString();
            item.SubItems[2].Text = book.PubDate.ToShortDateString();
            item.SubItems[3].Text = Book.CategoryToString[book.Category];
        }

        private void UpdateItem(ListViewItem item)
        {
            Book book = (Book)item.Tag;
            if (!filterIncludesInForm(book.PubDate))
            {
                return;
            }
            item.SubItems[0].Text = book.Title.ToString();
            item.SubItems[1].Text = book.Author.ToString();
            item.SubItems[2].Text = book.PubDate.ToShortDateString();
            item.SubItems[3].Text = Book.CategoryToString[book.Category];
        }



        private void UpdateItems()
        {
            booksListView.Items.Clear();
            foreach( Book book in Document.books)
            {
                if (!filterIncludesInForm(book.PubDate))
                {
                    continue;
                }
                ListViewItem item = new ListViewItem();
                item.Tag = book;
                
                AddItem(item);
                booksListView.Items.Add(item);
            }
            UpdateStatusStripValue();
        }

        private void UpdateStatusStripValue()
        {
            toolStripStatusLabel1.Text = "Wyświetlono elementów: " + booksListView.Items.Count.ToString();
            ResizeColumns();
        }

        private void StudentsForm_Activated(object sender, EventArgs e)
        {
            ToolStripManager.Merge(toolStrip1, ((MainForm)MdiParent).toolStrip1);
            ToolStripManager.Merge(statusStrip1, ((MainForm)MdiParent).statusStrip1);
        }

        private void StudentsForm_Deactivate(object sender, EventArgs e)
        {
            ToolStripManager.RevertMerge(((MainForm)MdiParent).toolStrip1, toolStrip1);
            ToolStripManager.RevertMerge(((MainForm)MdiParent).statusStrip1, statusStrip1);

        }

        private void addToolStripButton_Click(object sender, EventArgs e)
        {
            addBook_Click();
        }

        
        private void editToolStripButton_Click(object sender, EventArgs e)
        {
            editBook_Click();
        }

        private void deleteToolStripButton_Click(object sender, EventArgs e)
        {
            deleteBook_Click();
        }

        private void edytujToolStripMenuItem_Click(object sender, EventArgs e)
        {
            editBook_Click();
        }

        private void usuńToolStripMenuItem_Click(object sender, EventArgs e)
        {
            deleteBook_Click();
        }
        
        private void FilterComboBox_Validated(object sender, EventArgs e)
        {
            UpdateItems();
        }
    }
}
