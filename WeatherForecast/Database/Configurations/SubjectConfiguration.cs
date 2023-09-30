using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using WeatherForecast.Database.Helpers;
using WeatherForecast;

namespace Lab3.Database.Configurations
{
    public class SubjectConfiguration : IEntityTypeConfiguration<Subject>
    {
        private const string TableName = "Subject";

        public void Configure(EntityTypeBuilder<Subject> builder)
        {
            builder
                    .HasKey(p => p.SubjectId)
                    .HasName($"pk_(TableName)_SubjectId");

            builder.Property(p => p.SubjectId)
                .ValueGeneratedOnAdd();

            builder.Property(p => p.SubjectId)
                .HasColumnName("subject_id")
                .HasComment("Идентификатор предмета");

            builder.Property(p => p.SubjectName)
                .IsRequired()
                .HasColumnName("c_student_subjectname")
                .HasColumnType(ColumnType.String).HasMaxLength(100)
                .HasComment("Наименование предмета");

        }
    }
}
