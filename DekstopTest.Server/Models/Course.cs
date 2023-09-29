using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace DekstopTest.Server.Models
{
	[Table("CURSO")]
	public class Course
	{
		[Key, Column("ID")]
		public int ID { get; set; }
		[Required, Column("NOMBRE")]
		public string Nombre { get; set; }

		[Required, Column("ID_CLIENTE")]
		public int IDCliente { get; set; }

		public ICollection<Client> Clientes { get; set; }
	}


	public class CourseRequest
	{
		[Required]
		public string Nombre { get; set; }
		[Required, JsonPropertyName("id_cliente")]
		public int IDCliente { get; set; }
	}

	public class CourseResponse
	{
		public int ID { get; set; }
		public string Nombre { get; set; }
		[Required, JsonPropertyName("id_cliente")]
		public int IDCliente { get; set; }
	}
}
