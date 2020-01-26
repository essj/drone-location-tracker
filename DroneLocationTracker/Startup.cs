using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System.Reflection;

namespace DroneLocationTracker
{
	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		public void ConfigureServices(IServiceCollection services)
		{
			services.AddAutoMapper(Assembly.GetAssembly(typeof(Startup)));

			services.AddSwaggerGen(c =>
			{
				c.SwaggerDoc("v1", new OpenApiInfo
				{
					Title = "Drone Location Tracker API",
					Version = "v1",
				});
			});

			services.AddMvc(options =>
			{
				options.EnableEndpointRouting = false;
			})
				.SetCompatibilityVersion(CompatibilityVersion.Version_3_0);
		}

		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}
			else
			{
				app.UseExceptionHandler("/Error");
				app.UseHsts();
			}

			app.UseHttpsRedirection();

			var automapperConfiguration = app.ApplicationServices.GetRequiredService<AutoMapper.IConfigurationProvider>();
			automapperConfiguration.AssertConfigurationIsValid();

			app.UseMvc();

			app.UseSwagger();

			app.UseSwaggerUI(c =>
			{
				c.SwaggerEndpoint("/swagger/v1/swagger.json", "Drone Location Tracker API V1");
			});
		}
	}
}
