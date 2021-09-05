using System;
using System.Collections.Generic;
using System.Text;
using Common.DTO;

namespace Common.Business
{
    public interface IBookBusiness
    {

        BookDTO GetOne(int id);

        List<BookDTO> GetAll();

        void InputDataFileFile();

        void InsertBook(BookDTO book);

        bool RemoveBook(BookDTO bookDto);

        BookDTO UpdateBook(BookDTO bookDto);

        void WriteFile();
    }
}
