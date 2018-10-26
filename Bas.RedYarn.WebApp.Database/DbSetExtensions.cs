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
        public static EntityType FindByOwner<EntityType, OwnerType>(this DbSet<EntityType> dbSet, OwnerType owner) where EntityType : class
                                                                                                                     where OwnerType : class
        { 
            var dbContext = dbSet.GetService<ICurrentDbContext>().Context;
            return dbSet.SingleOrDefault(e => EF.Property<Guid>(e, $"{typeof(OwnerType).Name}Id") == (Guid)dbContext.Entry(owner).Property("Id").CurrentValue);
        }
    }
}
