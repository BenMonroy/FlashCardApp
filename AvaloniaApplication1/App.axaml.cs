using System;
using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Data.Core;
using Avalonia.Data.Core.Plugins;
using System.Linq;
using System.Security.Authentication.ExtendedProtection;
using Avalonia.Markup.Xaml;
using AvaloniaApplication1.Data;
using AvaloniaApplication1.Factories;
using AvaloniaApplication1.ViewModels;
using AvaloniaApplication1.Views;
using CommunityToolkit.Mvvm;
using Microsoft.Extensions.DependencyInjection;

namespace AvaloniaApplication1;

public partial class App : Application
{
    
    
    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);
    }

    public override void OnFrameworkInitializationCompleted()
    {

        var collection = new ServiceCollection();
        collection.AddSingleton<MainWindowViewModel>();
        collection.AddTransient<DecksViewModel>();
        collection.AddTransient<SettingsViewModel>();
        collection.AddTransient<PracticeViewModel>();
        collection.AddTransient<DashboardViewModel>();
        
        // Add DeckRepository
        collection.AddSingleton<DeckRepository>();

        collection.AddSingleton<Func<PageNames, PageViewModel>>(x => name => name switch
        {
            PageNames.Dashboard => x.GetRequiredService<DashboardViewModel>(),
            PageNames.Settings => x.GetRequiredService<SettingsViewModel>(),
            PageNames.Practice => x.GetRequiredService<PracticeViewModel>(),
            PageNames.Decks => x.GetRequiredService<DecksViewModel>(),
            _ => throw new InvalidOperationException()
        });
        
        collection.AddSingleton<PageFactory>();
        
        var services = collection.BuildServiceProvider();
        
        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            // Avoid duplicate validations from both Avalonia and the CommunityToolkit. 
            // More info: https://docs.avaloniaui.net/docs/guides/development-guides/data-validation#manage-validationplugins
            DisableAvaloniaDataAnnotationValidation();
            desktop.MainWindow = new MainWindow
            {
                DataContext = services.GetRequiredService<MainWindowViewModel>(),
            };
        }

        base.OnFrameworkInitializationCompleted();
    }

    private void DisableAvaloniaDataAnnotationValidation()
    {
        // Get an array of plugins to remove
        var dataValidationPluginsToRemove =
            BindingPlugins.DataValidators.OfType<DataAnnotationsValidationPlugin>().ToArray();

        // remove each entry found
        foreach (var plugin in dataValidationPluginsToRemove)
        {
            BindingPlugins.DataValidators.Remove(plugin);
        }
    }
}