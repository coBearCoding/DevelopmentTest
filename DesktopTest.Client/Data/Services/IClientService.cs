namespace DesktopTest.Client.Data.Services
{
	public interface IClientService
	{
		Task<List<Models.Client>> GetClientsAsync();

		Task<string> SaveClientAsync(Models.Client client);
	}
}
