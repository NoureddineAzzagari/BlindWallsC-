using Domain.Abstract;
using Domain.Concrete;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BlindWalls.Infrastructure
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
            kernel.Bind<IArtistRepository>().To<EFArtistRepository>();
            kernel.Bind<IMuralRepository>().To<EFMuralRepository>();
            kernel.Bind<IRoleRepository>().To<EFRoleRepository>();
            kernel.Bind<IAccountRepository>().To<EFAccountRepository>();
        }
    }
}