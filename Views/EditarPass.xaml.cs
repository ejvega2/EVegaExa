namespace EVegaExa.Views;

public partial class EditarPass : ContentPage
{
	public EditarPass()
	{
		InitializeComponent();
	}

    private void btnsavepass_Clicked(object sender, EventArgs e)
    {
        // Aqu� puedes agregar la l�gica para guardar la nueva contrase�a
        // Puedes acceder al texto ingresado en el Entry utilizando Entry.Text
        string nuevaContrase�a = entryNuevaContrase�a.Text;
        // L�gica para guardar la nueva contrase�a
    }
}