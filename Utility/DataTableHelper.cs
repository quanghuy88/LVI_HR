using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utility
{
    public static class DataTableHelper
    {
        public static List<T> ToList<T>(this DataTable dataTable)
        {
            var properties = typeof(T).GetProperties().Where(x => x.CanWrite);
            var columns = dataTable.Columns.OfType<DataColumn>();
            return dataTable.Rows
                .OfType<DataRow>()
                .Select(row =>
                {
                    var item = Activator.CreateInstance<T>();
                    foreach (var col in columns) properties.FirstOrDefault(p => p.Name.Equals(col.ColumnName, StringComparison.OrdinalIgnoreCase))?.SetValue(item, row.IsNull(col) ? default : row[col]);
                    return item;
                })
                .ToList();
        }

        public static List<Dictionary<string, object>> ToDictionaries(this DataTable dataTable)
        {
            var columns = dataTable.Columns.OfType<DataColumn>();
            return dataTable.Rows
                .OfType<DataRow>()
                .Select(row => columns.ToDictionary(col => col.ColumnName.ToLower(), col => row[col], StringComparer.OrdinalIgnoreCase))
                .ToList();
        }

        public static List<T> ToList<T>(this IDataReader dataReader)
        {
            var dataTable = new DataTable();
            dataTable.Load(dataReader);
            return dataTable.ToList<T>();
        }

        public static List<Dictionary<string, object>> ToDictionaries(this IDataReader dataReader)
        {
            var dataTable = new DataTable();
            dataTable.Load(dataReader);
            return dataTable.ToDictionaries();
        }
    }
}
