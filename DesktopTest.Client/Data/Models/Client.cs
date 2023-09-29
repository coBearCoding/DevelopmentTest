using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace DesktopTest.Client.Data.Models
{
	public class Client
	{
		[JsonPropertyName("id")]
		public int ID { get; set; }
		[Required, JsonPropertyName("nombre")]
		public string Nombre { get; set; }
		[Required, JsonPropertyName("apellido")]
		public string Apellido { get; set; }
		[Required, JsonPropertyName("cedula")]
		public string Cedula { get; set; }
		[JsonPropertyName("telefono")]
		public string Telefono { get; set; }
		[Required(ErrorMessage = "Correo no puede estar vacío"),
			EmailAddress(ErrorMessage = "Correo no es válido"),
			JsonPropertyName("correo")]
		public string Correo { get; set; }
		[JsonPropertyName("url_foto_perfil")]
		public string URLFotoPerfil { get; set; }

		[JsonPropertyName("cursos")]
		public ICollection<Course> Cursos { get; set; }
	}
}
