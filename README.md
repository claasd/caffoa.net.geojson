# Caffoa.NET.GeoJson
Extension library for CAFFOA.NET to support parsing/serializing GeoJson formats into/from NetTopologySuite objects

* Implements ToPoint, ToMultiPoint etc. in the Caffoa namespace.
* Provides an implementation of ICaffoaResultHandler that can directly handle outgoing NetTopologySuite objects.
* Provides an implementation of ICaffoaJsonParser that can directly hande incoming NetTopologySuite objects.
* startup extension `AddCaffoaGeoJsonHandling` to register the above.

## License
MIT License
