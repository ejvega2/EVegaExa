using EVegaExa.Models;
using Newtonsoft.Json;

namespace EVegaExa.Views;

public partial class Resumen : ContentPage
{
    private const string baseUrl = "http://localhost:8000/api/";
    private readonly HttpClient cliente = new HttpClient();
    int codigo = 0;
    public Resumen(int id)
    {
        InitializeComponent();
        CargarDatos(id);
        codigo = id;
    }

    private async void CargarDatos(int id)
    {
        HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, baseUrl + "estudiantes/" + id);

        HttpResponseMessage response = await cliente.SendAsync(request);

        if (response.IsSuccessStatusCode)
        {
            // Parse the JSON response body to extract authentication token or other data
            string responseBody = await response.Content.ReadAsStringAsync();
            Estudiante resp = JsonConvert.DeserializeObject<Estudiante>(responseBody);
            txtNombres.Text = resp.nombres;
            txtApellidos.Text = resp.apellidos;
            txtCedula.Text = resp.cedula;
            txtRuta.Text = resp.ruta;
        }
        else
        {
            Console.WriteLine("Error: " + response.StatusCode);
        }
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
        Navigation.PushAsync(new EditarPass(codigo));
    }
}