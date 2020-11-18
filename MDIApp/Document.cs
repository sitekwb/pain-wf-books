using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MDIApp
{

/*    Dane utworu: tytuł, autor, data wydania, kategoria (poezja, fantastyka, kryminał),
• Filtrowanie według daty wydania(przed 2000r, po 2000r.),
• Kontrolka użytkownika określająca kategorię(dedykowany edytor dla właściwości
określającej kategorię).
*/
    public class Document
    {
        public List<Book> students = new List<Book>();

        public event Action<Book> AddStudentEvent;

        public void AddStudent( Book student )
        {
            students.Add(student);

            //if (AddStudentEvent != null)
            //    AddStudentEvent(student);

            //if ( AddStudentEvent != null)
            //    AddStudentEvent.Invoke(student);

            AddStudentEvent?.Invoke(student);
        }

        public void UpdateStudent(Book student)
        {
            throw new NotImplementedException();
        }
    }
}
