using System.Net.NetworkInformation;
using NetTopologySuite.Geometries;

namespace Caffoa;

public static class CaffoaGeoJsonExtensions
{
    public static Point ToPoint(this Point p, bool deepClone = true) =>
        deepClone ? new Point(p.Coordinate) : p;

    public static MultiPoint ToMultiPoint(this MultiPoint p, bool deepClone = true) =>
        deepClone ? new MultiPoint(p.Geometries.Select(g=>g as Point).ToArray()) : p;

    public static LineString ToLineString(this LineString p, bool deepClone = true) =>
        deepClone ? new LineString(p.Coordinates) : p;

    public static MultiLineString ToMultiLineString(this MultiLineString p, bool deepClone = true) =>
        deepClone ? new MultiLineString(p.Geometries.Select(g => g as LineString).ToArray()) : p;

    public static Polygon ToPolygon(this Polygon poly, bool deepClone = true) =>
        deepClone ? new Polygon(poly.Shell, poly.Holes) : poly;

    public static MultiPolygon ToMultiPolygon(this MultiPolygon poly, bool deepClone = true) =>
        deepClone ? new MultiPolygon(poly.Geometries.Select(g => g as Polygon).ToArray()) : poly;

    public static bool IsNullOrXyOnly(this Coordinate? c) => c is null || (double.IsNaN(c.Z) && double.IsNaN(c.M)); 
    
    public static Point XYOnly(this Point geometry)
    {
        if(geometry.Coordinate.IsNullOrXyOnly())
            return geometry;
        return new Point(new Coordinate(geometry.Coordinate.X, geometry.Coordinate.Y));
    }
    
    public static MultiPoint XYOnly(this MultiPoint geometry)
    {
        if(geometry.Coordinate.IsNullOrXyOnly())
            return geometry;
        return new MultiPoint(geometry.Geometries.Select(m => (m as Point)!.XYOnly()).ToArray());
    }
    
    public static LineString XYOnly(this LineString geometry)
    {
        if(geometry.Coordinate.IsNullOrXyOnly())
            return geometry;
        return new LineString(geometry.Coordinates.Select(c => new Coordinate(c.X, c.Y)).ToArray());
    }

    public static MultiLineString XYOnly(this MultiLineString geometry)
    {
        if(geometry.Coordinate.IsNullOrXyOnly())
            return geometry;
        return new MultiLineString(geometry.Geometries.Select(m => (m as LineString)!.XYOnly()).ToArray());
    }
    
    public static Polygon XYOnly(this Polygon geometry)
    {
        if(geometry.Coordinate.IsNullOrXyOnly())
            return geometry;
        var shell = new LinearRing(geometry.Shell.Coordinates.Select(c => new Coordinate(c.X, c.Y)).ToArray());
        var holes = geometry.Holes.Select(h => new LinearRing(h.Coordinates.Select(c => new Coordinate(c.X, c.Y)).ToArray())).ToArray();
        return new Polygon(shell, holes);
    }
    
    public static MultiPolygon XYOnly(this MultiPolygon geometry)
    {
        if(geometry.Coordinate.IsNullOrXyOnly())
            return geometry;
        return new MultiPolygon(geometry.Geometries.Select(m => (m as Polygon)!.XYOnly()).ToArray());
    }
}