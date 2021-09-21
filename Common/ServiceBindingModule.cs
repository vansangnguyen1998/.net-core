using System;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.Text;
using Common.Business;
using Common.DataAccess;
using log4net;
using Ninject.Modules;

namespace Common
{
    public class ServiceBindingModule : NinjectModule
    {
        public override void Load()
        {
            LoadService();
            ConfigureLog4Net();
        }

        private void LoadService()
        {
            Bind<IBookBusiness>().To<BookBusiness>().InSingletonScope().Named("TXT");
            Bind<IBookBusiness>().To<BookBusiness>().InSingletonScope().Named("JSON");
            Bind<IBookDataAccess>().To<BookTxtDataAccess>().WhenAnyAncestorNamed("TXT").InSingletonScope();
            Bind<IBookDataAccess>().To<BookJsonDataAccess>().WhenAnyAncestorNamed("JSON").InSingletonScope();
        }
        private void ConfigureLog4Net()
        {
            log4net.Config.XmlConfigurator.Configure();

            var logger = LogManager.GetLogger("Log4net");
            Bind<ILog>().ToConstant(logger);
        }
    }
}
