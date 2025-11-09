using ReQuantum.Extensions;
using ReQuantum.Models;
using ReQuantum.ViewModels;
using System;

namespace ReQuantum.Services;

public interface IMenuItemAccessor
{
    MenuItem? MenuItem { get; }
}

public interface IMenuItemAccessor<TViewModel> : IMenuItemAccessor where TViewModel : class, IViewModel;

public class MenuItemAccessor<TViewModel> : IMenuItemAccessor<TViewModel>
    where TViewModel : class, IViewModel
{
    private readonly Lazy<MenuItem?> _menuItemFactory;
    public MenuItem? MenuItem => _menuItemFactory.Value;
    public MenuItemAccessor(Lazy<MenuItem?> menuItemFactory)
    {
        _menuItemFactory = menuItemFactory;
    }
}

public class MenuItemAccessorFactory<TViewModel> : MenuItemAccessor<TViewModel>
    where TViewModel : class, IViewModel
{
    public MenuItemAccessorFactory(IMenuManager menuManager) : base(new Lazy<MenuItem?>(menuManager.GetMenuItem<TViewModel>))
    {
    }
}

