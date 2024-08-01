using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingSync.Utilities;

public static class ErrorHandler
{
    public static void Handle(Exception ex)
    {
        if (ex == null) return;
        //Пока не знаю логику, надо подумать
        Console.WriteLine($"Global Error Handler: {ex.Message}");
        
    }
}
