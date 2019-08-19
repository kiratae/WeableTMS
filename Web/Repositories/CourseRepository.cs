using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Weable.TMS.Model.Models;

namespace Weable.TMS.Web.Repositories
{
    public class CourseRepository : BaseRepository
    {
        private readonly TMSDBContext context;
        public CourseRepository(TMSDBContext context)
        {
            this.context = context;
        }

        public List<Course> GetList()
        {
            List<Course> list = new List<Course>();
            try
            {
                var temp = context.Course.ToList();
                list.AddRange(temp);
            }
            catch (Exception ex)
            {

            }
            return list;
        }

        public Course SaveData(Course course)
        {
            //context.Database.BeginTransaction();
            using (var locaContext = context)
            {
                try
                {
                    Course courseContext = new Course();
                    courseContext.Code = course.Code;
                    courseContext.Name = course.Name;
                    courseContext.IsActive = course.IsActive;
                    courseContext.CreateDate = course.CreateDate;
                    courseContext.CreateUserId = course.CreateUserId;
                    courseContext.ModifyDate = course.ModifyDate;
                    courseContext.ModifyUserId = course.ModifyUserId;
                    locaContext.Course.Add(courseContext);
                    locaContext.SaveChanges();

                    //context.Database.CommitTransaction();
                }
                catch (Exception ex)
                {
                    //context.Database.RollbackTransaction();
                }
                return course;
            }
        }
    }
}
