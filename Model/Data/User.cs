using System;
using System.Collections.Generic;

namespace Weable.TMS.Model.Data
{
    public partial class User
    {
        public User()
        {
            CourseCreateUser = new HashSet<Course>();
            CourseModifyUser = new HashSet<Course>();
            DistrictCreateUser = new HashSet<District>();
            DistrictModifyUser = new HashSet<District>();
            FacultyCreateUser = new HashSet<Faculty>();
            FacultyModifyUser = new HashSet<Faculty>();
            InverseModifyUser = new HashSet<User>();
            Log = new HashSet<Log>();
            ProvinceCreateUser = new HashSet<Province>();
            ProvinceModifyUser = new HashSet<Province>();
            RegionCreateUser = new HashSet<Region>();
            RegionModifyUser = new HashSet<Region>();
            RoleMember = new HashSet<RoleMember>();
            SecurablePermission = new HashSet<SecurablePermission>();
            SubdistrictCreateUser = new HashSet<Subdistrict>();
            SubdistrictModifyUser = new HashSet<Subdistrict>();
            TitleCreateUser = new HashSet<Title>();
            TitleModifyUser = new HashSet<Title>();
            TrainingCreateUser = new HashSet<Training>();
            TrainingModifyUser = new HashSet<Training>();
            TrnSatisfactionQuestionCreateUser = new HashSet<TrnSatisfactionQuestion>();
            TrnSatisfactionQuestionModifyUser = new HashSet<TrnSatisfactionQuestion>();
            UniversityCourseCreateUser = new HashSet<UniversityCourse>();
            UniversityCourseModifyUser = new HashSet<UniversityCourse>();
            UniversityCreateUser = new HashSet<University>();
            UniversityModifyUser = new HashSet<University>();
        }

        public int UserId { get; set; }
        public string Name { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Data { get; set; }
        public string Note { get; set; }
        public sbyte IsActive { get; set; }
        public sbyte IsSystem { get; set; }
        public string Title { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int PersonId { get; set; }
        public int? FacultyId { get; set; }
        public sbyte IsPwdExpired { get; set; }
        public DateTime PwdModifyDate { get; set; }
        public DateTime CreateDate { get; set; }
        public int CreateUserId { get; set; }
        public DateTime? ModifyDate { get; set; }
        public int? ModifyUserId { get; set; }

        public virtual Faculty Faculty { get; set; }
        public virtual User ModifyUser { get; set; }
        public virtual ICollection<Course> CourseCreateUser { get; set; }
        public virtual ICollection<Course> CourseModifyUser { get; set; }
        public virtual ICollection<District> DistrictCreateUser { get; set; }
        public virtual ICollection<District> DistrictModifyUser { get; set; }
        public virtual ICollection<Faculty> FacultyCreateUser { get; set; }
        public virtual ICollection<Faculty> FacultyModifyUser { get; set; }
        public virtual ICollection<User> InverseModifyUser { get; set; }
        public virtual ICollection<Log> Log { get; set; }
        public virtual ICollection<Province> ProvinceCreateUser { get; set; }
        public virtual ICollection<Province> ProvinceModifyUser { get; set; }
        public virtual ICollection<Region> RegionCreateUser { get; set; }
        public virtual ICollection<Region> RegionModifyUser { get; set; }
        public virtual ICollection<RoleMember> RoleMember { get; set; }
        public virtual ICollection<SecurablePermission> SecurablePermission { get; set; }
        public virtual ICollection<Subdistrict> SubdistrictCreateUser { get; set; }
        public virtual ICollection<Subdistrict> SubdistrictModifyUser { get; set; }
        public virtual ICollection<Title> TitleCreateUser { get; set; }
        public virtual ICollection<Title> TitleModifyUser { get; set; }
        public virtual ICollection<Training> TrainingCreateUser { get; set; }
        public virtual ICollection<Training> TrainingModifyUser { get; set; }
        public virtual ICollection<TrnSatisfactionQuestion> TrnSatisfactionQuestionCreateUser { get; set; }
        public virtual ICollection<TrnSatisfactionQuestion> TrnSatisfactionQuestionModifyUser { get; set; }
        public virtual ICollection<UniversityCourse> UniversityCourseCreateUser { get; set; }
        public virtual ICollection<UniversityCourse> UniversityCourseModifyUser { get; set; }
        public virtual ICollection<University> UniversityCreateUser { get; set; }
        public virtual ICollection<University> UniversityModifyUser { get; set; }
    }
}
