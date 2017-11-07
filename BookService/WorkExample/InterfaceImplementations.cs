using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day8
{
    public class BookAuthorFinder : IFinder<Book, string>
    {
        public Book Find(IEnumerable<Book> coll, string author)
        {
            string strAuthor;
            try
            {
                strAuthor = author;
            }
            catch
            {
                throw new ArgumentException("Parameter must be string");
            }
            foreach (Book book in coll)
            {
                if (book.Author.Equals(strAuthor))
                    return book;
            }
            return null;
        }
    }

    public class BookPriceFinder : IFinder<Book, int>
    {
        public Book Find(IEnumerable<Book> coll, int price)
        {
            int intPrice;
            try
            {
                intPrice = price;
            }
            catch
            {
                throw new ArgumentException("Parameter must be int");
            }
            foreach (Book book in coll)
            {
                if (book.Price.Equals(intPrice))
                    return book;
            }
            return null;
        }
    }

    public class BookPriceComparer : IComparer<Book>
    {
        public int Compare(Book book1, Book book2)
        {
            return book1.Price.CompareTo(book2.Price);
        }
    }

    public class BookAuthorComparer : IComparer<Book>
    {
        public int Compare(Book book1, Book book2)
        {
            return book1.Author.CompareTo(book2.Author);
        }
    }
}
