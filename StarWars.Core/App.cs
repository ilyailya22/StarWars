using MvvmCross;
using MvvmCross.ViewModels;
using StarWars.Core.Services.Abstract;
using StarWars.Core.Services.Concrete;
using StarWars.Core.ViewModels;

namespace StarWars.Core;

public class App : MvxApplication
{
    public override void Initialize()
    {
        Mvx.IoCProvider.RegisterType<ISwapiService, SwapiService>();
        RegisterAppStart<MainViewModel>();
    }
}