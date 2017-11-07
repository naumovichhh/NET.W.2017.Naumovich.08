using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace Day8
{
    static class Program
    {
        static void Main(string[] args)
        {
            var bookListService = new BookListService();
            AddRandomGeneratedBook(bookListService);       //Добавляется книга с случайно сгенерированными параметрами
            StoreBooksList(bookListService, "storage");    //Запись в хранилище
            CreateAndAddBooks(bookListService);            //Добавляются 3 книги
            foreach (Book bk in bookListService)
                Console.WriteLine(bk);
            Console.WriteLine("\nЗагрузка из хранилища\n");
            LoadList(bookListService, "storage");          //Из хранилища загружается одна книга
            foreach (Book bk in bookListService)
                Console.WriteLine(bk);
            Console.WriteLine();
            CreateAndAddBooks(bookListService);            //Добавляются 3 книги
            AddRandomGeneratedBook(bookListService);       //Еще одна книга с случайными параметрами
            foreach (Book bk in bookListService)
                Console.WriteLine(bk);
            Console.WriteLine("\nСортировка по цене\n");
            bookListService.SortBooksByTag(new BookPriceComparer());  //Сортировка по цене
            foreach (Book bk in bookListService)
                Console.WriteLine(bk);
            Console.WriteLine("\nНахождение книги по автору Автор1\n");
            Console.WriteLine(bookListService.FindBookByTag(new BookAuthorFinder(), "Автор1")); //Нахождение книги по автору
            Console.ReadLine();
        }

        static void CreateAndAddBooks(BookListService bookListService)
        {
            bookListService.AddBook(new Book(
                new Book.ISBN(13, 23, 1, 1, 1), "Книга1",
                "Автор1", "Издательство", 2017, 44, 19));
            bookListService.AddBook(new Book(
                new Book.ISBN(13, 23, 1, 13, 1), "Книга2",
                "Автор1", "Издательство", 2001, 828, 20));
            bookListService.AddBook(new Book(
                new Book.ISBN(1323, 3, 21, 813, 9), "Book3",
                "Author2", "Publishing", 2010, 88, 4));
        }

        static void AddRandomGeneratedBook(BookListService bookListService)
        {
            Random generator = new Random();
            bookListService.AddBook(new Book(
                new Book.ISBN(generator.Next(1000), generator.Next(1000), generator.Next(1000),
                generator.Next(1000), generator.Next(1000)), "Book", "Author", "Publishing",
                2017, generator.Next(1, 1000), generator.Next(1, 100)));
        }

        static void StoreBooksList(BookListService bookListService, string file)
        {
            bookListService.Store(file);
        }

        static void AppendLoadList(BookListService bookListService, string file)
        {
            bookListService.AppendLoad(file);
        }

        static void LoadList(BookListService bookListService, string file)
        {
            bookListService.Load(file);
        }
    }
}
