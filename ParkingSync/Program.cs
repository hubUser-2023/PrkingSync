using ParkingSync.Services;
using System;
using System.Threading;
using ParkingSync.Converters;
using ParkingSync.Utilities;

public class Program
{
    public static void Main(string[] args)
    {
        SetupGlobalExceptionHandling();

        var almatyParkingService = new AlmatyParkingService();
        var astanaParkingService = new AstanaParkingService();
        var dictionService = new DictionariesService();

        Thread almatyThread = new(() =>
        {
            var almatyParkingData = almatyParkingService.GetDataAsync().Result;
            var almatyGeoModels = AlmatyParkingConverter.ConvertAlmatyParkings(almatyParkingData);
            dictionService.SendDataAsync(almatyGeoModels).Wait();
        });

        Thread astanaThread = new(() =>
        {
            var astanaParkingData = astanaParkingService.GetDataAsync().Result;
            var astanaGeoModels = AstanaParkingConverter.ConvertAstanaParkings(astanaParkingData);
            dictionService.SendDataAsync(astanaGeoModels).Wait();
        });

        almatyThread.Start();
        astanaThread.Start();

        almatyThread.Join();
        astanaThread.Join();
    }

    private static void SetupGlobalExceptionHandling()
    {
        AppDomain.CurrentDomain.UnhandledException += (sender, e) =>
        {
            var exception = e.ExceptionObject as Exception;
            ErrorHandler.Handle(exception);
        };

        TaskScheduler.UnobservedTaskException += (sender, e) =>
        {
            ErrorHandler.Handle(e.Exception);
            e.SetObserved();
        };
    }
}
