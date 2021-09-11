using Common;
using Common.Business;
using Common.Constants;
using Common.DTO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ninject;
using NSubstitute;
using NUnit.Framework;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace Test
{
    [TestFixture]
    public class UnitTest1
    {
        [OneTimeSetUp]
        public void Init()
        {
            IoC.Initialize(new StandardKernel(new NinjectSettings { LoadExtensions = true }),
                new ServiceBindingModule());
            IoC.Get<IBookBusiness>(Constants.MODE[1]).InputDataFileFile();
        }

        [TestMethod]
        public void TestLoadData()
        {
            var list = IoC.Get<IBookBusiness>(Constants.MODE[1]).GetAll();
            Assert.AreEqual(list.Count, 1);
        }

        [TestMethod]
        public void TestInsertData()
        {
            var insert = Substitute.For<IBookBusiness>();
            insert.InsertBook(new BookDTO()).Returns(true);
            
            Assert.AreEqual(insert.InsertBook(new BookDTO()), true);
        }
    }
}
