using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace DesktopTest.Client.Data.Models
{
	public class Course
	{
		[Key]
		public int ID { get; set; }
		[Required]
		public string Nombre { get; set; }

		[Required, JsonPropertyName("id_cliente")]
		public int IDCliente { get; set; }
	}
}
