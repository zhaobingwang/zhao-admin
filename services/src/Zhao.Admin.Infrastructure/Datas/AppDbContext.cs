using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Zhao.Admin.ApplicationCore.Entities;

namespace Zhao.Admin.Infrastructure.Datas
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Sample> Samples { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        protected override void ConfigureConventions(ModelConfigurationBuilder builder)
        {
            builder.Properties<DateOnly>()
                .HaveConversion<DateOnlyConverter>()
                .HaveColumnType("date");

            builder.Properties<DateOnly?>()
                .HaveConversion<NullableDateOnlyConverter>()
                .HaveColumnType("date");
        }

        /// <summary>
        /// Converts <see cref="DateOnly" /> to <see cref="DateTime"/> and vice versa.
        /// </summary>
        public class DateOnlyConverter : ValueConverter<DateOnly, DateTime>
        {
            /// <summary>
            /// Creates a new instance of this converter.
            /// </summary>
            public DateOnlyConverter() : base(
                    d => d.ToDateTime(TimeOnly.MinValue),
                    d => DateOnly.FromDateTime(d))
            { }
        }

        /// <summary>
        /// Converts <see cref="DateOnly?" /> to <see cref="DateTime?"/> and vice versa.
        /// </summary>
        public class NullableDateOnlyConverter : ValueConverter<DateOnly?, DateTime?>
        {
            /// <summary>
            /// Creates a new instance of this converter.
            /// </summary>
            public NullableDateOnlyConverter() : base(
                d => d == null
                    ? null
                    : new DateTime?(d.Value.ToDateTime(TimeOnly.MinValue)),
                d => d == null
                    ? null
                    : new DateOnly?(DateOnly.FromDateTime(d.Value)))
            { }
        }
    }
}
