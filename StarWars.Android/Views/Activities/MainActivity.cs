using _Microsoft.Android.Resource.Designer;
using MvvmCross.Platforms.Android.Presenters.Attributes;
using MvvmCross.Platforms.Android.Views;
using StarWars.Core.ViewModels;

namespace StarWars.Android.Views.Activities;

[MvxActivityPresentation]
[Activity(Label = "@string/app_name", MainLauncher = true)]
public class MainActivity : MvxActivity<MainViewModel>
{
    protected override void OnCreate(Bundle savedInstanceState)
    {
        base.OnCreate(savedInstanceState);
        
        SetContentView(ResourceConstant.Layout.activity_main);
        
        var selectCharactersBtn = FindViewById<Button>(Resource.Id.selectCharactersView);
        var selectPlanetsBtn = FindViewById<Button>(Resource.Id.selectPlanetsView);
        
        selectCharactersBtn.Click += (s, e) =>
        {
            ViewModel.SelectCharactersViewCommand.Execute(null);
        };

        selectPlanetsBtn.Click += (s, e) =>
        {
            ViewModel.SelectPlanetsViewCommand.Execute(null);
        };
        
    }
}