using IconPacks.Avalonia.Material;
using ReQuantum.Models;
using System;

namespace ReQuantum.Abstractions;

public interface IMenuItemProvider
{
    string Title { get; }
    PackIconMaterialKind IconKind { get; }
    uint Order { get; }
    Type ViewModelType { get; }

    Action<MenuItem> OnCultureChanged { get; }
}
