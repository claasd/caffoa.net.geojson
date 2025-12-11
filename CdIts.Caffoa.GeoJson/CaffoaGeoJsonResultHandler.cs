using Caffoa.Defaults;
using NetTopologySuite.IO.Converters;
using Newtonsoft.Json;

namespace Caffoa;

public class CaffoaGeoJsonResultHandler : DefaultCaffoaResultHandler
{
    public CaffoaGeoJsonResultHandler() : base(new JsonSerializerSettings()
    {
        Converters = new List<Newtonsoft.Json.JsonConverter>() { new GeometryConverter() }
    })
    {
    }
}