using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace DekstopTest.Server.Models
{
	[Table("CLIENTE")]
	public class Client
	{

		[Key, Column("ID")]
		public int ID { get; set; }
		[Required, Column("NOMBRE")]
		public string Nombre { get; set; }
		[Column("APELLIDO")]
		public string Apellido { get; set; }
		[Required, MinLength(10, ErrorMessage = "La cédula es inválida"), Column("CEDULA")]
		public string Cedula { get; set; }
		[Column("TELEFONO")]
		public string Telefono { get; set; }
		[Required(ErrorMessage = "Correo no puede estar vacío"),
			EmailAddress(ErrorMessage = "Correo no es válido"), Column("CORREO")]
		public string Correo { get; set; }
		[Column("URL_FOTO_PERFIL")]
		public string URLFotoPerfil { get; set; }

		//[ForeignKey("Cursos"), Column("ID_CURSO")]
		//[Column("ID_CURSO")]
		//public int IDCourse { get; set; }

		//public ICollection<Course> Cursos { get; set; }
		public ICollection<Course> Cursos { get; set; }
	}


	public class ClientRequest
	{
		[Required]
		public string Nombre { get; set; }
		[Required]
		public string Apellido { get; set; }
		[Required, MinLength(10, ErrorMessage = "La cédula es inválida"), MaxLength(10, ErrorMessage = "La cédula es inválida")]
		public string Cedula { get; set; }
		[MaxLength(10, ErrorMessage = "Teléfono inválido")]
		public string Telefono { get; set; }
		[Required(ErrorMessage = "Correo no puede estar vacío"),
			EmailAddress(ErrorMessage = "Correo no es válido")]
		public string Correo { get; set; }
		[JsonPropertyName("url_foto_perfil")]
		public string URLFotoPerfil { get; set; }

		//[Required, JsonPropertyName("id_curso")]
		//public int IDCourse { get; set; }
		

	}


	public class ClientResponse
	{
		public string Nombre { get; set; }
		public string Apellido { get; set; }
		public string Cedula { get; set; }
		public string Telefono { get; set; }
		public string Correo { get; set; }
		[JsonPropertyName("url_foto_perfil")]
		public string URLFotoPerfil { get; set; }

		public ICollection<Course> Cursos { get; set; }
	}
}
