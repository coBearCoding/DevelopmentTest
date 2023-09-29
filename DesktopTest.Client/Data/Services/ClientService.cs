//using System.Net.Http.Json;
using System.Net.Http;
using System.Text.Json;

namespace DesktopTest.Client.Data.Services
{

	public class ClientService : IClientService
	{
		private readonly HttpClient _httpClient;

		public ClientService(HttpClient httpClient)
		{
			_httpClient = httpClient;
		}

		public async Task<List<Models.Client>> GetClientsAsync()
		{
			string url = "https://localhost:7049/api/Client";

			var response = await _httpClient.GetAsync(url);

			if(response.IsSuccessStatusCode)
			{
				var clients = await JsonSerializer.DeserializeAsync<List<Models.Client>>(
					await response.Content.ReadAsStreamAsync());

				return clients;
			}

			return null;
		}
	}
}
