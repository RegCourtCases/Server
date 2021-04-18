using CW_Backend.POCOs;
using ServiceStack.OrmLite;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CW_Backend
{
    public static class DatabaseController
    {
        private static OrmLiteConnectionFactory DbFactory;
        private static IDbConnection Connection;
        private static string ConnectionString;
        private static bool isDebug = false;

        public static async Task<bool> ConnectToDatabase(params string[] args) //server, database, login, password
        {
            if (args.Last() == "DebugEnabled")
                isDebug = true;

            ConnectionString = $"Server={args[0]};Database={args[1]};Uid={args[2]};Pwd={args[3]};";
            DbFactory = new OrmLiteConnectionFactory(ConnectionString, MySqlDialect.Provider);
            Connection = await DbFactory.OpenAsync();
            CreateDatabase();
            return true;
        }

        public static async Task TryReconnect()
        {
            try
            {
                await Connection.GetTableNamesAsync();
            }
            catch (Exception)
            {
                DbFactory = new OrmLiteConnectionFactory(ConnectionString, MySqlDialect.Provider);
                Connection = await DbFactory.OpenAsync();
            }
        }

        private static void CreateDatabase()
        {
            if (isDebug)
            {
                Connection.DropAndCreateTables(
                    typeof(ArticlesCasePOCO),
                    typeof(ArticlePOCO),
                    typeof(CaseParticipantPOCO),
                    typeof(CourtCasePOCO),
                    typeof(DocumentPOCO),
                    typeof(EmployeesCasePOCO),
                    typeof(EmployeePOCO),
                    typeof(EpisodePOCO),
                    typeof(ExpertisePOCO),
                    typeof(ExpertsExpertisePOCO),
                    typeof(InspectorsCasePOCO),
                    typeof(InterestedPartiePOCO),
                    typeof(PersonPOCO),
                    typeof(PlaintiffPOCO),
                    typeof(ProductionPOCO),
                    typeof(RespondentPOCO),
                    typeof(ThingsCasePOCO),
                    typeof(ThirdPartiePOCO),
                    typeof(UserPOCO));
            }
            else
            {
                Connection.CreateTableIfNotExists(
                    typeof(ArticlesCasePOCO),
                    typeof(ArticlePOCO),
                    typeof(CaseParticipantPOCO),
                    typeof(CourtCasePOCO),
                    typeof(DocumentPOCO),
                    typeof(EmployeesCasePOCO),
                    typeof(EmployeePOCO),
                    typeof(EpisodePOCO),
                    typeof(ExpertisePOCO),
                    typeof(ExpertsExpertisePOCO),
                    typeof(InspectorsCasePOCO),
                    typeof(InterestedPartiePOCO),
                    typeof(PersonPOCO),
                    typeof(PlaintiffPOCO),
                    typeof(ProductionPOCO),
                    typeof(RespondentPOCO),
                    typeof(ThingsCasePOCO),
                    typeof(ThirdPartiePOCO),
                    typeof(UserPOCO));
            }
        }

        public static async Task<T> GetEntry<T>(long entryId)
        {
            await TryReconnect();
            return await Connection.SingleByIdAsync<T>(entryId);
        }

        public static async Task<IEnumerable<T>> GetAllEntries<T>()
        {
            await TryReconnect();
            return await Connection.SelectAsync<T>();
        }

        public static async Task<IEnumerable<T>> GetEntriesByPredicate<T>(Expression<Func<T, bool>> predicate)
        {
            await TryReconnect();
            return await Connection.SelectAsync(predicate);
        }

        public static async Task<bool> InsertOrUpdate<T>(T entry)
        {
            await TryReconnect();
            return await Connection.SaveAsync(entry);
        }

        public static async Task<IEnumerable<long>> GetAllIds<T>()
        {
            await TryReconnect();
            return await Connection.ColumnAsync<long>(Connection.From<T>());
        }
    }
}
