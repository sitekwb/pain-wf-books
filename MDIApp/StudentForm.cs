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
    public partial class StudentForm : Form
    {
        private Book student;
        private List<Book> students;

        public string StudentName
        {
            get { return nameTextBox.Text; }
        }

        public long StudentIndex
        {
            get { return long.Parse( indexTextBox.Text ); }
        }

        public DateTime StudentBirthDay
        {
            get { return birthDayDateTimePicker.Value; }
        }

        public StudentForm(Book student, List<Book> students)
        {
            InitializeComponent();
            this.student = student;
            this.students = students;
        }

        private void StudentForm_Load(object sender, EventArgs e)
        {
            if (student != null)
            {
                nameTextBox.Text = student.Name;
                indexTextBox.Text = student.Index.ToString();
                birthDayDateTimePicker.Value = student.BirthDate;
            }
            else
            {
                nameTextBox.Text = "Jan";
                birthDayDateTimePicker.Value = new DateTime(1980, 1, 1);
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

        private void IndexTextBox_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                long index = long.Parse(indexTextBox.Text);
                foreach (Book s in students)
                    if (s.Index == index && !ReferenceEquals(s, student))
                        throw new Exception( "Student already exists." );
            }
            catch( Exception exception )
            {
                e.Cancel = true;
                errorProvider.SetError(indexTextBox, exception.Message);
            }
        }

        private void IndexTextBox_Validated(object sender, EventArgs e)
        {
            errorProvider.SetError(indexTextBox, "");
        }
    }
}
