using CommunityToolkit.Mvvm.ComponentModel;
using ReQuantum.Services;
using System;
using System.ComponentModel;

namespace ReQuantum.ViewModels;

// Only used to mark ViewModel types
public interface IViewModel;

public abstract class ViewModelBase<TView> : ObservableObject, IViewModel, IDisposable
{
    public ILocalizer Localizer { get; }
    public ViewModelBase(ILocalizer localizer)
    {
        Localizer = localizer;
        Localizer.CultureChanged += OnCultureChanged;
    }

    protected virtual void OnCultureChanged()
    {
        OnPropertyChanged(new PropertyChangedEventArgs(null));
    }

    public virtual void Dispose()
    {
        Localizer.CultureChanged -= OnCultureChanged;
        GC.SuppressFinalize(this);
    }
}