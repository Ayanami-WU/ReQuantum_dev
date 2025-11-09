using ReQuantum.Models;
using ReQuantum.Services;
using ReQuantum.ViewModels;

namespace ReQuantum.Extensions;
public static class MenuManagerExtensions
{
    public static MenuItem? GetMenuItem<TViewModel>(this IMenuManager menuManager)
        where TViewModel : class, IViewModel
    {
        return menuManager.GetMenuItem(typeof(TViewModel));
    }
}
