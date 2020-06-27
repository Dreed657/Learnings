using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;

namespace MiniORM
{
	public class ChangeTracker<T> 
        where T: class, new()
    {
        private readonly List<T> allEntities;

        private readonly List<T> added;
        
        private readonly List<T> removed;

        public ChangeTracker(IEnumerable<T> entities) 
        {
            this.added = new List<T>();
            this.removed = new List<T>();

            this.allEntities = CloneEntities(entities);
        }

        public IReadOnlyCollection<T> AllEntities => this.allEntities.AsReadOnly();
        public IReadOnlyCollection<T> Added => this.added.AsReadOnly();
        public IReadOnlyCollection<T> Removed => this.removed.AsReadOnly();

        public void Add(T Item) => this.added.Add(Item);

        public void Remove(T Item) => this.removed.Add(Item);

        public IEnumerable<T> GetModifiedEntities(DbSet<T> dbSet)
        {
            var modifiedEntities = new List<T>();

            var primaryKeys = typeof(T).GetProperties()
                .Where(pi => pi.HasAttribute<KeyAttribute>())
                .ToArray();

            foreach (var proxyEntity in this.AllEntities)
            {
                var primaryKeyValues = GetPrimaryKeyValues(primaryKeys, proxyEntity).ToArray();

                var entity = dbSet.Entities
                    .Single(e => GetPrimaryKeyValues(primaryKeys, e).SequenceEqual(primaryKeyValues));

                var isModified = IsModified(proxyEntity, entity);

                if (isModified) modifiedEntities.Add(entity);
            }

            return modifiedEntities;
        }

        private static bool IsModified(T entity, T proxyEntity)
        {
            var monitoredProperties = typeof(T).GetProperties()
                .Where(pi => DbContext.AllowedSqlTypes.Contains(pi.GetType()));

            var modifiedProperties = monitoredProperties
                .Where(pi => !Equals(pi.GetValue(entity), pi.GetValue(proxyEntity)))
                .ToArray();

            return modifiedProperties.Any();
        }

        private static IEnumerable<object> GetPrimaryKeyValues(IEnumerable<PropertyInfo> primaryKeys, T entity)
        {
            return primaryKeys.Select(pk => pk.GetValue(entity));
        }

        private List<T> CloneEntities(IEnumerable<T> entities)
        {
            var clonedEntities = new List<T>();

            var propertiesToClone = typeof(T).GetProperties()
                .Where(pi => DbContext.AllowedSqlTypes.Contains(pi.GetType()))
                .ToArray();

            foreach (T entity in entities)
            {
                var clone = Activator.CreateInstance<T>();

                foreach(var property in propertiesToClone)
                {
                    object value = property.GetValue(entity);
                    property.SetValue(clone, value);
                }
                clonedEntities.Add(clone);
            }

            return clonedEntities;
        }
    }
}