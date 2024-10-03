using Dapper;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datalayer
{
    public interface IRepositoryService
    {
        DbConnection GetDbconnection();

        T Get<T>(string sp, DynamicParameters parms, CommandType commandType = CommandType.StoredProcedure);
        List<T> GetAll<T>(string sp, DynamicParameters parms, CommandType commandType = CommandType.StoredProcedure);
        int Execute(string sp, DynamicParameters parms, CommandType commandType = CommandType.StoredProcedure);
        T Insert<T>(string sp, DynamicParameters parms, CommandType commandType = CommandType.StoredProcedure);
        T Update<T>(string sp, DynamicParameters parms, CommandType commandType = CommandType.StoredProcedure);

        //Task<CustomModelResponse> UpdateAsync(string sp, DynamicParameters parms);

        //Task<CustomModelResponse> GetAsync<TModel>(string sp, DynamicParameters parms);

        Task<TModel> GetJsonPathAsync<TModel>(string sp, DynamicParameters parameters) where TModel : class;

        Task<IList<TModel>> GetJsonPathListAsync<TModel>(string sp, DynamicParameters parameters) where TModel : class;

        Task<IList<T>> GetAllAsync<T>(string sp, DynamicParameters parms);
        Task<T> InsertAsync<T>(string sp, DynamicParameters parms);

        Task<TModel> ExecuteWithReturnAsync<TModel>(string sp, DynamicParameters parms);

        Task ExecuteAsync(string sp, DynamicParameters parms);

        Task<IEnumerable<TModel>> GetListAsync<TModel>(string sp, DynamicParameters parms);

        Task<TModel> GetJsonPathAsyncV2<TModel>(string sp, DynamicParameters parameters) where TModel : class;
    }
}
