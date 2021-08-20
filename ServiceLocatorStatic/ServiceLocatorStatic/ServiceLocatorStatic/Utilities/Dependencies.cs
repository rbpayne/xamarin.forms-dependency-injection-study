using System;
using System.Net.Http;
using ServiceLocatorStatic.Services;

namespace ServiceLocatorStatic.Utilities
{
    public static class Dependencies
    {
        public static readonly HttpClient HttpClient = GetHttpClient();
        public static readonly ParkService ParkService = new ParkService();

        /*
         * Constructing this in a service locator creates a separation of concerns. This means I control what
         * the implementation of the HttpClient is outside of where it is called.
         *
         * An example where this is helpful is if I want to pass in an environment variable when the object
         * is constructed. If I had to do that directly in the caller, that would violate the
         * Single Responsibility Principle (SRP).
         */
        private static HttpClient GetHttpClient()
        {
            var httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(Constants.BaseUrl);
            return httpClient;
        }
    }
}
