using DekstopTest.Server.DAL.Client;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace DekstopTest.Server.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class ClientController : Controller
	{
		private readonly IClientRepository _clientRepository;

        public ClientController(IClientRepository clientRepository)
        {
			_clientRepository = clientRepository;
        }
       
        [HttpGet]
		public async Task<ActionResult> Index()
		{
			List<Models.Client?> clients = await _clientRepository.GetClientsAsync();
			if (clients.IsNullOrEmpty())
			{
				return NotFound("Clientes no registrados");
			}
			return Ok(clients);
		}


		[HttpPost("save")]
		public async Task<ActionResult<Models.ClientResponse>> Create([FromBody] Models.ClientRequest clientRequest)
		{
			Models.Client client = await _clientRepository.SaveClient(clientRequest);

			return new ObjectResult(client) {
				StatusCode = StatusCodes.Status201Created,
			};
		}
	}
}
