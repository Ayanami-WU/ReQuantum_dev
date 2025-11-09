using ReQuantum.Services;
using ReQuantum.ViewModels;

namespace ReQuantum.Extensions;

public static class NavigatorExtensions
{
    public static void NavigateTo<TViewModel>(this INavigator navigator)
        where TViewModel : class, IViewModel
    {
        navigator.NavigateTo(typeof(TViewModel));
    }
}
