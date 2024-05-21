namespace EVegaExa.Views;

public partial class ReporteTransportista : ContentPage
{
	public ReporteTransportista()
	{
		InitializeComponent();
        // Supongamos que tienes una lista de estudiantes
        List<Estudiante> estudiantes = ObtenerListaEstudiantes();
        lstEstudiantes.ItemsSource = estudiantes;
    }
    // Método ficticio para obtener una lista de estudiantes
    private List<Estudiante> ObtenerListaEstudiantes()
    {
        List<Estudiante> estudiantes = new List<Estudiante>
            {
                new Estudiante { Nombre = "Juan", Apellido = "Perez", Cedula = "123456789" },
                new Estudiante { Nombre = "Maria", Apellido = "Gonzalez", Cedula = "987654321" }
                // Agrega más estudiantes si es necesario
            };

        return estudiantes;
    }
    // Clase de ejemplo para representar un estudiante
    public class Estudiante
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Cedula { get; set; }
    }
}