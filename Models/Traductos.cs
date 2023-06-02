
namespace ProyectoFinalLab3.Models;

static class Traductor
{
      public static async Task<String> traducir(String texto)
    {
        string apiKey = "AIzaSyDDQIKsmuGd02yGXb77VB1pXnhHFjymZg0";
        string targetLanguage = "es";

        HttpClient httpClient = new HttpClient();

        string url = $"https://translation.googleapis.com/language/translate/v2?key={apiKey}&q={Uri.EscapeDataString(texto)}&target={targetLanguage}";
        var response = await httpClient.GetAsync(url);
        if (response.IsSuccessStatusCode)
        {
            var translationData = await response.Content.ReadFromJsonAsync<TranslationData>();
            if (translationData != null && translationData.Data != null && translationData.Data.Translations.Count > 0)
            {
                string translatedText = translationData.Data.Translations[0].TranslatedText;
                Console.WriteLine($"Texto traducido: {translatedText}");

                return translatedText;
            }
            else
            {
                return "fallo en la traduccion";
            }
        }
        else
        {
            return "fallo en la traduccion por api";
        }
    }
}

public class TranslationData
{
    public TranslationDataItem Data { get; set; }
}

public class TranslationDataItem
{
    public List<TranslationItem> Translations { get; set; }
}

public class TranslationItem
{
    public string TranslatedText { get; set; }
}

    
