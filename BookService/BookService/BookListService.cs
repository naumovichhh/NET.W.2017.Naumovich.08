using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace Day8
{
    /// <summary>
    /// Allow to work with a bunch of books. Providing functionality of
    /// sorting books by tag, finding books by tag, uploading and downloading from
    /// disk storage
    /// </summary>
    public class BookListService
    {
        public void AddBook(Book book)
        {
            if (books.Contains(book))
                throw new Exception("This book is present in list");
            books.Add(book);
        }

        public void RemoveBook(Book book)
        {
            if (!books.Contains(book))
                throw new Exception("This book is not present in list");
            books.Remove(book);
        }

        /// <summary>
        /// Downloading from storage without preliminary cleaning
        /// </summary>
        /// <param name="name">Storage file name</param>
        public void AppendLoad(string name)
        {
            using (var reader = new BinaryReader(File.OpenRead(name)))
            {
                int isbnEANPref, isbnRegGroupNum, isbnRegistrantNum, isbnPublicationNum,
                    isbnControlDigit, year, size, price;
                string title, author, publishing;
                try
                {
                    while (true)
                    {
                        isbnEANPref = reader.ReadInt32();
                        isbnRegGroupNum = reader.ReadInt32();
                        isbnRegistrantNum = reader.ReadInt32();
                        isbnPublicationNum = reader.ReadInt32();
                        isbnControlDigit = reader.ReadInt32();
                        title = reader.ReadString();
                        author = reader.ReadString();
                        publishing = reader.ReadString();
                        year = reader.ReadInt32();
                        size = reader.ReadInt32();
                        price = reader.ReadInt32();
                        books.Add(new Book(
                            new Book.ISBN(isbnEANPref, isbnRegGroupNum, isbnRegistrantNum,
                                          isbnPublicationNum, isbnControlDigit),
                            title, author, publishing, year, size, price));
                    }
                }
                catch
                {

                }
            }
        }

        /// <summary>
        /// Downloading from storage
        /// </summary>
        /// <param name="name">Storage file name</param>
        public void Load(string name)
        {
            if (books.Count != 0)
                books.Clear();
            AppendLoad(name);
        }

        /// <summary>
        /// Uploading to storage
        /// </summary>
        /// <param name="name">Storage file name</param>
        public void Store(string name)
        {
            using (var writer = new BinaryWriter(File.Open(name, FileMode.Create)))
            {
                foreach (Book book in books)
                {
                    writer.Write(book.Isbn.EANPref);
                    writer.Write(book.Isbn.RegGroupNum);
                    writer.Write(book.Isbn.RegistrantNum);
                    writer.Write(book.Isbn.PublicationNum);
                    writer.Write(book.Isbn.ControlDigit);
                    writer.Write(book.Title);
                    writer.Write(book.Author);
                    writer.Write(book.Publishing);
                    writer.Write(book.Year);
                    writer.Write(book.Size);
                    writer.Write(book.Price);
                }
            }
        }

        /// <summary>
        /// Finding first book with the similar value of tag, defined by finder
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="finder">Provider of finding</param>
        /// <param name="value">Value of tag</param>
        /// <returns></returns>
        public Book FindBookByTag<T>(IFinder<Book, T> finder, T value)
        {
            return finder.Find(books, value);
        }

        /// <summary>
        /// Sorting books by tag, defined in comparer
        /// </summary>
        /// <param name="comparer">Provider of comparing</param>
        public void SortBooksByTag(IComparer<Book> comparer)
        {
            for (int i = 1; i < books.Count; ++i)
            {
                int j = i - 1;
                while (comparer.Compare(books[j], books[i]) > 0)
                {
                    --j;
                    if (j == -1)
                        break;
                }
                Book temp = books[i];
                int k;
                for (k = i - 1; k >= j + 1; --k)
                {
                    books[k + 1] = books[k];
                }
                books[k + 1] = temp;
            }
        }

        public List<Book>.Enumerator GetEnumerator()
        {
            return books.GetEnumerator();
        }

        /*public Book this[int i]
        {
            get { return books[i]; }
            private set { books[i] = value; }
        }
        public int Length { get { return books.Count; } }*/

        List<Book> books = new List<Book>();
    }

    public interface IFinder<T1, T2>
    {
        T1 Find(IEnumerable<T1> list, T2 value);
    }
}
