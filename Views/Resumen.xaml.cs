namespace EVegaExa.Views;

public partial class Resumen : ContentPage
{
	public Resumen()
	{
		InitializeComponent();
	}

    private void btncancelres_Clicked(object sender, EventArgs e)
    {

    }

    private void btncanceledit_Clicked(object sender, EventArgs e)
    {

    }

    private void btnsavedit_Clicked(object sender, EventArgs e)
    {

    }

    private void btneditarclave_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new EditarPass());
    }
}