using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bas.RedYarn.WebApp.Database
{
    public static class DbSetExtensions
    {
        /// <summary>
        /// Returns the "child" entity for the provided "parent" entity.
        /// </summary>
        /// <typeparam name="ChildType">The type of the child entity to return</typeparam>
        /// <typeparam name="ParentType">The parent entity's type</typeparam>
        /// <param name="dbSet">A <see cref="DbSet{TEntity}"/> in which the child entity is to be sought.</param>
        /// <param name="parentEntity">The parent entity.</param>
        /// <returns>The "child" entity for <paramref name="parentEntity"/>.</returns>
        public static ChildType FindByParent<ChildType, ParentType>(this DbSet<ChildType> dbSet, ParentType parentEntity) where ChildType : class
                                                                                                                    where ParentType : class
        { 
            var dbContext = dbSet.GetService<ICurrentDbContext>().Context; // The DBContext can be found via the DBSet.

            // The child entity will always have a foreign key with the name {ParentType}Id, e.g. StorylineNode.StorylineId,
            // containing the parent entity's ID. We can retrieve both the foreign key and the parent entity's primary key via EF Core's
            // shadow property syntax. Note that we need to use both variations: the LINQ query needs to use the LINQ query version of EF.Property(),
            // while the primary key's value with which we compare it needs to be found using the regular dbContex.Entry() variation.
            return dbSet.SingleOrDefault(e => 
                EF.Property<Guid>(e, $"{typeof(ParentType).Name}Id") == (Guid)dbContext.Entry(parentEntity).Property(ShadowPropertyNames.Id).CurrentValue);
        }
    }
}
