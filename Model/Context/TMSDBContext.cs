using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Weable.TMS.Model.Data
{
    public partial class TMSDBContext : DbContext
    {
        public TMSDBContext()
        {
        }

        public TMSDBContext(DbContextOptions<TMSDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Attendee> Attendee { get; set; }
        public virtual DbSet<ConfigSection> ConfigSection { get; set; }
        public virtual DbSet<Configuration> Configuration { get; set; }
        public virtual DbSet<Course> Course { get; set; }
        public virtual DbSet<District> District { get; set; }
        public virtual DbSet<Faculty> Faculty { get; set; }
        public virtual DbSet<File> File { get; set; }
        public virtual DbSet<Log> Log { get; set; }
        public virtual DbSet<Person> Person { get; set; }
        public virtual DbSet<Province> Province { get; set; }
        public virtual DbSet<Reference> Reference { get; set; }
        public virtual DbSet<Region> Region { get; set; }
        public virtual DbSet<Sequence> Sequence { get; set; }
        public virtual DbSet<SequencePeriod> SequencePeriod { get; set; }
        public virtual DbSet<Subdistrict> Subdistrict { get; set; }
        public virtual DbSet<Title> Title { get; set; }
        public virtual DbSet<Training> Training { get; set; }
        public virtual DbSet<TrnCoordinator> TrnCoordinator { get; set; }
        public virtual DbSet<TrnDoc> TrnDoc { get; set; }
        public virtual DbSet<TrnImgOther> TrnImgOther { get; set; }
        public virtual DbSet<TrnPrerequisite> TrnPrerequisite { get; set; }
        public virtual DbSet<TrnResponsible> TrnResponsible { get; set; }
        public virtual DbSet<TrnSatisfactionAnswer> TrnSatisfactionAnswer { get; set; }
        public virtual DbSet<TrnSatisfactionForm> TrnSatisfactionForm { get; set; }
        public virtual DbSet<TrnSatisfactionFormCh2> TrnSatisfactionFormCh2 { get; set; }
        public virtual DbSet<TrnSatisfactionQuestion> TrnSatisfactionQuestion { get; set; }
        public virtual DbSet<University> University { get; set; }
        public virtual DbSet<UniversityCourse> UniversityCourse { get; set; }
        public virtual DbSet<User> User { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseMySql("Server=localhost;Database=training_db;User=root;TreatTinyAsBoolean=false");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Attendee>(entity =>
            {
                entity.ToTable("attendee");

                entity.HasIndex(e => e.PersonId)
                    .HasName("fk_Attendee_Person1_idx");

                entity.HasIndex(e => e.TrainingId)
                    .HasName("fk_Attendee_Training1_idx");

                entity.Property(e => e.AttendeeId)
                    .HasColumnName("attendee_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.AtdStatusId)
                    .HasColumnName("atd_status_id")
                    .HasColumnType("tinyint(4)");

                entity.Property(e => e.CitizenId)
                    .IsRequired()
                    .HasColumnName("citizen_id")
                    .HasColumnType("varchar(13)");

                entity.Property(e => e.PersonId)
                    .HasColumnName("person_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.TrainingId)
                    .HasColumnName("training_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.TrainingResultId)
                    .HasColumnName("training_result_id")
                    .HasColumnType("tinyint(4)");

                entity.HasOne(d => d.Person)
                    .WithMany(p => p.Attendee)
                    .HasForeignKey(d => d.PersonId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Attendee_Person1");

                entity.HasOne(d => d.Training)
                    .WithMany(p => p.Attendee)
                    .HasForeignKey(d => d.TrainingId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Attendee_Training1");
            });

            modelBuilder.Entity<ConfigSection>(entity =>
            {
                entity.ToTable("config_section");

                entity.HasIndex(e => e.Name)
                    .HasName("UC_Name")
                    .IsUnique();

                entity.Property(e => e.ConfigSectionId)
                    .HasColumnName("config_section_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasColumnType("varchar(100)");
            });

            modelBuilder.Entity<Configuration>(entity =>
            {
                entity.ToTable("configuration");

                entity.HasIndex(e => e.ConfigSectionId)
                    .HasName("IX_ConfigSectionId");

                entity.HasIndex(e => new { e.ConfigSectionId, e.Name })
                    .HasName("UX_ConfigSectionId_Name")
                    .IsUnique();

                entity.Property(e => e.ConfigurationId)
                    .HasColumnName("configuration_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.ConfigSectionId)
                    .HasColumnName("config_section_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.DataType).HasColumnName("data_type");

                entity.Property(e => e.DefaultValue)
                    .HasColumnName("default_value")
                    .HasColumnType("text");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.OrderNo)
                    .HasColumnName("order_no")
                    .HasColumnType("smallint(6)");

                entity.Property(e => e.Value)
                    .HasColumnName("value")
                    .HasColumnType("text");

                entity.HasOne(d => d.ConfigSection)
                    .WithMany(p => p.Configuration)
                    .HasForeignKey(d => d.ConfigSectionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Configuration_ConfigSection");
            });

            modelBuilder.Entity<Course>(entity =>
            {
                entity.ToTable("course");

                entity.HasIndex(e => e.CreateUserId)
                    .HasName("FK_Course_User_idx");

                entity.HasIndex(e => e.ModifyUserId)
                    .HasName("FK_Course_User_2_idx");

                entity.Property(e => e.CourseId)
                    .HasColumnName("course_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasColumnName("code")
                    .HasColumnType("varchar(7)");

                entity.Property(e => e.CreateDate)
                    .HasColumnName("create_date")
                    .HasColumnType("datetime");

                entity.Property(e => e.CreateUserId)
                    .HasColumnName("create_user_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.IsActive)
                    .HasColumnName("is_active")
                    .HasColumnType("tinyint(1)");

                entity.Property(e => e.ModifyDate)
                    .HasColumnName("modify_date")
                    .HasColumnType("datetime");

                entity.Property(e => e.ModifyUserId)
                    .HasColumnName("modify_user_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasColumnType("varchar(200)");

                entity.HasOne(d => d.CreateUser)
                    .WithMany(p => p.CourseCreateUser)
                    .HasForeignKey(d => d.CreateUserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Course_User");

                entity.HasOne(d => d.ModifyUser)
                    .WithMany(p => p.CourseModifyUser)
                    .HasForeignKey(d => d.ModifyUserId)
                    .HasConstraintName("FK_Course_User_2");
            });

            modelBuilder.Entity<District>(entity =>
            {
                entity.ToTable("district");

                entity.HasIndex(e => e.CreateUserId)
                    .HasName("FK_District_User_idx");

                entity.HasIndex(e => e.ModifyUserId)
                    .HasName("FK_District_User_2_idx");

                entity.HasIndex(e => e.ProvinceId)
                    .HasName("FK_District_Province_idx");

                entity.Property(e => e.DistrictId)
                    .HasColumnName("district_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Code)
                    .HasColumnName("code")
                    .HasColumnType("varchar(20)");

                entity.Property(e => e.CreateDate)
                    .HasColumnName("create_date")
                    .HasColumnType("datetime");

                entity.Property(e => e.CreateUserId)
                    .HasColumnName("create_user_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.GeoName)
                    .HasColumnName("geo_name")
                    .HasColumnType("varchar(200)");

                entity.Property(e => e.IsActive)
                    .HasColumnName("is_active")
                    .HasColumnType("tinyint(1)");

                entity.Property(e => e.ModifyDate)
                    .HasColumnName("modify_date")
                    .HasColumnType("datetime");

                entity.Property(e => e.ModifyUserId)
                    .HasColumnName("modify_user_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasColumnType("varchar(200)");

                entity.Property(e => e.Note)
                    .HasColumnName("note")
                    .HasColumnType("text");

                entity.Property(e => e.ProvinceId)
                    .HasColumnName("province_id")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.CreateUser)
                    .WithMany(p => p.DistrictCreateUser)
                    .HasForeignKey(d => d.CreateUserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_District_User");

                entity.HasOne(d => d.ModifyUser)
                    .WithMany(p => p.DistrictModifyUser)
                    .HasForeignKey(d => d.ModifyUserId)
                    .HasConstraintName("FK_District_User_2");

                entity.HasOne(d => d.Province)
                    .WithMany(p => p.District)
                    .HasForeignKey(d => d.ProvinceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_District_Province");
            });

            modelBuilder.Entity<Faculty>(entity =>
            {
                entity.ToTable("faculty");

                entity.HasIndex(e => e.CreateUserId)
                    .HasName("fk_faculty_user_idx");

                entity.HasIndex(e => e.ModifyUserId)
                    .HasName("fk_faculty_user2_idx");

                entity.HasIndex(e => e.UniversityId)
                    .HasName("fk_faculty_university_idx");

                entity.Property(e => e.FacultyId)
                    .HasColumnName("faculty_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.CreateDate)
                    .HasColumnName("create_date")
                    .HasColumnType("datetime");

                entity.Property(e => e.CreateUserId)
                    .HasColumnName("create_user_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.IsActive)
                    .HasColumnName("is_active")
                    .HasColumnType("tinyint(1)");

                entity.Property(e => e.ModifyDate)
                    .HasColumnName("modify_date")
                    .HasColumnType("datetime");

                entity.Property(e => e.ModifyUserId)
                    .HasColumnName("modify_user_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.NameEn)
                    .HasColumnName("name_en")
                    .HasColumnType("varchar(200)");

                entity.Property(e => e.NameTh)
                    .IsRequired()
                    .HasColumnName("name_th")
                    .HasColumnType("varchar(200)");

                entity.Property(e => e.Note)
                    .HasColumnName("note")
                    .HasColumnType("text");

                entity.Property(e => e.UniversityId)
                    .HasColumnName("university_id")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.CreateUser)
                    .WithMany(p => p.FacultyCreateUser)
                    .HasForeignKey(d => d.CreateUserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_faculty_user");

                entity.HasOne(d => d.ModifyUser)
                    .WithMany(p => p.FacultyModifyUser)
                    .HasForeignKey(d => d.ModifyUserId)
                    .HasConstraintName("fk_faculty_user2");

                entity.HasOne(d => d.University)
                    .WithMany(p => p.Faculty)
                    .HasForeignKey(d => d.UniversityId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_faculty_university");
            });

            modelBuilder.Entity<File>(entity =>
            {
                entity.ToTable("file");

                entity.Property(e => e.FileId)
                    .HasColumnName("file_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.CreateDate)
                    .HasColumnName("create_date")
                    .HasColumnType("datetime");

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasColumnType("varchar(500)");

                entity.Property(e => e.FileGuid)
                    .IsRequired()
                    .HasColumnName("file_guid")
                    .HasColumnType("varchar(40)");

                entity.Property(e => e.FileName)
                    .IsRequired()
                    .HasColumnName("file_name")
                    .HasColumnType("varchar(200)");

                entity.Property(e => e.FileSize)
                    .HasColumnName("file_size")
                    .HasColumnType("int(11)");

                entity.Property(e => e.IsTemp)
                    .HasColumnName("is_temp")
                    .HasColumnType("tinyint(1)");

                entity.Property(e => e.MimeType)
                    .IsRequired()
                    .HasColumnName("mime_type")
                    .HasColumnType("varchar(100)");
            });

            modelBuilder.Entity<Log>(entity =>
            {
                entity.ToTable("log");

                entity.HasIndex(e => e.LogResultId)
                    .HasName("IX_LogResultId");

                entity.HasIndex(e => e.LogTypeId)
                    .HasName("IX_LogTypeId");

                entity.HasIndex(e => e.UserId)
                    .HasName("IX_UserId");

                entity.Property(e => e.LogId)
                    .HasColumnName("log_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasColumnType("text");

                entity.Property(e => e.FacultyId)
                    .HasColumnName("faculty_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.ForwardedIp)
                    .HasColumnName("forwarded_ip")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.LogDate)
                    .HasColumnName("log_date")
                    .HasColumnType("datetime");

                entity.Property(e => e.LogResultId)
                    .HasColumnName("log_result_id")
                    .HasColumnType("tinyint(4)");

                entity.Property(e => e.LogTypeId)
                    .HasColumnName("log_type_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.RemoteIp)
                    .HasColumnName("remote_ip")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.UserId)
                    .HasColumnName("user_id")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Log)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_Log_User");
            });

            modelBuilder.Entity<Person>(entity =>
            {
                entity.ToTable("person");

                entity.HasIndex(e => e.SubdistrictId)
                    .HasName("FK_Person_Subdistrict_idx");

                entity.HasIndex(e => e.TitleId)
                    .HasName("FK_Person_Title_idx");

                entity.HasIndex(e => e.UniversityCourseId)
                    .HasName("fk_person_university_course_idx");

                entity.Property(e => e.PersonId)
                    .HasColumnName("person_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.AddressNo)
                    .HasColumnName("address_no")
                    .HasColumnType("varchar(20)");

                entity.Property(e => e.BirthDate)
                    .HasColumnName("birth_date")
                    .HasColumnType("datetime");

                entity.Property(e => e.Building)
                    .HasColumnName("building")
                    .HasColumnType("varchar(200)");

                entity.Property(e => e.CitizenId)
                    .IsRequired()
                    .HasColumnName("citizen_id")
                    .HasColumnType("varchar(13)");

                entity.Property(e => e.Community)
                    .HasColumnName("community")
                    .HasColumnType("varchar(200)");

                entity.Property(e => e.Email)
                    .HasColumnName("email")
                    .HasColumnType("varchar(200)");

                entity.Property(e => e.Facebook)
                    .HasColumnName("facebook")
                    .HasColumnType("varchar(200)");

                entity.Property(e => e.Fax)
                    .HasColumnName("fax")
                    .HasColumnType("varchar(10)");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasColumnName("first_name")
                    .HasColumnType("varchar(200)");

                entity.Property(e => e.GenderTypeId)
                    .HasColumnName("gender_type_id")
                    .HasColumnType("tinyint(4)");

                entity.Property(e => e.Landlines)
                    .HasColumnName("landlines")
                    .HasColumnType("varchar(20)");

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasColumnName("last_name")
                    .HasColumnType("varchar(200)");

                entity.Property(e => e.LineId)
                    .HasColumnName("line_id")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.MobilePhone)
                    .HasColumnName("mobile_phone")
                    .HasColumnType("varchar(10)");

                entity.Property(e => e.Moo)
                    .HasColumnName("moo")
                    .HasColumnType("varchar(10)");

                entity.Property(e => e.PostalCode)
                    .HasColumnName("postal_code")
                    .HasColumnType("varchar(5)");

                entity.Property(e => e.Road)
                    .HasColumnName("road")
                    .HasColumnType("varchar(200)");

                entity.Property(e => e.Soi)
                    .HasColumnName("soi")
                    .HasColumnType("varchar(200)");

                entity.Property(e => e.StudentCode)
                    .HasColumnName("student_code")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.SubdistrictId)
                    .HasColumnName("subdistrict_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.TitleId)
                    .HasColumnName("title_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.TitleNote)
                    .HasColumnName("title_note")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.TrainingAmount)
                    .HasColumnName("training_amount")
                    .HasColumnType("int(11)");

                entity.Property(e => e.UniversityCourseId)
                    .HasColumnName("university_course_id")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.Subdistrict)
                    .WithMany(p => p.Person)
                    .HasForeignKey(d => d.SubdistrictId)
                    .HasConstraintName("FK_Person_Subdistrict");

                entity.HasOne(d => d.Title)
                    .WithMany(p => p.Person)
                    .HasForeignKey(d => d.TitleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Person_Title");

                entity.HasOne(d => d.UniversityCourse)
                    .WithMany(p => p.Person)
                    .HasForeignKey(d => d.UniversityCourseId)
                    .HasConstraintName("fk_person_university_course");
            });

            modelBuilder.Entity<Province>(entity =>
            {
                entity.ToTable("province");

                entity.HasIndex(e => e.CreateUserId)
                    .HasName("FK_Province_User_idx");

                entity.HasIndex(e => e.ModifyUserId)
                    .HasName("FK_Province_User_2_idx");

                entity.HasIndex(e => e.RegionId)
                    .HasName("FK_Province_Region_idx");

                entity.Property(e => e.ProvinceId)
                    .HasColumnName("province_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Abbr)
                    .HasColumnName("abbr")
                    .HasColumnType("varchar(3)");

                entity.Property(e => e.Code)
                    .HasColumnName("code")
                    .HasColumnType("varchar(20)");

                entity.Property(e => e.CreateDate)
                    .HasColumnName("create_date")
                    .HasColumnType("datetime");

                entity.Property(e => e.CreateUserId)
                    .HasColumnName("create_user_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.GeoName)
                    .HasColumnName("geo_name")
                    .HasColumnType("varchar(200)");

                entity.Property(e => e.IsActive)
                    .HasColumnName("is_active")
                    .HasColumnType("tinyint(1)");

                entity.Property(e => e.ModifyDate)
                    .HasColumnName("modify_date")
                    .HasColumnType("datetime");

                entity.Property(e => e.ModifyUserId)
                    .HasColumnName("modify_user_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasColumnType("varchar(200)");

                entity.Property(e => e.Note)
                    .HasColumnName("note")
                    .HasColumnType("text");

                entity.Property(e => e.RegionId)
                    .HasColumnName("region_id")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.CreateUser)
                    .WithMany(p => p.ProvinceCreateUser)
                    .HasForeignKey(d => d.CreateUserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Province_User");

                entity.HasOne(d => d.ModifyUser)
                    .WithMany(p => p.ProvinceModifyUser)
                    .HasForeignKey(d => d.ModifyUserId)
                    .HasConstraintName("FK_Province_User_2");

                entity.HasOne(d => d.Region)
                    .WithMany(p => p.Province)
                    .HasForeignKey(d => d.RegionId)
                    .HasConstraintName("FK_Province_Region");
            });

            modelBuilder.Entity<Reference>(entity =>
            {
                entity.HasKey(e => new { e.GroupName, e.ReferenceId })
                    .HasName("PRIMARY");

                entity.ToTable("reference");

                entity.Property(e => e.GroupName)
                    .HasColumnName("group_name")
                    .HasColumnType("varchar(20)");

                entity.Property(e => e.ReferenceId)
                    .HasColumnName("reference_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.EnUsText)
                    .IsRequired()
                    .HasColumnName("en_us_text")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.OrderNo)
                    .HasColumnName("order_no")
                    .HasColumnType("smallint(6)");

                entity.Property(e => e.ThThText)
                    .IsRequired()
                    .HasColumnName("th_th_text")
                    .HasColumnType("varchar(100)");
            });

            modelBuilder.Entity<Region>(entity =>
            {
                entity.ToTable("region");

                entity.HasIndex(e => e.CreateUserId)
                    .HasName("FK_Province_User_idx");

                entity.HasIndex(e => e.ModifyUserId)
                    .HasName("FK_Province_User_2_idx");

                entity.Property(e => e.RegionId)
                    .HasColumnName("region_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.CreateDate)
                    .HasColumnName("create_date")
                    .HasColumnType("datetime");

                entity.Property(e => e.CreateUserId)
                    .HasColumnName("create_user_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.GeoName)
                    .HasColumnName("geo_name")
                    .HasColumnType("varchar(200)");

                entity.Property(e => e.IsActive)
                    .HasColumnName("is_active")
                    .HasColumnType("tinyint(1)");

                entity.Property(e => e.ModifyDate)
                    .HasColumnName("modify_date")
                    .HasColumnType("datetime");

                entity.Property(e => e.ModifyUserId)
                    .HasColumnName("modify_user_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasColumnType("varchar(200)");

                entity.Property(e => e.Note)
                    .HasColumnName("note")
                    .HasColumnType("text");

                entity.Property(e => e.OrderNo)
                    .HasColumnName("order_no")
                    .HasColumnType("smallint(6)");

                entity.HasOne(d => d.CreateUser)
                    .WithMany(p => p.RegionCreateUser)
                    .HasForeignKey(d => d.CreateUserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Region_User");

                entity.HasOne(d => d.ModifyUser)
                    .WithMany(p => p.RegionModifyUser)
                    .HasForeignKey(d => d.ModifyUserId)
                    .HasConstraintName("FK_Region_User_2");
            });

            modelBuilder.Entity<Sequence>(entity =>
            {
                entity.ToTable("sequence");

                entity.HasIndex(e => new { e.TableName, e.ColumnName })
                    .HasName("UC_TableName_ColumnName")
                    .IsUnique();

                entity.Property(e => e.SequenceId)
                    .HasColumnName("sequence_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.ColumnName)
                    .IsRequired()
                    .HasColumnName("column_name")
                    .HasColumnType("varchar(20)");

                entity.Property(e => e.Len).HasColumnName("len");

                entity.Property(e => e.Note)
                    .HasColumnName("note")
                    .HasColumnType("text");

                entity.Property(e => e.PeriodPattern).HasColumnName("period_pattern");

                entity.Property(e => e.PrefixPattern)
                    .HasColumnName("prefix_pattern")
                    .HasColumnType("varchar(20)");

                entity.Property(e => e.SuffixPattern)
                    .HasColumnName("suffix_pattern")
                    .HasColumnType("varchar(20)");

                entity.Property(e => e.TableName)
                    .IsRequired()
                    .HasColumnName("table_name")
                    .HasColumnType("varchar(20)");
            });

            modelBuilder.Entity<SequencePeriod>(entity =>
            {
                entity.ToTable("sequence_period");

                entity.HasIndex(e => e.SequenceId)
                    .HasName("IX_SequenceId");

                entity.Property(e => e.SequencePeriodId)
                    .HasColumnName("sequence_period_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Branch)
                    .HasColumnName("branch")
                    .HasColumnType("varchar(10)");

                entity.Property(e => e.FromDate)
                    .HasColumnName("from_date")
                    .HasColumnType("datetime");

                entity.Property(e => e.Len).HasColumnName("len");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.NextNumber)
                    .HasColumnName("next_number")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Note)
                    .HasColumnName("note")
                    .HasColumnType("text");

                entity.Property(e => e.Prefix)
                    .HasColumnName("prefix")
                    .HasColumnType("varchar(10)");

                entity.Property(e => e.SequenceId)
                    .HasColumnName("sequence_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Suffix)
                    .HasColumnName("suffix")
                    .HasColumnType("varchar(10)");

                entity.Property(e => e.ToDate)
                    .HasColumnName("to_date")
                    .HasColumnType("datetime");

                entity.HasOne(d => d.Sequence)
                    .WithMany(p => p.SequencePeriod)
                    .HasForeignKey(d => d.SequenceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SequencePeriod_Sequence");
            });

            modelBuilder.Entity<Subdistrict>(entity =>
            {
                entity.ToTable("subdistrict");

                entity.HasIndex(e => e.CreateUserId)
                    .HasName("FK_Subdistrict_User_idx");

                entity.HasIndex(e => e.DistrictId)
                    .HasName("FK_Subdistrict_District_idx");

                entity.HasIndex(e => e.ModifyUserId)
                    .HasName("FK_Subdistrict_User_2_idx");

                entity.Property(e => e.SubdistrictId)
                    .HasColumnName("subdistrict_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Code)
                    .HasColumnName("code")
                    .HasColumnType("varchar(20)");

                entity.Property(e => e.CreateDate)
                    .HasColumnName("create_date")
                    .HasColumnType("datetime");

                entity.Property(e => e.CreateUserId)
                    .HasColumnName("create_user_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.DistrictId)
                    .HasColumnName("district_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.GeoName)
                    .HasColumnName("geo_name")
                    .HasColumnType("varchar(200)");

                entity.Property(e => e.IsActive)
                    .HasColumnName("is_active")
                    .HasColumnType("tinyint(1)");

                entity.Property(e => e.ModifyDate)
                    .HasColumnName("modify_date")
                    .HasColumnType("datetime");

                entity.Property(e => e.ModifyUserId)
                    .HasColumnName("modify_user_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasColumnType("varchar(200)");

                entity.Property(e => e.Note)
                    .HasColumnName("note")
                    .HasColumnType("text");

                entity.HasOne(d => d.CreateUser)
                    .WithMany(p => p.SubdistrictCreateUser)
                    .HasForeignKey(d => d.CreateUserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Subdistrict_User");

                entity.HasOne(d => d.District)
                    .WithMany(p => p.Subdistrict)
                    .HasForeignKey(d => d.DistrictId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Subdistrict_District");

                entity.HasOne(d => d.ModifyUser)
                    .WithMany(p => p.SubdistrictModifyUser)
                    .HasForeignKey(d => d.ModifyUserId)
                    .HasConstraintName("FK_Subdistrict_User_2");
            });

            modelBuilder.Entity<Title>(entity =>
            {
                entity.ToTable("title");

                entity.HasIndex(e => e.CreateUserId)
                    .HasName("IX_CreateUserId");

                entity.HasIndex(e => e.ModifyUserId)
                    .HasName("IX_ModifyUserId");

                entity.Property(e => e.TitleId)
                    .HasColumnName("title_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.CreateDate)
                    .HasColumnName("create_date")
                    .HasColumnType("datetime");

                entity.Property(e => e.CreateUserId)
                    .HasColumnName("create_user_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.IsActive)
                    .HasColumnName("is_active")
                    .HasColumnType("tinyint(1)");

                entity.Property(e => e.ModifyDate)
                    .HasColumnName("modify_date")
                    .HasColumnType("datetime");

                entity.Property(e => e.ModifyUserId)
                    .HasColumnName("modify_user_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasColumnType("varchar(200)");

                entity.Property(e => e.Note)
                    .HasColumnName("note")
                    .HasColumnType("text");

                entity.Property(e => e.OrderNo)
                    .HasColumnName("order_no")
                    .HasColumnType("smallint(6)");

                entity.HasOne(d => d.CreateUser)
                    .WithMany(p => p.TitleCreateUser)
                    .HasForeignKey(d => d.CreateUserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Title_User");

                entity.HasOne(d => d.ModifyUser)
                    .WithMany(p => p.TitleModifyUser)
                    .HasForeignKey(d => d.ModifyUserId)
                    .HasConstraintName("FK_Title_User_2");
            });

            modelBuilder.Entity<Training>(entity =>
            {
                entity.ToTable("training");

                entity.HasIndex(e => e.CourseId)
                    .HasName("fk_Training_Course1_idx");

                entity.HasIndex(e => e.CreateUserId)
                    .HasName("fk_Training_User1_idx");

                entity.HasIndex(e => e.ModifyUserId)
                    .HasName("fk_Training_User2_idx");

                entity.HasIndex(e => e.TrnImage)
                    .HasName("fk_Training_File1_idx");

                entity.Property(e => e.TrainingId)
                    .HasColumnName("training_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.AttendeeQty)
                    .HasColumnName("attendee_qty")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Code)
                    .HasColumnName("code")
                    .HasColumnType("varchar(12)");

                entity.Property(e => e.Condition)
                    .HasColumnName("condition")
                    .HasColumnType("text");

                entity.Property(e => e.CourseId)
                    .HasColumnName("course_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.CreateDate)
                    .HasColumnName("create_date")
                    .HasColumnType("datetime");

                entity.Property(e => e.CreateUserId)
                    .HasColumnName("create_user_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasColumnType("text");

                entity.Property(e => e.IsPrerequisite)
                    .HasColumnName("is_prerequisite")
                    .HasColumnType("tinyint(1)");

                entity.Property(e => e.IsPublishNow)
                    .HasColumnName("is_publish_now")
                    .HasColumnType("tinyint(1)");

                entity.Property(e => e.IsRecommend)
                    .HasColumnName("is_recommend")
                    .HasColumnType("tinyint(1)");

                entity.Property(e => e.Location)
                    .HasColumnName("location")
                    .HasColumnType("varchar(200)");

                entity.Property(e => e.LocationLatitude)
                    .HasColumnName("location_latitude")
                    .HasColumnType("decimal(10,6)");

                entity.Property(e => e.LocationLongitude)
                    .HasColumnName("location_longitude")
                    .HasColumnType("decimal(10,6)");

                entity.Property(e => e.ModifyDate)
                    .HasColumnName("modify_date")
                    .HasColumnType("datetime");

                entity.Property(e => e.ModifyUserId)
                    .HasColumnName("modify_user_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasColumnType("varchar(200)");

                entity.Property(e => e.Objective)
                    .HasColumnName("objective")
                    .HasColumnType("text");

                entity.Property(e => e.PublishAtdDate)
                    .HasColumnName("publish_atd_date")
                    .HasColumnType("datetime");

                entity.Property(e => e.PublishDate)
                    .HasColumnName("publish_date")
                    .HasColumnType("datetime");

                entity.Property(e => e.RegisterEndDate)
                    .HasColumnName("register_end_date")
                    .HasColumnType("datetime");

                entity.Property(e => e.RegisterStartDate)
                    .HasColumnName("register_start_date")
                    .HasColumnType("datetime");

                entity.Property(e => e.SeatQty)
                    .HasColumnName("seat_qty")
                    .HasColumnType("int(11)");

                entity.Property(e => e.TargetGroup)
                    .HasColumnName("target_group")
                    .HasColumnType("text");

                entity.Property(e => e.Token)
                    .HasColumnName("token")
                    .HasColumnType("varchar(10)");

                entity.Property(e => e.TrnEndDate)
                    .HasColumnName("trn_end_date")
                    .HasColumnType("datetime");

                entity.Property(e => e.TrnImage)
                    .HasColumnName("trn_image")
                    .HasColumnType("int(11)");

                entity.Property(e => e.TrnStartDate)
                    .HasColumnName("trn_start_date")
                    .HasColumnType("datetime");

                entity.Property(e => e.Year)
                    .HasColumnName("year")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.Course)
                    .WithMany(p => p.Training)
                    .HasForeignKey(d => d.CourseId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Training_Course");

                entity.HasOne(d => d.CreateUser)
                    .WithMany(p => p.TrainingCreateUser)
                    .HasForeignKey(d => d.CreateUserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Training_User");

                entity.HasOne(d => d.ModifyUser)
                    .WithMany(p => p.TrainingModifyUser)
                    .HasForeignKey(d => d.ModifyUserId)
                    .HasConstraintName("fk_Training_User_2");

                entity.HasOne(d => d.TrnImageNavigation)
                    .WithMany(p => p.Training)
                    .HasForeignKey(d => d.TrnImage)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Training_File");
            });

            modelBuilder.Entity<TrnCoordinator>(entity =>
            {
                entity.ToTable("trn_coordinator");

                entity.HasIndex(e => e.TrainingId)
                    .HasName("fk_TrnCoordinator_Training1_idx");

                entity.Property(e => e.TrnCoordinatorId)
                    .HasColumnName("trn_coordinator_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.CoordinatorName)
                    .IsRequired()
                    .HasColumnName("coordinator_name")
                    .HasColumnType("varchar(200)");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("email")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.Fax)
                    .HasColumnName("fax")
                    .HasColumnType("varchar(10)");

                entity.Property(e => e.Phone)
                    .IsRequired()
                    .HasColumnName("phone")
                    .HasColumnType("varchar(10)");

                entity.Property(e => e.TrainingId)
                    .HasColumnName("training_id")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.Training)
                    .WithMany(p => p.TrnCoordinator)
                    .HasForeignKey(d => d.TrainingId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_TrnCoordinator_Training");
            });

            modelBuilder.Entity<TrnDoc>(entity =>
            {
                entity.ToTable("trn_doc");

                entity.HasIndex(e => e.FileId)
                    .HasName("fk_TrnDoc_File1_idx");

                entity.HasIndex(e => e.TrainingId)
                    .HasName("fk_TrnDoc_Training1_idx");

                entity.Property(e => e.TrnDocId)
                    .HasColumnName("trn_doc_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.FileId)
                    .HasColumnName("file_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Note)
                    .HasColumnName("note")
                    .HasColumnType("text");

                entity.Property(e => e.TrainingId)
                    .HasColumnName("training_id")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.File)
                    .WithMany(p => p.TrnDoc)
                    .HasForeignKey(d => d.FileId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_TrnDoc_File");

                entity.HasOne(d => d.Training)
                    .WithMany(p => p.TrnDoc)
                    .HasForeignKey(d => d.TrainingId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_TrnDoc_Training");
            });

            modelBuilder.Entity<TrnImgOther>(entity =>
            {
                entity.ToTable("trn_img_other");

                entity.HasIndex(e => e.FileId)
                    .HasName("fk_TrnImgOther_File1_idx");

                entity.HasIndex(e => e.TrainingId)
                    .HasName("fk_TrnImgOther_Training1_idx");

                entity.Property(e => e.TrnImgOtherId)
                    .HasColumnName("trn_img_other_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.FileId)
                    .HasColumnName("file_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Note)
                    .HasColumnName("note")
                    .HasColumnType("text");

                entity.Property(e => e.TrainingId)
                    .HasColumnName("training_id")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.File)
                    .WithMany(p => p.TrnImgOther)
                    .HasForeignKey(d => d.FileId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_TrnImgOther_File");

                entity.HasOne(d => d.Training)
                    .WithMany(p => p.TrnImgOther)
                    .HasForeignKey(d => d.TrainingId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_TrnImgOther_Training");
            });

            modelBuilder.Entity<TrnPrerequisite>(entity =>
            {
                entity.ToTable("trn_prerequisite");

                entity.HasIndex(e => e.CourseId)
                    .HasName("fk_TrnPrerequisite_Course1_idx");

                entity.HasIndex(e => e.TrainingId)
                    .HasName("fk_TrnPrerequisite_Training1_idx");

                entity.Property(e => e.TrnPrerequisiteId)
                    .HasColumnName("trn_prerequisite_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.CourseId)
                    .HasColumnName("course_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.TrainingId)
                    .HasColumnName("training_id")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.Course)
                    .WithMany(p => p.TrnPrerequisite)
                    .HasForeignKey(d => d.CourseId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_TrnPrerequisite_Course");

                entity.HasOne(d => d.Training)
                    .WithMany(p => p.TrnPrerequisite)
                    .HasForeignKey(d => d.TrainingId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_TrnPrerequisite_Training");
            });

            modelBuilder.Entity<TrnResponsible>(entity =>
            {
                entity.ToTable("trn_responsible");

                entity.HasIndex(e => e.TrainingId)
                    .HasName("fk_TrnResponsible_Training1_idx");

                entity.Property(e => e.TrnResponsibleId)
                    .HasColumnName("trn_responsible_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.ResponsibleName)
                    .IsRequired()
                    .HasColumnName("responsible_name")
                    .HasColumnType("varchar(200)");

                entity.Property(e => e.TrainingId)
                    .HasColumnName("training_id")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.Training)
                    .WithMany(p => p.TrnResponsible)
                    .HasForeignKey(d => d.TrainingId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_TrnResponsible_Training");
            });

            modelBuilder.Entity<TrnSatisfactionAnswer>(entity =>
            {
                entity.ToTable("trn_satisfaction_answer");

                entity.HasIndex(e => e.TrnSatisfactionFormCh2Id)
                    .HasName("FK_TrnSatisfactionAnswer_TrnSatisfactionFormCh2_idx");

                entity.HasIndex(e => e.TrnSatisfactionFormId)
                    .HasName("FK_TrnSatisfactionAnswer_TrnSatisfactionForm_idx");

                entity.Property(e => e.TrnSatisfactionAnswerId)
                    .HasColumnName("trn_satisfaction_answer_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.TrnSatisfactionCh2Answer)
                    .HasColumnName("trn_satisfaction_ch2_answer")
                    .HasColumnType("int(11)");

                entity.Property(e => e.TrnSatisfactionFormCh2Id)
                    .HasColumnName("trn_satisfaction_form_ch2_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.TrnSatisfactionFormId)
                    .HasColumnName("trn_satisfaction_form_id")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.TrnSatisfactionFormCh2)
                    .WithMany(p => p.TrnSatisfactionAnswer)
                    .HasForeignKey(d => d.TrnSatisfactionFormCh2Id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TrnSatisfactionAnswer_TrnSatisfactionFormCh2");

                entity.HasOne(d => d.TrnSatisfactionForm)
                    .WithMany(p => p.TrnSatisfactionAnswer)
                    .HasForeignKey(d => d.TrnSatisfactionFormId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TrnSatisfactionAnswer_TrnSatisfactionForm");
            });

            modelBuilder.Entity<TrnSatisfactionForm>(entity =>
            {
                entity.ToTable("trn_satisfaction_form");

                entity.HasIndex(e => e.TrainingId)
                    .HasName("fk_TrnSatisfactionForm_Training1_idx");

                entity.Property(e => e.TrnSatisfactionFormId)
                    .HasColumnName("trn_satisfaction_form_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Ch1AgeRangeTypeId)
                    .HasColumnName("ch1_age_range_type_id")
                    .HasColumnType("tinyint(4)");

                entity.Property(e => e.Ch1GenderType)
                    .HasColumnName("ch1_gender_type")
                    .HasColumnType("tinyint(4)");

                entity.Property(e => e.Ch1KnowTrainingNote)
                    .HasColumnName("ch1_know_training_note")
                    .HasColumnType("text");

                entity.Property(e => e.Ch1KnowTrainingTypeId)
                    .HasColumnName("ch1_know_training_type_id")
                    .HasColumnType("tinyint(4)");

                entity.Property(e => e.Ch3Note)
                    .HasColumnName("ch3_note")
                    .HasColumnType("text");

                entity.Property(e => e.CreateDate)
                    .HasColumnName("create_date")
                    .HasColumnType("datetime");

                entity.Property(e => e.TrainingId)
                    .HasColumnName("training_id")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.Training)
                    .WithMany(p => p.TrnSatisfactionForm)
                    .HasForeignKey(d => d.TrainingId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_TrnSatisfactionForm_Training");
            });

            modelBuilder.Entity<TrnSatisfactionFormCh2>(entity =>
            {
                entity.ToTable("trn_satisfaction_form_ch2");

                entity.HasIndex(e => e.TrainingId)
                    .HasName("FK_TrnSatisfactionFormCh2_Training_idx");

                entity.HasIndex(e => e.TrnSatisfactionQuestionId)
                    .HasName("IX_TrnSatisfactionFormCh2_TrnSatisfactionQuestionId");

                entity.Property(e => e.TrnSatisfactionFormCh2Id)
                    .HasColumnName("trn_satisfaction_form_ch2_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.OrderNo)
                    .HasColumnName("order_no")
                    .HasColumnType("smallint(6)");

                entity.Property(e => e.Question)
                    .HasColumnName("question")
                    .HasColumnType("text");

                entity.Property(e => e.TrainingId)
                    .HasColumnName("training_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.TrnSatisfactionQuestionId)
                    .HasColumnName("trn_satisfaction_question_id")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.Training)
                    .WithMany(p => p.TrnSatisfactionFormCh2)
                    .HasForeignKey(d => d.TrainingId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TrnSatisfactionFormCh2_Training");

                entity.HasOne(d => d.TrnSatisfactionQuestion)
                    .WithMany(p => p.TrnSatisfactionFormCh2)
                    .HasForeignKey(d => d.TrnSatisfactionQuestionId)
                    .HasConstraintName("FK_TrnSatisfactionFormCh2_TrnSatisfactionQuestion");
            });

            modelBuilder.Entity<TrnSatisfactionQuestion>(entity =>
            {
                entity.ToTable("trn_satisfaction_question");

                entity.HasIndex(e => e.CreateUserId)
                    .HasName("IX_CreateUserId");

                entity.HasIndex(e => e.ModifyUserId)
                    .HasName("IX_ModifyUserId");

                entity.Property(e => e.TrnSatisfactionQuestionId)
                    .HasColumnName("trn_satisfaction_question_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.CreateDate)
                    .HasColumnName("create_date")
                    .HasColumnType("datetime");

                entity.Property(e => e.CreateUserId)
                    .HasColumnName("create_user_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.IsActive)
                    .HasColumnName("is_active")
                    .HasColumnType("tinyint(1)");

                entity.Property(e => e.ModifyDate)
                    .HasColumnName("modify_date")
                    .HasColumnType("datetime");

                entity.Property(e => e.ModifyUserId)
                    .HasColumnName("modify_user_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasColumnType("varchar(200)");

                entity.Property(e => e.Note)
                    .HasColumnName("note")
                    .HasColumnType("text");

                entity.Property(e => e.OrderNo)
                    .HasColumnName("order_no")
                    .HasColumnType("smallint(6)");

                entity.HasOne(d => d.CreateUser)
                    .WithMany(p => p.TrnSatisfactionQuestionCreateUser)
                    .HasForeignKey(d => d.CreateUserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TrnSatisfactionQuestion_User");

                entity.HasOne(d => d.ModifyUser)
                    .WithMany(p => p.TrnSatisfactionQuestionModifyUser)
                    .HasForeignKey(d => d.ModifyUserId)
                    .HasConstraintName("FK_TrnSatisfactionQuestion_User_2");
            });

            modelBuilder.Entity<University>(entity =>
            {
                entity.ToTable("university");

                entity.HasIndex(e => e.CreateUserId)
                    .HasName("fk_university_user_idx");

                entity.HasIndex(e => e.ModifyUserId)
                    .HasName("fk_university_user2_idx");

                entity.Property(e => e.UniversityId)
                    .HasColumnName("university_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.CreateDate)
                    .HasColumnName("create_date")
                    .HasColumnType("datetime");

                entity.Property(e => e.CreateUserId)
                    .HasColumnName("create_user_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.IsActive)
                    .HasColumnName("is_active")
                    .HasColumnType("tinyint(1)");

                entity.Property(e => e.ModifyDate)
                    .HasColumnName("modify_date")
                    .HasColumnType("datetime");

                entity.Property(e => e.ModifyUserId)
                    .HasColumnName("modify_user_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.NameEn)
                    .HasColumnName("name_en")
                    .HasColumnType("varchar(200)");

                entity.Property(e => e.NameTh)
                    .IsRequired()
                    .HasColumnName("name_th")
                    .HasColumnType("varchar(200)");

                entity.Property(e => e.Note)
                    .HasColumnName("note")
                    .HasColumnType("text");

                entity.HasOne(d => d.CreateUser)
                    .WithMany(p => p.UniversityCreateUser)
                    .HasForeignKey(d => d.CreateUserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_university_user");

                entity.HasOne(d => d.ModifyUser)
                    .WithMany(p => p.UniversityModifyUser)
                    .HasForeignKey(d => d.ModifyUserId)
                    .HasConstraintName("fk_university_user2");
            });

            modelBuilder.Entity<UniversityCourse>(entity =>
            {
                entity.ToTable("university_course");

                entity.HasIndex(e => e.CreateUserId)
                    .HasName("fk_university_course_user_idx");

                entity.HasIndex(e => e.FacultyId)
                    .HasName("fk_university_course_faculty_idx");

                entity.HasIndex(e => e.ModifyUserId)
                    .HasName("fk_university_course_user2_idx");

                entity.Property(e => e.UniversityCourseId)
                    .HasColumnName("university_course_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.CreateDate)
                    .HasColumnName("create_date")
                    .HasColumnType("datetime");

                entity.Property(e => e.CreateUserId)
                    .HasColumnName("create_user_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.DegreeName)
                    .IsRequired()
                    .HasColumnName("degree_name")
                    .HasColumnType("varchar(200)");

                entity.Property(e => e.FacultyId)
                    .HasColumnName("faculty_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.IsActive)
                    .HasColumnName("is_active")
                    .HasColumnType("tinyint(1)");

                entity.Property(e => e.ModifyDate)
                    .HasColumnName("modify_date")
                    .HasColumnType("datetime");

                entity.Property(e => e.ModifyUserId)
                    .HasColumnName("modify_user_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasColumnType("varchar(200)");

                entity.Property(e => e.Note)
                    .HasColumnName("note")
                    .HasColumnType("text");

                entity.Property(e => e.UniversityCourseTypeId)
                    .HasColumnName("university_course_type_id")
                    .HasColumnType("tinyint(4)");

                entity.HasOne(d => d.CreateUser)
                    .WithMany(p => p.UniversityCourseCreateUser)
                    .HasForeignKey(d => d.CreateUserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_university_course_user");

                entity.HasOne(d => d.Faculty)
                    .WithMany(p => p.UniversityCourse)
                    .HasForeignKey(d => d.FacultyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_university_course_faculty");

                entity.HasOne(d => d.ModifyUser)
                    .WithMany(p => p.UniversityCourseModifyUser)
                    .HasForeignKey(d => d.ModifyUserId)
                    .HasConstraintName("fk_university_course_user2");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("user");

                entity.HasIndex(e => e.CreateUserId)
                    .HasName("IX_CreateUserId");

                entity.HasIndex(e => e.FacultyId)
                    .HasName("fk_user_faculty_idx");

                entity.HasIndex(e => e.ModifyUserId)
                    .HasName("IX_ModifyUserId");

                entity.HasIndex(e => e.PersonId)
                    .HasName("IX_PersonId");

                entity.HasIndex(e => e.Username)
                    .HasName("UC_UserName")
                    .IsUnique();

                entity.Property(e => e.UserId)
                    .HasColumnName("user_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.CreateDate)
                    .HasColumnName("create_date")
                    .HasColumnType("datetime");

                entity.Property(e => e.CreateUserId)
                    .HasColumnName("create_user_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Data)
                    .HasColumnName("data")
                    .HasColumnType("text");

                entity.Property(e => e.FacultyId)
                    .HasColumnName("faculty_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasColumnName("first_name")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.IsActive)
                    .HasColumnName("is_active")
                    .HasColumnType("tinyint(1)");

                entity.Property(e => e.IsPwdExpired)
                    .HasColumnName("is_pwd_expired")
                    .HasColumnType("tinyint(1)");

                entity.Property(e => e.IsSystem)
                    .HasColumnName("is_system")
                    .HasColumnType("tinyint(1)");

                entity.Property(e => e.LastName)
                    .HasColumnName("last_name")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.ModifyDate)
                    .HasColumnName("modify_date")
                    .HasColumnType("datetime");

                entity.Property(e => e.ModifyUserId)
                    .HasColumnName("modify_user_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasColumnType("varchar(200)");

                entity.Property(e => e.Note)
                    .HasColumnName("note")
                    .HasColumnType("text");

                entity.Property(e => e.Password)
                    .HasColumnName("password")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.PersonId)
                    .HasColumnName("person_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.PwdModifyDate)
                    .HasColumnName("pwd_modify_date")
                    .HasColumnType("datetime");

                entity.Property(e => e.Title)
                    .HasColumnName("title")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasColumnName("username")
                    .HasColumnType("varchar(50)");

                entity.HasOne(d => d.Faculty)
                    .WithMany(p => p.User)
                    .HasForeignKey(d => d.FacultyId)
                    .HasConstraintName("fk_user_faculty");

                entity.HasOne(d => d.ModifyUser)
                    .WithMany(p => p.InverseModifyUser)
                    .HasForeignKey(d => d.ModifyUserId)
                    .HasConstraintName("FK_User_User_2");
            });
        }
    }
}
