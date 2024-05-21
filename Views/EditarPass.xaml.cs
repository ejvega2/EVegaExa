namespace EVegaExa.Views;

public partial class EditarPass : ContentPage
{
	public EditarPass()
	{
		InitializeComponent();
	}

    private void btnsavepass_Clicked(object sender, EventArgs e)
    {
        // Aquí puedes agregar la lógica para guardar la nueva contraseña
        // Puedes acceder al texto ingresado en el Entry utilizando Entry.Text
        string nuevaContraseña = entryNuevaContraseña.Text;
        // Lógica para guardar la nueva contraseña
    }
}