using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace TimeLine.EntityFrameworkCore
{
    public static class TimeLineDbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<TimeLineDbContext> builder, string connectionString)
        {
            builder.UseSqlServer(connectionString);
        }

        public static void Configure(DbContextOptionsBuilder<TimeLineDbContext> builder, DbConnection connection)
        {
            builder.UseSqlServer(connection);
        }
    }
}
