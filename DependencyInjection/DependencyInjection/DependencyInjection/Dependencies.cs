using System;
using System.Net.Http;
using DependencyInjection.Services;
using DependencyInjection.Utilities;
using Microsoft.Extensions.DependencyInjection;

namespace DependencyInjection
{
    public static class Dependencies
    {
        private static readonly ServiceCollection _serviceCollection = new ServiceCollection();
        public static ServiceProvider ServiceProvider { get; private set; }
        
        // Helpers for easy access
        public static ParkService ParkService => ServiceProvider.GetRequiredService<ParkService>();

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
