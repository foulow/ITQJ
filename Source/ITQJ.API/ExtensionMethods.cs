using ITQJ.EFCore.Configurations;
using ITQJ.EFCore.DbContexts;
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
                return (context.Projects.Any()) ? DBState.Fetched : DBState.Unfetched;
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

            if (!context.Users.Any())
            {
                Log.Debug("Users being populated...");
                context.Users.AddRange(DataConfig.Users);
                context.SaveChanges();
                Log.Debug("Users populated.");
            }
            else
            {
                Log.Debug("Users already populated.");
            }

            if (!context.LegalDocuments.Any())
            {
                Log.Debug("LegalDocuments being populated...");
                context.LegalDocuments.AddRange(DataConfig.LegalDocuments);
                context.SaveChanges();
                Log.Debug("LegalDocuments populated.");
            }
            else
            {
                Log.Debug("LegalDocuments already populated.");
            }

            if (!context.PersonalInfos.Any())
            {
                Log.Debug("PersonalInfos being populated...");
                context.PersonalInfos.AddRange(DataConfig.PersonalInfos);
                context.SaveChanges();
                Log.Debug("PersonalInfos populated.");
            }
            else
            {
                Log.Debug("PersonalInfos already populated.");
            }

            if (!context.ProfesionalSkills.Any())
            {
                Log.Debug("ProfesionalSkills being populated...");
                context.ProfesionalSkills.AddRange(DataConfig.ProfesionalSkills);
                context.SaveChanges();
                Log.Debug("ProfesionalSkills populated.");
            }
            else
            {
                Log.Debug("ProfesionalSkills already populated.");
            }
            Log.Information("Data feched.");


            if (!context.Projects.Any())
            {
                Log.Debug("Projects being populated...");
                context.Projects.AddRange(DataConfig.Projects);
                context.SaveChanges();
                Log.Debug("Projects populated.");
            }
            else
            {
                Log.Debug("Projects already populated.");
            }
            Log.Information("Data feched.");

        }
    }
}
