using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SportsStoreDomainLibrary.Abstract;
using SportsStoreDomainLibrary.Concrete;

namespace SportsStoreMVVMWpfApp
{
    public static class SportsStoreContainer
    {
        private static UnityContainer _container;
        static SportsStoreContainer()
        {
            _container = new UnityContainer();
            AddBindings();
        }

        public static UnityContainer Container { get => _container;  }

        private static void AddBindings()
        {
            Container.RegisterType<IProductRepository, EfProductRepository>(new ContainerControlledLifetimeManager());
        }


    }
}
