using Autofac;
using EFCoreSampleXamarinForms.Data;
using EFCoreSampleXamarinForms.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Z.EntityFramework.Plus;

namespace EFCoreSampleXamarinForms
{
	public static class TestHelper
	{

		public static async void RunTests()
		{
			TruncateDB();
			await InsertTestData(100000);

			await IncludeOptimizedTest();

			await UpdateFromQueryTest();
			await UpdateFromQueryAsyncTest();

			await DeleteFromQueryAsyncTest();
		}

		private static void TruncateDB()
		{
			Debug.WriteLine($"Truncating db");
			var dbContextFactory = AppContainer.GlobalContainer.Resolve<CustomDBContextFactory>();

			using (var dbContext = dbContextFactory.CreateDbContext(new string[] { }))
			{
				dbContext.Database.ExecuteSqlRaw("DELETE FROM first_child;");
				dbContext.Database.ExecuteSqlRaw("DELETE FROM second_child;");
				dbContext.Database.ExecuteSqlRaw("DELETE FROM test_model;");
			}
		}

		public static async Task InsertTestData(int count)
		{
			Debug.WriteLine($"Begin inserting {count} TestModels to the db");
			var dbContextFactory = AppContainer.GlobalContainer.Resolve<CustomDBContextFactory>();

			int batch;
			var stopwatch = new Stopwatch();
			stopwatch.Start();
			while (count > 0)
			{
				batch = count > 5000 ? 5000 : count;

				var modelList = new List<TestModel>();
				var firstChildList = new List<FirstChild>();

				for (int i = 0; i < batch; i++)
				{

					var testModel = new TestModel()
					{
						TestModelName = "Test Name",
						Description = "Test Description",
						Height = i,
						Width = i,
						TestModelId = count - i + 1
					};

					var firstChild = new FirstChild
					{
						FirstChildName = "First Child Name",
						Description = "First Child Description",
						Height = i,
						Width = i,
						TestModelId = count - i + 1,
						FirstChildId = count - i + 1
					};

					modelList.Add(testModel);
					firstChildList.Add(firstChild);
				}

				using (var dbContext = dbContextFactory.CreateDbContext(new string[] { }))
				{
					dbContext.TestModels.AddRange(modelList);
					dbContext.FirstChildren.AddRange(firstChildList);
					await dbContext.SaveChangesAsync();
				}

				Debug.WriteLine($"{count} more to insert...");
				count -= batch;
			}

			Debug.WriteLine($"Finished inserting testmodels: {stopwatch.Elapsed}");
		}

		public static async Task<List<TestModel>> IncludeOptimizedTest(){
			Debug.WriteLine($"Retrieving some TestModels from the db. Uses IncludeOptimized");
			var dbContextFactory = AppContainer.GlobalContainer.Resolve<CustomDBContextFactory>();

			using (var dbContext = dbContextFactory.CreateDbContext(new string[] { }))
			{
				var query = dbContext.TestModels
						.Where(e => e.TestModelId < 50)
						.AsQueryable();

				query = query.IncludeOptimized(e => e.FirstChildren).AsQueryable();

				var result = await query.AsNoTracking().ToListAsync(); // UWP: "InvalidOperationException: the source IQueryable doesn't implement IAsyncEnumerable<TestModel> ..."
				return result;
			}
		}

		public static async Task UpdateFromQueryTest()
		{
			Debug.WriteLine($"Updating first children using UpdateFromQuery");
			var dbContextFactory = AppContainer.GlobalContainer.Resolve<CustomDBContextFactory>();

			using (var dbContext = dbContextFactory.CreateDbContext(new string[] { }))
			{
				dbContext.FirstChildren
					.Where(e => e.Height < 100)
					.UpdateFromQuery(e => new FirstChild { Description = "Short first child" });
			}
		}

		public static async Task UpdateFromQueryAsyncTest()
		{
			Debug.WriteLine($"Updating first children using UpdateFromQueryAsync");
			var dbContextFactory = AppContainer.GlobalContainer.Resolve<CustomDBContextFactory>();

			using (var dbContext = dbContextFactory.CreateDbContext(new string[] { }))
			{
				await dbContext.FirstChildren
					.Where(e => e.Height > 4000)
					.UpdateFromQueryAsync(e => new FirstChild { Description = "Tall first child" });
			}
		}

		public static async Task DeleteFromQueryAsyncTest()
		{
			Debug.WriteLine($"Deleting first children using DeleteFromQueryAsync");
			var dbContextFactory = AppContainer.GlobalContainer.Resolve<CustomDBContextFactory>();

			using (var dbContext = dbContextFactory.CreateDbContext(new string[] { }))
			{
				await dbContext.FirstChildren
					.Where(e => e.Height == 999)
					.DeleteFromQueryAsync();
			}
		}
	}
}
