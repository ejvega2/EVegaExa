using Newtonsoft.Json;
using System.Collections.ObjectModel;

namespace EVegaExa.Views;

public partial class ReporteTransportista : ContentPage
{
    private const string baseUrl = "http://localhost:8000/api/";
    private readonly HttpClient cliente = new HttpClient();
    private ObservableCollection<Estudiante> est;
    public ReporteTransportista(int id)
    {
        InitializeComponent();
        ObtenerDatos(id);
    }
    // Método ficticio para obtener una lista de estudiantes
    public async void ObtenerDatos(int id)
    {
        var content = await cliente.GetStringAsync(baseUrl + "rutas/" + id);
        List<Estudiante> mostrar = JsonConvert.DeserializeObject<List<Estudiante>>(content);
        est = new ObservableCollection<Estudiante>(mostrar);
        lstEstudiantes.ItemsSource = est;
    }
    // Clase de ejemplo para representar un estudiante
    public class Estudiante
    {
        public string nombres { get; set; }
        public string apellidos { get; set; }
        public string cedula { get; set; }
    }
}