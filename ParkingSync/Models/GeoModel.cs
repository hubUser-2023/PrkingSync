using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingSync.Models
{
    public static class GeoConstants
    {
        public const string PolygonType = "Polygon";
        public const string FeatureType = "Feature";
        public const string FeatureCollectionType = "FeatureCollection";
        public const int LattitudeIndex = 0;
        public const int LongitudeIndex = 1;
    }

    public record GeoModels
    {
        public Guid Id { get; init; } = Guid.NewGuid();
        public required string Name { get; init; }
        public int? RegionId { get; init; }
        public int? CategoryId { get; init; }
        public string? ServiceAttribute { get; init; }
        public required GeoJsonModel ObjectArea { get; init; }
        public bool IsActive { get; init; } = true;
    }

    public record GeoJsonModel
    {
        public string Type { get; init; } = GeoConstants.FeatureCollectionType;
        public IReadOnlyCollection<Feature> Features { get; init; }
    }

    public record Feature
    {
        public string Type { get; init; } = GeoConstants.FeatureType;
        public IReadOnlyDictionary<string, object> Properties { get; init; } = new Dictionary<string, object>();
        public required Geometry Geometry { get; init; }
    }

    public record Geometry
    {
        public string Type { get; init; } = GeoConstants.PolygonType;
        public IReadOnlyCollection<IReadOnlyCollection<IReadOnlyCollection<double>>> Coordinates { get; init; }
    }

    public record GeoModelsResult(IReadOnlyCollection<GeoModels> GeoModelsArray);

}
