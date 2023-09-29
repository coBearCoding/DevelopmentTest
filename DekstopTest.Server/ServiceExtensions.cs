﻿using DekstopTest.Server.DAL.Client;
using DekstopTest.Server.DAL.Client.ClientRepository;
using DekstopTest.Server.DAL.Course;
using DekstopTest.Server.Entities;

namespace DekstopTest.Server
{
	public static class ServiceExtensions
	{
		public static void ConfigureDBContexts(this IServiceCollection services)
		{
			services.AddDbContext<ClientContext>();
		}

		public static void ConfigureDAL(this IServiceCollection services)
		{
			services.AddScoped<IClientRepository, ClientRepository>();
			services.AddScoped<ICourseRepository, CourseRepository>();
		}
	}
}
