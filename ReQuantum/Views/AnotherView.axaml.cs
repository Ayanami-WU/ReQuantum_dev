using Avalonia.Controls;
using ReQuantum.Attributes;

namespace ReQuantum.Views;

[AutoInject(Lifetime.Singleton, RegisterTypes = [typeof(AnotherView)])]
public partial class AnotherView : UserControl
{
    public AnotherView()
    {
        InitializeComponent();
    }
}