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
    public partial class StudentsForm : Form
    {
        private Document Document { get; set; }

        public StudentsForm( Document document )
        {
            InitializeComponent();
            Document = document;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            UpdateItems();
            Document.AddStudentEvent += Document_AddStudentEvent;
        }

        private void Document_AddStudentEvent(Book student)
        {
            ListViewItem item = new ListViewItem();
            item.Tag = student;
            UpdateItem(item);
            studentsListView.Items.Add(item);
        }

        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StudentForm studentForm = new StudentForm(null, Document.students);
            if( studentForm.ShowDialog() == DialogResult.OK)
            {
                Book newStudent = new Book(studentForm.StudentName, studentForm.StudentIndex, studentForm.StudentBirthDay);

                Document.AddStudent(newStudent);

                //ListViewItem item = new ListViewItem();
                //item.Tag = newStudent;
                //UpdateItem(item);
                //studentsListView.Items.Add(item);
            }
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if( studentsListView.SelectedItems.Count == 1)
            {
                Book student = (Book)studentsListView.SelectedItems[0].Tag;
                StudentForm studentForm = new StudentForm(student, Document.students);
                if (studentForm.ShowDialog() == DialogResult.OK)
                {
                    student.Name = studentForm.StudentName;
                    student.Index = studentForm.StudentIndex;
                    student.BirthDate = studentForm.StudentBirthDay;

                    Document.UpdateStudent(student);

                    //UpdateItem(studentsListView.SelectedItems[0]);
                }
            }
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void UpdateItem( ListViewItem item)
        {
            Book student = (Book)item.Tag;
            while (item.SubItems.Count < 3)
                item.SubItems.Add(new ListViewItem.ListViewSubItem());
            item.SubItems[0].Text = student.Index.ToString();
            item.SubItems[1].Text = student.Name;
            item.SubItems[2].Text = student.BirthDate.ToShortDateString();
        }

        private void UpdateItems()
        {
            studentsListView.Items.Clear();
            foreach( Book student in Document.students)
            {
                ListViewItem item = new ListViewItem();
                item.Tag = student;
                UpdateItem(item);
                studentsListView.Items.Add(item);
            }
        }

        private void StudentsForm_Activated(object sender, EventArgs e)
        {
            ToolStripManager.Merge(toolStrip1, ((MainForm)MdiParent).toolStrip1);
        }

        private void StudentsForm_Deactivate(object sender, EventArgs e)
        {
            ToolStripManager.RevertMerge(((MainForm)MdiParent).toolStrip1, toolStrip1);
        }
    }
}
