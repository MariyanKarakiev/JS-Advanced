using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Data.Sql;

namespace MiniORM
{
    class ChangeTrakcer<T> where T : class, new()
    {
        private readonly List<T> allEntities;
        private readonly List<T> added;
        private readonly List<T> removed;

        public ChangeTrakcer(IEnumerable<T> entities)
        {
            this.added = new List<T>();
            this.removed = new List<T>();


        }

        private static List<T> CloneEntities(IEnumerable<T> entities)
        {
            var clonedEntities = new List<T>();

            PropertyInfo[] propertiesToClone = typeof(T).GetProperties()
                .Where(pi => DbContext.AllowedSqlTypes
                .Contains(pi.PropertyType))
                .ToArray();

            foreach (var entity in entities)
            {
                T clonedEntity = Activator.CreateInstance<T>();

                foreach (PropertyInfo property in propertiesToClone)
                {
                    object value = property.GetValue(entity);
                    property.SetValue(clonedEntity, value);
                }

                clonedEntities.Add(clonedEntity);
            }
            return clonedEntities;
        }
        public IReadOnlyCollection<T> Removed => this.removed.AsReadOnly();
        public IReadOnlyCollection<T> Added => this.added.AsReadOnly();
        public IReadOnlyCollection<T> AllEntitieas => this.allEntities.AsReadOnly();

        public void Add(T item) => this.added.Add(item);

        public IEnumerable<T> GetModifiedEntities(DbSet<T> dbSet)
            {
            List<>
        }
    }


}