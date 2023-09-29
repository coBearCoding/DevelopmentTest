namespace DekstopTest.Server.DAL.Course
{
	public interface ICourseRepository
	{
		Task<List<Models.Course>?> GetCoursesByClientIDAsync(int client_id);
		Task<Models.Course> SaveCourse(Models.CourseRequest courseRequest);
	}
}
