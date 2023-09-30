using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using WeatherForecast.Database.Helpers;
using WeatherForecast;

namespace Lab3.Database.Configurations
{
    public class TestConfiguration : IEntityTypeConfiguration<Test>
    {
        private const string TableName = "Test";

        public void Configure(EntityTypeBuilder<Test> builder)
        {
            builder
                    .HasKey(p => p.TestId)
                    .HasName($"pk_(TableName)_TestId");

            builder.Property(p => p.TestId)
                .ValueGeneratedOnAdd();

            builder.Property(p => p.TestId)
                .HasColumnName("test_id")
                .HasComment("Идентификатор успеваемости (зачеты)");

            builder.Property(p => p.TestName)
                .IsRequired()
                .HasColumnName("c_student_testname")
                .HasColumnType(ColumnType.String)
                .HasComment("Наименование зачета");

            builder.Property(p => p.DateOfTest)
                .IsRequired()
                .HasColumnName("c_student_dateoftest")
                .HasColumnType(ColumnType.Date)
                .HasComment("Дата зачета");

            builder.Property(p => p.TestCondition)
                .IsRequired()
                .HasColumnName("c_student_testcondition")
                .HasColumnType(ColumnType.String)
                .HasComment("Итог зачета");

            builder.Property(p => p.SubjectId)
                .IsRequired()
                .HasColumnName("c_student_subjectid")
                .HasColumnType(ColumnType.Int)
                .HasComment("Идентификатор предмета");

            builder.ToTable(TableName)
                .HasOne(p => p.Subject)
                .WithMany(p => p.Tests)
                .HasForeignKey(P => P.SubjectId)
                .HasConstraintName("fk_f_subject_id")
                .OnDelete(DeleteBehavior.Cascade);

            builder.ToTable(TableName)
                .HasIndex(p => p.SubjectId, $"idx_(TableName)_fk_f_subject_id");

            builder.Navigation(p => p.Subject)
                .AutoInclude();

            builder.Property(p => p.StudentId)
                .IsRequired()
                .HasColumnName("c_student_studentid")
                .HasColumnType(ColumnType.Int)
                .HasComment("Идентификатор студента");

            builder.ToTable(TableName)
                .HasOne(p => p.Student)
                .WithMany(p => p.Tests)
                .HasForeignKey(P => P.StudentId)
                .HasConstraintName("fk_f_student_id")
                .OnDelete(DeleteBehavior.Cascade);

            builder.ToTable(TableName)
                .HasIndex(p => p.StudentId, $"idx_(TableName)_fk_f_student_id");

            builder.Navigation(p => p.Student)
                .AutoInclude();

        }
    }
}