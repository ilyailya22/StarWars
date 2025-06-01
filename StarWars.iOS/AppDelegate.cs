using MvvmCross.Platforms.Ios.Core;
using StarWars.Core;

namespace StarWars.iOS;

[Register("AppDelegate")]
public class AppDelegate : MvxApplicationDelegate<Setup, App>
{
    public override UIWindow Window { get; set; }
}