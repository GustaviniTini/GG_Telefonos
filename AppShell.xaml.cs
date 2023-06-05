namespace GG_Telefonos;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();

        Routing.RegisterRoute(nameof(Views.GG_TelefonoPage), typeof(Views.GG_TelefonoPage));
    }
}