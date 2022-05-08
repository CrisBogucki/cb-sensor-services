namespace CB.SS.Host.Configuration;

public static class EnvironmentConfiguration
{
    public static string Environment
    {
        get
        {
            string environmentName;
#if LOCAL
            environmentName = "local";
#elif DEMO
            environmentName = "demo";
#elif UAT
            environmentName = "uat";
#elif PROD
            environmentName = "prod";
#endif

            return environmentName;
        }
    }

    public static void UseEnvironmentByProfile(this WebApplication app)
    {
        app.Environment.EnvironmentName = Environment;
    }
}