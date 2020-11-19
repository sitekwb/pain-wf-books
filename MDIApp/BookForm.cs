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
    public partial class BookForm : Form
    {
        private Book book;
        private List<Book> books;
        

        public string BookTitle
        {
            get { return titleTextBox.Text; }
        }

        public string BookAuthor
        {
            get { return authorTextBox.Text; }
        }


        public DateTime BookPubDate
        {
            get { return pubDateTimePicker.Value; }
        }

        public Book.CategoryEnum BookCategory
        {
            get { return categoryControl1.Category; }
        }

        public BookForm(Book book, List<Book> books)
        {
            InitializeComponent();
            this.AcceptButton = okButton;
            this.CancelButton = cancelButton;
            this.book = book;
            this.books = books;
            categoryControl1.UpdateCategoryEvent += CategoryControl1_UpdateCategoryEvent;
        }

        public void CategoryControl1_UpdateCategoryEvent(Book.CategoryEnum category)
        {
            categoryLabel.Text = Book.CategoryToString[category];
        }

        private void StudentForm_Load(object sender, EventArgs e)
        {
            if (book != null)
            {
                titleTextBox.Text = book.Title.ToString();
                authorTextBox.Text = book.Author.ToString();
                pubDateTimePicker.Value = book.PubDate;
                categoryControl1.Category = book.Category;
            }
            else
            {
                pubDateTimePicker.Value = new DateTime(2020, 11, 20);
                categoryControl1.Category = Book.CategoryEnum.criminal;
            }
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            if (ValidateChildren())
                DialogResult = DialogResult.OK;
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void AuthorTextBox_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                string author = authorTextBox.Text.ToString();
                string title = titleTextBox.Text.ToString();

                if (author.Length == 0)
                {
                    throw new Exception("Pole autor nie może być puste.");
                }
                foreach (Book b in books)
                    if (b.Author == author && b.Title == title && !ReferenceEquals(b, book))
                        throw new Exception( "Book already exists." );
            }
            catch( Exception exception )
            {
                e.Cancel = true;
                errorProvider.SetError(authorTextBox, exception.Message);
            }
            
        }

        private void TitleTextBox_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                string author = authorTextBox.Text.ToString();
                string title = titleTextBox.Text.ToString();

                if(title.Length == 0)
                {
                    throw new Exception("Tytuł nie może być pusty.");
                }

                foreach (Book b in books)
                    if (b.Author == author && b.Title == title && !ReferenceEquals(b, book))
                        throw new Exception("Book already exists.");
            }
            catch (Exception exception)
            {
                e.Cancel = true;
                errorProvider.SetError(titleTextBox, exception.Message);
            }

        }


        private void AuthorTextBox_Validated(object sender, EventArgs e)
        {
            errorProvider.SetError(authorTextBox, "");
        }

        private void TitleTextBox_Validated(object sender, EventArgs e)
        {
            errorProvider.SetError(titleTextBox, "");
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }


        /*private void setImageByBookCategory(Book.CategoryEnum category)
        {
            switch (category)
            {
                case Book.CategoryEnum.criminal:
                    this.categoryPictureBox.Image = global::MDIApp.Properties.Resources.criminal;
                    break;
                case Book.CategoryEnum.poetry:
                    this.categoryPictureBox.Image = global::MDIApp.Properties.Resources.poetry;
                    break;
                case Book.CategoryEnum.fantasy:
                default:
                    this.categoryPictureBox.Image = global::MDIApp.Properties.Resources.fantasy;
                    break;
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            book.Category = (Book.CategoryEnum)(((int)book.Category + 1) % 3); // next category
            setImageByBookCategory(book.Category);
        }*/

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}
