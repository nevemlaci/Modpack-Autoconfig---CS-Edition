using System;
using System.Threading.Tasks;
using Avalonia.Controls;
using Avalonia.Platform.Storage;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ModpackAutoconfig.Views;

namespace ModpackAutoconfig.ViewModels;

public partial class MainViewModel : ViewModelBase
{
    [ObservableProperty] private IStorageFolder? workingDirectory;

    public MainViewModel()
    {
        this.PropertyChanged += (sender, args) =>
        {
            if (args.PropertyName == nameof(WorkingDirectory))
            {
                Console.WriteLine($"{WorkingDirectory?.TryGetLocalPath()}");
            }
        };
    } 
}