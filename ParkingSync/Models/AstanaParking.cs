using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingSync.Models;

public record AstanaParking
{
    public IReadOnlyCollection<AstanaObject> Objects { get; init; }
}

public record AstanaObject
{
    public Description Description { get; init; }
    public int Id { get; init; }
    public int Number { get; init; }
    public string Type { get; init; }
    public AstanaLocation Location { get; init; }
    public bool Active { get; init; }
    public Center Center { get; init; }
    public IReadOnlyCollection<Price> Prices { get; init; }
}

public record AstanaLocation
{
    public string Type { get; init; }
    public IReadOnlyCollection<IReadOnlyCollection<double>> Coordinates { get; init; }
}

public record Description
{
    public string Ru { get; init; }
    public string Kz { get; init; }
    public string En { get; init; }
}

public record Price
{
    public string VehicleType { get; init; }
    public int PriceValue { get; init; }
}

public record Center
{
    public double Longitude { get; init; }
    public double Lattitude { get; init; }
}
