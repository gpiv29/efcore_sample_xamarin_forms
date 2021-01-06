using Autofac;
using EFCoreSampleXamarinForms.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace EFCoreSampleXamarinForms.Data
{
	public class CustomDBContext : DbContext
	{

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			var dbPath = AppContainer.GlobalContainer.Resolve<IFileHelper>().GetLocalFilePath("testDB.db");
			optionsBuilder.UseSqlite($"Filename={dbPath}");
			optionsBuilder.UseLoggerFactory(new DbContextLoggerFactory());
			optionsBuilder.EnableSensitiveDataLogging();
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<TestModel>(entity =>
			{
				entity.ToTable("test_model");
				entity.HasKey(e => e.TestModelId).HasName("test_model_pk");
				entity.Property(e => e.TestModelId).HasColumnName("test_model_id");
				entity.Property(e => e.TestModelName).HasColumnName("test_model_name");
				entity.Property(e => e.Description).HasColumnName("description");
				entity.Property(e => e.Height).HasColumnName("height");
				entity.Property(e => e.Width).HasColumnName("width");
			});

			modelBuilder.Entity<FirstChild>(entity =>
			{
				entity.ToTable("first_child");
				entity.HasKey(e => e.FirstChildId).HasName("first_child_pk");
				entity.Property(e => e.FirstChildId).HasColumnName("first_child_id");
				entity.Property(e => e.FirstChildName).HasColumnName("first_child_name");
				entity.Property(e => e.TestModelId).HasColumnName("test_model_id");
				entity.Property(e => e.Description).HasColumnName("description");
				entity.Property(e => e.Height).HasColumnName("height");
				entity.Property(e => e.Width).HasColumnName("width");
				entity.HasOne(e => e.TestModel).WithMany(e => e.FirstChildren).HasForeignKey(e => e.FirstChildId).HasConstraintName("test_model_first_child");
			});

			modelBuilder.Entity<SecondChild>(entity =>
			{
				entity.ToTable("second_child");
				entity.HasKey(e => e.SecondChildId).HasName("second_child_pk");
				entity.Property(e => e.SecondChildId).HasColumnName("second_child_id");
				entity.Property(e => e.SecondChildName).HasColumnName("second_child_name");
				entity.Property(e => e.TestModelId).HasColumnName("test_model_id");
				entity.Property(e => e.Description).HasColumnName("description");
				entity.Property(e => e.Height).HasColumnName("height");
				entity.Property(e => e.Width).HasColumnName("width");
				entity.HasOne(e => e.TestModel).WithMany(e => e.SecondChildren).HasForeignKey(e => e.SecondChildId).HasConstraintName("test_model_second_child");
			});
		}

		#region DbSets
		public DbSet<TestModel> TestModels { get; set; }
		public DbSet<FirstChild> FirstChildren { get; set; }
		public DbSet<SecondChild> SecondChildren { get; set; }

		#endregion
	}
}
