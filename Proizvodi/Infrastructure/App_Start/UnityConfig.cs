using BAL.Services;
using BAL.ViewModels;
using DAL.Models.Context;
using DAL.UoW;
using DALzaJSON.ApiClient;
using DALzaJSON.DTO;
using DALzaJSON.Services;
using System.Configuration;
using System.Data.Entity;
using System.Web.Mvc;
using Unity;
using Unity.Injection;
using Unity.Mvc5;

namespace Infrastructure
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();
            var jsonFilePath = ConfigurationManager.AppSettings["JsonFilePath"].ToString();
            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();
            container.RegisterType<DbContext, ProizvodiContext>();
            container.RegisterType<IUnitOfWork, UnitOfWork>();
            container.RegisterType<IProizvodiService, ProizvodiService>();
            container.RegisterType<IProizvodiServiceJson, ProizvodiServiceJson>();
            container.RegisterType<IJsonService<ProizvodDTO>, ProizvodiJsonService>(new InjectionConstructor(jsonFilePath));
            
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}