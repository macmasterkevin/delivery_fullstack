
using DeliveryDevil.Domain;

namespace DeliveryDevil.Middleware;


public static class PagingMiddleware
{
    public static void UsePaging(this IApplicationBuilder app)
    {
        app.Use(async (httpContext, next) =>
        {
            var paging = (Paging)httpContext.RequestServices.GetService(typeof(Paging));

            int.TryParse(httpContext.Request.Query["pageNumber"].ToString(), out var pageNumber);
            int.TryParse(httpContext.Request.Query["pageSize"].ToString(), out var pageSize);

            var number = pageNumber > 0 ? pageNumber : (int?)null;
            var size = pageSize > 0 ? pageSize : (int?)null;
            paging.SetPage(size, number);

            await next.Invoke();
        });
    }
}