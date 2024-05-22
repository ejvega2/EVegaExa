using System.Collections.ObjectModel;

namespace EVegaExa.Views;

public partial class Reporte : ContentPage
{
    public ObservableCollection<Usuario> Usuarios { get; set; }
    public Reporte()
	{
		InitializeComponent();

        // Aqu� puedes inicializar y cargar la colecci�n de usuarios con los datos del registro
        Usuarios = new ObservableCollection<Usuario>
            {
                new Usuario { Cedula = "123456789", NombreApellido = "Juan P�rez", RutaViaje = "Ruta 1" },
                new Usuario { Cedula = "987654321", NombreApellido = "Mar�a Garc�a", RutaViaje = "Ruta 2" }
                // Agrega m�s usuarios seg�n sea necesario
            };

        // Asignar la colecci�n de usuarios al contexto de datos de la vista
        BindingContext = this;
    }

    // Clase para representar los datos de un usuario
    public class Usuario
    {
        public string Cedula { get; set; }
        public string NombreApellido { get; set; }
        public string RutaViaje { get; set; }
    }

    private async void btndesloguear_Clicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }

    private void btneditar_Clicked(object sender, EventArgs e)
    {
        //Navigation.PushAsync(new Resumen());
    }
}