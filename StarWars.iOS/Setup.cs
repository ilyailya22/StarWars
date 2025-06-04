using Microsoft.Extensions.Logging;
using MvvmCross.Platforms.Ios.Core;
using MvvmCross.Platforms.Ios.Presenters;
using Serilog;
using Serilog.Extensions.Logging;
using StarWars.Core;

namespace StarWars.iOS;

public class Setup : MvxIosSetup<App>
{
    protected override IMvxIosViewPresenter CreateViewPresenter()
    {
        return new MvxIosViewPresenter(Window!);
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