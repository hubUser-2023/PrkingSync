using ParkingSync.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingSync.Converters;

public static class AlmatyParkingConverter
{

    private const int AlmatyRegionId = 1;
    private const int CategoryId = 47;

    public static GeoModelsResult ConvertAlmatyParkings(AlmatyParking almatyParking)
    {
        var groupedParkings = almatyParking.Parkings
            .GroupBy(p => p.ZoneNumber)
            .Select(g => new GeoModels
            {
                Name = "almatyParkingReal",
                RegionId = AlmatyRegionId,
                CategoryId = CategoryId,
                ServiceAttribute = g.Key,
                ObjectArea = new GeoJsonModel
                {
                    Features = g.Select(p => new Feature
                    {
                        Geometry = new Geometry
                        {
                            Coordinates = new[]
                            {
                                p.Location.Polygon.Coordinates
                                    .Select(c => new[]
                                    {
                                        c.Longitude,
                                        c.Lattitude
                                    })
                                    .ToArray()
                            }
                        }
                    }).ToArray()
                },
                IsActive = true
            })
            .ToArray();

        return new GeoModelsResult(groupedParkings);
    }

}