using DekstopTest.Server.DAL.Client;
using DekstopTest.Server.DAL.Course;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace DekstopTest.Server.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class CourseController : Controller
	{
		private readonly ICourseRepository _courseRepository;

		public CourseController(ICourseRepository courseRepository)
		{
			_courseRepository = courseRepository;
		}

		[HttpGet, Route("{client_id}")]
		public async Task<ActionResult<List<Models.Course>>> GetCourses(int client_id)
		{
			List<Models.Course?> courses = await _courseRepository.GetCoursesByClientIDAsync(client_id);
			if (courses.IsNullOrEmpty())
			{
				return NotFound("Cursos no registrados");
			}
			return Ok(courses);
		}


		[HttpPost, Route("save")]
		public async Task<ActionResult<Models.CourseResponse>> SaveCourse([FromBody] Models.CourseRequest courseRequest)
		{
			Models.Course course = await _courseRepository.SaveCourse(courseRequest);

			return new ObjectResult(course)
			{
				StatusCode = StatusCodes.Status201Created,
			};
		}
	}
}
