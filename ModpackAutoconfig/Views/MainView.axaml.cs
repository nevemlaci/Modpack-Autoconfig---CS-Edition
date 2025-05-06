using System;
using System.Threading;
using System.Threading.Tasks;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Platform.Storage;
using ModpackAutoconfig.ViewModels;

namespace ModpackAutoconfig.Views;

public partial class MainView : UserControl
{
    private MainViewModel viewModel = new MainViewModel();
    
    public MainView()
    {
        InitializeComponent();
        Loaded += OnLoaded;
    }
    
    private async void OnLoaded(object? sender, RoutedEventArgs e)
    {
        await SelectWorkingDirectoryAsync();
    }


    private async void WorkingDirectoryButton_OnClick(object? sender, RoutedEventArgs e)
    {
        await SelectWorkingDirectoryAsync();
    }
    
    private async Task SelectWorkingDirectoryAsync()
    {
        while (true)
        {
            var topLevel = TopLevel.GetTopLevel(this);
            if (topLevel is null)
            {
                throw new InvalidOperationException("TopLevel is null");
            }
            var folders = await topLevel.StorageProvider.OpenFolderPickerAsync(
                new FolderPickerOpenOptions { Title = "Select Working Directory", AllowMultiple = false});
            if (folders.Count > 0)
            {
                viewModel.WorkingDirectory = folders[0];
                return;
            }
            if (viewModel.WorkingDirectory is not null) return;
        }
    }
    
    private async void NewMaterialButton_OnClick(object? sender, RoutedEventArgs e)
    {
        Window window = new GregTechMaterialCreatorWindow();
        var parentWindow = TopLevel.GetTopLevel(this) as Window;
        
        parentWindow?.Hide();
        window.Show();

        window.Closed += (_, _) =>
        {
            parentWindow.Show();
        };

    }
}