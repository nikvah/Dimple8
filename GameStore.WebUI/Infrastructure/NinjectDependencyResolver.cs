﻿using GameStore.Domain.Abstract;
using GameStore.Domain.Concrete;
using GameStore.Domain.Entities;
using Moq;
using Ninject;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace GameStore.WebUI.Infrastructure
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

        //private void AddBindings()
        //{
        //    // Здесь размещаются привязки
        //    Mock<IGameRepository> mock = new Mock<IGameRepository>();
        //    mock.Setup(m => m.Games).Returns(new List<Game>
        //    {
        //        new Game { Name = "SimCity", Price = 1499 },
        //        new Game { Name = "TITANFALL", Price = 2299 },
        //        new Game { Name = "Battlefield 4", Price = 899.4M }
        //    });
        //    kernel.Bind<IGameRepository>().ToConstant(mock.Object);
        //}

        private void AddBindings()
        {
            kernel.Bind<IGameRepository>().To<EFGameRepository>();
        }
    }
}