using Avalonia.Controls;
using ReQuantum.Attributes;

namespace ReQuantum.Views;

[AutoInject(Lifetime.Singleton, RegisterTypes = [typeof(SettingsView)])]
public partial class SettingsView : UserControl
{
    public SettingsView()
    {
        InitializeComponent();
    }
}
