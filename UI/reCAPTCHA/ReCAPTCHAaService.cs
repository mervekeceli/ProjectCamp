using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
namespace UI.reCAPTCHA
{
    public class ReCAPTCHAaService
    {
        private readonly string _secretKey;

        public ReCAPTCHAaService(string secretKey)
        {
            _secretKey = secretKey;
        }

        public async Task<bool> ValidateRecaptchaAsync(string recaptchaResponse)
        {
            using var httpClient = new HttpClient();
            var url = "https://www.google.com/recaptcha/api/siteverify";

            var response = await httpClient.PostAsJsonAsync(url, new
            {
                secret = _secretKey,
                response = recaptchaResponse
            });

            var jsonResponse = await response.Content.ReadAsStringAsync();
            var recapthaResult = JsonSerializer.Deserialize<RecaptchaResponse>(jsonResponse);

            return recapthaResult?.Success == true;
        }
    }

    public class RecaptchaResponse
    {
        public bool Success { get; set; }
    }
}
