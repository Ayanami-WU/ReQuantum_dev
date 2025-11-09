using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using IconPacks.Avalonia.Material;
using ReQuantum.Abstractions;
using ReQuantum.Attributes;
using ReQuantum.Models;
using ReQuantum.Resources.I18n;
using ReQuantum.Services;
using ReQuantum.Views;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ReQuantum.ViewModels;

[AutoInject(Lifetime.Transient, RegisterTypes = [typeof(SettingsViewModel), typeof(IMenuItemProvider)])]
public partial class SettingsViewModel : ViewModelBase<SettingsView>, IMenuItemProvider
{
    #region MenuItemProvider APIs
    public string Title => UIText.Settings;
    public PackIconMaterialKind IconKind => PackIconMaterialKind.Cog;
    public uint Order => uint.MaxValue;
    public Type ViewModelType => typeof(SettingsViewModel);
    Action<MenuItem> IMenuItemProvider.OnCultureChanged => item => item.Title = UIText.Settings;
    #endregion

    private readonly ILocalizer _localizer;
    public ZjuSsoLoginViewModel ZjuSsoLoginViewModel { get; }

    [ObservableProperty]
    private LanguageOption _selectedLanguage;

    public List<LanguageOption> AvailableLanguages { get; } = new()
    {
        new LanguageOption("English", "en-US"),
        new LanguageOption("中文", "zh-CN")
    };

    public SettingsViewModel(ILocalizer localizer, ZjuSsoLoginViewModel zjuSsoLoginViewModel) : base(localizer)
    {
        _localizer = localizer;
        ZjuSsoLoginViewModel = zjuSsoLoginViewModel;

        // Set current language
        var currentCulture = System.Globalization.CultureInfo.CurrentUICulture.Name;
        _selectedLanguage = AvailableLanguages.FirstOrDefault(l => l.CultureCode == currentCulture) 
                            ?? AvailableLanguages[0];
    }

    partial void OnSelectedLanguageChanged(LanguageOption value)
    {
        if (value != null)
        {
            _localizer.SetCulture(value.CultureCode);
        }
    }

    public override void Dispose()
    {
        ZjuSsoLoginViewModel?.Dispose();
        base.Dispose();
    }
}

public class LanguageOption
{
    public string DisplayName { get; set; }
    public string CultureCode { get; set; }

    public LanguageOption(string displayName, string cultureCode)
    {
        DisplayName = displayName;
        CultureCode = cultureCode;
    }

    public override bool Equals(object? obj)
    {
        return obj is LanguageOption option && CultureCode == option.CultureCode;
    }

    public override int GetHashCode()
    {
        return CultureCode.GetHashCode();
    }
}
