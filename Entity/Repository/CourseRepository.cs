﻿using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Weable.TMS.Model.Data;
using Weable.TMS.Model.RepositoryModel;

namespace Weable.TMS.Entity.Repository
{
    public class CourseRepository : BaseRepository, ICourseRepository
    {
        private readonly TMSDBContext _context;
        private readonly ILogger<ICourseRepository> _logger;
        public CourseRepository(TMSDBContext context, ILogger<ICourseRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        public IEnumerable<Course> GetList()
        {
            const string func = "GetList";
            _logger.LogTrace("{}: Entering {}.", func, func);
            try
            {
                List<Course> list = new List<Course>();
                list.AddRange(_context.Course.ToList());

                return list;
            }
            catch (Exception ex)
            {
                _logger.LogInformation("{}: Exception caught.", func, ex);
                throw ex;
            }
        }

        public async Task<Course> GetData(int? courseId)
        {
            const string func = "GetData";
            _logger.LogTrace("{}: Entering {}.", func, func);
            try
            {
                return await _context.Course.FindAsync(courseId);
            }
            catch (Exception ex)
            {
                _logger.LogInformation("{}: Exception caught.", func, ex);
                throw ex;
            }
        }

        public async Task<Course> SaveData(Course course)
        {
            const string func = "SaveData";
            _logger.LogTrace("{}: Entering {}.", func, func);
            try
            {
                if (course.CourseId == 0)
                {
                    _context.Course.Add(course);
                    await _context.SaveChangesAsync();
                }
                else
                {
                    _context.Course.Update(course);
                    await _context.SaveChangesAsync();
                }
                return course;
            }
            catch (Exception ex)
            {
                _logger.LogInformation("{}: Exception caught.", func, ex);
                throw ex;
            }
        }

        public async Task<bool> DeleteData(int? courseId)
        {
            const string func = "DeleteData";
            _logger.LogTrace("{}: Entering {}.", func, func);
            try
            {
                var course = await _context.Course.FindAsync(courseId);
                _context.Course.Remove(course);
                await _context.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {
                _logger.LogInformation("{}: Exception caught.", func, ex);
                throw ex;
            }
        }

    }
}
