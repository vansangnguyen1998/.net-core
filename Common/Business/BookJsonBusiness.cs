using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Common.DataAccess;
using Common.DTO;

namespace Common.Business
{
    public class BookJsonBusiness
    {
        private readonly BookJsonDataAccess _bookDataAccess;

        public BookJsonBusiness(BookJsonDataAccess bookDataAccess)
        {
            _bookDataAccess = bookDataAccess;
        }

        public void InsertBook(BookDTO book)
        {
            _bookDataAccess.InsertBook(book);
        }

        public bool RemoveBook(BookDTO bookDto)
        {
            return _bookDataAccess.RemoveBook(bookDto);
        }

        public BookDTO UpdateBook(BookDTO bookDto)
        {
            return _bookDataAccess.UpdateBook(bookDto);
        }

        public void WriteFile()
        {
            _bookDataAccess.WriteFile();
        }
    }
}
