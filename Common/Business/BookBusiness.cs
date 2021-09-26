using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using AutoMapper;
using Common.DataAccess;
using Common.DTO;
using Common.Entity;
using Ninject;

namespace Common.Business
{
    public class BookBusiness : IBookBusiness
    {
        private IBookDataAccess _bookDataAccess;
        public IMapper _bookMapper;
        public void InputDataFileFile()
        {
            _bookDataAccess.InputDataFileFile();
        }
        public BookBusiness(IBookDataAccess bookDataAccess, IMapper mapper)
        {
            _bookDataAccess = bookDataAccess;
            _bookMapper = mapper;
        }

        public BookEntity GetOne(int id)
        {
            return _bookMapper.Map<BookDTO, BookEntity>(_bookDataAccess.GetOne(id));
        }

        public List<BookEntity> GetAll()
        {
            var listBook = _bookDataAccess.GetAll();
            var books = _bookMapper.Map<List<BookDTO>, List<BookEntity>>(listBook);
            return books;
        }

        public bool InsertBook(BookDTO book)
        {
            _bookDataAccess.InsertBook(book);
            return true;
        }

        public bool RemoveBook(BookDTO bookDto)
        {
            return _bookDataAccess.RemoveBook(bookDto);
        }

        public BookEntity UpdateBook(BookDTO bookDto)
        {
            return _bookMapper.Map<BookDTO, BookEntity>(_bookDataAccess.UpdateBook(bookDto));
        }

        public void WriteFile()
        {
            _bookDataAccess.WriteFile();
        }
    }
}
