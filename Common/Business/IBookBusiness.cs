using System;
using System.Collections.Generic;
using System.Text;
using Common.DTO;
using Common.Entity;

namespace Common.Business
{
    public interface IBookBusiness
    {

        BookEntity GetOne(int id);

        List<BookEntity> GetAll();

        void InputDataFileFile();

        bool InsertBook(BookDTO book);

        bool RemoveBook(BookDTO bookDto);

        BookEntity UpdateBook(BookDTO bookDto);

        void WriteFile();
    }
}
