using CommunityToolkit.Mvvm.ComponentModel;

namespace ModpackAutoconfig.ViewModels;

public partial class MainViewModel : ViewModelBase
{
    [ObservableProperty] private string greeting = "Welcome to Avalonia!";
}