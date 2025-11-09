using CommunityToolkit.Mvvm.Input;
using IconPacks.Avalonia.Material;
using ReQuantum.Abstractions;
using ReQuantum.Attributes;
using ReQuantum.Models;
using ReQuantum.Resources.I18n;
using ReQuantum.Services;
using ReQuantum.Views;
using System;
using System.ComponentModel;

namespace ReQuantum.ViewModels;

[AutoInject(Lifetime.Transient, RegisterTypes = [typeof(AnotherViewModel), typeof(IMenuItemProvider)])]
public partial class AnotherViewModel : ViewModelBase<AnotherView>, IMenuItemProvider
{
    #region MenuItemProvider APIs
    public string Title => UIText.Home;
    public PackIconMaterialKind IconKind => PackIconMaterialKind.Home;
    public uint Order => 1;
    public Type ViewModelType => typeof(AnotherViewModel);
    Action<MenuItem> IMenuItemProvider.OnCultureChanged => item => item.Title = UIText.Home;
    #endregion

    private readonly ILocalizer _localizer;

    public string Welcome => _localizer[UIText.HelloWorld];

    public AnotherViewModel(ILocalizer localizer) : base(localizer)
    {
        _localizer = localizer;
    }

    [RelayCommand]
    private void UpdateWelcome()
    {
        _localizer.SetCulture("en-US");
        OnPropertyChanged(new PropertyChangedEventArgs(null));
    }
}
