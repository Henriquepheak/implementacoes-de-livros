﻿using CasaDoCodigo.DataAccess;
using CasaDoCodigo.DataAccess.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Threading.Tasks;

namespace CasaDoCodigo.DAL
{
    public abstract class DALBase<T> : IDAL<T> where T : class
    {
        protected DatabaseContext context;
        protected string dbPath;

        public DALBase(string dbPath)
        {
            this.dbPath = dbPath;
        }

        public virtual async Task DeleteAsync(T item)
        {
            using (var context = DatabaseContext.GetContext(dbPath))
            {
                context.Remove(item);
                await context.SaveChangesAsync();
            }
        }

        protected IQueryable<T> PrepareDataToGetAll(DatabaseContext context, string campoClassificacao, OrderByType orderByType)
        {
            var query = context.Set<T>().AsNoTracking();
            if (!string.IsNullOrEmpty(campoClassificacao))
            {
                var parameter = Expression.Parameter(typeof(T));
                var autoBoxing = Expression.Convert(Expression.Property(parameter, campoClassificacao), typeof(object));
                var sortExpression = Expression.Lambda<Func<T, object>>(autoBoxing, parameter);

                if (orderByType == OrderByType.Descendente)
                    query = query.OrderByDescending(sortExpression);
                else
                    query = query.OrderBy(sortExpression);
            }
            return query;
        }

        public async virtual Task<List<T>> GetAllAsync(string campoClassificacao = null, OrderByType orderByType = OrderByType.NaoClassificado)
        {
            using (var context = DatabaseContext.GetContext(this.dbPath))
            {
                var query = PrepareDataToGetAll(context, campoClassificacao, orderByType);
                return await query.ToListAsync();
            }
        }

        public virtual T GetById(long? id, params string[] includeProperties)
        {
            using (var context = DatabaseContext.GetContext(dbPath)) {
                var result = context.Set<T>().Find(id);
                for (int i = 0; i < includeProperties.Count(); i++)
                {
                    context.Entry(result).Reference(includeProperties[i]).Load();
                }
                return result;
            }
        }

        public virtual Task<T> GetByIdAsync(long? id)
        {
            throw new NotImplementedException();
        }

        public async virtual Task<IEnumerable<T>> GetStartsWithByFieldAsync(string field, string value)
        {
            using (var context = DatabaseContext.GetContext(dbPath))
            {
                ParameterExpression parameterExpression = Expression.Parameter(typeof(T), "t");
                MemberExpression memberExpression = Expression.Property(parameterExpression, field);
                ConstantExpression constantExpression = Expression.Constant(value, typeof(string));
                MethodInfo methodInfo = typeof(string).GetMethod("StartsWith", new Type[] { typeof(string) });
                Expression call = Expression.Call(memberExpression, methodInfo, constantExpression);

                Expression<Func<T, bool>> lambda = Expression.Lambda<Func<T, bool>>(call, parameterExpression);
                return await context.Set<T>().Where(lambda).ToArrayAsync();
            }
        }

        public async Task<T> UpdateAsync(T item, long? itemID, params object[] associatedObjects)
        {
            using (var context = DatabaseContext.GetContext(dbPath))
            {
                foreach (var associated in associatedObjects)
                {
                    context.Entry(associated).State = EntityState.Unchanged;
                }

                if (itemID != null)
                {
                    context.Update(item);
                }
                else
                {
                    await context.AddAsync(item);
                }
                await context.SaveChangesAsync();
            }
            return item;
        }
    }
}
