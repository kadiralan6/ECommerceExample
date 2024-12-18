using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Autofac;
using ECommerce.Business.AutoMapper;

namespace ECommerce.Business.DependencyResolvers.Autofac
{
    public class AutofacAutoMapperModule :Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterInstance(CreateConfiguration().CreateMapper()).As<IMapper>();
        }

        private MapperConfiguration CreateConfiguration()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(typeof(ProductProfile));
                cfg.AddProfile(typeof(CategoryProfile));
                cfg.AddMaps(GetType().Assembly);
                
            });

            return config;
        }
    }
}
