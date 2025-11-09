using CommunityToolkit.Mvvm.ComponentModel;
using IconPacks.Avalonia.Material;

namespace ReQuantum.Models;

public partial class MenuItem : ObservableObject
{
    [ObservableProperty]
    private string _title = string.Empty;

    [ObservableProperty]
    private PackIconMaterialKind _iconKind;
}