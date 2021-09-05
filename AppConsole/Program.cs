using System;
using Common.DataAccess;
using Common.DTO;

namespace AppConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var d = new BookTxtDataAccess();
            d.RemoveBook(new BookDTO(){ Id = 1 });
            d.WriteFile();
        }
    }
}
