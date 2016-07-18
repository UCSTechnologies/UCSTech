using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Ninject;
using Moq;
using GFS.Domain.Abstract;
using GFS.Domain.Entities;
using GFS.Models;
using System.Configuration;
using GFS.Domain.Concrete;


namespace GFS.Infrastructure
{
    public class NinjectDependencyResolver : IDependencyResolver
    {
        private IKernel kernel;

        public NinjectDependencyResolver(IKernel kernelParam)
        {
            kernel = kernelParam;
            AddBindings();
        }

        public object GetService(Type serviceType)
        {
            return kernel.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return kernel.GetAll(serviceType);
        }

        private void AddBindings()
        {
            // put bindings here
            
                 kernel.Bind<IProductRepository>().To<GFSProductRepository>();
            EmailSettings emailSettings = new EmailSettings {
                WriteAsFile = bool.Parse(ConfigurationManager
                .AppSettings["Email.WriteAsFile"] ?? "false")
            };

            kernel.Bind<IFuneralFormProcessor>().To<EmailFuneralItemsProcessor>()
                .WithConstructorArgument("settings", emailSettings);
        }
    }
   
    
}