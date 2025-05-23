using _Microsoft.Android.Resource.Designer;
using MvvmCross.Platforms.Android.Presenters.Attributes;
using MvvmCross.Platforms.Android.Views;
using StarWars.Core.ViewModels;

namespace StarWars.Android.Views;

[MvxActivityPresentation]
[Activity(Label = "@string/app_name", MainLauncher = true)]
public class MainActivity : MvxActivity<MainViewModel>
{
    protected override void OnCreate(Bundle savedInstanceState)
    {
        base.OnCreate(savedInstanceState);
        
        SetContentView(ResourceConstant.Layout.activity_main);
        
        if (savedInstanceState == null)
        {
            var fragment = new CharactersFragment();
            SupportFragmentManager
                .BeginTransaction()
                .Replace(ResourceConstant.Id.content_frame, fragment)
                .Commit();
        }
    }
}