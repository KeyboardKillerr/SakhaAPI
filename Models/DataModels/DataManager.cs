using DataModels.Repositories;
using System;
using DataModels.DataProviders.Ef.Core.Repositories;
using System.IO;

namespace DataModels;

public class DataManager
{
    public IUserRep User { get; }

    private DataManager(IUserRep user)
    {
        User = user;
    }

    public static DataManager Get(DataProvidersList dataProviders)
    {
        switch (dataProviders)
        {
            case DataProvidersList.Json:
            case DataProvidersList.Txt:
            case DataProvidersList.Oracle:
            case DataProvidersList.SqLite:
                var sqlite = new DataProviders.Ef.Contexts.SqLiteDbContext();
                if (!Directory.Exists(@"C:\Data")) Directory.CreateDirectory(@"C:\Data");
                if (!sqlite.Database.EnsureCreated()) throw new Exception();
                return new DataManager
                (
                    new EfUsers(sqlite)
                );
            case DataProvidersList.MySql:
                throw new NotSupportedException("Поставщики данных находятся в стадии разработки");
            case DataProvidersList.SqlServer:
                var sqlserver = new DataProviders.Ef.Contexts.SqlServerDbContext();
                sqlserver.Database.EnsureCreated();
                return new DataManager
                (
                    new EfUsers(sqlserver)
                );
            case DataProvidersList.PostgreSQL:
                var postgresql = new DataProviders.Ef.Contexts.PostgreSQLDbContext();
                postgresql.Database.EnsureCreated();
                return new DataManager
                (
                    new EfUsers(postgresql)
                );
            default:
                throw new NotSupportedException("Поставщики данных неизвестен");
        }
    }
}
