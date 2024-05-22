using System.Text;
using System.Text.Json;

namespace EVegaExa.Views;

public partial class EditarPass : ContentPage
{
    private const string baseUrl = "http://localhost:8000/api/";
    private readonly HttpClient cliente = new HttpClient();
    private int codigo = 0;
    public string pass { get; private set; }
    JsonSerializerOptions _serializerOptions = new JsonSerializerOptions
    {
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
        WriteIndented = true
    };
    public EditarPass(int id)
	{
		InitializeComponent();
        codigo = id;
	}

    private void btnsavepass_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new Login());
    //    HttpClient client = new HttpClient();

    //    var requestBody = new
    //    {
    //        id_estudiante = codigo,
    //        password = entryNuevaContrase�a.Text
    //};

    //    string jsonBody = JsonSerializer.Serialize(requestBody);

    //    HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Put, baseUrl + "estudiantes");
    //    request.Content = new StringContent(jsonBody, Encoding.UTF8, "application/json");

    //    HttpResponseMessage response = await client.SendAsync(request);
    //    // Aqu� puedes agregar el c�digo para guardar los datos en la base de datos o en otro lugar
    //    await DisplayAlert("�xito", "Los datos del registro han sido guardados correctamente.", "OK");
    //    // Aqu� puedes agregar la l�gica para guardar la nueva contrase�a
    //    // Puedes acceder al texto ingresado en el Entry utilizando Entry.Text
    //    // L�gica para guardar la nueva contrase�a
    }
}