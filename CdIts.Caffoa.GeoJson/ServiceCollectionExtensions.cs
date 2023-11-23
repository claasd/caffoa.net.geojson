using Microsoft.Extensions.DependencyInjection;

namespace Caffoa;

public static class GeoJsonServiceCollectionExtensions
{
    public static IServiceCollection AddCaffoaGeoJsonHandling(this IServiceCollection services)
    {
        services.AddCaffoaJsonParser<CaffoaGeoJsonParser>();
        services.AddCaffoaResultHandler<CaffoaGeoJsonResultHandler>();
        return services;
    }
}