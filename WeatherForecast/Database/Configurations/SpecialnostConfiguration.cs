using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using WeatherForecast.Database.Helpers;
using WeatherForecast.Models;

namespace WeatherForecast.Database.Configurations
{
        public class SpecialnostConfiguration : IEntityTypeConfiguration<Specialnost>
        {
            private const string TableName = "Specialnost";

            public void Configure(EntityTypeBuilder<Specialnost> builder)
            {
                builder
                        .HasKey(p => p.SpecialnostId)
                        .HasName($"pk_(TableName)_SpecialnostId");

                builder.Property(p => p.SpecialnostId)
                    .ValueGeneratedOnAdd();

                builder.Property(p => p.SpecialnostId)
                    .HasColumnName("specialnost_id")
                    .HasComment("Идентификатор специальности");

                builder.Property(p => p.SpecialnostName)
                    .IsRequired()
                    .HasColumnName("c_group_specialnostname")
                    .HasColumnType(ColumnType.String).HasMaxLength(100)
                    .HasComment("Наименование специальности");
            }
        }
    }
