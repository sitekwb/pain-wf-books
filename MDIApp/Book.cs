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
        public enum CategoryEnum : int
        {
            criminal = 0,
            poetry = 1,
            fantasy = 2
        }

        public CategoryEnum Category {
            get;
            set;
        }

        public static Dictionary<CategoryEnum, string> CategoryToString = new Dictionary<CategoryEnum, string>();

        public Book( string title, string author, DateTime pubDate, CategoryEnum category )
        {
            Title = title;
            Author = author;
            Category = category;
            PubDate = pubDate;

            
        }
    }
}
