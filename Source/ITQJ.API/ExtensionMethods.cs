using Microsoft.EntityFrameworkCore;
using Serilog;
using System;
using System.Linq;

namespace ITQJ.EFCore
{
    public enum DBState
    {
        Fetched,
        Unfetched,
        Unmigrated
    }

    public static class ExtensionMethods
    {
        public static DBState IsDataFetched(this ApplicationDBContext context)
        {
            try
            {
                return (context.DocumentTypes.Any()) ? DBState.Fetched : DBState.Unfetched;
            }
            catch (Exception ex)
            {
                Log.Error("Database data is not fetched.\nError: {0}.", ex.Message);
                return DBState.Unmigrated;
            }
        }

        public static void FetchDataBase(this ApplicationDBContext context)
        {
            if (IsDataFetched(context) == DBState.Unmigrated)
            {
                Log.Debug("Migrating database...");
                context.Database.Migrate();
                Log.Debug("Database migrated.");
            }

            Log.Debug("Fetching database...");
            if (!context.Skills.Any())
            {
                Log.Debug("Roles being populated...");
                context.Roles.AddRange(DataConfig.Roles);
                context.SaveChanges();
                Log.Debug("Roles populated.");
            }
            else
            {
                Log.Debug("Roles already populated.");
            }

            if (!context.DocumentTypes.Any())
            {
                Log.Debug("DocumentTypes being populated...");
                context.DocumentTypes.AddRange(DataConfig.DocumentTypes);
                context.SaveChanges();
                Log.Debug("DocumentTypes populated.");
            }
            else
            {
                Log.Debug("DocumentTypes already populated.");
            }

            if (!context.Skills.Any())
            {
                Log.Debug("Skills being populated...");
                context.Skills.AddRange(DataConfig.Skills);
                context.SaveChanges();
                Log.Debug("Skills populated.");
            }
            else
            {
                Log.Debug("Skills already populated.");
            }
            Log.Information("Data feched.");
        }
    }
}
