using System;
using System.Globalization;
using Avalonia.Data.Converters;
using Avalonia.Platform.Storage;

namespace ModpackAutoconfig.Converters;

public class PathConverter : IValueConverter
{
    public static readonly PathConverter Instance = new();
    public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        var valueAsPath = value as IStorageFolder;
        return valueAsPath?.TryGetLocalPath();
    }

    public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}