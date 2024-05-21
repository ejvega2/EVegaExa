namespace EVegaExa.Views;

public partial class Login : ContentPage
{
	public Login()
	{
		InitializeComponent();
	}

    private void btnIngresar_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new ReporteTransportista());
    }

    private void btnRegistro_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new Registro());
    }

    private void btnAcercaDe_Clicked(object sender, EventArgs e)
    {
        DisplayAlert("Acerca de", "Esta aplicación fue desarrollada por el Grupo 5.\nVersión 1.0\nGracias por usar nuestra aplicación.", "OK");
    }
}