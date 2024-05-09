using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    /// <summary>
    /// Dictionary contains field(s) that will be used to update to entity.
    /// </summary>
    public class EntityModel : Dictionary<string, object>
    {
        public EntityModel() : base(StringComparer.OrdinalIgnoreCase) { }

        /// <summary>
        /// Create model with PrimaryKey value for tracking entity. If entity has composite primary key, the keys can be provided later.
        /// </summary>
        /// <param name="primaryKey">Name of property being used as primary key. Name is case-insensitive.</param>
        /// <param name="primaryValue">Value of the primary key.</param>
        public EntityModel(string primaryKey, object primaryValue) : base(StringComparer.OrdinalIgnoreCase) => this[primaryKey] = primaryValue;

        public EntityModel(IEnumerable<KeyValuePair<string, object>> collection) : base(collection, StringComparer.OrdinalIgnoreCase)
        {
        }

        /// <summary>
        /// Create an instance of entity. The entity can be used in update progress.
        /// </summary>
        /// <typeparam name="TEntity">Type of entity.</typeparam>
        /// <returns>Target entity.</returns>
        public TEntity ToEntity<TEntity>() where TEntity : class
        {
            var entity = Activator.CreateInstance<TEntity>();
            var properties = typeof(TEntity)
                .GetProperties()
                .Where(x => x.CanWrite && Keys.Any(k => k.ToLower() == x.Name.ToLower()));
            foreach (var property in properties) property.SetValue(entity, this[property.Name]);
            return entity;
        }

        /// <summary>
        /// Create a generic model from an entity instance.
        /// </summary>
        /// <typeparam name="TEntity">Type of entity.</typeparam>
        /// <param name="entity">Entity instance to create generic model.</param>
        /// <returns>Model of entity.</returns>
        public static EntityModel FromEntity<TEntity>(TEntity entity) where TEntity : class
        {
            var properties = typeof(TEntity)
                .GetProperties()
                .ToDictionary(x => x.Name.ToLower(), x => x.GetValue(entity));
            return new EntityModel(properties);
        }
    }
}
