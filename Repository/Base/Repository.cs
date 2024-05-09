using Core.Models;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utility;
using Microsoft.Data.SqlClient;

namespace Repository.Base
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly DbContext _dbContext;
        protected readonly DbSet<TEntity> _dbSet;

        public Repository(DbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = dbContext.Set<TEntity>();
        }

        public virtual IQueryable<TEntity> AsNoTracking() => _dbSet.AsNoTracking();

        public virtual ValueTask<TEntity> FindByKeys(params object[] keys) => _dbSet.FindAsync(keys);

        public virtual ValueTask<EntityEntry<TEntity>> AddAsync(TEntity record) => _dbSet.AddAsync(record);

        public virtual Task AddRangeAsync(IEnumerable<TEntity> records) => _dbSet.AddRangeAsync(records);

        public virtual void Update(TEntity record)
        {
            TryAttach(record);
            _dbSet.Update(record);
        }

        public virtual void Update(EntityModel model)
        {
            var record = model.ToEntity<TEntity>();
            UpdateOnlyFields(record, model.Keys.ToArray());
        }

        public virtual void UpdateIgnoreFields(TEntity record, params string[] ignoredFields)
        {
            TryAttach(record);
            var entry = _dbContext.Entry(record);
            entry.State = EntityState.Modified;
            if (ignoredFields?.Any() == true)
            {
                typeof(TEntity)
                    .GetProperties()
                    .Where(x => x.CanWrite && ignoredFields?.Any(p => p.ToLower() == x.Name.ToLower()) == true)
                    .ToList()
                    .ForEach(x => entry.Member(x.Name).IsModified = false);
            }
        }

        public virtual void UpdateOnlyFields(TEntity record, params string[] onlyFields)
        {
            TryAttach(record);
            var entry = _dbContext.Entry(record);
            var primaryKeyProperties = _dbContext.Model
                .FindEntityType(typeof(TEntity))
                .FindPrimaryKey().Properties;
            var properties = typeof(TEntity)
                .GetProperties()
                .Where(x => !primaryKeyProperties.Any(k => k.Name == x.Name))
                .Where(x => x.CanWrite && onlyFields?.Any(c => c.ToLower() == x.Name.ToLower()) == true);
            if (properties.Any() == true)
            {
                entry.State = EntityState.Modified;
                foreach (var prop in entry.Properties) prop.IsModified = properties.Any(x => x.Name == prop.Metadata.Name);
            }
            else entry.State = EntityState.Unchanged;
        }

        public virtual void UpdateRange(IEnumerable<TEntity> records)
        {
            foreach (var record in records) TryAttach(record);
            _dbSet.UpdateRange(records);
        }

        public virtual void Remove(TEntity record)
        {
            TryAttach(record);
            _dbSet.Remove(record);
        }

        public virtual void RemoveRange(IEnumerable<TEntity> records)
        {
            foreach (var record in records) TryAttach(record);
            _dbSet.RemoveRange(records);
        }

        public virtual Task<int> SaveChangesAsync() => _dbContext.SaveChangesAsync();

        public virtual Task<IDbContextTransaction> BeginTransactionAsync() => _dbContext.Database.BeginTransactionAsync();

        public virtual async Task<DataSet> ExecuteDataSetAsync(string procedure, IEnumerable<KeyValuePair<string, object>> args = null)
        {
            var dataSet = new DataSet();
            using (var cmd = await CreateCommandAsync(procedure, args))
            {
                var reader = await cmd.ExecuteReaderAsync();
                while (!reader.IsClosed)
                {
                    var dataTable = new DataTable();
                    dataTable.Load(reader);
                    dataSet.Tables.Add(dataTable);
                }
            }
            return dataSet;
        }

        public virtual async Task<DataTable> ExecuteDataTableAsync(string procedure, IEnumerable<KeyValuePair<string, object>> args = null)
        {
            var dataTable = new DataTable();
            using (var cmd = await CreateCommandAsync(procedure, args))
            {
                var reader = await cmd.ExecuteReaderAsync();
                dataTable.Load(reader);
                return dataTable;
            }
        }

        public virtual async Task<List<Dictionary<string, object>>> ExecuteDictionariesAsync(string procedure, IEnumerable<KeyValuePair<string, object>> args = null)
        {
            using (var cmd = await CreateCommandAsync(procedure, args))
            {
                return (await cmd.ExecuteReaderAsync()).ToDictionaries();
            }
        }

        public virtual async Task<List<T>> ExecuteListAsync<T>(string procedure, IEnumerable<KeyValuePair<string, object>> args = null) where T : class
        {
            using (var cmd = await CreateCommandAsync(procedure, args))
            {
                return (await cmd.ExecuteReaderAsync()).ToList<T>();
            }
        }

        public virtual async Task<T> ExecuteFirstOrDefaultAsync<T>(string procedure, IEnumerable<KeyValuePair<string, object>> args = null) where T : class
        {
            return (await ExecuteListAsync<T>(procedure, args)).FirstOrDefault();
        }

        public virtual async Task<T> ExecuteScalarAsync<T>(string procedure, IEnumerable<KeyValuePair<string, object>> args = null)
        {
            using (var cmd = await CreateCommandAsync(procedure, args))
            {
                return (T)await cmd.ExecuteScalarAsync();
            }
        }

        public virtual async Task<int> ExecuteNonQueryAsync(string procedure, IEnumerable<KeyValuePair<string, object>> args = null)
        {
            using (var cmd = await CreateCommandAsync(procedure, args))
            {
                return await cmd.ExecuteNonQueryAsync();
            }
        }

        public virtual async Task<Dictionary<string, object>> ExecuteParametersAsync(string procedure, IEnumerable<ParameterModel> args)
        {
            using (var cmd = await CreateCommandAsync(procedure, args))
            {
                await cmd.ExecuteNonQueryAsync();
                var outputParameters = cmd.Parameters.OfType<IDataParameter>();
                return args.Where(x => x.Direction != ParameterDirection.Input).ToDictionary(
                    x => x.Name,
                    x => outputParameters.FirstOrDefault(p => p.ParameterName.Equals($"@{x.Name.TrimStart('@')}", StringComparison.OrdinalIgnoreCase))?.Value
                );
            }
        }

        public virtual async Task<int> ExecuteSqlRawAsync(string rawSql, params object[] agrs)
        {
            return await _dbContext.Database.ExecuteSqlRawAsync(rawSql, agrs);
        }

        protected bool TryAttach(TEntity record)
        {
            try
            {
                if (_dbContext.Entry(record).State == EntityState.Detached) _dbSet.Attach(record);
                return true;
            }
            catch
            {
                return false;
            }
        }

        private async Task<DbCommand> CreateCommandAsync(string procedure, IEnumerable<KeyValuePair<string, object>> args = null)
        {
            var cmd = _dbContext.Database.GetDbConnection().CreateCommand();
            cmd.Transaction = _dbContext.Database.CurrentTransaction?.GetDbTransaction();
            cmd.CommandText = procedure;
            cmd.CommandType = CommandType.StoredProcedure;
            if (args?.Any() == true) cmd.Parameters.AddRange(args.Select(x => new SqlParameter($"@{x.Key.TrimStart('@')}", x.Value ?? "")).ToArray());
            if (cmd.Connection.State == ConnectionState.Closed) await cmd.Connection.OpenAsync();
            return cmd;
        }

        private async Task<DbCommand> CreateCommandAsync(string procedure, IEnumerable<ParameterModel> args)
        {
            var cmd = await CreateCommandAsync(procedure);
            var parameters = args.Select(x =>
            {
                var parameter = new SqlParameter($"@{x.Name.TrimStart('@')}", x.Value);
                parameter.Direction = x.Direction;
                if (x.DbType != null) parameter.DbType = x.DbType.Value;
                if ((x.Direction & ParameterDirection.Input) != 0) parameter.Size = -1;
                return parameter;
            }).ToArray();
            cmd.Parameters.AddRange(parameters);
            return cmd;
        }
    }
}
