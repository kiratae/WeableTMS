using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Weable.TMS.Model.Models;
using Weable.TMS.Web.Repositories;

namespace Weable.TMS.UnitTest
{
    [TestClass]
    public class CourseRepositoryTest
    {
        private TMSDBContext context = new TMSDBContext();
        [TestMethod]
        public void GetList()
        {
            //CourseRepository repo = new CourseRepository(context);
            //Course course = new Course();
            //List<Course> result = repo.GetList();

            //Assert.IsNotNull(result);
        }
    }
}
