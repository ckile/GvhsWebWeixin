using System;
using Gvhs.Web.ServiceContracts;
using Microsoft.Data.Entity;
using Microsoft.Extensions.DependencyInjection;

namespace Gvhs.Web.Services
{
    public class BllServiceProvider : IBllServiceProvider
    {
        private readonly DbContext _dbContext;
        private readonly IServiceProvider _serviceProvider;

        public BllServiceProvider(IServiceProvider services, WeixinDbContext dbContext)
        {
            _serviceProvider = services;
            _dbContext = dbContext;
        }


        public DbContext DbContext
        {
            get
            {
                return _dbContext;
            }
        }

        public T CreateService<T>()
        {
            var ser = _serviceProvider.GetService<T>();
            var serInit = ser as IServiceInit;
            if(serInit != null)
            {
                serInit.Init();
            }
            return ser;
        }
    }
}
