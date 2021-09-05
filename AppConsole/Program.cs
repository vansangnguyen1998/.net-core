using System;
using System.Reflection.Metadata;
using Common;
using Common.Business;
using Common.Constants;
using Common.DataAccess;
using Common.DTO;
using Ninject;

namespace AppConsole
{
    class Program
    {
        private static int s_index_mode = 0;
        private static void MainMenu()
        {
            Console.WriteLine("-------------------=-------------------");

            Console.WriteLine("Input 1 to Insert");
            Console.WriteLine("Input 2 to update");
            Console.WriteLine("Input 3 to remove");
            Console.WriteLine("Input 4 switch to other type");

            Console.WriteLine("-------------------=-------------------");
        }

        private static void InsertBook()
        {
            BookDTO book = new BookDTO();
            Console.WriteLine("Input id");
            if (int.TryParse(Console.ReadLine(), out int bookId))
            {
                book.Id = bookId;
            }
            Console.WriteLine("Input name");
            book.Name = Console.ReadLine();
            Console.WriteLine("Input price");
            if (int.TryParse(Console.ReadLine(), out int bookPrice))
            {
                book.Price = bookPrice;
            }
            Console.WriteLine("Input stock");
            if (int.TryParse(Console.ReadLine(), out int bookStock))
            {
                book.Stock = bookStock;
            }

            var business = IoC.Get<IBookBusiness>(Constants.MODE[s_index_mode]);
            business.InsertBook(book);
        }

        private static void RemoveBook()
        {
            BookDTO book = new BookDTO();
            Console.WriteLine("Input id");
            if (int.TryParse(Console.ReadLine(), out int bookId))
            {
                book.Id = bookId;
            }
            
            var business = IoC.Get<IBookBusiness>(Constants.MODE[s_index_mode]);
            business.RemoveBook(book);
        }

        private static void UpdateBook()
        {
            BookDTO book = new BookDTO();
            Console.WriteLine("Input id book want to update");
            if (int.TryParse(Console.ReadLine(), out int bookId))
            {
                book.Id = bookId;
            }

            var business = IoC.Get<IBookBusiness>(Constants.MODE[s_index_mode]);
            var oldBook =  business.GetOne(book.Id);
            if (oldBook != null)
            {
                Console.WriteLine($"Old value is name={oldBook.Name}, price={oldBook.Price}, stock={oldBook.Stock}");
                Console.WriteLine("Input new name");
                book.Name = Console.ReadLine();
                Console.WriteLine("Input new price");
                if (int.TryParse(Console.ReadLine(), out int bookPrice))
                {
                    book.Price = bookPrice;
                }
                Console.WriteLine("Input new stock");
                if (int.TryParse(Console.ReadLine(), out int bookStock))
                {
                    book.Stock = bookStock;
                }

                business.UpdateBook(book);
            }
            else
            {
                Console.WriteLine("Book not exists in systems");
            }
        }


        private static void SwitchOption(string option)
        {
            switch (option)
            {
                case Constants.INSERT_BOOK:
                    InsertBook();
                    break;
                case Constants.UPDATE_BOOK:
                    UpdateBook();
                    break;
                case Constants.REMOVE_BOOK:
                    RemoveBook();
                    break;
                case Constants.SWITCH_MODE_BOOK:
                    s_index_mode = 1 - s_index_mode; //Constants.MODE[1 - s_index_mode];
                    break;
            }
        }

        static void Main(string[] args)
        {
            IoC.Initialize(new StandardKernel(new NinjectSettings { LoadExtensions = true }),
                new ServiceBindingModule());
            var d = IoC.Get<IBookBusiness>(Constants.MODE[s_index_mode]);
            d.InputDataFileFile();
            do
            {
                MainMenu();
                var option = Console.ReadLine();
                if (option == "0")
                {
                    break;
                }

                SwitchOption(option);

            } while (true);
            var d1 = IoC.Get<IBookBusiness>(Constants.MODE[s_index_mode]);
            Console.WriteLine("Hello World!");
            d1.WriteFile();
        }
    }
}
