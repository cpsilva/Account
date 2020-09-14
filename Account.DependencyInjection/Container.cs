using Account.DataAccess.Command;
using Account.DataAccess.Query;
using Account.DataAccess.UnitOfWork;
using Account.Services.LancamentoService;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Account.DependencyInjection
{
    public static class Container
    {
        private static IServiceProvider _serviceProvider;
        private static IServiceCollection _services;

        public static T GetService<T>()
        {
            if (_services == null)
            {
                _services = RegisterServices();
            }

            if (_serviceProvider == null)
            {
                _serviceProvider = _services.BuildServiceProvider();
            }

            return _serviceProvider.GetService<T>();
        }

        public static IServiceCollection RegisterServices(IServiceCollection services = null)
        {
            _services = services ?? new ServiceCollection();

            _services.AddScoped<ILancamentoService, LancamentoService>();

            //Account.DataAccess
            _services.AddScoped<IUnitOfWork, UnitOfWork>();
            _services.AddScoped<IQueryStack, QueryStack>();
            _services.AddScoped<ICommandStack, CommandStack>();

            return _services;
        }

        public static void AddDbContextInMemoryDatabase<T>() where T : DbContext
        {
            _services.AddDbContext<T>(options => options.UseInMemoryDatabase(typeof(T).Name));
            GetService<T>().Database.EnsureCreated();
        }
    }
}