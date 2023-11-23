using Caffoa.Defaults;
using Microsoft.Extensions.Logging;
using NetTopologySuite.IO.Converters;
using Newtonsoft.Json;

namespace Caffoa;

public class CaffoaGeoJsonParser : DefaultCaffoaJsonParser
{
    public CaffoaGeoJsonParser(ILogger<CaffoaGeoJsonParser> logger, ICaffoaResultHandler? resultHandler = null) : base(
        new DefaultCaffoaErrorHandler(logger, resultHandler ?? new CaffoaGeoJsonResultHandler()), new JsonSerializerSettings()
        {
            Converters = new List<Newtonsoft.Json.JsonConverter>() { new GeometryConverter() }
        })
    {
    }
}