using CB.SensorService.Src.Domain.Exception;

namespace CB.SensorService.Src.Domain.Utils;

public static class EnvUtils
{
    public static string GetVal(string variable)
    {
        return Environment.GetEnvironmentVariable(variable) ??
               throw new EnvironmentException(
                   $"The defined variable {variable} does not exist in the current environment");
    }
}