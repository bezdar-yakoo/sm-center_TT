using System.Linq.Expressions;
using System.Reflection;

namespace sm_center_TT.Extensions
{
    public static class DataBaseFilter
    {
        public static IQueryable<T> OrderByDynamic<T>(this IQueryable<T> query, string sortColumn, bool descending)
        {
            var parameter = Expression.Parameter(typeof(T), "p");

            string command = "OrderBy";

            if (descending)
            {
                command = "OrderByDescending";
            }

            Expression resultExpression = null;
            PropertyInfo property = null;
            try
            {
                property = typeof(T).GetProperty(sortColumn);
            }
            catch (ArgumentNullException ex)
            {
                return query;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            var propertyAccess = Expression.MakeMemberAccess(parameter, property);

            var orderByExpression = Expression.Lambda(propertyAccess, parameter);

            resultExpression = Expression.Call(typeof(Queryable), command, new Type[] { typeof(T), property.PropertyType },
               query.Expression, Expression.Quote(orderByExpression));

            return query.Provider.CreateQuery<T>(resultExpression);
        }
    }
}
