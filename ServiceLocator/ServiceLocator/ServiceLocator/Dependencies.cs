using System;
using System.Net.Http;
using Microsoft.Extensions.DependencyInjection;
using ServiceLocator.Services;
using ServiceLocator.Utilities;

namespace ServiceLocator
{
    public static class Dependencies
    {
        private static readonly ServiceCollection _serviceCollection = new ServiceCollection();
        public static ServiceProvider ServiceProvider { get; private set; }

        public static void Init()
        {
            // Register HttpClient
            var httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(Constants.BaseUrl);
            _serviceCollection.AddSingleton(httpClient);
            
            // Register ParkService
            _serviceCollection.AddSingleton<ParkService>();

            ServiceProvider = _serviceCollection.BuildServiceProvider();
        }
    }
}
