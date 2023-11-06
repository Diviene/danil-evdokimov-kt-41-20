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
                .HasColumnName("c_group_groupname")
                .HasColumnType(ColumnType.String).HasMaxLength(100)
                .HasComment("Наименование группы");

            builder.Property(p => p.GroupYear)
                .IsRequired()
                .HasColumnName("c_group_groupyear")
                .HasColumnType(ColumnType.Int).HasMaxLength(100)
                .HasComment("Год формирования группы");

            builder.Property(p => p.DoesExist)
                .IsRequired()
                .HasColumnName("c_group_doesexist")
                .HasColumnType(ColumnType.Bool)
                .HasComment("Существует ли группа");

            builder.Property(p => p.SpecialnostId)
                .IsRequired()
                .HasColumnName("c_group_specialnostid")
                .HasColumnType(ColumnType.Int)
                .HasComment("ИД специальности");

            builder.ToTable(TableName)
            .HasOne(p => p.Specialnosts)                 
            .WithMany(p => p.Groups)                                   
            .HasForeignKey(p => p.SpecialnostId)          
            .HasConstraintName("fk_f_specialnost_id")   
            .OnDelete(DeleteBehavior.Cascade);           

            builder.ToTable(TableName)
                .HasIndex(p => p.SpecialnostId, $"idx_{TableName}_fk_f_specialnost_id");

            builder.Navigation(p => p.Specialnosts)
                .AutoInclude();
        }
    }
}
