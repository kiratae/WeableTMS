﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Weable.TMS.Model.Models;

namespace Weable.TMS.Model.ServiceModel
{
    public interface ICourseService
    {
        IEnumerable<Course> GetList();
        Task<Course> GetData(int? courseId);
        Task<Course> SaveData(Course course);
        Task<bool> DeleteData(int? courseId);
    }
}
