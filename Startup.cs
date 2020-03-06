using System;
using DependencyInjectionFunctions;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;

[assembly: FunctionsStartup(typeof(Startup))]
namespace DependencyInjectionFunctions
{
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            builder.Services.AddSingleton<IRepository, Repository>();
            //builder.Services.AddScoped<ICci, CCI>();
            builder.Services.AddSingleton<ICci, CCI>();
            builder.Services.AddLogging();
        }
    }

    public interface IRepository
    {
        string GetData();
    }

    public class Repository : IRepository
    {
        public string GetData()
        {
            return "some data!";
        }
    }

    public interface ICci
    {
        string GetCCI();
    }

    public class CCI : ICci
    {
        Guid _guid;
        public CCI()
        {
            _guid = Guid.NewGuid();
        }
        public string GetCCI()
        {
            return _guid.ToString();
        }
    }

}