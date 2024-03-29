﻿using Hook.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Hook.Core.Repositories
{
    public interface IGenericRepository<T> where T : BaseEntity, new()
    {
        DbSet<T> Table {  get; }
        Task CreateAsync(T entity);
        void Delete(T entity);
        Task<int>CommitAsync();
        IQueryable<T> GetAll(params string[] includes);
        IQueryable<T> GetAllWhere(Expression<Func<T, bool>> expression, params string[] includes);

        Task<T> GetSingleAsync(Expression<Func<T, bool>> expression, params string[] includes);


    }
}
