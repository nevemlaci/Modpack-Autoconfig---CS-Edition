using Avalonia.Controls;

namespace ModpackAutoconfig.Views;


public abstract class ViewBase<T> : UserControl where T : new()
{
    protected T ViewModel { get; }

    protected ViewBase()
    {
        ViewModel = new T();
        DataContext = ViewModel;
    }
}