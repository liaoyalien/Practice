using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace ERPWebSite.Common.Extensions
{
    public static class ModelStateDictionaryExtension
    {
        /// <summary>
        /// Returns true when a model state validation error is found for the property provided
        /// </summary>
        /// <typeparam name="TModel">Model type to search</typeparam>
        /// <typeparam name="TProp">Property type searching</typeparam>
        /// <param name="expression">Property to search for</param>
        /// <returns></returns>
        public static bool HasErrorForProperty<TModel, TProp>(this ModelStateDictionary modelState, Expression<Func<TModel, TProp>> expression)
        {
            var memberExpression = expression.Body as MemberExpression;

            for (int i = 0; i < modelState.Keys.Count; i++)
            {
                if (modelState.Keys.ElementAt(i).Equals(memberExpression?.Member.Name))
                {
                    return modelState.Values.ElementAt(i).Errors.Count > 0;
                }
            }

            return false;
        }
    }
}
