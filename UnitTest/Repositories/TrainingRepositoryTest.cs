using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
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
    public class TrainingRepositoryTest
    {
        private readonly ITrainingRepository _repo; 

        public TrainingRepositoryTest()
        {
            var services = new ServiceCollection();
            services.AddDbContext<TMSDBContext>(option =>
                option.UseMySql("Server=localhost;Database=training_db;User=root;TreatTinyAsBoolean=false",
                mySqlOptions =>
                {
                    mySqlOptions.ServerVersion(new Version(10, 1, 37), ServerType.MariaDb)
                    .DisableBackslashEscaping();
                }));
            services.AddTransient<ITrainingRepository, TrainingRepository>();

            var serviceProvider = services.BuildServiceProvider();

            _repo = serviceProvider.GetService<ITrainingRepository>();
        }

        [TestMethod]
        public void GetList()
        {
            // no filter
            IList<Training> result = _repo.GetList(new TrainingFilter(), null).Results;
            Assert.IsNotNull(result);

            // filter with course id = 1
            result = _repo.GetList(new TrainingFilter() { CourseId = 1 }, null).Results;
            Assert.IsNotNull(result);
        }

    }
}
