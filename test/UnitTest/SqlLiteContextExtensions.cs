namespace UnitTest
{
    using Infrastructure;
    using Microsoft.EntityFrameworkCore;

    internal static class SqlLiteContextExtensions
    {
        internal static SqlLiteContext GetInMemoryContext()
        {
            var options = new DbContextOptionsBuilder<SqlLiteContext>()
                .UseInMemoryDatabase(databaseName: "inMemorydb")
                .Options;

            return new SqlLiteContext(options);
        }
    }
}
