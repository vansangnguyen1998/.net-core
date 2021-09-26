using System;
using System.Collections.Generic;
using System.Text;
using Common.Business;
using Common.DataAccess;
using Common.DTO;
using Common.Entity;
using Ninject.Modules;
using NSubstitute;

namespace Test
{
    public class TestServiceBinding : NinjectModule
    {
        public override void Load()
        {
            Bind<IBookBusiness>().To<BookBusiness>();
            var mockBookstoreDataAccess = GetMockBookDataAccess();
            Bind<IBookDataAccess>().ToConstant(mockBookstoreDataAccess);
        }

        private IBookDataAccess GetMockBookDataAccess()
        {
            var listBook = new List<BookDTO>(){new BookDTO(){Id = 1}};
            var bookstoreDa = Substitute.For<IBookDataAccess>();

            bookstoreDa.GetAll().Returns(listBook);

            bookstoreDa.InsertBook(default);

            bookstoreDa.UpdateBook(default).ReturnsForAnyArgs(new BookDTO() { Id = 999, Name = "name updated", Price = 9999 });

            return bookstoreDa;
        }
    }
}
