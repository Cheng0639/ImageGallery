﻿using System;
using Microsoft.EntityFrameworkCore;

namespace SimpleImageGallery.Data
{
	public class SimpleImageGalleryContext : DbContext
	{
		public SimpleImageGalleryContext( DbContextOptions options ) : base( options )
		{

		}

		public DbSet<GalleryImage> GalleryImages { get; set; }

		public DbSet<ImageTag> ImageTags { get; set; }

	}
}
