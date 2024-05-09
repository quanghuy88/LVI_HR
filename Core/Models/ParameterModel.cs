using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    public class ParameterModel
    {
        public ParameterModel()
        {
        }

        public ParameterModel(string name, object value)
        {
            Name = name;
            Value = value;
        }

        public ParameterModel(string name, DbType dbType)
        {
            Name = name;
            Value = "";
            Direction = ParameterDirection.InputOutput;
            DbType = dbType;
        }

        public ParameterModel(string name, object value, ParameterDirection direction)
        {
            Name = name;
            Value = value;
            Direction = direction;
        }

        public ParameterModel(string name, object value, DbType dbType, ParameterDirection direction)
        {
            Name = name;
            Value = value;
            DbType = dbType;
            Direction = direction;
        }

        public ParameterModel(string name, DbType dbType, ParameterDirection direction)
        {
            Name = name;
            Direction = direction;
            DbType = dbType;
        }

        public string Name { get; set; }
        public object Value { get; set; }
        public ParameterDirection Direction { get; set; }
        public DbType? DbType { get; set; }

    }
}
