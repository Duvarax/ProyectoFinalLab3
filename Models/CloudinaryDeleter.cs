namespace ProyectoFinalLab3.Models;

public class CloudinaryImageDeleter
{
    private readonly HttpClient _httpClient;

    public CloudinaryImageDeleter()
    {
        _httpClient = new HttpClient();
    }

    public async Task DeleteImage(string imageUrl)
    {
        HttpResponseMessage response = await _httpClient.DeleteAsync(imageUrl);

        if (response.IsSuccessStatusCode)
        {
            Console.WriteLine("La imagen se eliminó correctamente.");
        }
        else
        {
            Console.WriteLine("Hubo un error al intentar eliminar la imagen: " + response.StatusCode);
        }
    }
}