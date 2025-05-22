using Microsoft.Extensions.Logging;
using MvvmCross.Platforms.Android.Core;
using MvvmCross.Platforms.Android.Presenters;
using Serilog;
using Serilog.Extensions.Logging;
using StarWars.Core;

namespace StarWars.Android;

public class Setup : MvxAndroidSetup<App>
{
    protected override IMvxAndroidViewPresenter CreateViewPresenter()
    {
        return new MvxAndroidViewPresenter(AndroidViewAssemblies);
    }

    protected override ILoggerProvider CreateLogProvider()
    {
        return new SerilogLoggerProvider();
    }

    protected override ILoggerFactory CreateLogFactory()
    {
        // serilog configuration
        Log.Logger = new LoggerConfiguration()
            .MinimumLevel.Debug()
            // add more sinks here
            .CreateLogger();

        return new SerilogLoggerFactory();
    }
}