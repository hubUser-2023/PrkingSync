using ParkingSync.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingSync.Converters;

public static class AstanaParkingConverter
{
    private const int AstanaRegionId = 2;
    private const int CategoryId = 47;
    public static GeoModelsResult ConvertAstanaParkings(AstanaParking astanaParking)
    {
        var groupedObjects = astanaParking.Objects
            .Where(o => o.Active)
            .GroupBy(o => o.Number)
            .Select(g => new GeoModels
            {
                Name = "astanaParking",
                RegionId = AstanaRegionId,
                CategoryId = CategoryId,
                ServiceAttribute = g.Key.ToString(),
                ObjectArea = new GeoJsonModel
                {
                    Features = g.Select(o => new Feature
                    {
                        Geometry = new Geometry
                        {
                            Coordinates = new[]
                            {
                                o.Location.Coordinates
                            }
                        }
                    }).ToArray()
                },
                IsActive = true
            })
            .ToArray();

        return new GeoModelsResult(groupedObjects);
    }
}