namespace DesktopTest.Client.Data.Services
{
	public interface IClientService
	{
		Task<List<Models.Client>> GetClientsAsync();

	}
}
