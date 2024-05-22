namespace EVegaExa.Views;

using EVegaExa.Models;
using Microsoft.Maui.Media;
using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Text.Json;

public partial class Registro : ContentPage
{
    private const string baseUrl = "http://localhost:8000/api/";
    private const string apiImg = "https://api.imgbb.com/1/upload";
    private const string apiImgKey = "9c30c9c20900109a7befbd39f63551c4";
    private const string urlImage = "";

    private readonly HttpClient cliente = new HttpClient();
    public List<Ruta> Rutas { get; private set; }
    JsonSerializerOptions _serializerOptions = new JsonSerializerOptions
    {
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
        WriteIndented = true
    };
    int id = 0;
    public Registro()
    {
        InitializeComponent();
        CargarRuta();
        btnGuardar.IsEnabled = false;
    }

    private async void btnGuardar_Clicked(object sender, EventArgs e)
    {
        // Mostrar un mensaje de confirmación al usuario
        bool answer = await DisplayAlert("Confirmación", "¿Desea guardar los datos del registro?", "Sí", "No");

        if (answer)
        {
            //Lógica para guardar los datos del registro
            HttpClient client = new HttpClient();

            var requestBody = new
            {
                cedula = txtCedulaR.Text,
                password = txtClaveR.Text,
                nombres = txtNombreR.Text,
                apellidos = txtApellidoR.Text,
                //foto = urlImage,
                id_conductor = id + 1
            };

            string jsonBody = JsonSerializer.Serialize(requestBody);

            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, baseUrl + "estudiantes");
            request.Content = new StringContent(jsonBody, Encoding.UTF8, "application/json");

            HttpResponseMessage response = await client.SendAsync(request);
            // Aquí puedes agregar el código para guardar los datos en la base de datos o en otro lugar
            await DisplayAlert("Éxito", "Los datos del registro han sido guardados correctamente.", "OK");
        }
        else
        {
            // El usuario ha optado por no guardar los datos del registro
            await DisplayAlert("Cancelado", "Los datos del registro no han sido guardados.", "OK");
        }
        Navigation.PopAsync();
    }

    private async void CargarRuta()
    {
        Rutas = new List<Ruta>();

        Uri uri = new Uri(string.Format(baseUrl + "rutas", string.Empty));
        try
        {
            HttpResponseMessage response = await cliente.GetAsync(uri);
            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                Rutas = JsonSerializer.Deserialize<List<Ruta>>(content, _serializerOptions);
            }
            //pkRutaR.ItemsSource = Rutas;

        }
        catch (Exception ex)
        {
            //Debug.WriteLine(@"\tERROR {0}", ex.Message);
        }
    }

    private async void btnCancelar_Clicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }

    private async void btnFoto_Clicked(object sender, EventArgs e)
    {
        try
        {
            var result = await DisplayActionSheet("Seleccionar opción", "Cancelar", null, "Tomar Foto", "Elegir de la Galería");
            if (result == "Tomar Foto")
            {
                var photo = await MediaPicker.CapturePhotoAsync();
                if (photo != null)
                {
                    await LoadPhotoAsync(photo);
                }
            }
            else if (result == "Elegir de la Galería")
            {
                var photo = await MediaPicker.PickPhotoAsync();
                if (photo != null)
                {
                    await LoadPhotoAsync(photo);
                }
            }
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", "No se pudo completar la operación: " + ex.Message, "OK");
        }
    }
    async Task LoadPhotoAsync(FileResult photo)
    {
        // Cancelar si el usuario no seleccionó una foto
        if (photo == null)
        {
            return;
        }

        // Guardar la foto en un lugar accesible
        var newFile = Path.Combine(FileSystem.AppDataDirectory, photo.FileName);

        using (var stream = await photo.OpenReadAsync())
        using (var newStream = File.OpenWrite(newFile))
        {
            await stream.CopyToAsync(newStream);
        }

        using (var multipartFormData = new MultipartFormDataContent())
        {
            // Agregar el archivo de imagen a la solicitud
            using (var fileStream = await photo.OpenReadAsync())
            {
                var fileContent = new StreamContent(fileStream);
                multipartFormData.Add(fileContent, "image", photo.FileName);
            }

            // Enviar la solicitud y obtener la respuesta
            var response = await cliente.PostAsync(apiImg + "?key="+apiImgKey, multipartFormData);

            // Procesar la respuesta
            if (response.IsSuccessStatusCode)
            {
                // Obtener la URL de la imagen de la respuesta
                string imageUrl = await response.Content.ReadAsStringAsync();

                // Almacenar la URL de la imagen en la base de datos
                //await SaveImageUrlToDatabase(imageUrl);
            }
            else
            {
                // Manejar el error de la subida de la foto
                await DisplayAlert("Error", "No se pudo subir la foto a la API", "OK");
            }
        }

        await DisplayAlert("Foto Guardada", "La foto ha sido guardada exitosamente.", "OK");
    }

    private void pkRutaR_SelectedIndexChanged(object sender, EventArgs e)
    {
        id = pkRutaR.SelectedIndex;
    }

    private void txtConfClaveR_TextChanged(object sender, TextChangedEventArgs e)
    {
        if (txtClaveR.Text == txtConfClaveR.Text)
        {
            btnGuardar.IsEnabled = true;
        }
    }

    private void SaveImageUrlToDatabase(string imageUrl)
    {
        //urlImage = imageUrl;
    }
}