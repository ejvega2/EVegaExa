namespace EVegaExa.Views;
using Microsoft.Maui.Media;
using System;
using System.IO;

public partial class Registro : ContentPage
{
	public Registro()
	{
		InitializeComponent();
	}

    private async void btnGuardar_Clicked(object sender, EventArgs e)
    {
        // Mostrar un mensaje de confirmación al usuario
        bool answer = await DisplayAlert("Confirmación", "¿Desea guardar los datos del registro?", "Sí", "No");

        if (answer)
        {
            // Lógica para guardar los datos del registro
            // Aquí puedes agregar el código para guardar los datos en la base de datos o en otro lugar
            await DisplayAlert("Éxito", "Los datos del registro han sido guardados correctamente.", "OK");
        }
        else
        {
            // El usuario ha optado por no guardar los datos del registro
            await DisplayAlert("Cancelado", "Los datos del registro no han sido guardados.", "OK");
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

        await DisplayAlert("Foto Guardada", "La foto ha sido guardada exitosamente.", "OK");
    }
}