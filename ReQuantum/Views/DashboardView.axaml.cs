using Avalonia.Controls;
using ReQuantum.Attributes;

namespace ReQuantum.Views;

[AutoInject(Lifetime.Singleton, RegisterTypes = [typeof(DashboardView)])]
public partial class DashboardView : UserControl
{
    public DashboardView()
    {
        InitializeComponent();
    }
}