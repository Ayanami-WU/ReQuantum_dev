using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ReQuantum.Extensions;
using ReQuantum.Services;
using ReQuantum.ViewModels;
using System.Collections.Generic;
using System.Linq;

namespace ReQuantum.Shells;

public partial class ShellViewModel : ViewModelBase<ShellView>
{
    private readonly INavigator _navigator;
    private readonly IMenuManager _navMenuManager;
    private readonly IStorage _storage;

    private const string MenuExpandedStateKey = "Shell:MenuExpanded";
    private bool _isDesktop = true;

    public ShellViewModel(INavigator navigator, IMenuManager navMenuManager, ILocalizer localizer, IStorage storage) : base(localizer)
    {
        _navigator = navigator;
        _navMenuManager = navMenuManager;
        _storage = storage;
        _currentViewModel = _navigator.CurrentViewModel;
        _navigator.CurrentViewModelChanged += OnNavigate;

        InitializeMenuState();
    }

    private void InitializeMenuState()
    {
        if (_isDesktop)
        {
            if (!_storage.TryGet(MenuExpandedStateKey, out _isMenuExpanded))
            {
                _isMenuExpanded = true;
            }
        }
        else
        {
            _isMenuExpanded = false;
        }

        OnPropertyChanged(nameof(IsMenuExpanded));
    }

    public void SetPlatformMode(bool isDesktop)
    {
        if (_isDesktop == isDesktop)
        {
            return;
        }

        _isDesktop = isDesktop;
        InitializeMenuState();
    }

    [ObservableProperty]
    private IViewModel _currentViewModel;

    private bool _isMenuExpanded;
    public bool IsMenuExpanded
    {
        get => _isMenuExpanded;
        set
        {
            if (!SetProperty(ref _isMenuExpanded, value))
            {
                return;
            }

            if (!_isDesktop)
            {
                return;
            }

            _storage.Set(MenuExpandedStateKey, value);
        }
    }

    public IReadOnlyCollection<MenuItemPair> MenuItems => _navMenuManager.MenuItemPairs;

    /// <summary>
    /// Top 3 menu items for mobile bottom navigation
    /// </summary>
    public IEnumerable<MenuItemPair> TopMenuItems => MenuItems.Take(3);

    private MenuItemPair? _selectedMenuItemPair;
    public MenuItemPair? SelectedMenuItemPair
    {
        get => _selectedMenuItemPair;
        set
        {
            if (value is null || _selectedMenuItemPair == value)
            {
                return;
            }

            SetProperty(ref _selectedMenuItemPair, value);
            _navigator.NavigateTo(value.ViewModelType);

            if (!_isDesktop)
            {
                IsMenuExpanded = false;
            }
        }
    }

    private void OnNavigate()
    {
        CurrentViewModel = _navigator.CurrentViewModel;
    }

    [RelayCommand]
    private void ToggleMenu()
    {
        IsMenuExpanded = !IsMenuExpanded;
    }

    [RelayCommand]
    private void SelectMenuItem(MenuItemPair menuItemPair)
    {
        SelectedMenuItemPair = menuItemPair;
    }
}
