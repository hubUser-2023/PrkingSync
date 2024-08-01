using ParkingSync.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingSync.Services
{
    public interface IDictionariesService
    {
        Task SendDataAsync(GeoModelsResult data);
    }
}
