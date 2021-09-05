using System;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.Text;
using Common.Business;
using Common.DataAccess;
using Ninject.Modules;

namespace Common
{
    public class ServiceBindingModule : NinjectModule
    {
        public override void Load()
        {
            LoadService();
        }

        private void LoadService()
        {
            Bind<IBookBusiness>().To<BookBusiness>().InSingletonScope().Named("TXT");
            Bind<IBookBusiness>().To<BookBusiness>().InSingletonScope().Named("JSON");
            _ = Bind<IBookDataAccess>().To<BookTxtDataAccess>().WhenAnyAnchestorNamed("TXT").InSingletonScope();
            _ = Bind<IBookDataAccess>().To<BookJsonDataAccess>().WhenAnyAnchestorNamed("JSON").InSingletonScope();
        }
    }
}
