﻿using System;
using System.IO;
using System.Windows;

using BunLabs.IO;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

using Randomizer.SMZ3.Generation;
using Randomizer.SMZ3.Tracking.VoiceCommands;

namespace Randomizer.App
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private IHost _host;

        protected static void ConfigureServices(IServiceCollection services)
        {
            var configFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "SMZ3CasRandomizer");
            var trackerConfigPath = Path.Combine(configFolder, "tracker.json");

            services.AddSingleton<Smz3Randomizer>();
            services.AddTracker<Smz3Randomizer>(trackerConfigPath)
                .AddOptionalModule<PegWorldModeModule>();
            services.AddWindows<App>();
        }

        private void Application_Startup(object sender, StartupEventArgs e)
        {
            _host = Host.CreateDefaultBuilder(e.Args)
                .ConfigureLogging(logging =>
                {
                    logging.AddFile($"smz3-cas-{DateTime.UtcNow:yyyyMMdd}.log", options =>
                    {
                        options.Append = true;
                        options.FileSizeLimitBytes = FileSize.MB(20);
                        options.MaxRollingFiles = 5;
                    });
                })
                .ConfigureServices((context, services) => ConfigureServices(services))
                .Start();

            var mainWindow = _host.Services.GetRequiredService<MainWindow>();
            mainWindow.Show();
        }

        private async void Application_Exit(object sender, ExitEventArgs e)
        {
            if (_host != null)
            {
                await _host.StopAsync();
                _host.Dispose();
            }
        }
    }
}
