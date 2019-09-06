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
        public virtual DbSet<AttendeeScore> AttendeeScore { get; set; }
        public virtual DbSet<Course> Course { get; set; }
        public virtual DbSet<File> File { get; set; }
        public virtual DbSet<Person> Person { get; set; }
        public virtual DbSet<TargetGroup> TargetGroup { get; set; }
        public virtual DbSet<TargetGroupMember> TargetGroupMember { get; set; }
        public virtual DbSet<Training> Training { get; set; }
        public virtual DbSet<TrnCoordinator> TrnCoordinator { get; set; }
        public virtual DbSet<TrnPrerequisite> TrnPrerequisite { get; set; }
        public virtual DbSet<TrnResponsible> TrnResponsible { get; set; }
        public virtual DbSet<TrnResultScore> TrnResultScore { get; set; }

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

                entity.Property(e => e.Registeration)
                    .HasColumnName("registeration")
                    .HasColumnType("datetime");

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

            modelBuilder.Entity<AttendeeScore>(entity =>
            {
                entity.ToTable("attendee_score");

                entity.HasIndex(e => e.AttendeeId)
                    .HasName("fk_attendee_score_attendee_idx");

                entity.HasIndex(e => e.TrnResultScoreId)
                    .HasName("fk_attendee_score_trn_result_score_idx");

                entity.Property(e => e.AttendeeScoreId)
                    .HasColumnName("attendee_score_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.AttendeeId)
                    .HasColumnName("attendee_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Score)
                    .HasColumnName("score")
                    .HasColumnType("decimal(10,2)");

                entity.Property(e => e.TrnResultScoreId)
                    .HasColumnName("trn_result_score_id")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.Attendee)
                    .WithMany(p => p.AttendeeScore)
                    .HasForeignKey(d => d.AttendeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_attendee_score_attendee");

                entity.HasOne(d => d.TrnResultScore)
                    .WithMany(p => p.AttendeeScore)
                    .HasForeignKey(d => d.TrnResultScoreId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_attendee_score_trn_result_score");
            });

            modelBuilder.Entity<Course>(entity =>
            {
                entity.ToTable("course");

                entity.Property(e => e.CourseId)
                    .HasColumnName("course_id")
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

            modelBuilder.Entity<Person>(entity =>
            {
                entity.ToTable("person");

                entity.Property(e => e.PersonId)
                    .HasColumnName("person_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.BirthDate)
                    .HasColumnName("birth_date")
                    .HasColumnType("datetime");

                entity.Property(e => e.CitizenId)
                    .IsRequired()
                    .HasColumnName("citizen_id")
                    .HasColumnType("varchar(13)");

                entity.Property(e => e.Email)
                    .HasColumnName("email")
                    .HasColumnType("varchar(200)");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasColumnName("first_name")
                    .HasColumnType("varchar(200)");

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasColumnName("last_name")
                    .HasColumnType("varchar(200)");

                entity.Property(e => e.MobilePhone)
                    .HasColumnName("mobile_phone")
                    .HasColumnType("varchar(10)");

                entity.Property(e => e.Prefix)
                    .HasColumnName("prefix")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.TrainingAmount)
                    .HasColumnName("training_amount")
                    .HasColumnType("int(11)");
            });

            modelBuilder.Entity<TargetGroup>(entity =>
            {
                entity.ToTable("target_group");

                entity.Property(e => e.TargetGroupId)
                    .HasColumnName("target_group_id")
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

                entity.Property(e => e.IsPublic)
                    .HasColumnName("is_public")
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
            });

            modelBuilder.Entity<TargetGroupMember>(entity =>
            {
                entity.ToTable("target_group_member");

                entity.HasIndex(e => e.TargetGroupId)
                    .HasName("fk_target_group_member_target_group_idx");

                entity.Property(e => e.TargetGroupMemberId)
                    .HasColumnName("target_group_member_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.CitizenId)
                    .IsRequired()
                    .HasColumnName("citizen_id")
                    .HasColumnType("varchar(13)");

                entity.Property(e => e.CreateDate)
                    .HasColumnName("create_date")
                    .HasColumnType("datetime");

                entity.Property(e => e.CreateUserId)
                    .HasColumnName("create_user_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Data1)
                    .HasColumnName("data_1")
                    .HasColumnType("varchar(200)");

                entity.Property(e => e.Data2)
                    .HasColumnName("data_2")
                    .HasColumnType("varchar(200)");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasColumnName("first_name")
                    .HasColumnType("varchar(200)");

                entity.Property(e => e.Identification)
                    .IsRequired()
                    .HasColumnName("identification")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasColumnName("last_name")
                    .HasColumnType("varchar(200)");

                entity.Property(e => e.Prefix)
                    .IsRequired()
                    .HasColumnName("prefix")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.TargetGroupId)
                    .HasColumnName("target_group_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.VerifyCode)
                    .IsRequired()
                    .HasColumnName("verify_code")
                    .HasColumnType("varchar(100)");

                entity.HasOne(d => d.TargetGroup)
                    .WithMany(p => p.TargetGroupMember)
                    .HasForeignKey(d => d.TargetGroupId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_target_group_member_target_group");
            });

            modelBuilder.Entity<Training>(entity =>
            {
                entity.ToTable("training");

                entity.HasIndex(e => e.CourseId)
                    .HasName("fk_Training_Course1_idx");

                entity.HasIndex(e => e.TargetGroupId)
                    .HasName("fk_training_target_group_idx");

                entity.HasIndex(e => e.TrnImage)
                    .HasName("fk_Training_File1_idx");

                entity.Property(e => e.TrainingId)
                    .HasColumnName("training_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.AttendeeQty)
                    .HasColumnName("attendee_qty")
                    .HasColumnType("int(11)");

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

                entity.Property(e => e.Location)
                    .HasColumnName("location")
                    .HasColumnType("varchar(200)");

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

                entity.Property(e => e.TargetGroupId)
                    .HasColumnName("target_group_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.TargetGroupNote)
                    .HasColumnName("target_group_note")
                    .HasColumnType("text");

                entity.Property(e => e.TrnEndDate)
                    .HasColumnName("trn_end_date")
                    .HasColumnType("datetime");

                entity.Property(e => e.TrnImage)
                    .HasColumnName("trn_image")
                    .HasColumnType("int(11)");

                entity.Property(e => e.TrnStartDate)
                    .HasColumnName("trn_start_date")
                    .HasColumnType("datetime");

                entity.HasOne(d => d.Course)
                    .WithMany(p => p.Training)
                    .HasForeignKey(d => d.CourseId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Training_Course");

                entity.HasOne(d => d.TargetGroup)
                    .WithMany(p => p.Training)
                    .HasForeignKey(d => d.TargetGroupId)
                    .HasConstraintName("fk_training_target_group");

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

            modelBuilder.Entity<TrnResultScore>(entity =>
            {
                entity.ToTable("trn_result_score");

                entity.HasIndex(e => e.TrainingId)
                    .HasName("fk_trn_result_score_training_idx");

                entity.Property(e => e.TrnResultScoreId)
                    .HasColumnName("trn_result_score_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.MaxScore)
                    .HasColumnName("max_score")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasColumnType("varchar(150)");

                entity.Property(e => e.ScoreRatio)
                    .HasColumnName("score_ratio")
                    .HasColumnType("int(11)");

                entity.Property(e => e.TrainingId)
                    .HasColumnName("training_id")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.Training)
                    .WithMany(p => p.TrnResultScore)
                    .HasForeignKey(d => d.TrainingId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_trn_result_score_training");
            });
        }
    }
}
