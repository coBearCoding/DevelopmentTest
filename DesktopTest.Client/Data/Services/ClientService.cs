//using System.Net.Http.Json;
using System.Net.Http;
using System.Text;
using System.Text.Json;

namespace DesktopTest.Client.Data.Services
{

	public class ClientService : IClientService
	{
		private readonly HttpClient _httpClient;


		private string baseURL = "https://localhost:7049";

		public ClientService(HttpClient httpClient)
		{
			_httpClient = httpClient;
		}

		public async Task<List<Models.Client>> GetClientsAsync()
		{
			string url = baseURL + "/api/client";

			var response = await _httpClient.GetAsync(url);

			if(response.IsSuccessStatusCode)
			{
				var clients = await JsonSerializer.DeserializeAsync<List<Models.Client>>(
					await response.Content.ReadAsStreamAsync());

				return clients;
			}

			return null;
		}

		public async Task<string> SaveClientAsync(Models.Client cliente)
		{
			string url = baseURL + "/api/client/save";

			var jsonData = new
			{
				nombre = cliente.Nombre,
				apellido = cliente.Apellido,
				cedula = cliente.Cedula,
				telefono = cliente.Telefono,
				correo = cliente.Correo,
				url_foto_perfil = cliente.URLFotoPerfil,
			};

			var serializedJson = JsonSerializer.Serialize(jsonData);

			var content = new StringContent(serializedJson, Encoding.UTF8, "application/json");

			Console.WriteLine(content);

			var response = await _httpClient.PostAsync(url , content);

			Console.WriteLine(response.ToString());

			return response.StatusCode.ToString();

			//if (response.IsSuccessStatusCode)
			//{
			//	return response.StatusCode.ToString();
			//	//return $"Cliente {cliente.Nombre} {cliente.Apellido} guardado existosamente";
			//}

			//return $"No se pudo guardar al cliente: {cliente.Nombre} {cliente.Apellido}";
		}
	}
}
