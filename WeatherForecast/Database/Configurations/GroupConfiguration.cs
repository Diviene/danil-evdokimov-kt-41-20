using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Text.RegularExpressions;
using WeatherForecast.Database.Helpers;
using WeatherForecast;

namespace Lab3.Database.Configurations
{
    public class GroupConfiguration : IEntityTypeConfiguration<WeatherForecast.Group>
    {
        private const string TableName = "Group";

        public void Configure(EntityTypeBuilder<WeatherForecast.Group> builder)
        {
            builder
                    .HasKey(p => p.GroupId)
                    .HasName($"pk_(TableName)_GroupId");

            builder.Property(p => p.GroupId)
                .ValueGeneratedOnAdd();

            builder.Property(p => p.GroupId)
                .HasColumnName("group_id")
                .HasComment("Идентификатор группы");

            builder.Property(p => p.GroupName)
                .IsRequired()
                .HasColumnName("c_student_groupname")
                .HasColumnType(ColumnType.String).HasMaxLength(100)
                .HasComment("Наименование группы");

            builder.Property(p => p.StudentQuantity)
                .IsRequired()
                .HasColumnName("c_student_quantity")
                .HasColumnType(ColumnType.Int)
                .HasComment("Количество студентов");
        }
    }
}
