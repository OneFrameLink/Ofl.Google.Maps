﻿using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Ofl.Google.Maps.Tests
{
    public class MapClientTestsFixture : IDisposable
    {
        #region Constructor

        public MapClientTestsFixture()
        {
            // Assign values.
            _serviceProvider = CreateServiceProvider();
        }

        #endregion

        #region Read-only state.

        private static readonly IConfigurationRoot ConfigurationRoot = new ConfigurationBuilder()
            // For local debugging.
            .AddJsonFile("appsettings.local.json", true)
            // For Appveyor.
            .AddEnvironmentVariables()
            .Build();

        private readonly ServiceProvider _serviceProvider;

        #endregion

        #region Helpers

        private static ServiceProvider CreateServiceProvider()
        {
            // Create a collection.
            var sc = new ServiceCollection();

            // Add the google apis.
            sc.AddGoogleApi(ConfigurationRoot.GetSection("google"));

            // Add the youtube client.
            sc.AddGoogleMapsClients();

            // Build and return.
            return sc.BuildServiceProvider();
        }

        public T GetRequiredService<T>() => _serviceProvider.GetRequiredService<T>();

        #endregion

        #region IDisposable implementation.

        public void Dispose()
        {
            // Call the overload and
            // suppress finalization.
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected void Dispose(bool disposing)
        {
            // Dispose of unmanaged resources.

            // If not disposing, get out.
            if (!disposing) return;

            // Dispose of IDisposable implementations.
            using var _ = _serviceProvider;
        }

        ~MapClientTestsFixture() => Dispose(false);

        #endregion
    }
}
