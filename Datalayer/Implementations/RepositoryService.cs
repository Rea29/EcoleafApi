//using Common.ViewModels;
using Dapper;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace Datalayer
{
    public class RepositoryService : IRepositoryService
    {
        private readonly IConfiguration _config;
        //private readonly ILogger //_log;
        private readonly string Connectionstring = "DefaultConnection";

        public RepositoryService(IConfiguration config/*, ILogger log*/)
        {
            _config = config;
            ////_log = log;
        }

        public void Dispose()
        {

        }


        public DbConnection GetDbconnection()
        {
            return new SqlConnection(_config.GetConnectionString(Connectionstring));
        }

        public async Task<TModel> ExecuteWithReturnAsync<TModel>(string sp, DynamicParameters parms)
        {
            TModel result;
            using IDbConnection db = new SqlConnection(_config.GetConnectionString(Connectionstring));
            try
            {
                if (db.State == ConnectionState.Closed)
                    db.Open();

                using var tran = db.BeginTransaction();
                try
                {
                    result = await db.QueryFirstOrDefaultAsync<TModel>(sp, parms, commandType: CommandType.StoredProcedure, transaction: tran);
                    tran.Commit();
                }
                catch (SqlException ex)
                {
                    ////_log.LogError(ex.ToString());
                    tran.Rollback();
                    throw new Exception(ex.Message);
                }
            }
            catch (Exception ex)
            {
                ////_log.LogError(ex.ToString());
                throw new Exception(ex.Message);
            }
            finally
            {
                ////_log.LogInformation("Connection is now closing");
                if (db.State == ConnectionState.Open)
                    db.Close();
            }

            return result;
        }

        public async Task<IEnumerable<TModel>> GetListAsync<TModel>(string sp, DynamicParameters parms)
        {
            try
            {
                using IDbConnection db = new SqlConnection(_config.GetConnectionString(Connectionstring));
                var result = await db.QueryAsync<TModel>(sp, parms, commandType: CommandType.StoredProcedure);
                return result;
            }
            catch (Exception ex)
            {
                ////_log.LogError(ex.ToString());
                throw new Exception(ex.Message);
            }
        }

        public async Task ExecuteAsync(string sp, DynamicParameters parms)
        {
            using IDbConnection db = new SqlConnection(_config.GetConnectionString(Connectionstring));
            try
            {
                if (db.State == ConnectionState.Closed)
                    db.Open();

                using var tran = db.BeginTransaction();
                try
                {
                    var result = await db.ExecuteAsync(sp, parms, commandType: CommandType.StoredProcedure, transaction: tran);
                    tran.Commit();
                }
                catch (SqlException ex)
                {
                    ////_log.LogError(ex.ToString());
                    tran.Rollback();
                    throw new Exception(ex.Message);
                }
            }
            catch (Exception ex)
            {
                //_log.LogError(ex.ToString());
                throw new Exception(ex.Message);
            }
            finally
            {
                //_log.LogInformation("Connection is now closing");
                if (db.State == ConnectionState.Open)
                    db.Close();
            }
        }

        public async Task<IList<T>> GetAllAsync<T>(string sp, DynamicParameters parms)
        {
            try
            {
                using SqlConnection con = new(_config.GetConnectionString(Connectionstring));

                var result = await con.QueryAsync<T>(sp, parms, commandType: CommandType.StoredProcedure);

                return result.ToList();
            }
            catch (Exception ex)
            {
                //_log.LogError(ex.ToString());
                throw new Exception(ex.Message);
            }
        }

        public async Task<T> InsertAsync<T>(string sp, DynamicParameters parms)
        {
            T result;

            using SqlConnection con = new(_config.GetConnectionString(Connectionstring));

            if (con.State == ConnectionState.Closed)
                con.Open();

            using var tran = con.BeginTransaction();

            try
            {
                result = await con.QueryFirstOrDefaultAsync<T>(sp, parms, commandType: CommandType.StoredProcedure, transaction: tran);

                tran.Commit();
            }
            catch (Exception ex)
            {
                //_log.LogError(ex.ToString());
                tran.Rollback();
                throw new Exception(ex.Message);
            }

            return result;
        }

        public T Get<T>(string sp, DynamicParameters parms, CommandType commandType = CommandType.Text)
        {
            using IDbConnection db = new SqlConnection(_config.GetConnectionString(Connectionstring));
            return db.Query<T>(sp, parms, commandType: commandType).FirstOrDefault();
        }

        public List<T> GetAll<T>(string sp, DynamicParameters parms, CommandType commandType = CommandType.StoredProcedure)
        {
            using IDbConnection db = new SqlConnection(_config.GetConnectionString(Connectionstring));
            return db.Query<T>(sp, parms, commandType: commandType).ToList();
        }

        public T Insert<T>(string sp, DynamicParameters parms, CommandType commandType = CommandType.StoredProcedure)
        {
            T result;
            using IDbConnection db = new SqlConnection(_config.GetConnectionString(Connectionstring));
            try
            {
                if (db.State == ConnectionState.Closed)
                    db.Open();

                using var tran = db.BeginTransaction();
                try
                {
                    result = db.Query<T>(sp, parms, commandType: commandType, transaction: tran).FirstOrDefault();
                    tran.Commit();
                }
                catch (Exception ex)
                {
                    tran.Rollback();
                    throw ex;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (db.State == ConnectionState.Open)
                    db.Close();
            }

            return result;
        }

        public T Update<T>(string sp, DynamicParameters parms, CommandType commandType = CommandType.StoredProcedure)
        {
            T result;
            using IDbConnection db = new SqlConnection(_config.GetConnectionString(Connectionstring));
            try
            {
                if (db.State == ConnectionState.Closed)
                    db.Open();

                using var tran = db.BeginTransaction();
                try
                {
                    result = db.Query<T>(sp, parms, commandType: commandType, transaction: tran).FirstOrDefault();
                    tran.Commit();
                }
                catch (Exception ex)
                {
                    tran.Rollback();
                    throw ex;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (db.State == ConnectionState.Open)
                    db.Close();
            }

            return result;
        }

        //public async Task<CustomModelResponse> GetAsync<TModel>(string sp, DynamicParameters parms)
        //{
        //    try
        //    {
        //        using (SqlConnection con = new SqlConnection(_config.GetConnectionString(Connectionstring)))
        //        {
        //            var result = await con.QuerySingleOrDefaultAsync<TModel>(sp, parms,
        //                                                            commandType: CommandType.StoredProcedure).ConfigureAwait(false);

        //            return new CustomModelResponse("Successfully Retrieved!", 200, true, result);
        //        }
        //    }
        //    catch (Exception ex)
        //    {

        //        return new CustomModelResponse(ex.Message, 500, false, "");
        //    }
        //}

        //public async Task<CustomModelResponse> UpdateAsync(string sp, DynamicParameters parameter)
        //{
        //    try
        //    {
        //        using (SqlConnection con = new SqlConnection(_config.GetConnectionString(Connectionstring)))
        //        {
        //            var result = Convert.ToBoolean(await con.ExecuteAsync(sp, parameter, commandType: CommandType.StoredProcedure).ConfigureAwait(false));
        //            return new CustomModelResponse("Successfully Updated", 200, result, "");
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        return new CustomModelResponse(ex.Message, 500, false, "");
        //    }

        //}

        public async Task<TModel> GetJsonPathAsync<TModel>(string sp, DynamicParameters parameters) where TModel : class
        {
            using (var con = new SqlConnection(_config.GetConnectionString(Connectionstring)))
            {
                var test = await con.QueryAsync(sp, parameters, commandType: CommandType.StoredProcedure);

                var result = (from row in await con.QueryAsync(sp, parameters, commandType: CommandType.StoredProcedure)
                              select row as IDictionary<string, object>)
                              .SingleOrDefault();

                if (result is null)
                {
                    return null;
                }

                var render = new Dictionary<string, object>(result)
                                .Select(x => x.Value)
                                .SingleOrDefault();


                var getModel = JsonConvert.DeserializeObject<TModel>(render.ToString());

                return getModel;
            }
        }

        public async Task<IList<TModel>> GetJsonPathListAsync<TModel>(string sp, DynamicParameters parameters) where TModel : class
        {
            try
            {
                using (var con = new SqlConnection(_config.GetConnectionString(Connectionstring)))
                {
                    var result = (from row in await con.QueryAsync(sp, parameters, commandType: CommandType.StoredProcedure)
                                  select row as IDictionary<string, object>);

                    if (result is null || result.Count() is 0)
                    {
                        return Enumerable.Empty<TModel>().ToList();
                    }

                    //_log.LogInformation("Render json path to products");

                    var resultSet = new StringBuilder();

                    foreach (var product in result)
                    {
                        var render = new Dictionary<string, object>(product)
                                .Select(x => x.Value)
                                .SingleOrDefault()
                                .ToString();

                        resultSet.Append(render);
                    }

                    var renderList = resultSet.ToString();

                    var getModel = JsonConvert.DeserializeObject<List<TModel>>(renderList);

                    return getModel;
                }
            }
            catch (Exception ex)
            {
                //_log.LogError(ex.ToString());
                throw new Exception(ex.Message);
            }
        }

        public int Execute(string sp, DynamicParameters parms, CommandType commandType = CommandType.StoredProcedure)
        {
            throw new NotImplementedException();
        }

        public async Task<TModel> GetJsonPathAsyncV2<TModel>(string sp, DynamicParameters parameters) where TModel : class
        {
            try
            {
                using (var con = new SqlConnection(_config.GetConnectionString(Connectionstring)))
                {
                    //var test = await con.QueryAsync(sp, parameters, commandType: CommandType.StoredProcedure);

                    var result = (from row in await con.QueryAsync(sp, parameters, commandType: CommandType.StoredProcedure)
                              select row as IDictionary<string, object>);

                    if (result is null)
                    {
                        return null;
                    }

                    var resultSet = new StringBuilder();

                    foreach (var product in result)
                    {
                        var render = new Dictionary<string, object>(product)
                                .Select(x => x.Value)
                                .SingleOrDefault()
                                .ToString();

                        resultSet.Append(render);
                    }

                    var renderList = resultSet.ToString();

                    var getModel = JsonConvert.DeserializeObject<TModel>(renderList);

                    return getModel;
                }
            }
            catch (DbException ex)
            {
                //_log.LogError(ex.ToString());
                throw new Exception(ex.Message);
            }
            catch (Exception ex)
            {
                //_log.LogError(ex.ToString());
                throw new Exception(ex.Message);
            }
        }
    }
}
