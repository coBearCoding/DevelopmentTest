using DekstopTest.Server;

namespace DekstopTest.Server.DAL.Client
{
	public interface IClientRepository
	{
		Task<List<Models.Client>?> GetClientsAsync();
		Task<Models.Client> SaveClient(Models.ClientRequest clientRequest);
	}
}
