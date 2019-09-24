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
    public class PersonRepositoryTest
    {
        private readonly IPersonRepository _repo; 

        public PersonRepositoryTest()
        {
            var services = new ServiceCollection();
            services.AddDbContext<TMSDBContext>(option =>
                option.UseMySql("Server=localhost;Database=training_db;User=root;TreatTinyAsBoolean=false",
                mySqlOptions =>
                {
                    mySqlOptions.ServerVersion(new Version(10, 1, 37), ServerType.MariaDb)
                    .DisableBackslashEscaping();
                }));
            services.AddTransient<IPersonRepository, PersonRepository>();

            var serviceProvider = services.BuildServiceProvider();

            _repo = serviceProvider.GetService<IPersonRepository>();
        }

        [TestMethod]
        public void GetList()
        {
            IList<Person> result = _repo.GetList(new PersonFilter(), null).Results;

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public async Task CRUD()
        {
            // Create
            var person = new Person()
            {
                CitizenId = "unit-test",
                FirstName = "unit-test",
                LastName = "unit-test"
            };
            person = await _repo.SaveData(person);
            Assert.IsNotNull(person);

            // Read
            person = await _repo.GetData(person.PersonId);
            Assert.IsNotNull(person);

            // Update
            string updateText = "updated";
            person.FirstName = updateText;
            person = await _repo.SaveData(person);
            Assert.AreEqual(updateText, person.FirstName);

            // Delete
            bool isDeletd = await _repo.DeleteData(person.PersonId);
            Assert.IsTrue(isDeletd);
        }
    }
}
