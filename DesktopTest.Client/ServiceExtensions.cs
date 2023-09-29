using DesktopTest.Client.Data.Services;
using Microsoft.Extensions.DependencyInjection.Extensions;
//using Microsoft.Extensions.Http;
using System.Net.Http;
namespace DekstopTest.Client
{
	public static class ServiceExtensions
	{
		public static void ConfigureServices(this IServiceCollection services )
		{
			services.AddHttpClient();
			
			services.AddSingleton<IClientService, ClientService>();
			services.AddSingleton<DesktopTest.Client.Data.Models.Client>();
		}

		
	}
}
