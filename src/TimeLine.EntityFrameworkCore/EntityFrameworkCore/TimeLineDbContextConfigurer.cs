using System.Data.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;

namespace TimeLine.EntityFrameworkCore
{
    public static class TimeLineDbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<TimeLineDbContext> builder, string connectionString)
        {
            builder.UseLoggerFactory(MyLoggerFactory).UseLazyLoadingProxies().UseMySql(connectionString);
        }

        public static void Configure(DbContextOptionsBuilder<TimeLineDbContext> builder, DbConnection connection)
        {
            builder.UseLoggerFactory(MyLoggerFactory).UseLazyLoadingProxies().UseMySql(connection);
        }

        public static readonly LoggerFactory MyLoggerFactory
            = new LoggerFactory(new[]
            {
                new ConsoleLoggerProvider((category, level)
                    => category == DbLoggerCategory.Database.Command.Name
                       && level == LogLevel.Information, true)
            });
    }
}
