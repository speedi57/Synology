﻿using System;
using Microsoft.Extensions.DependencyInjection;
using Synology.Classes;
using Synology.Interfaces;
using Synology.Settings;
using Synology.Utilities;

namespace Synology
{
    /// <summary>
    /// Logging service collection extensions.
    /// </summary>
    public static class LoggingServiceCollectionExtensions
    {
        //
        // Static Methods
        //
        /// <summary>
        /// Adds the Synology classes, with all features.
        /// </summary>
        /// <returns>The synology.</returns>
        /// <param name="services">Services.</param>
        public static IServiceCollection AddSynology(this IServiceCollection services)
        {
            return AddSynology(services, b => b.AddApi().AddAudioStation().AddDownloadStation().AddDownloadStation2().AddFileStation().AddSurveillanceStation().AddVideoStation());
        }

        /// <summary>
        /// Adds the Synology classes, you can choose the features.
        /// </summary>
        /// <returns>The synology.</returns>
        /// <param name="services">Services.</param>
        /// <param name="configure">Configure.</param>
        public static IServiceCollection AddSynology(this IServiceCollection services, Action<ISynologyBuilder> configure)
        {
            if (configure == null) throw new ArgumentNullException(nameof(configure));

            services.AddOptions();
            services.AddSingleton<ISynologyConnectionSettings, SynologyConnectionSettings>();
            services.AddSingleton<SidContainer, SidContainer>();
            services.AddTransient<ISynologyConnection, SynologyConnection>();

            configure(new SynologyBuilder(services));

            return services;
        }

        internal static IServiceCollection AddRequest<TRequestInterface, TRequest>(this IServiceCollection services)
            where TRequestInterface : class, ISynologyRequest
            where TRequest : SynologyRequest, TRequestInterface
        {
            return services.AddTransient<TRequestInterface, TRequest>();
        }

        internal static IServiceCollection AddApi<TApiInterface, TApi>(this IServiceCollection services)
            where TApiInterface : class, ISynologyApi
            where TApi : SynologyApi, TApiInterface
        {
            return services.AddTransient<TApiInterface, TApi>();
        }
    }
}
