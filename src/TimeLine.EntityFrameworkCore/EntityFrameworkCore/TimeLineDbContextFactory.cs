using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using TimeLine.Configuration;
using TimeLine.Web;

namespace TimeLine.EntityFrameworkCore
{
    /* This class is needed to run "dotnet ef ..." commands from command line on development. Not used anywhere else */
    public class TimeLineDbContextFactory : IDesignTimeDbContextFactory<TimeLineDbContext>
    {
        public TimeLineDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<TimeLineDbContext>();
            var configuration = AppConfigurations.Get(WebContentDirectoryFinder.CalculateContentRootFolder());

            TimeLineDbContextConfigurer.Configure(builder, configuration.GetConnectionString(TimeLineConsts.ConnectionStringName));

            return new TimeLineDbContext(builder.Options);
        }
    }
}
