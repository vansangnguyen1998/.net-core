using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Common.DataAccess;
using Common.DTO;
using Ninject;

namespace Common.Business
{
    public class BookBusiness : IBookBusiness
    {
        private IBookDataAccess _bookDataAccess;

        public void InputDataFileFile()
        {
            _bookDataAccess.InputDataFileFile();
        }
        public BookBusiness(IBookDataAccess bookDataAccess)
        {
            _bookDataAccess = bookDataAccess;
        }

        public BookDTO GetOne(int id)
        {
            return _bookDataAccess.GetOne(id);
        }

        public List<BookDTO> GetAll()
        {
            return _bookDataAccess.GetAll();
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
