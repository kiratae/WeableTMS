using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Weable.TMS.Entity.Repository;
using Weable.TMS.Model.Data;
using Weable.TMS.Model.Filter;
using Weable.TMS.Model.RepositoryModel;

namespace Weable.TMS.UnitTest
{
    [TestClass]
    public class CourseRepositoryTest
    {
        private readonly ICourseRepository _repo;

        public CourseRepositoryTest()
        {
            var services = new ServiceCollection();
            services.AddDbContext<TMSDBContext>(option =>
                option.UseMySql("Server=localhost;Database=training_db;User=root;TreatTinyAsBoolean=false",
                mySqlOptions =>
                {
                    mySqlOptions.ServerVersion(new Version(10, 1, 37), ServerType.MariaDb)
                    .DisableBackslashEscaping();
                }));
            services.AddTransient<ICourseRepository, CourseRepository>();

            var serviceProvider = services.BuildServiceProvider();

            _repo = serviceProvider.GetService<ICourseRepository>();
        }

        [TestMethod]
        public void GetList()
        {
            IList<Course> result = _repo.GetList(new CourseFilter(), null).Results;

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public async Task CRUD()
        {
            // Create
            var course = new Course()
            {
                Name = "unit-test",
                IsActive = 0,
                CreateDate = DateTime.Now,
                CreateUserId = 0
            };
            course = await _repo.SaveData(course);
            Assert.IsNotNull(course);

            // Read
            course = await _repo.GetData(course.CourseId);
            Assert.IsNotNull(course);

            // Update
            string updateText = "updated";
            course.Name = updateText;
            course = await _repo.SaveData(course);
            Assert.AreEqual(updateText, course.Name);

            // Delete
            bool isDeletd = await _repo.DeleteData(course.CourseId);
            Assert.IsTrue(isDeletd);
        }
    }
}
