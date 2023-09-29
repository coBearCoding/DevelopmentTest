using DekstopTest.Server.Entities;
using Microsoft.EntityFrameworkCore;

namespace DekstopTest.Server.DAL.Course
{
	public class CourseRepository : ICourseRepository
	{
		private readonly ClientContext _clientContext;
        public CourseRepository(ClientContext clientContext)
        {
			_clientContext = clientContext;
        }
        public async Task<List<Models.Course>?> GetCoursesByClientIDAsync(int client_id)
		{
			var courses = await _clientContext.Cursos.Where(x => x.IDCliente == client_id).ToListAsync();
			if(courses.Count() == 0)
			{
				return null;
			}
			return courses;
		}

		public async Task<Models.Course> SaveCourse(Models.CourseRequest courseRequest)
		{
			var course = new Models.Course
			{
				Nombre = courseRequest.Nombre,
				IDCliente = courseRequest.IDCliente,
			};

			await _clientContext.AddAsync(course);

			await _clientContext.SaveChangesAsync();

			

			return course;
		}
	}
}
