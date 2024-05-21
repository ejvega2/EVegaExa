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
        // Mostrar un mensaje de confirmaci�n al usuario
        bool answer = await DisplayAlert("Confirmaci�n", "�Desea guardar los datos del registro?", "S�", "No");

        if (answer)
        {
            // L�gica para guardar los datos del registro
            // Aqu� puedes agregar el c�digo para guardar los datos en la base de datos o en otro lugar
            await DisplayAlert("�xito", "Los datos del registro han sido guardados correctamente.", "OK");
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
            var result = await DisplayActionSheet("Seleccionar opci�n", "Cancelar", null, "Tomar Foto", "Elegir de la Galer�a");
            if (result == "Tomar Foto")
            {
                var photo = await MediaPicker.CapturePhotoAsync();
                if (photo != null)
                {
                    await LoadPhotoAsync(photo);
                }
            }
            else if (result == "Elegir de la Galer�a")
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
            await DisplayAlert("Error", "No se pudo completar la operaci�n: " + ex.Message, "OK");
        }
    }
    async Task LoadPhotoAsync(FileResult photo)
    {
        // Cancelar si el usuario no seleccion� una foto
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