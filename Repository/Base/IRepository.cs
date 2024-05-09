using Core.Models;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Base
{
    public interface IRepository<TEntity> where TEntity : class
    {
        IQueryable<TEntity> AsNoTracking();
        ValueTask<TEntity> FindByKeys(params object[] keys);
        ValueTask<EntityEntry<TEntity>> AddAsync(TEntity record);
        Task AddRangeAsync(IEnumerable<TEntity> records);
        void Update(TEntity record);
        /// <summary>
        /// Update only field(s) specificed in dictionary when updating the entity. Primary key(s) will be ignored by default. If no field left, the entity update will be ignored.
        /// </summary>
        /// <param name="model">Dictionary contains field(s) to be updated. Name of field is case-insensitive.</param>
        void Update(EntityModel model);
        /// <summary>
        /// Ignore specified field(s) when updating the entity record.
        /// </summary>
        /// <param name="record">The record will be updated.</param>
        /// <param name="ignoredFields">The field(s) will be excluded when updating. Name of field is case-insensitive.</param>
        void UpdateIgnoreFields(TEntity record, params string[] ignoredFields);
        /// <summary>
        /// Update only specified field(s) when updaing the entity record. If no field(s) provided, the entity update will be ignored.
        /// </summary>
        /// <param name="record">The record will be updated.</param>
        /// <param name="onlyFields">The field(s) will be updated. Name of field is case-insensitive.</param>
        void UpdateOnlyFields(TEntity record, params string[] onlyFields);
        void UpdateRange(IEnumerable<TEntity> records);
        void Remove(TEntity record);
        void RemoveRange(IEnumerable<TEntity> records);
        Task<int> SaveChangesAsync();
        Task<IDbContextTransaction> BeginTransactionAsync();
        /// <summary>
        /// Execute stored procedure.
        /// </summary>
        /// <returns>Dataset contains all data table selected.</returns>
        Task<DataSet> ExecuteDataSetAsync(string procedure, IEnumerable<KeyValuePair<string, object>> args = null);
        /// <summary>
        /// Execute stored procedure.
        /// </summary>
        /// <returns>First data table selected.</returns>
        Task<DataTable> ExecuteDataTableAsync(string procedure, IEnumerable<KeyValuePair<string, object>> args = null);
        /// <summary>
        /// Execute stored procedure.
        /// </summary>
        /// <returns>List of dictionary. Each dictionary representatives a record from first record set.</returns>
        Task<List<Dictionary<string, object>>> ExecuteDictionariesAsync(string procedure, IEnumerable<KeyValuePair<string, object>> args = null);
        /// <summary>
        /// Execute stored procedure.
        /// </summary>
        /// <typeparam name="T">Target type of each object will be returned.</typeparam>
        /// <returns>List of object. Each object representative a record from first record set.</returns>
        Task<List<T>> ExecuteListAsync<T>(string procedure, IEnumerable<KeyValuePair<string, object>> args = null) where T : class;
        /// <summary>
        /// Execute stored procedure.
        /// </summary>
        /// <typeparam name="T">Target type of each object will be returned.</typeparam>
        /// <returns>First object record.</returns>
        Task<T> ExecuteFirstOrDefaultAsync<T>(string procedure, IEnumerable<KeyValuePair<string, object>> args = null) where T : class;
        /// <summary>
        /// Execute stored procedure.
        /// </summary>
        /// <typeparam name="T">Target type of result will be returned.</typeparam>
        /// <returns>First cell value from first record set.</returns>
        Task<T> ExecuteScalarAsync<T>(string procedure, IEnumerable<KeyValuePair<string, object>> args = null);
        /// <summary>
        /// Execute stored procedure.
        /// </summary>
        /// <returns>Number of record(s) affected.</returns>
        Task<int> ExecuteNonQueryAsync(string procedure, IEnumerable<KeyValuePair<string, object>> args = null);
        /// <summary>
        /// Execute stored procedure and get output parameters.
        /// </summary>
        /// <param name="procedure">Name of stored procedure.</param>
        /// <returns>Output parameters.</returns>
        Task<Dictionary<string, object>> ExecuteParametersAsync(string procedure, IEnumerable<ParameterModel> args);
        Task<int> ExecuteSqlRawAsync(string rawSql, params object[] agrs);
    }
}
