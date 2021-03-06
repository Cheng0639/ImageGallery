﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SimpleImageGallery.Data;
using SimpleImageGallery.Service;

namespace SimpleImageGallery
{
	public class Startup
	{
		public Startup( IConfiguration configuration )
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices( IServiceCollection services )
		{
			services.AddDbContext<SimpleImageGalleryContext>( option => {
				option.UseSqlServer( Configuration.GetConnectionString( "DefaultConnectionString" ) );
			} );

			services.AddScoped<IImage, ImageService>( );

			services.AddMvc( );
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure( IApplicationBuilder app, IHostingEnvironment env )
		{
			if( env.IsDevelopment( ) ) {
				app.UseBrowserLink( );
				app.UseDeveloperExceptionPage( );
			} else {
				app.UseExceptionHandler( "/Home/Error" );
			}

			app.UseStaticFiles( );

			app.UseMvc( routes => {
				routes.MapRoute(
					name: "default",
					template: "{controller=Gallery}/{action=Index}/{id?}" );
			} );
		}
	}
}
