using System;
using System.Collections.Generic;
using System.Text;
using Common.DTO;

namespace Common.DataAccess
{
    public interface IBookDataAccess
    {
        void InputDataFileFile();

        BookDTO GetOne(int id);

        List<BookDTO> GetAll(); 

        bool InsertBook(BookDTO book);

        bool RemoveBook(BookDTO bookDto);

        BookDTO UpdateBook(BookDTO bookDto);

        void WriteFile();
    }
}
