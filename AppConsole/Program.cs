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
            Console.WriteLine("Input 5 read all data");

            Console.WriteLine("-------------------=-------------------");
        }

        private static void InsertBook()
        {
            log.Info(nameof(InsertBook));

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
            if (business.InsertBook(book))
            {
                log.Info("Create new data " + book.ToString());
            }
            else
            {
                log.Error("Can't insert data " + book.ToString());
            }
            
        }

        private static void RemoveBook()
        {
            log.Info(nameof(RemoveBook));
            BookDTO book = new BookDTO();
            Console.WriteLine("Input id");
            if (int.TryParse(Console.ReadLine(), out int bookId))
            {
                book.Id = bookId;
            }

            var business = IoC.Get<IBookBusiness>(Constants.MODE[s_index_mode]);
            business.RemoveBook(book);
            log.Info("End " + nameof(RemoveBook));

        }

        private static void UpdateBook()
        {
            log.Info(nameof(UpdateBook));
            BookDTO book = new BookDTO();
            Console.WriteLine("Input id book want to update");
            if (int.TryParse(Console.ReadLine(), out int bookId))
            {
                book.Id = bookId;
            }

            var business = IoC.Get<IBookBusiness>(Constants.MODE[s_index_mode]);
            var oldBook = business.GetOne(book.Id);
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
                log.Info("Update success" + book.ToString());
            }
            else
            {
                Console.WriteLine("Book not exists in systems");
                log.Error("Can't update " + book.ToString());
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
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(nameof(Program));
        static void Main(string[] args)
        {
            IoC.Initialize(new StandardKernel(new NinjectSettings { LoadExtensions = true }),
                new ServiceBindingModule());
            log.Info("start application");
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
            d1.WriteFile();
            log.Info("end application");

        }
    }
}


//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace linq
//{
//    class Program
//    {
//        static void Main(string[] args)
//        {
//            //#region sqrNo
//            //var arr1 = new List<int>() { 3, 9, 2, 8, 6, 5 };
//            //var result = arr1.Where(a => a * a > 20).Select(x => new OutputLinq(x, x * x)).ToList();
//            //Console.WriteLine(result.ToString());
//            //#endregion

//            //#region Write a program to generate a Cartesian Product of three sets.

//            //char[] charset1 = { 'X', 'Y', 'Z' };
//            //int[] numset1 = { 1, 2, 3 };
//            //string[] colorset1 = { "Green", "Orange" };

//            //Console.Write("\nLINQ : Generate a cartesian product of three sets : ");
//            //Console.Write("\n----------------------------------------------------\n");

//            //var cartesianProduct = from letter in charset1
//            //                       from number in numset1
//            //                       from colour in colorset1
//            //                       select new { letter, number, colour };

//            //Console.Write("The Cartesian Product are : \n");
//            //foreach (var ProductList in cartesianProduct)
//            //{
//            //    Console.WriteLine(ProductList);
//            //}

//            //#endregion

//            //#region count times number

//            //arr1 = new List<int> { 5, 9, 1, 5, 5, 9 };
//            //Console.Write("\nLINQ : Display the number and frequency of number from given array : \n");

//            //var n = from x in arr1
//            //        group x by x into y
//            //        select y;
//            //Console.WriteLine("\nThe number and the Frequency are : \n");
//            //foreach (var arrNo in n)
//            //{
//            //    Console.WriteLine("Number " + arrNo.Key + " appears " + arrNo.Count() + " times");
//            //}
//            //Console.WriteLine("\n");

//            //#endregion

//        }
//    }

//    class OutputLinq
//    {
//        public int Number { get; set; }
//        public int SqrNo { get; set; }

//        public OutputLinq(int number, int sqrNo)
//        {
//            Number = number;
//            SqrNo = sqrNo;
//        }
//    }
//}
