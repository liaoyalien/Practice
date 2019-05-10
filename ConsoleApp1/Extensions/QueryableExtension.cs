using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using ERPWebSite.Common.Enums;
using ERPWebSite.Common.Misc;

namespace ERPWebSite.Common.Extensions
{
    public static class QueryableExtension
    {
        public static IQueryable<T> DoPaging<T>(this IQueryable<T> iqJoin, Pagination pager)
            where T : new()
        {
            int skipCount = (pager.Page - 1) * pager.PerPage;

            bool isDESC = pager.Order == SortDirectionEnum.DESC;

            return iqJoin.OrderByField(pager.SortBy, isDESC).Skip(skipCount).Take(pager.PerPage);
        }

        public static IQueryable<T> OrderByField<T>(this IQueryable<T> q, string SortField, bool Descending)
        {
            SortField = SortField.Trim();
            var param = Expression.Parameter(typeof(T), "p");
            var prop = Expression.Property(param, SortField);
            var exp = Expression.Lambda(prop, param);
            string method = Descending ? "OrderByDescending" : "OrderBy";

            Type[] types = new Type[] { q.ElementType, exp.Body.Type };

            var mce = Expression.Call(typeof(Queryable), method, types, q.Expression, exp);

            return q.Provider.CreateQuery<T>(mce);
        }

        /// <summary>
        /// 分頁
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="iq"></param>
        /// <param name="pagination">TakeSize為0時取得所有資料</param>
        /// <returns></returns>
        public static PagingResult<T> ToPagingResult<T>(this IQueryable<T> iq, Pagination pagination = null)
            where T : new()
        {
            int count = iq.Count();

            if (pagination == null || pagination.PerPage == 0)
            {
                return new PagingResult<T>
                {
                    Items = iq.ToList(),
                    Pagination = new Pagination
                    {
                        Total = count,
                        PerPage = count,
                        TotalPage = 1,
                        Page = 1
                    }
                };
            }

            if (pagination.Page <= 0)
            {
                pagination.Page = 1;
            }

            // 不開放取太多筆
            if (pagination.PerPage >= 1000)
            {
                pagination.PerPage = 1000;
            }

            int totalPage = count / pagination.PerPage;

            PagingResult<T> pagingResult = new PagingResult<T>()
            {
                Items = iq.DoPaging(pagination).ToList(),
                Pagination = new Pagination
                {
                    Order = pagination.Order,
                    Page = pagination.Page,
                    PerPage = pagination.PerPage,
                    SortBy = pagination.SortBy,
                    Total = count,
                    TotalPage = count % pagination.PerPage == 0 ? totalPage : totalPage + 1
                }
            };

            return pagingResult;
        }
    }
}
