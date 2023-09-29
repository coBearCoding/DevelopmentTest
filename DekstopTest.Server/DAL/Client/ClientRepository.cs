using DekstopTest.Server.Entities;
using Microsoft.EntityFrameworkCore;

namespace DekstopTest.Server.DAL.Client.ClientRepository
{
	public class ClientRepository : IClientRepository
	{
		private readonly ClientContext _clientContext;
        public ClientRepository(ClientContext clientContext)
        {
			_clientContext = clientContext;
        }
        public async Task<List<Models.Client>?> GetClientsAsync()
		{
			List<Models.Client> clients = await _clientContext.Clients.Select(x => x).ToListAsync();
			if(clients.Count() == 0)
			{
				return null;
			}
			return clients;
		}

		public async Task<Models.Client> SaveClient(Models.ClientRequest clientRequest)
		{
			var client = new Models.Client
			{
				Nombre = clientRequest.Nombre,
				Apellido = clientRequest.Apellido,
				Cedula = clientRequest.Cedula,
				Correo = clientRequest.Correo,
				Telefono = clientRequest.Telefono,
				URLFotoPerfil = clientRequest.URLFotoPerfil,
			};

			await _clientContext.AddAsync(client);

			await _clientContext.SaveChangesAsync();

			List<Models.Course> cursos = await _clientContext.Cursos.Where(x => x.IDCliente == client.ID).ToListAsync();

			client.Cursos = cursos;

			return client;
		}
	}
}
