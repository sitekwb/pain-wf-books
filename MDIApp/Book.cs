using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MDIApp
{
    public class Book
    {
        public string Title
        {
            get;
            set;
        }
        public string Author
        {
            get;
            set;
        }

        public DateTime PubDate
        {
            get;
            set;
        }
        public string Category
        {
            get;
            set;
        }

        public Book( string title, string author, DateTime pubDate, string category )
        {
            Title = title;
            Author = author;
            Category = category;
            PubDate = pubDate;
        }
    }
}
