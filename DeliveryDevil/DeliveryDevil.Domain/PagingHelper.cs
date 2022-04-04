
using DeliveryDevil.Domain;

namespace DeliveryDevil.Helpers;


public static class PagingHelper
{
    public static IQueryable<T> Paginate<T>(this IQueryable<T> query, Paging paging)
    {
        if (paging?.Number == null || paging?.Size == null) return query;
        if (paging.Number <= 0 || paging.Size <= 0) return query;
        return query.Skip((paging.Number.Value - 1) * paging.Size.Value).Take(paging.Size.Value);
    }
}
