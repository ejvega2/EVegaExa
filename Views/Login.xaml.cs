using static EVegaExa.Views.ReporteTransportista;
using System.Text.Json;
using System.Text;
using Newtonsoft.Json;
using EVegaExa.Models;

namespace EVegaExa.Views;

public partial class Login : ContentPage
{
    string baseUrl = "http://localhost:8000/api/login";
    public Login()
    {
        InitializeComponent();
    }

    private async void btnIngresar_Clicked(object sender, EventArgs e)
    {
        try
        {
            HttpClient client = new HttpClient();

            var requestBody = new
            {
                cedula = txtUsuario.Text,
                password = txtPassword.Text,
            };

            string jsonBody = JsonConvert.SerializeObject(requestBody);

            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, baseUrl);
            request.Content = new StringContent(jsonBody, Encoding.UTF8, "application/json");

            HttpResponseMessage response = await client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                // Parse the JSON response body to extract authentication token or other data
                string responseBody = await response.Content.ReadAsStringAsync();
                Respuesta resp = JsonConvert.DeserializeObject<Respuesta>(responseBody);

                if (resp.status == 0)
                {
                    Navigation.PushAsync(new ReporteTransportista(resp.id));
                }
                else if (resp.status == 1)
                {
                    Navigation.PushAsync(new Resumen(resp.id));
                }
            }
            else
            {
                Console.WriteLine("Error: " + response.StatusCode);
            }
        }
        catch (Exception ex)
        {

            DisplayAlert("Alerta!", ex.Message, "Cerrar");
        }
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