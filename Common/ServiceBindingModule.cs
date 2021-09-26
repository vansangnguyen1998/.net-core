using System;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.Text;
using AutoMapper;
using Common.Business;
using Common.DataAccess;
using Common.DTO;
using Common.Entity;
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
            ConfigureAutomapper();
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

        private void ConfigureAutomapper()
        {
            var mapperConfiguration = new MapperConfiguration(cfg => cfg.CreateMap<BookDTO, BookEntity>()
                .ForMember(dest => dest.Type,
                    opt => opt.MapFrom(src => GetTypeBook(src.Price)))
                .ReverseMap());

            Bind<IMapper>().ToConstructor(c => new AutoMapper.Mapper(mapperConfiguration)).InSingletonScope();
        }

        private string GetTypeBook(int price)
        {
            if (price <= 100)
            {
                return "Cheap";
            }

            if (price >= 1000)
            {
                return "Expensive";
            }

            return "Normal";
        }
    }
}
