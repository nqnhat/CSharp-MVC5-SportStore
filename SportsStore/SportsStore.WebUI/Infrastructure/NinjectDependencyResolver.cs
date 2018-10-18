using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Ninject;
using System.Web.Mvc;

using SportsStore.Domain.Abstract;
using SportsStore.Domain.Entities;
using Moq;

namespace SportsStore.WebUI.Infrastructure
{
    public class NinjectDependencyResolver : IDependencyResolver
    {
        private IKernel kernel;

        public NinjectDependencyResolver(IKernel kernelParam)
        {
            this.kernel = kernelParam;
            AddBindings();
        }

        private void AddBindings()
        {
            Mock<IProductRepository> mock = new Mock<IProductRepository>();
            List<Product> mockProducts = new List<Product>();

            mockProducts.Add(new Product { Name = "Football", Price = 25 });
            mockProducts.Add(new Product { Name = "Surf board", Price = 179});
            mockProducts.Add(new Product { Name = "Running shoes", Price = 95});

            mock.Setup(i => i.Products).Returns(mockProducts);

            kernel.Bind<IProductRepository>().ToConstant(mock.Object);
        }

        public object GetService(Type serviceType)
        {
            return kernel.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return kernel.GetAll(serviceType);
        }
    }
}