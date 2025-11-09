using Avalonia.Controls;
using ReQuantum.Attributes;

namespace ReQuantum.Views;

[AutoInject(Lifetime.Singleton, RegisterTypes = [typeof(ZjuSsoLoginView)])]
public partial class ZjuSsoLoginView : UserControl
{
    public ZjuSsoLoginView()
    {
        InitializeComponent();
    }
}
