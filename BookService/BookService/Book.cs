using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace Day8
{
    public class Book : IEquatable<Book>, IComparable<Book>
    {
        public Book(ISBN isbn, string title, string author, string publishing, int year, 
            int size, int price)
        {
            Isbn = isbn;
            Title = title;
            Author = author;
            Publishing = publishing;
            Year = year;
            Size = size;
            Price = price;
        }

        bool IEquatable<Book>.Equals(Book other)
        {
            if (other == null)
                return false;
            if (other.Title.Equals(Title) && other.Author.Equals(Author) &&
                other.Author.Equals(Author) && other.Year.Equals(Year) &&
                other.Size.Equals(Size))
                return true;
            else
                return false;
        }

        int IComparable<Book>.CompareTo(Book other) => Size.CompareTo(other.Size);

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            builder.Append(Isbn.ToString());
            builder.Append(", ");
            builder.Append(Title);
            builder.Append(", ");
            builder.Append(Author);
            builder.Append(", ");
            builder.Append(Publishing);
            builder.Append(", ");
            builder.Append(Year);
            builder.Append("y");
            builder.Append(", ");
            builder.Append(Size);
            builder.Append("pp");
            builder.Append(", ");
            builder.Append(Price);
            builder.Append('$');
            return builder.ToString();
        }

        public override int GetHashCode()
        {
            return Title.GetHashCode() + Author.GetHashCode() + Publishing.GetHashCode() +
                Year.GetHashCode() + Size.GetHashCode();
        }

        public override bool Equals(object param)
        {
            Book otherBook = param as Book;
            if (otherBook == null)
                return false;
            if (otherBook.Title.Equals(Title) && otherBook.Author.Equals(Author) &&
                otherBook.Author.Equals(Author) && otherBook.Year.Equals(Year) &&
                otherBook.Size.Equals(Size))
                return true;
            else
                return false;
        }

        public ISBN Isbn { get; }
        public string Title { get; }
        public string Author { get; }
        public string Publishing { get; }
        public int Year { get; }
        public int Size { get; }
        public int Price { get; }

        public class ISBN
        {
            public ISBN(int EANPref, int regGroupNum, int registrantNum, int publicationNum,
                int controlDigit)
            {
                this.EANPref = EANPref;
                RegGroupNum = regGroupNum;
                RegistrantNum = registrantNum;
                PublicationNum = publicationNum;
                ControlDigit = controlDigit;
            }

            public int EANPref { get; }
            public int RegGroupNum { get; }
            public int RegistrantNum { get; }
            public int PublicationNum { get; }
            public int ControlDigit { get; }

            public override string ToString()
            {
                var builder = new StringBuilder();
                builder.Append(EANPref);
                builder.Append('-');
                builder.Append(RegGroupNum);
                builder.Append('-');
                builder.Append(RegistrantNum);
                builder.Append('-');
                builder.Append(PublicationNum);
                builder.Append('-');
                builder.Append(ControlDigit);
                return builder.ToString();
            }
        }
    }
}
