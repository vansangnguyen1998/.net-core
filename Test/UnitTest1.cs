using System;
using Common;
using Common.Business;
using Common.Constants;
using Common.DTO;
using Common.Entity;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ninject;
using NSubstitute;
using NUnit.Framework;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;
using FluentAssertions;

namespace Test
{
    [TestFixture]
    public class UnitTest1
    {
        private IBookBusiness _bookBusiness;
        [OneTimeSetUp]
        public void Init()
        {
            IoC.Initialize(new StandardKernel(new NinjectSettings { LoadExtensions = true }),
                new ServiceBindingModule());
            IoC.Get<IBookBusiness>(Constants.MODE[0]).InputDataFileFile();
            _bookBusiness = IoC.Get<IBookBusiness>(Constants.MODE[0]);
        }

        [TestMethod]
        public void TestLoadData()
        {
            var list = IoC.Get<IBookBusiness>(Constants.MODE[0]).GetAll();
            list.Should().HaveCount(1);
            Assert.AreEqual(list.Count, 1);
        }

        [TestMethod]
        public void TestInsertData()
        {
            var insert = Substitute.For<IBookBusiness>();
            insert.InsertBook(new BookDTO()).Returns(true);
            var response = insert.InsertBook(new BookDTO());
            response.Should().BeTrue();
        }

        [TestMethod]
        public void TestInsertErrorData()
        {
            var insert = Substitute.For<IBookBusiness>();
            insert.InsertBook(new BookDTO()).Returns(x => throw new Exception());
            var response = insert.InsertBook(new BookDTO());
            response.
        }

        [TestMethod]
        public void TestUpdateData()
        {
            var update = Substitute.For<IBookBusiness>();
            update.UpdateBook(default).ReturnsForAnyArgs(new BookEntity(){Id = 999, Name = "name updated", Price = 9999});
            var response = update.UpdateBook(new BookDTO());
            response.Id.Should().Be(999);
            response.Name.Should().Be("name updated");
            response.Price.Should().Be(9999);
        }
    }
}
