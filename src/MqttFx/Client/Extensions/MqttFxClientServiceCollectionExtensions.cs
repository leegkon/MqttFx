﻿using MqttFx;
using MqttFx.Client;
using MqttFx.Client.Abstractions;
using System;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class MqttFxClientServiceCollectionExtensions
    {
        public static IServiceCollection AddMqttFxClient(this IServiceCollection services, Action<MqttClientOptions> optionsAction)
        {
            if (optionsAction == null)
                throw new ArgumentNullException(nameof(optionsAction));

            services.AddLogging();
            services.AddOptions();
            services.Configure(optionsAction);
            services.AddSingleton<IMqttClient, MqttClient>();
            return services;
        }
    }
}