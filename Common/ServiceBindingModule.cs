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
            Bind<BookJsonBusiness>().To<BookJsonBusiness>().InSingletonScope();
            Bind<BookTxtBusiness>().To<BookTxtBusiness>().InSingletonScope();
            Bind<BookJsonDataAccess>().To<BookJsonDataAccess>().InSingletonScope();
            Bind<BookTxtDataAccess>().To<BookTxtDataAccess>().InSingletonScope();
        }
    }
}
