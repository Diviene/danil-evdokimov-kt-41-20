using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WeatherForecast.Database.Helpers;
using WeatherForecast;

namespace Lab3.Database.Configurations
{
    public class GradeConfiguration : IEntityTypeConfiguration<Grade>
    {
        private const string TableName = "Grade";

        public void Configure(EntityTypeBuilder<Grade> builder)
        {
            builder
                    .HasKey(p => p.GradeId)
                    .HasName($"pk_(TableName)_GradeId");

            builder.Property(p => p.GradeId)
                .ValueGeneratedOnAdd();

            builder.Property(p => p.GradeId)
                .HasColumnName("grade_id")
                .HasComment("Идентификатор успеваемости");

            builder.Property(p => p.GradeNumber)
                .IsRequired()
                .HasColumnName("c_student_gradenumber")
                .HasColumnType(ColumnType.Int)
                .HasComment("Оценка");

            builder.Property(p => p.GradeDate)
                .IsRequired()
                .HasColumnName("c_student_gradedate")
                .HasColumnType(ColumnType.Date)
                .HasComment("Дата оценки");

            builder.Property(p => p.SubjectId)
                .IsRequired()
                .HasColumnName("c_student_subjectid")
                .HasColumnType(ColumnType.Int)
                .HasComment("Идентификатор предмета");

            builder.ToTable(TableName)
                .HasOne(p => p.Subject)
                .WithMany(a => a.Grades)
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
                .WithMany(a => a.Grades)
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
