namespace UnitTest
{
    using Infrastructure;
    using Microsoft.EntityFrameworkCore;

    internal static class SqlLiteContextExtensions
    {
        internal static SqliteContext GetInMemoryContext()
        {
            var options = new DbContextOptionsBuilder<SqliteContext>()
                .UseInMemoryDatabase(databaseName: "inMemorydb")
                .Options;

            return new SqliteContext(options);
        }
    }
}
