using System;
using System.Collections.Generic;
using System.Text;
using Common.DTO;

namespace Common.DataAccess
{
    interface IBookDataAccess
    {
        void InsertBook(BookDTO book);

        bool RemoveBook(BookDTO bookDto);

        BookDTO UpdateBook(BookDTO bookDto);

        void WriteFile();
    }
}
