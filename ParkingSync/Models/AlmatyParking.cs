using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingSync.Models;

public record AlmatyParking
{
    public IReadOnlyCollection<AlmatyParkingObject> Parkings { get; init; }
}

public record AlmatyParkingObject
{
    public string Uuid { get; init; }
    public string Name { get; init; }
    public string Address { get; init; }
    public AlmatyLocation Location { get; init; }
    public Center Center { get; init; }
    public string ZoneUuid { get; init; }
    public string ZoneNumber { get; init; }
}

public record AlmatyLocation
{
    public string Type { get; init; }
    public AlmatyPolygon Polygon { get; init; }
}

public record AlmatyPolygon
{
    public IReadOnlyCollection<AlmatyCoordinate> Coordinates { get; init; }
}

public record AlmatyCoordinate
{
    public double Longitude { get; init; }
    public double Lattitude { get; init; }
}